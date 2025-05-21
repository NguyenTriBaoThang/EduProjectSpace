// File: Models/AdminUserDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu thông tin người dùng (Admin, Giảng viên, Sinh viên) giữa API và frontend, loại bỏ mật khẩu trong DTO trả về để bảo mật.
// Hỗ trợ chức năng:
//   Quản lý tài khoản người dùng (xem, tạo, cập nhật thông tin người dùng, bao gồm sinh viên và giảng viên).

using System;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin chi tiết người dùng
    public class AdminUserDto
    {
        // ID của người dùng
        public long Id { get; set; }

        // Tên đăng nhập
        public string Username { get; set; }

        // Email của người dùng
        public string Email { get; set; }

        // Họ và tên đầy đủ
        public string FullName { get; set; }

        // Mã lớp học (tùy chọn, chủ yếu áp dụng cho sinh viên)
        public string ClassCode { get; set; }

        // ID của vai trò
        public long RoleId { get; set; }

        // Tên vai trò (ví dụ: "Admin", "Student", "LecturerGuide")
        public string RoleName { get; set; }

        // Số lần đăng nhập thất bại
        public int FailedLoginAttempts { get; set; }

        // Trạng thái khóa tài khoản (true: khóa, false: không khóa)
        public bool Locked { get; set; }

        // Thời gian tạo tài khoản
        public DateTime CreatedAt { get; set; }

        // Thời gian cập nhật tài khoản (tùy chọn)
        public DateTime? UpdatedAt { get; set; }
    }

    // DTO để yêu cầu tạo tài khoản người dùng chung
    public class CreateAdminUserRequest
    {
        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Mật khẩu (tùy chọn, sẽ được mã hóa nếu cung cấp)
        public string? Password { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (tùy chọn, chủ yếu áp dụng cho sinh viên)
        public string ClassCode { get; set; }

        // ID của vai trò (bắt buộc)
        public long RoleId { get; set; }
    }

    // DTO để yêu cầu cập nhật tài khoản người dùng chung
    public class UpdateAdminUserRequest
    {
        // ID của người dùng (bắt buộc)
        public long Id { get; set; }

        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (tùy chọn, chủ yếu áp dụng cho sinh viên)
        public string ClassCode { get; set; }

        // ID của vai trò (bắt buộc)
        public long RoleId { get; set; }

        // Mật khẩu (tùy chọn, sẽ được mã hóa nếu cung cấp)
        public string? Password { get; set; }

        // Trạng thái khóa tài khoản (bắt buộc, true: khóa, false: không khóa)
        public bool Locked { get; set; }
    }

    // DTO để yêu cầu tạo tài khoản sinh viên
    public class CreateAdminUserStudentRequest
    {
        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (bắt buộc, áp dụng cho sinh viên)
        public string ClassCode { get; set; }
    }

    // DTO để yêu cầu cập nhật tài khoản sinh viên
    public class UpdateAdminUserStudentRequest
    {
        // ID của sinh viên (bắt buộc)
        public long Id { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (bắt buộc, áp dụng cho sinh viên)
        public string ClassCode { get; set; }

        // Trạng thái khóa tài khoản (bắt buộc, true: khóa, false: không khóa)
        public bool Locked { get; set; }

        // Mật khẩu (tùy chọn, sẽ được mã hóa nếu cung cấp)
        public string? Password { get; set; }
    }

    // DTO để yêu cầu tạo tài khoản giảng viên
    public class CreateAdminUserLecturerRequest
    {
        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (tùy chọn, thường không áp dụng cho giảng viên)
        public string ClassCode { get; set; }

        // ID của vai trò (bắt buộc, ví dụ: vai trò giảng viên)
        public long RoleId { get; set; }
    }

    // DTO để yêu cầu cập nhật tài khoản giảng viên
    public class UpdateAdminUserLecturerRequest
    {
        // ID của giảng viên (bắt buộc)
        public long Id { get; set; }

        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Email (bắt buộc)
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc)
        public string FullName { get; set; }

        // Mã lớp học (tùy chọn, thường không áp dụng cho giảng viên)
        public string ClassCode { get; set; }

        // ID của vai trò (bắt buộc, ví dụ: vai trò giảng viên)
        public long RoleId { get; set; }

        // Mật khẩu (tùy chọn, sẽ được mã hóa nếu cung cấp)
        public string? Password { get; set; }

        // Trạng thái khóa tài khoản (bắt buộc, true: khóa, false: không khóa)
        public bool Locked { get; set; }
    }
}