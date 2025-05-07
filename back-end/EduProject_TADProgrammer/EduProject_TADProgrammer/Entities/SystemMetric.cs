// File: Core/Entities/SystemMetric.cs
// Mục đích: Định nghĩa entity SystemMetric để lưu số liệu hiệu suất hệ thống (CPU, RAM).
// Hỗ trợ chức năng: 
//   26: Quản lý hiệu suất và tài nguyên hệ thống
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class SystemMetric
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MetricType { get; set; } // CPU, RAM, ACTIVE_USERS

        [Required]
        public float Value { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
