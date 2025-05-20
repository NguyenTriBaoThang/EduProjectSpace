// File: Services/RolePermissionService.cs
// Mục đích: Xử lý logic nghiệp vụ cho quản lý quyền truy cập
// Ghi chú: Lấy RoleName từ bảng Roles
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminRolePermissionService
    {
        private readonly ApplicationDbContext _context;

        public AdminRolePermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ghi chú: Lấy danh sách quyền, bao gồm tên vai trò từ Role
        public async Task<List<AdminRolePermissionDto>> GetAllPermissions()
        {
            return await _context.RolePermissions
                .Include(rp => rp.Role) // Ghi chú: Join với bảng Roles
                .Select(rp => new AdminRolePermissionDto
                {
                    Id = rp.Id,
                    RoleId = rp.RoleId,
                    RoleName = rp.Role.Name, // Ghi chú: Lấy tên từ Role
                    ViewUsers = rp.ViewUsers,
                    EditUsers = rp.EditUsers,
                    ViewProjects = rp.ViewProjects,
                    EditProjects = rp.EditProjects,
                    ViewGrading = rp.ViewGrading,
                    EditGrading = rp.EditGrading
                })
                .ToListAsync();
        }

        // Ghi chú: Cập nhật quyền cho một vai trò
        public async System.Threading.Tasks.Task UpdatePermission(long roleId, AdminRolePermissionDto request)
        {
            var permission = await _context.RolePermissions.FirstOrDefaultAsync(rp => rp.RoleId == roleId);
            if (permission == null)
            {
                throw new Exception($"Không tìm thấy quyền cho vai trò ID {roleId}.");
            }

            // Ghi chú: Admin có tất cả quyền, không thể thay đổi
            if (roleId == 1)
            {
                throw new Exception("Không thể sửa quyền của vai trò Admin.");
            }

            // Ghi chú: Sinh viên không được sửa người dùng hoặc hội đồng
            if (roleId == 3)
            {
                request.EditUsers = false;
                request.EditGrading = false;
            }

            permission.ViewUsers = request.ViewUsers;
            permission.EditUsers = request.EditUsers;
            permission.ViewProjects = request.ViewProjects;
            permission.EditProjects = request.EditProjects;
            permission.ViewGrading = request.ViewGrading;
            permission.EditGrading = request.EditGrading;
            permission.UpdatedAt = DateTime.UtcNow;

            _context.RolePermissions.Update(permission);
            await _context.SaveChangesAsync();
        }
    }
}