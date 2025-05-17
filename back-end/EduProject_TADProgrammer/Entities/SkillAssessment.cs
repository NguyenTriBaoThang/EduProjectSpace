// File: Entities/SkillAssessment.cs
// Mục đích: Định nghĩa entity SkillAssessment để lưu kết quả tự đánh giá kỹ năng của sinh viên.
// Hỗ trợ chức năng: 
//   60: Đánh giá năng lực cá nhân
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class SkillAssessment
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        [StringLength(100)]
        public string Skill { get; set; }

        [Required]
        [Range(1, 10)]
        public int Score { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
