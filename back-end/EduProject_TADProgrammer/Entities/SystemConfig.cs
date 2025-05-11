// File: Core/Entities/SystemConfig.cs
// Mục đích: Định nghĩa entity SystemConfig để lưu cấu hình hệ thống (logo, màu sắc).
// Hỗ trợ chức năng: 
//   16: Admin - Cấu hình hệ thống
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class SystemConfig
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Key { get; set; } // LOGO_URL, THEME_COLOR

        [Required]
        public string Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
