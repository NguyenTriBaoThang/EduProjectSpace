using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using System.Linq;
using EduProject_TADProgrammer.Models;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EduProject_TADProgrammer.Services
{
    public class DeadlineReminderService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly ILogger<DeadlineReminderService> _logger;
        private DateTime _mockedNow = DateTime.UtcNow; // Mock thời gian

        public DeadlineReminderService(
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            ILogger<DeadlineReminderService> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void SetMockedTime(DateTime mockedTime)
        {
            _mockedNow = mockedTime.ToUniversalTime(); // Chuyển sang UTC
        }

        private DateTime GetCurrentTime() => _mockedNow;

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Chạy ngay lập tức và lặp lại sau 1 phút
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendDeadlineReminders();
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Lặp lại sau 1 phút
            }
        }

        /*
        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendDeadlineReminders();
                var now = DateTime.UtcNow;
                var nextRun = now.Date.AddDays(1).AddHours(0).AddMinutes(0); // Chạy lúc 00:00 UTC
                var delay = nextRun - now;
                _logger.LogInformation("Next reminder check at: {NextRun}", nextRun);
                await System.Threading.Tasks.Task.Delay(delay, stoppingToken);
            }
        }
        */

        private async System.Threading.Tasks.Task SendDeadlineReminders()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var notificationService = scope.ServiceProvider.GetRequiredService<NotificationService>();
            var now = DateTime.UtcNow;
            var tomorrow = now.Date.AddDays(1);
            _logger.LogInformation("Checking deadlines for {Tomorrow}", tomorrow);

            var tasks = await context.Tasks
                .Include(t => t.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Where(t => t.Deadline.HasValue && t.Deadline.Value.Date == tomorrow && t.Status != "DONE")
                .ToListAsync();

            if (!tasks.Any())
            {
                _logger.LogInformation("No tasks due tomorrow.");
                return;
            }

            foreach (var task in tasks)
            {
                if (task.Group == null || task.Group.GroupMembers == null)
                {
                    _logger.LogWarning("Task {TaskId} has no valid group or members.", task.Id);
                    continue;
                }

                var recipients = task.Group.GroupMembers
                    .Select(gm => gm.Student)
                    .Where(s => s != null && !string.IsNullOrEmpty(s.Email))
                    .Distinct()
                    .ToList();

                if (!recipients.Any())
                {
                    _logger.LogWarning("No valid recipients for task {TaskId}.", task.Id);
                    continue;
                }

                foreach (var recipient in recipients)
                {
                    try
                    {
                        // Tạo và gửi thông báo web/email
                        var notificationDto = new NotificationDto
                        {
                            UserId = recipient.Id,
                            Title = $"Nhắc nhở: Nhiệm vụ '{task.Title}' đến hạn ngày mai",
                            Content = $"Nhiệm vụ '{task.Title}' đến hạn vào {task.Deadline.Value:yyyy-MM-dd}. Vui lòng hoàn thành đúng hạn.",
                            Type = "WEB,EMAIL",
                            Status = "SENT",
                            RecipientType = "user"
                        };

                        await notificationService.CreateNotificationAsync(notificationDto);

                        // Gửi email
                        await SendEmailReminder(recipient, task, context);
                        _logger.LogInformation("Sent reminder for task {TaskId} to {Email}", task.Id, recipient.Email);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to send reminder for task {TaskId} to {Email}", task.Id, recipient.Email);
                    }
                }
            }
        }

        private async System.Threading.Tasks.Task SendEmailReminder(User student, Entities.Task task, ApplicationDbContext context)
        {
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUsername = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
                Timeout = 10000
            };

            var course = await context.Courses
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(c => c.Id == task.Project.CourseId);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                Subject = $"Nhắc nhở: Nhiệm vụ '{task.Title}' đến hạn",
                Body = $@"
                    <h3>Thông báo từ HUTECH EduProject</h3>
                    <p>Xin chào {student.FullName},</p>
                    <p>Nhiệm vụ <strong>{task.Title}</strong> trong môn học <strong>{course?.Name ?? "Không rõ"}</strong> (Học kỳ: {course?.Semester?.Name ?? "Không rõ"}) sẽ đến hạn vào ngày <strong>{task.Deadline.Value:dd/MM/yyyy}</strong>.</p>
                    <p>Vui lòng hoàn thành đúng hạn. Liên hệ giảng viên hướng dẫn nếu cần hỗ trợ!</p>
                    <p>Trân trọng,<br>Đội ngũ HUTECH EduProject</p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(student.Email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}