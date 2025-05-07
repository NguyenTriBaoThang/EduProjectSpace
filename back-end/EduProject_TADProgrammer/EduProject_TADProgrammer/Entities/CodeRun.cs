// File: Core/Entities/CodeRun.cs
// Mục đích: Định nghĩa entity CodeRun để lưu kết quả kiểm tra hoặc chạy mã nguồn.
// Hỗ trợ chức năng: 
//   44: Sinh viên - Kiểm tra mã nguồn
//   57: Hỗ trợ lập trình
//   65: Kiểm tra và chạy mã nguồn tự động
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class CodeRun
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long SubmissionId { get; set; }

        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; } // Java, Python, etc.

        public string Result { get; set; }

        public float? PlagiarismScore { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
