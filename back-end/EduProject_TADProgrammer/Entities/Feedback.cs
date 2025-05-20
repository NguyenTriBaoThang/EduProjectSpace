// File: Entities/Feedback.cs
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
        // Khóa chính của bản ghi phản hồi
        [Key]
        public long Id { get; set; }

        // ID của bài nộp liên quan (bắt buộc)
        [Required]
        public long SubmissionId { get; set; }

        // Liên kết với entity Submission (bài nộp được phản hồi)
        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        // ID của giảng viên cung cấp phản hồi (bắt buộc)
        [Required]
        public long LecturerId { get; set; }

        // Liên kết với entity User (giảng viên cung cấp phản hồi)
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        // Nội dung phản hồi (bắt buộc)
        [Required]
        public string Content { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
