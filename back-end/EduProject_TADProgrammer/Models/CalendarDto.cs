// File: Core/Models/CalendarDto.cs
// Mục đích: Truyền dữ liệu lịch cá nhân và nhóm giữa API và frontend.
// Chức năng hỗ trợ: 
//   84: Quản lý lịch cá nhân và nhóm
namespace EduProject_TADProgrammer.Models
{
    public class CalendarDto
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? GroupId { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public bool IsAllDay { get; set; }
        public string Type { get; set; } //Meeting, Deadline, Reminder, Other
        public string Status { get; set; } //Scheduled, Completed, Cancelled
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}