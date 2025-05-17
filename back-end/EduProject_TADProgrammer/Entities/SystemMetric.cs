// File: Entities/SystemMetric.cs
// Mục đích: Định nghĩa entity SystemMetric để lưu số liệu hiệu suất hệ thống (CPU, RAM).
// Hỗ trợ chức năng: 
//   26: Quản lý hiệu suất và tài nguyên hệ thống
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa loại số liệu hệ thống
    public enum MetricType
    {
        CPU,     // Sử dụng CPU
        RAM,     // Sử dụng RAM
        Disk,    // Sử dụng ổ đĩa
        Network  // Sử dụng mạng
    }

    public class SystemMetric
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string MetricType { get; set; }

        [Required]
        public float Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
