// File: Core/Models/GradeScheduleDto.cs
// Mục đích: Truyền dữ liệu lịch trình chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   75: Lịch trình chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class GradeScheduleDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long LecturerId { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}