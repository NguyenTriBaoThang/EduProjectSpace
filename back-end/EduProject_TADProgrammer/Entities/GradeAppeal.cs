// File: Core/Entities/GradeAppeal.cs
// Mục đích: Định nghĩa entity GradeAppeal để lưu yêu cầu phúc khảo điểm.
// Hỗ trợ chức năng: 
//   72: Phúc khảo và phản hồi điểm số
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeAppeal
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public string Status { get; set; } // PENDING, APPROVED, REJECTED

        public string? Response { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
