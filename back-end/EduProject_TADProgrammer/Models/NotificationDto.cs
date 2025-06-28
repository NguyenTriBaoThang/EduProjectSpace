using System;

namespace EduProject_TADProgrammer.Models
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public long[] UserIds { get; set; } // Thay UserId thành mảng
        public long[] GroupIds { get; set; } // Thay GroupId thành mảng
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string RecipientType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsFirstViewed { get; set; }
        public DateTime? FirstViewedAt { get; set; }
        public long? UserId { get; internal set; }
        public long? GroupId { get; internal set; }
    }

    public class NotificationConfigDto
    {
        public bool EnableWeb { get; set; }
        public bool EnableEmail { get; set; }
        public string ReminderFrequency { get; set; }
        public SmtpConfig SmtpConfig { get; set; }
    }

    public class SmtpConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserNotificationDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class GroupNotificationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}