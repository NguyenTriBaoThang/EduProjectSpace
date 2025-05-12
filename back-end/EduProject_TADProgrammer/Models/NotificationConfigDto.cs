// File: Models/NotificationConfigDto.cs
// Mục đích: DTO cho cấu hình thông báo (web, email, tần suất nhắc nhở).

namespace EduProject_TADProgrammer.Models
{
    public class NotificationConfigDto
    {
        public bool EnableWeb { get; set; }
        public bool EnableEmail { get; set; }
        public string ReminderFrequency { get; set; } // none, daily, weekly
    }
}