// File: Entities/RolePermission.cs
// Mục đích: Định nghĩa entity RolePermission để lưu trữ quyền truy cập cho từng vai trò trong hệ thống.
// Ghi chú: Mỗi bản ghi đại diện cho các quyền của một vai trò (ví dụ: Admin, Giảng viên, Sinh viên).
// Hỗ trợ chức năng:
//   1: Phân quyền và bảo mật
//   4: Quản lý phân quyền

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class RolePermission
    {
        // Khóa chính của bản ghi quyền vai trò
        [Key]
        public long Id { get; set; }

        // ID của vai trò liên quan (bắt buộc)
        [Required]
        public long RoleId { get; set; }

        // Liên kết với entity Role (vai trò được gán quyền)
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

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

        // Thời gian cập nhật bản ghi
        public DateTime UpdatedAt { get; set; }
    }
}