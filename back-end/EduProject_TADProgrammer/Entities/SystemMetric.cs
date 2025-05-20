// File: Entities/SystemMetric.cs
// Mục đích: Định nghĩa entity SystemMetric để lưu trữ số liệu hiệu suất hệ thống (CPU, RAM, ổ đĩa, mạng).
// Hỗ trợ chức năng:
//   26: Quản lý hiệu suất và tài nguyên hệ thống

using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class SystemMetric
    {
        // Khóa chính của bản ghi số liệu hệ thống
        [Key]
        public long Id { get; set; }

        // Loại số liệu (bắt buộc, giá trị: "CPU", "RAM", "Disk", "Network")
        [Required]
        public string MetricType { get; set; }

        // Giá trị số liệu (bắt buộc, ví dụ: phần trăm sử dụng CPU hoặc RAM)
        [Required]
        public float Value { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}