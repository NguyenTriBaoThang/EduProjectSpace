// File: Entities/Question.cs
// Mục đích: Định nghĩa entity Question để lưu trữ câu hỏi kiểm tra trước bảo vệ của đề tài.
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
        // Khóa chính của bản ghi câu hỏi
        [Key]
        public long Id { get; set; }

        // ID của đề tài liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (đề tài chứa câu hỏi)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Nội dung câu hỏi (bắt buộc)
        [Required]
        public string Content { get; set; }

        // ID của người tạo câu hỏi (bắt buộc, thường là giảng viên)
        [Required]
        public long CreatedBy { get; set; }

        // Liên kết với entity User (người tạo câu hỏi)
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}