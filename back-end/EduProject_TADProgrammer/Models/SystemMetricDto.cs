// File: Core/Models/SystemMetricDto.cs
// Mục đích: Truyền dữ liệu số liệu hiệu suất hệ thống (CPU, RAM) giữa API và frontend.
// Chức năng hỗ trợ: 
//   26: Quản lý hiệu suất và tài nguyên hệ thống
namespace EduProject_TADProgrammer.Models
{
    public class SystemMetricDto
    {
        public long Id { get; set; }
        public string MetricType { get; set; }
        public float Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}