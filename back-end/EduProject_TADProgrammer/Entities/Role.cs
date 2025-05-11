// File: Core/Entities/Role.cs
// Mục đích: Định nghĩa entity Role để lưu vai trò người dùng (ROLE_ADMIN, ROLE_STUDENT, v.v.).
// Hỗ trợ chức năng: 
//   1: Phân quyền và bảo mật
//   4: Quản lý phân quyền
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class Role
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
