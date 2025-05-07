// File: Core/Models/BackupDto.cs
// Mục đích: Truyền dữ liệu thông tin sao lưu dữ liệu giữa API và frontend.
// Chức năng hỗ trợ: 
//   25: Quản lý vận hành hệ thống
namespace EduProject_TADProgrammer.Models
{
    public class BackupDto
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}