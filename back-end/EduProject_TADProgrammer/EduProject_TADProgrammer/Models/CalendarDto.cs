// File: Core/Models/CalendarDto.cs
// Mục đích: Truyền dữ liệu lịch cá nhân và nhóm giữa API và frontend.
// Chức năng hỗ trợ: 
//   84: Quản lý lịch cá nhân và nhóm
namespace EduProject_TADProgrammer.Models
{
    public class CalendarDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? GroupId { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}