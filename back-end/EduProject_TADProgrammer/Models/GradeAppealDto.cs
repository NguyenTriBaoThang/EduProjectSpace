// File: Core/Models/GradeAppealDto.cs
// Mục đích: Truyền dữ liệu yêu cầu phúc khảo điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   72: Phúc khảo và phản hồi điểm số
namespace EduProject_TADProgrammer.Models
{
    public class GradeAppealDto
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public long StudentId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string Response { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}