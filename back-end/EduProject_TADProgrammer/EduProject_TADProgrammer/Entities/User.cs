// File: Core/Entities/User.cs
// Mục đích: Định nghĩa entity User để lưu thông tin người dùng (Admin, Giảng viên, Sinh viên).
// Hỗ trợ chức năng: 
//   1: Phân quyền và bảo mật
//   3: Quản lý tài khoản
//   4: Quản lý phân quyền
//   6: Thông báo tự động
//   9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using BCrypt.Net;

namespace EduProject_TADProgrammer.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [Required]
        public int FailedLoginAttempts { get; set; } = 0;

        [Required]
        public bool Locked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Phương thức mã hóa mật khẩu
        public void HashPassword()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }

        // Phương thức kiểm tra mật khẩu
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
