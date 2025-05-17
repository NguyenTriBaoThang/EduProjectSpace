// File: Entities/FAQ.cs
// Mục đích: Định nghĩa entity FAQ để lưu câu hỏi thường gặp và câu trả lời.
// Hỗ trợ chức năng: 
//   58: Quản lý câu hỏi thường gặp
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa các danh mục FAQ
    public enum FAQCategory
    {
        Project,    // Đề tài
        Submission, // Nộp bài
        Grading,    // Chấm điểm
        Schedule,   // Lịch trình (bảo vệ, học tập)
        Other       // Các câu hỏi khác
    }

    public class FAQ
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
