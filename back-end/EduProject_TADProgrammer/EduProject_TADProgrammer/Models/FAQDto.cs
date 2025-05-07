// File: Core/Models/FAQDto.cs
// Mục đích: Truyền dữ liệu câu hỏi thường gặp và câu trả lời giữa API và frontend.
// Chức năng hỗ trợ: 
//   58: Quản lý câu hỏi thường gặp
namespace EduProject_TADProgrammer.Models
{
    public class FAQDto
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
