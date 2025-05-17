// File: Entities/Question.cs
// Mục đích: Định nghĩa entity Question để lưu câu hỏi kiểm tra trước bảo vệ.
// Hỗ trợ chức năng: 
//   33: Giảng viên - Tạo câu hỏi kiểm tra
//   85: Quản lý danh sách câu hỏi bảo vệ
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Question
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
