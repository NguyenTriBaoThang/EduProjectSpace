using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminProjectService
    {
        private readonly ApplicationDbContext _context;

        public AdminProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminProjectDto>> GetAllProjects()
        {
            return await _context.Projects
                .Include(p => p.Course)
                .Include(p => p.Group)
                    .ThenInclude(g => g.Lecturer)
                .Include(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                        .ThenInclude(gm => gm.Student)
                .Select(p => new AdminProjectDto
                {
                    Id = p.Id,
                    ProjectCode = p.ProjectCode,
                    Title = p.Title,
                    CourseId = p.CourseId,
                    CourseName = p.Course.Name,
                    LecturerId = p.Group != null ? p.Group.LecturerId : (long?)null, // Avoid ?. with conditional
                    LecturerName = p.Group != null && p.Group.Lecturer != null ? p.Group.Lecturer.FullName : "Chưa có giảng viên", // Avoid ?. and ??Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Group = p.Group != null ? new AdminProjectGroupDto
                    {
                        Id = p.Group.Id,
                        Students = p.Group.GroupMembers.Select(gm => new AdminProjectStudentDto
                        {
                            Id = gm.Student.Id,
                            FullName = gm.Student.FullName
                        }).ToList()
                    } : null
                })
                .ToListAsync();
        }

        // Hàm lấy danh sách tất cả môn học
        public async Task<List<CourseAdminProjectDto>> GetAllCoursesAsync()
        {
            return await _context.Courses
                .AsNoTracking() // Tăng hiệu suất vì chỉ đọc dữ liệu
                .Select(c => new CourseAdminProjectDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<AdminProjectDto> GetProjectById(long id)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .Include(p => p.Group)
                    .ThenInclude(g => g.Lecturer)
                .Include(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                        .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                return null;

            return new AdminProjectDto
            {
                Id = project.Id,
                ProjectCode = project.ProjectCode,
                Title = project.Title,
                CourseId = project.CourseId,
                CourseName = project.Course.Name,
                LecturerId = project.Group != null ? project.Group.LecturerId : (long?)null, // Avoid ?. with conditional
                LecturerName = project.Group != null && project.Group.Lecturer != null ? project.Group.Lecturer.FullName : "Chưa có giảng viên", // Avoid ?. and ??Status = project.Status,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt,
                Group = project.Group != null ? new AdminProjectGroupDto
                {
                    Id = project.Group.Id,
                    Students = project.Group.GroupMembers.Select(gm => new AdminProjectStudentDto
                    {
                        Id = gm.Student.Id,
                        FullName = gm.Student.FullName
                    }).ToList()
                } : null
            };
        }

        public async Task<Project> GetById(long id)
        {
            return await _context.Projects
                .Include(p => p.Course)
                .Include(p => p.Group)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<AdminProjectDto> CreateProject(Project project)
        {
            if (await _context.Projects.AnyAsync(p => p.ProjectCode == project.ProjectCode))
                throw new System.Exception("Mã đề tài đã tồn tại.");
            if (!await _context.Courses.AnyAsync(c => c.Id == project.CourseId))
                throw new System.Exception("Môn học không hợp lệ.");
            if (!await _context.Users.AnyAsync(u => u.Id == project.Group.LecturerId && (u.RoleId == 2 || u.RoleId == 4)))
                throw new System.Exception("Giảng viên không hợp lệ.");

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            var createdProject = await _context.Projects
                .Include(p => p.Course)
                .Include(p => p.Group)
                .FirstOrDefaultAsync(p => p.Id == project.Id);
            return new AdminProjectDto
            {
                Id = createdProject.Id,
                ProjectCode = createdProject.ProjectCode,
                Title = createdProject.Title,
                CourseId = createdProject.CourseId,
                CourseName = createdProject.Course.Name,
                LecturerId = createdProject.Group != null ? createdProject.Group.LecturerId : (long?)null, // Avoid ?. with conditional
                LecturerName = createdProject.Group != null && createdProject.Group.Lecturer != null ? createdProject.Group.Lecturer.FullName : "Chưa có giảng viên", // Avoid ?. and ??Status = createdProject.Status,
                CreatedAt = createdProject.CreatedAt,
                UpdatedAt = createdProject.UpdatedAt
            };
        }

        public async System.Threading.Tasks.Task UpdateProject(Project project)
        {
            if (await _context.Projects.AnyAsync(p => p.ProjectCode == project.ProjectCode && p.Id != project.Id))
                throw new System.Exception("Mã đề tài đã tồn tại.");
            if (!await _context.Courses.AnyAsync(c => c.Id == project.CourseId))
                throw new System.Exception("Môn học không hợp lệ.");
            if (!await _context.Users.AnyAsync(u => u.Id == project.Group.LecturerId && (u.RoleId == 2 || u.RoleId == 4)))
                throw new System.Exception("Giảng viên không hợp lệ.");

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteProject(long id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task LogAction(long projectId, string action, string details)
        {
            var log = new Log
            {
                UserId = projectId, // Lưu ý: UserId có thể cần là ID của người thực hiện hành động, không phải projectId
                Action = action,
                Details = details,
                CreatedAt = DateTime.UtcNow
            };
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}