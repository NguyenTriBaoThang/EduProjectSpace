// File: Models/LoginRequest.cs
// Mục đích: Định nghĩa DTO để truyền dữ liệu yêu cầu đăng nhập (tên đăng nhập và mật khẩu) từ frontend đến API.
// Hỗ trợ chức năng:
//   Xác thực người dùng (đăng nhập vào hệ thống).

namespace EduProject_TADProgrammer.Models
{
    // DTO cho yêu cầu đăng nhập
    public class LoginRequest
    {
        // Tên đăng nhập (bắt buộc)
        public string Username { get; set; }

        // Mật khẩu (bắt buộc, sẽ được kiểm tra mã hóa)
        public string Password { get; set; }
    }
}