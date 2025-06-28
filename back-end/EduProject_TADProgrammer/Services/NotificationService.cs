using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace EduProject_TADProgrammer.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private SmtpClient _smtpClient;

        public NotificationService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private void InitializeSmtpClient(NotificationConfigDto config)
        {
            if (config?.EnableEmail == true && config.SmtpConfig != null)
            {
                _smtpClient = new SmtpClient(config.SmtpConfig.Host)
                {
                    Port = config.SmtpConfig.Port,
                    Credentials = new NetworkCredential(config.SmtpConfig.Username, config.SmtpConfig.Password),
                    EnableSsl = true,
                };
            }
            else
            {
                _smtpClient = null;
            }
        }

        public async Task<(List<NotificationDto> Notifications, int TotalItems)> GetNotificationsAsync()
        {
            var query = _context.Notifications
                .Include(n => n.User)
                .Include(n => n.Group)
                .AsQueryable();

            var totalItems = await query.CountAsync();
            var notifications = await query
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    GroupId = n.GroupId,
                    Title = n.Title,
                    Content = n.Content,
                    Type = n.Type,
                    Status = n.Status,
                    RecipientType = n.RecipientType,
                    CreatedAt = n.CreatedAt,
                    IsFirstViewed = n.IsFirstViewed,
                    FirstViewedAt = n.FirstViewedAt
                })
                .ToListAsync();

            return (notifications, totalItems);
        }

        public async Task<List<NotificationDto>> GetRecentNotificationsAsync()
        {
            return await _context.Notifications
                .OrderByDescending(n => n.CreatedAt)
                .Take(5)
                .Select(n => new NotificationDto
                {
                    Id = n.Id,
                    UserId = n.UserId,
                    GroupId = n.GroupId,
                    Title = n.Title,
                    Content = n.Content,
                    Type = n.Type,
                    Status = n.Status,
                    RecipientType = n.RecipientType,
                    CreatedAt = n.CreatedAt,
                    IsFirstViewed = n.IsFirstViewed,
                    FirstViewedAt = n.FirstViewedAt
                })
                .ToListAsync();
        }

        public async Task<NotificationConfigDto> GetConfigAsync()
        {
            var systemConfig = await _context.SystemConfigs
                .FirstOrDefaultAsync(sc => sc.Key == "NOTIFICATION_CONFIG");

            if (systemConfig == null) return new NotificationConfigDto();

            var parts = systemConfig.Value.Split(',');
            var config = new NotificationConfigDto
            {
                EnableWeb = parts.Any(p => p.Contains("WEB:True")),
                EnableEmail = parts.Any(p => p.Contains("EMAIL:True")),
                ReminderFrequency = parts.FirstOrDefault(p => p.Contains("FREQUENCY:"))?.Replace("FREQUENCY:", "") ?? "none",
                SmtpConfig = new SmtpConfig()
            };

            var smtpHost = parts.FirstOrDefault(p => p.Contains("SMTP_HOST:"))?.Replace("SMTP_HOST:", "");
            var smtpPort = parts.FirstOrDefault(p => p.Contains("SMTP_PORT:"))?.Replace("SMTP_PORT:", "");
            var smtpUsername = parts.FirstOrDefault(p => p.Contains("SMTP_USERNAME:"))?.Replace("SMTP_USERNAME:", "");
            var smtpPassword = parts.FirstOrDefault(p => p.Contains("SMTP_PASSWORD:"))?.Replace("SMTP_PASSWORD:", "");

            if (!string.IsNullOrEmpty(smtpHost))
            {
                config.SmtpConfig.Host = smtpHost;
                config.SmtpConfig.Port = int.TryParse(smtpPort, out var port) ? port : 587;
                config.SmtpConfig.Username = smtpUsername;
                config.SmtpConfig.Password = smtpPassword;
            }

            return config;
        }

        public async Task<NotificationDto> CreateNotificationAsync(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                throw new ArgumentNullException(nameof(notificationDto));

            var config = await GetConfigAsync();
            InitializeSmtpClient(config);

            var recipients = new List<User>();
            switch (notificationDto.RecipientType?.ToLower())
            {
                case "all":
                    recipients = await _context.Users.ToListAsync();
                    break;
                case "student":
                    recipients = notificationDto.UserIds != null && notificationDto.UserIds.Length > 0
                        ? await _context.Users.Where(u => notificationDto.UserIds.Contains(u.Id) && u.RoleId == 3).ToListAsync()
                        : await _context.Users.Where(u => u.RoleId == 3).ToListAsync();
                    break;
                case "lecturer":
                    recipients = notificationDto.UserIds != null && notificationDto.UserIds.Length > 0
                        ? await _context.Users.Where(u => notificationDto.UserIds.Contains(u.Id) && u.RoleId == 2).ToListAsync()
                        : await _context.Users.Where(u => u.RoleId == 2).ToListAsync();
                    break;
                case "admin":
                    recipients = await _context.Users.Where(u => u.RoleId == 1).ToListAsync();
                    break;
                case "head":
                    recipients = notificationDto.UserIds != null && notificationDto.UserIds.Length > 0
                        ? await _context.Users.Where(u => notificationDto.UserIds.Contains(u.Id) && u.RoleId == 4).ToListAsync()
                        : await _context.Users.Where(u => u.RoleId == 4).ToListAsync();
                    break;
                case "group":
                    if (notificationDto.GroupIds != null && notificationDto.GroupIds.Length > 0)
                    {
                        recipients = await _context.GroupMembers
                            .Where(gm => notificationDto.GroupIds.Contains(gm.GroupId))
                            .Include(gm => gm.Student)
                            .Select(gm => gm.Student)
                            .Where(s => s != null)
                            .Distinct()
                            .ToListAsync();
                    }
                    break;
                default:
                    throw new ArgumentException("RecipientType không hợp lệ.");
            }

            foreach (var recipient in recipients.Distinct())
            {
                var notification = new Notification
                {
                    UserId = recipient.Id, // Gán UserId cho từng người nhận
                    Title = notificationDto.Title,
                    Content = notificationDto.Content,
                    Type = config.EnableEmail && notificationDto.Type == "Email" ? "Email" : "Web",
                    Status = notificationDto.Status ?? "PENDING",
                    RecipientType = notificationDto.RecipientType,
                    CreatedAt = DateTime.UtcNow,
                    IsFirstViewed = false,
                    FirstViewedAt = null
                };
                _context.Notifications.Add(notification);

                if (config?.EnableEmail == true && !string.IsNullOrEmpty(recipient.Email) && notification.Type == "Email")
                    await SendEmailAsync(recipient.Email, notification.Title, notification.Content);
            }

            // Nếu không gửi cho cá nhân hoặc nhóm cụ thể, tạo thông báo chung
            if (!recipients.Any() && notificationDto.RecipientType != "student" && notificationDto.RecipientType != "lecturer" &&
                notificationDto.RecipientType != "head" && notificationDto.RecipientType != "group")
            {
                var notification = new Notification
                {
                    Title = notificationDto.Title,
                    Content = notificationDto.Content,
                    Type = config.EnableEmail && notificationDto.Type == "Email" ? "Email" : "Web",
                    Status = notificationDto.Status ?? "PENDING",
                    RecipientType = notificationDto.RecipientType,
                    CreatedAt = DateTime.UtcNow,
                    IsFirstViewed = false,
                    FirstViewedAt = null
                };
                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
            notificationDto.Id = _context.Notifications.Max(n => n.Id);
            return notificationDto;
        }

        public async System.Threading.Tasks.Task UpdateNotificationAsync(long id, NotificationDto notificationDto)
        {
            if (notificationDto == null)
                throw new ArgumentNullException(nameof(notificationDto));

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
                throw new Exception("Không tìm thấy thông báo");

            notification.Title = notificationDto.Title;
            notification.Content = notificationDto.Content;
            notification.Status = notificationDto.Status ?? "PENDING";
            notification.Type = notificationDto.Type ?? "Web";
            notification.RecipientType = notificationDto.RecipientType;
            notification.UserId = (long)notificationDto.UserId;
            notification.GroupId = notificationDto.GroupId;
            notification.CreatedAt = DateTime.UtcNow;

            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteNotificationAsync(long id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
                throw new Exception("Không tìm thấy thông báo");

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task SaveConfigAsync(NotificationConfigDto config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            var systemConfig = await _context.SystemConfigs
                .FirstOrDefaultAsync(sc => sc.Key == "NOTIFICATION_CONFIG");

            if (systemConfig == null)
            {
                systemConfig = new SystemConfig
                {
                    Key = "NOTIFICATION_CONFIG",
                    CreatedAt = DateTime.UtcNow
                };
                _context.SystemConfigs.Add(systemConfig);
            }

            systemConfig.Value = $"WEB:{config.EnableWeb},EMAIL:{config.EnableEmail},FREQUENCY:{config.ReminderFrequency}";
            if (config.SmtpConfig != null)
            {
                systemConfig.Value += $",SMTP_HOST:{config.SmtpConfig.Host},SMTP_PORT:{config.SmtpConfig.Port},SMTP_USERNAME:{config.SmtpConfig.Username},SMTP_PASSWORD:{config.SmtpConfig.Password}";
            }
            await _context.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                if (_smtpClient == null)
                {
                    throw new InvalidOperationException("SMTP client chưa được cấu hình.");
                }

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpClient.Credentials.GetCredential(_smtpClient.Host, _smtpClient.Port, "Basic").UserName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gửi email thất bại: {ex.Message}");
                throw;
            }
        }

        public async Task<List<UserNotificationDto>> GetUsersByRoleAsync(int roleId)
        {
            return await _context.Users
                .Where(u => u.RoleId == roleId)
                .Select(u => new UserNotificationDto
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<List<GroupNotificationDto>> GetGroupsAsync()
        {
            return await _context.Groups
                .Select(g => new GroupNotificationDto
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }
    }

}