// File: Services/RoleService.cs
// Mục đích: Xử lý logic nghiệp vụ liên quan đến vai trò (CRUD).
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật (quản lý vai trò).
//   4: Quản lý phân quyền.
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminRoleService
    {
        private readonly ApplicationDbContext _context;

        public AdminRoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả vai trò, ánh xạ sang RoleDto.
        public async Task<List<AdminRoleDto>> GetAllRoles()
        {
            return await _context.Roles
                .Select(r => new AdminRoleDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description
                })
                .ToListAsync();
        }

        // Lấy vai trò theo ID, ánh xạ sang RoleDto.
        public async Task<AdminRoleDto> GetRoleById(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
                return null;

            return new AdminRoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        // Lấy vai trò theo ID (entity).
        public async Task<Role> GetById(long id)
        {
            return await _context.Roles.FindAsync(id);
        }

        // Tạo vai trò mới.
        public async Task<AdminRoleDto> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return new AdminRoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        // Cập nhật vai trò.
        public async System.Threading.Tasks.Task UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        // Xóa vai trò.
        public async System.Threading.Tasks.Task DeleteRole(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
