// File: Entities/Role.cs
// Mục đích: Định nghĩa entity Role để lưu trữ vai trò người dùng trong hệ thống (ví dụ: ROLE_ADMIN, ROLE_STUDENT).
// Hỗ trợ chức năng:
//   1: Phân quyền và bảo mật
//   4: Quản lý phân quyền

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Role
    {
        // Khóa chính của bản ghi vai trò
        [Key]
        public long Id { get; set; }

        // Tên vai trò (bắt buộc, tối đa 50 ký tự, ví dụ: "Admin", "Student", "LecturerGuide", "Head", "LecturerReview")
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Mô tả chi tiết về vai trò (tùy chọn)
        public string Description { get; set; }

        // Danh sách người dùng thuộc vai trò này
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}