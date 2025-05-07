// File: Core/Entities/Backup.cs
// Mục đích: Định nghĩa entity Backup để lưu thông tin sao lưu dữ liệu.
// Hỗ trợ chức năng: 
//   25: Quản lý vận hành hệ thống
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class Backup
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
