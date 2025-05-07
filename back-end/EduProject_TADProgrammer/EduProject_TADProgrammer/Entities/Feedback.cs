// File: Core/Entities/Feedback.cs
// Mục đích: Định nghĩa entity Feedback để lưu phản hồi của giảng viên về bài nộp.
// Hỗ trợ chức năng: 
//   14: Xem phản hồi và điểm số
//   62: Quản lý phản hồi giảng viên
//   86: Hỗ trợ phân tích phản hồi giảng viên
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Feedback
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long SubmissionId { get; set; }

        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        [Required]
        public long LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
