// File: Core/Models/NotificationDto.cs
// Mục đích: Truyền dữ liệu thông báo gửi đến người dùng hoặc nhóm giữa API và frontend.

namespace EduProject_TADProgrammer.Models
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? GroupId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string RecipientType { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NotificationConfigDto
    {
        public bool EnableWeb { get; set; }
        public bool EnableEmail { get; set; }
        public string ReminderFrequency { get; set; } // none, daily, weekly
    }
}