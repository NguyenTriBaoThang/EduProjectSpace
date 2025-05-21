// File: Models/AdminRoleDto.cs
// Mục đích: Định nghĩa DTO để truyền dữ liệu vai trò người dùng (ví dụ: ROLE_ADMIN, ROLE_STUDENT) giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý vai trò người dùng (xem, tạo, cập nhật thông tin vai trò).

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin vai trò người dùng
    public class AdminRoleDto
    {
        // ID của vai trò
        public long Id { get; set; }

        // Tên vai trò (ví dụ: "Admin", "Student", "LecturerGuide")
        public string Name { get; set; }

        // Mô tả chi tiết về vai trò (ví dụ: "Quản trị viên hệ thống", "Sinh viên thực hiện đồ án")
        public string Description { get; set; }
    }
}