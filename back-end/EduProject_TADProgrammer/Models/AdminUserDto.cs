// File: Core/Models/UserDto.cs
// Mục đích: Truyền dữ liệu thông tin người dùng (Admin, Giảng viên, Sinh viên) giữa API và frontend, loại bỏ mật khẩu để bảo mật.

namespace EduProject_TADProgrammer.Models
{
    public class AdminUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; } // Thêm để trả tên vai trò
        public int FailedLoginAttempts { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateAdminUserRequest
    {
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateAdminUserRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }

    public class CreateAdminUserStudentRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
    }

    public class UpdateAdminUserStudentRequest
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public bool Locked { get; set; }
        public string? Password { get; set; }
    }

    public class CreateAdminUserLecturerRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateAdminUserLecturerRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }
}