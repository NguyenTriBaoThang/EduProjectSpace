// File: Entities/SubmissionVersion.cs
// Mục đích: Định nghĩa entity SubmissionVersion để lưu trữ lịch sử phiên bản của bài nộp.
// Hỗ trợ chức năng:
//   59: Quản lý phiên bản tài liệu

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class SubmissionVersion
    {
        // Khóa chính của bản ghi phiên bản bài nộp
        [Key]
        public long Id { get; set; }

        // ID của bài nộp liên quan (bắt buộc)
        [Required]
        public long SubmissionId { get; set; }

        // Liên kết với entity Submission (bài nộp chứa phiên bản)
        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        // Đường dẫn đến file của phiên bản bài nộp (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        // Số phiên bản của bài nộp (bắt buộc, ví dụ: 1, 2, 3...)
        [Required]
        public int VersionNumber { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}