// File: Entities/Submission.cs
// Mục đích: Định nghĩa entity Submission để lưu bài nộp của nhóm (báo cáo, mã nguồn).
// Hỗ trợ chức năng: 
//   7: Quản lý quy trình đồ án
//   10: Nộp bài và gia hạn
//   11: Kiểm tra tài liệu nộp bài
//   32: Giảng viên - Kiểm tra tính hợp lệ bài nộp
//   59: Quản lý phiên bản tài liệu
//   65: Kiểm tra và chạy mã nguồn tự động
//   69: Hỗ trợ phân loại tài liệu
//   88: Theo dõi tiến độ nộp tài liệu
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Submission
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ?ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public string Status { get; set; } // Submitted, Validated, Rejected

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SubmissionVersion> SubmissionVersions { get; set; } = new List<SubmissionVersion>();
        public virtual ICollection<CodeRun> CodeRuns { get; set; } = new List<CodeRun>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
