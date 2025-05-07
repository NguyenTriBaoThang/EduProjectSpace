// File: Core/Entities/Log.cs
// Mục đích: Định nghĩa entity Log để lưu nhật ký hệ thống (hành động, truy cập).
// Hỗ trợ chức năng: 
//   24: Theo dõi nhật ký hệ thống
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Log
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [StringLength(255)]
        public string Action { get; set; } // LOGIN, UPDATE, DELETE

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
