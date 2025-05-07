// File: Core/Entities/TimeTracking.cs
// Mục đích: Định nghĩa entity TimeTracking để lưu thời gian làm việc của sinh viên.
// Hỗ trợ chức năng: 
//   37: Giảng viên - Phân tích mức độ tham gia
//   55: Theo dõi thời gian làm việc
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class TimeTracking
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? Duration { get; set; } // Minutes

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
