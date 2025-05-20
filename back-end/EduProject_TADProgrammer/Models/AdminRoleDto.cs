// File: Core/Models/RoleDto.cs
// Mục đích: Truyền dữ liệu vai trò người dùng (ROLE_ADMIN, ROLE_STUDENT, v.v.) giữa API và frontend.
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật
//   4: Quản lý phân quyền
namespace EduProject_TADProgrammer.Models
{
    public class AdminRoleDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}