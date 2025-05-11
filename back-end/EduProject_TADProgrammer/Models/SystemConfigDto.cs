// File: Core/Models/SystemConfigDto.cs
// Mục đích: Truyền dữ liệu cấu hình hệ thống (logo, màu sắc) giữa API và frontend.
// Chức năng hỗ trợ: 
//   16: Admin - Cấu hình hệ thống
namespace EduProject_TADProgrammer.Models
{
    public class SystemConfigDto
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}