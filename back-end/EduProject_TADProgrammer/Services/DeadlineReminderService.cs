// File: Services/DeadlineReminderService.cs
// Mục đích: Dịch vụ nền kiểm tra nhiệm vụ đến hạn sau 1 ngày, gửi nhắc nhở qua web và email.
// Chạy: Hàng ngày lúc nửa đêm.

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

namespace EduProject_TADProgrammer.Services
{
    public class DeadlineReminderService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DeadlineReminderService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendDeadlineReminders();
                var now = DateTime.UtcNow;
                var nextRun = now.Date.AddDays(1);
                var delay = nextRun - now;
                await System.Threading.Tasks.Task.Delay(delay, stoppingToken);
            }
        }

        private async System.Threading.Tasks.Task SendDeadlineReminders()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var notificationService = scope.ServiceProvider.GetRequiredService<NotificationService>();

            var tomorrow = DateTime.UtcNow.Date.AddDays(1);
            var tasks = await context.Tasks
                .Include(t => t.Student)
                .Include(t => t.Group)
                .Where(t => t.Deadline.HasValue && t.Deadline.Value.Date == tomorrow && t.Status != "DONE")
                .ToListAsync();

            foreach (var task in tasks)
            {
                var recipients = new List<User>();

                // Thêm sinh viên được gán trực tiếp (nếu có)
                if (task.StudentId.HasValue && task.Student != null)
                {
                    recipients.Add(task.Student);
                }

                // Thêm các sinh viên trong nhóm (nếu có)
                if (task.GroupId.HasValue)
                {
                    var groupMembers = await context.GroupMembers
                        .Where(gm => gm.GroupId == task.GroupId)
                        .Include(gm => gm.Student)
                        .Select(gm => gm.Student)
                        .Where(s => s != null)
                        .ToListAsync();
                    recipients.AddRange(groupMembers);
                }

                // Gửi thông báo cho từng người nhận (loại bỏ trùng lặp)
                foreach (var recipient in recipients.Distinct())
                {
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
                }
            }
        }
    }
}