// File: Core/Entities/DefenseSchedule.cs
// Mục đích: Định nghĩa entity DefenseSchedule để lưu lịch bảo vệ đồ án.
// Hỗ trợ chức năng: 
//   56: Quản lý lịch bảo vệ
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class DefenseSchedule
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Room { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
