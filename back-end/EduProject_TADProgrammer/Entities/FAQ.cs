// File: Entities/FAQ.cs
// Mục đích: Định nghĩa entity FAQ để lưu câu hỏi thường gặp và câu trả lời.
// Hỗ trợ chức năng: 
//   58: Quản lý câu hỏi thường gặp

using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class FAQ
    {
        // Khóa chính của bản ghi câu hỏi thường gặp
        [Key]
        public long Id { get; set; }

        // Câu hỏi (bắt buộc)
        [Required]
        public string Question { get; set; }

        // Câu trả lời (bắt buộc)
        [Required]
        public string Answer { get; set; }

        // Danh mục của câu hỏi (bắt buộc, ví dụ: "Đăng ký môn học", "Bảo vệ đồ án")
        [Required]
        public string Category { get; set; } // Project, Submission, Grading, Schedule, Other

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
