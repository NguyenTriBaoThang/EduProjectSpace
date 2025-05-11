// File: Core/Models/UserDto.cs
// Mục đích: Truyền dữ liệu thông tin người dùng (Admin, Giảng viên, Sinh viên) giữa API và frontend, loại bỏ mật khẩu để bảo mật.
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật
//   3: Quản lý tài khoản
//   4: Quản lý phân quyền
//   6: Thông báo tự động
//   9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
namespace EduProject_TADProgrammer.Models
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; } // Thêm để trả tên vai trò
        public string Tokenn { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}