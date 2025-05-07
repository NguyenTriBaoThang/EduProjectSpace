// File: Core/Entities/Grade.cs
// Mục đích: Định nghĩa entity Grade để lưu điểm số của nhóm hoặc sinh viên.
// Hỗ trợ chức năng: 
//   12: Hỗ trợ chấm điểm
//   13: Đánh giá minh bạch
//   14: Xem phản hồi và điểm
//   15: Báo cáo và thống kê
//   36, 61, 66, 71, 72, 74, 76-83
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace EduProject_TADProgrammer.Entities
{
    public class Grade
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public long? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        public long CriteriaId { get; set; }

        [ForeignKey("CriteriaId")]
        public GradeCriteria Criteria { get; set; }

        [Required]
        public float Score { get; set; }

        public string Comment { get; set; }

        public DateTime GradedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public long GradedBy { get; set; }

        [ForeignKey("GradedBy")]
        public User GradedByUser { get; set; }
    }
}
