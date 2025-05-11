// File: Core/Entities/Calendar.cs
// Mục đích: Định nghĩa entity Calendar để lưu lịch cá nhân và nhóm.
// Hỗ trợ chức năng: 
//   84: Quản lý lịch cá nhân và nhóm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Calendar
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        [StringLength(255)]
        public string EventTitle { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
