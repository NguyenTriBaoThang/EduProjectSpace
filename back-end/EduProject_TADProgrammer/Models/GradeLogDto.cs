// File: Core/Models/GradeLogDto.cs
// Mục đích: Truyền dữ liệu nhật ký chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   74: Nhật ký chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class GradeLogDto
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public long LecturerId { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}