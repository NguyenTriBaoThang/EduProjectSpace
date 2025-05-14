using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class GroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả group, ánh xạ sang GroupDto
        public async Task<List<GroupDto>> GetAllGroups()
        {
            return await _context.Groups
                .Include(g => g.Project)
                .Select(group => new GroupDto
                {
                    Id = group.Id,
                    Name = group.Name,
                    ProjectId = group.ProjectId,
                    CreatedAt = group.CreatedAt
                })
                .ToListAsync();
        }

        // Lấy group theo ID, ánh xạ sang GroupDto
        public async Task<GroupDto> GetGroupById(long id)
        {
            var group = await _context.Groups
                .Include(g => g.Project)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (group == null)
                return null;

            return new GroupDto
            {
                Id = group.Id,
                Name = group.Name,
                ProjectId = group.ProjectId,
                CreatedAt = group.CreatedAt
            };
        }

        // Lấy group theo ID (entity)
        public async Task<Group> GetById(long id)
        {
            return await _context.Groups
                .Include(g => g.Project)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        // Tạo group mới
        public async Task<GroupDto> CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            var createdGroup = await _context.Groups
                .Include(g => g.Project)
                .FirstOrDefaultAsync(g => g.Id == group.Id);

            return new GroupDto
            {
                Id = createdGroup.Id,
                Name = createdGroup.Name,
                ProjectId = createdGroup.ProjectId,
                CreatedAt = createdGroup.CreatedAt
            };
        }

        // Cập nhật group
        public async System.Threading.Tasks.Task UpdateGroup(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        // Xóa group
        public async System.Threading.Tasks.Task DeleteGroup(long id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }    
    }
}