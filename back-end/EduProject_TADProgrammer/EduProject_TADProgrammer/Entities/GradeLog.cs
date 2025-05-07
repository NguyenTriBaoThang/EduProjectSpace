// File: Core/Entities/GradeLog.cs
// Mục đích: Định nghĩa entity GradeLog để lưu nhật ký chấm điểm.
// Hỗ trợ chức năng: 
//   74: Nhật ký chấm điểm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeLog
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        [Required]
        public long LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        [Required]
        [StringLength(50)]
        public string Action { get; set; } // CREATE, UPDATE

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
