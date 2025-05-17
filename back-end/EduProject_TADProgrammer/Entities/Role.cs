// File: Entities/Role.cs
// Mục đích: Định nghĩa entity Role để lưu vai trò người dùng (ROLE_ADMIN, ROLE_STUDENT, v.v.).
// Hỗ trợ chức năng: 
//   1: Phân quyền và bảo mật
//   4: Quản lý phân quyền
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa các vai trò trong hệ thống
    public enum RoleName
    {
        Admin,           // Quản trị viên
        LecturerGuide,   // Giảng viên hướng dẫn
        Student,         // Sinh viên
        Head,            // Trưởng khoa/bộ môn
        LecturerReview   // Giảng viên phản biện
    }

    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
