// File: Models/LogDto.cs
// Mục đích: Định nghĩa DTO để truyền dữ liệu nhật ký hệ thống (hành động, truy cập) giữa API và frontend.
// Hỗ trợ chức năng:
//   24: Theo dõi nhật ký hệ thống (ghi lại các hành động của người dùng).

using System;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin nhật ký hệ thống
    public class LogDto
    {
        // ID của bản ghi nhật ký
        public long Id { get; set; }

        // ID của người dùng thực hiện hành động
        public long UserId { get; set; }

        // Họ và tên đầy đủ của người dùng
        public string FullName { get; set; }

        // Tên vai trò của người dùng (ví dụ: "Admin", "Student", "LecturerGuide")
        public string RoleName { get; set; }

        // Hành động thực hiện (ví dụ: "Đăng nhập", "Cập nhật đề tài")
        public string Action { get; set; }

        // Chi tiết hành động (ví dụ: "Cập nhật đề tài DA001 thành công")
        public string Details { get; set; }

        // Thời gian thực hiện hành động
        public DateTime CreatedAt { get; set; }
    }
}