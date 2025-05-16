// File: Models/RolePermissionDto.cs
// Mục đích: DTO để truyền dữ liệu quyền truy cập qua API
// Ghi chú: Chỉ chứa các trường cần thiết, không bao gồm thông tin nhạy cảm
namespace EduProject_TADProgrammer.Models
{
    public class RolePermissionDto
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; } // Ghi chú: Tên vai trò (VD: Admin, Giảng viên)
        public bool ViewUsers { get; set; }
        public bool EditUsers { get; set; }
        public bool ViewProjects { get; set; }
        public bool EditProjects { get; set; }
        public bool ViewGrading { get; set; }
        public bool EditGrading { get; set; }
    }
}