// File: Core/Models/TimeTrackingDto.cs
// Mục đích: Truyền dữ liệu thời gian làm việc của sinh viên giữa API và frontend.
// Chức năng hỗ trợ: 
//   37: Giảng viên - Phân tích mức độ tham gia
//   55: Theo dõi thời gian làm việc
namespace EduProject_TADProgrammer.Models
{
    public class TimeTrackingDto
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Duration { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
