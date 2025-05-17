// File: Entities/SubmissionVersion.cs
// Mục đích: Định nghĩa entity SubmissionVersion để lưu lịch sử phiên bản bài nộp.
// Hỗ trợ chức năng: 
//   59: Quản lý phiên bản tài liệu
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class SubmissionVersion
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long SubmissionId { get; set; }

        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        [Required]
        public int VersionNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
