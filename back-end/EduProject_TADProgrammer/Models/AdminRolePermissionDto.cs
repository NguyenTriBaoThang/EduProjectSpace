// File: Models/AdminRolePermissionDto.cs
// Mục đích: Định nghĩa DTO để truyền dữ liệu quyền truy cập của vai trò giữa API và frontend.
// Ghi chú: Chỉ chứa các trường cần thiết, không bao gồm thông tin nhạy cảm.
// Hỗ trợ chức năng:
//   Quản lý phân quyền (xem, cập nhật quyền truy cập của vai trò).

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin quyền truy cập của vai trò
    public class AdminRolePermissionDto
    {
        // ID của bản ghi quyền vai trò
        public long Id { get; set; }

        // ID của vai trò liên quan
        public long RoleId { get; set; }

        // Tên vai trò (ví dụ: "Admin", "Giảng viên", "Sinh viên")
        public string RoleName { get; set; }

        // Quyền xem thông tin người dùng (true: cho phép, false: không cho phép)
        public bool ViewUsers { get; set; }

        // Quyền chỉnh sửa thông tin người dùng (true: cho phép, false: không cho phép)
        public bool EditUsers { get; set; }

        // Quyền xem thông tin đề tài (true: cho phép, false: không cho phép)
        public bool ViewProjects { get; set; }

        // Quyền chỉnh sửa thông tin đề tài (true: cho phép, false: không cho phép)
        public bool EditProjects { get; set; }

        // Quyền xem thông tin chấm điểm (true: cho phép, false: không cho phép)
        public bool ViewGrading { get; set; }

        // Quyền chỉnh sửa thông tin chấm điểm (true: cho phép, false: không cho phép)
        public bool EditGrading { get; set; }
    }
}