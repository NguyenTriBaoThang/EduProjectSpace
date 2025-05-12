// File: Services/NotificationService.cs
// Mục đích: Thực hiện quản lý thông báo, bao gồm CRUD, gửi email, cấu hình.
// Sử dụng: EF Core cho cơ sở dữ liệu, SMTP cho email.

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

namespace EduProject_TADProgrammer.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;
        private readonly SmtpClient _smtpClient;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
                EnableSsl = true,
            };
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
                    CreatedAt = n.CreatedAt
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
                    CreatedAt = n.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<NotificationDto> CreateNotificationAsync(NotificationDto notificationDto)
        {
            if (notificationDto == null)
                throw new ArgumentNullException(nameof(notificationDto));

            var config = await _context.SystemConfigs
                .Where(sc => sc.Key == "NOTIFICATION_CONFIG")
                .Select(sc => new NotificationConfigDto
                {
                    EnableWeb = sc.Value.Contains("WEB"),
                    EnableEmail = sc.Value.Contains("EMAIL"),
                    ReminderFrequency = sc.Value.Contains("DAILY") ? "daily" : sc.Value.Contains("WEEKLY") ? "weekly" : "none"
                })
                .FirstOrDefaultAsync();

            var notification = new Notification
            {
                UserId = notificationDto.UserId,
                GroupId = notificationDto.GroupId,
                Title = notificationDto.Title,
                Content = notificationDto.Content,
                Type = config?.EnableEmail == true ? notificationDto.Type : "WEB",
                Status = notificationDto.Status ?? "PENDING",
                CreatedAt = DateTime.UtcNow
            };

            var recipients = new List<User>();
            switch (notificationDto.RecipientType?.ToLower())
            {
                case "all":
                    recipients = await _context.Users.ToListAsync();
                    break;
                case "student":
                    recipients = await _context.Users.Where(u => u.RoleId == 3).ToListAsync();
                    break;
                case "lecturer":
                    recipients = await _context.Users.Where(u => u.RoleId == 2).ToListAsync();
                    break;
                case "admin":
                    recipients = await _context.Users.Where(u => u.RoleId == 1).ToListAsync();
                    break;
                case "head":
                    recipients = await _context.Users.Where(u => u.RoleId == 4).ToListAsync();
                    break;
                case "user":
                    var user = await _context.Users.FindAsync(notificationDto.UserId);
                    if (user != null) recipients.Add(user);
                    break;
                case "group":
                    if (notificationDto.GroupId.HasValue)
                    {
                        recipients = await _context.GroupMembers
                            .Where(gm => gm.GroupId == notificationDto.GroupId)
                            .Include(gm => gm.Student)
                            .Select(gm => gm.Student)
                            .Where(s => s != null)
                            .ToListAsync();
                    }
                    break;
                default:
                    throw new ArgumentException("RecipientType không hợp lệ.");
            }

            foreach (var recipient in recipients.Distinct())
            {
                var userNotification = new Notification
                {
                    UserId = recipient.Id,
                    Title = notification.Title,
                    Content = notification.Content,
                    Type = notification.Type,
                    Status = notification.Status,
                    CreatedAt = notification.CreatedAt
                };
                _context.Notifications.Add(userNotification);

                if (config?.EnableEmail == true && !string.IsNullOrEmpty(recipient.Email))
                    await SendEmailAsync(recipient.Email, notification.Title, notification.Content);
            }

            if (notificationDto.RecipientType != "user" && notificationDto.RecipientType != "group")
            {
                _context.Notifications.Add(notification);
            }

            await _context.SaveChangesAsync();
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
            notification.Type = notificationDto.Type ?? "WEB";
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
            await _context.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("your-email@gmail.com"),
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
            }
        }
    }
}