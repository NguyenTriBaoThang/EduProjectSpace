// File: Core/Entities/GradeSchedule.cs
// Mục đích: Định nghĩa entity GradeSchedule để lưu lịch trình chấm điểm.
// Hỗ trợ chức năng: 
//   75: Lịch trình chấm điểm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeSchedule
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public long LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string Status { get; set; } // PENDING, COMPLETED

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
