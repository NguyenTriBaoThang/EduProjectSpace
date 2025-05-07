// File: Core/Models/QuestionDto.cs
// Mục đích: Truyền dữ liệu câu hỏi kiểm tra trước bảo vệ giữa API và frontend.
// Chức năng hỗ trợ: 
//   33: Giảng viên - Tạo câu hỏi kiểm tra
//   85: Quản lý danh sách câu hỏi bảo vệ
namespace EduProject_TADProgrammer.Models
{
    public class QuestionDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string Content { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}