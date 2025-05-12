// File: Core/Models/LogDto.cs
// Mục đích: Truyền dữ liệu nhật ký hệ thống (hành động, truy cập) giữa API và frontend.
// Chức năng hỗ trợ: 
//   24: Theo dõi nhật ký hệ thống
namespace EduProject_TADProgrammer.Models
{
    public class LogDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}