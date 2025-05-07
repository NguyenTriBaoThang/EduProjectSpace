// File: Core/Models/DefenseScheduleDto.cs
// Mục đích: Truyền dữ liệu lịch bảo vệ đồ án giữa API và frontend.
// Chức năng hỗ trợ: 
//   56: Quản lý lịch bảo vệ
namespace EduProject_TADProgrammer.Models
{
    public class DefenseScheduleDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}   