// File: Entities/SystemConfig.cs
// Mục đích: Định nghĩa entity SystemConfig để lưu trữ cấu hình hệ thống (ví dụ: logo, màu sắc).
// Hỗ trợ chức năng:
//   16: Admin - Cấu hình hệ thống

using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class SystemConfig
    {
        // Khóa chính của bản ghi cấu hình
        [Key]
        public long Id { get; set; }

        // Tên khóa cấu hình (bắt buộc, tối đa 50 ký tự, ví dụ: "LOGO_URL", "THEME_COLOR")
        [Required]
        [StringLength(50)]
        public string Key { get; set; }

        // Giá trị của cấu hình (bắt buộc, ví dụ: URL của logo hoặc mã màu)
        [Required]
        public string Value { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}