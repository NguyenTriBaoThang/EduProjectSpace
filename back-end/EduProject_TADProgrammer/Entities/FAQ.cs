// File: Core/Entities/FAQ.cs
// Mục đích: Định nghĩa entity FAQ để lưu câu hỏi thường gặp và câu trả lời.
// Hỗ trợ chức năng: 
//   58: Quản lý câu hỏi thường gặp
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class FAQ
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } // Đề tài, Nộp bài, Chấm điểm

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
