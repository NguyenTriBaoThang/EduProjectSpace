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
    public class ProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all projects
        public async Task<List<ProjectDto>> GetAllProjects()
        {
            return await _context.Projects
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Course)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.GroupMembers)
                            .ThenInclude(gm => gm.Student)
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    ProjectCode = p.ProjectCode,
                    Title = p.Title,
                    StudentCourseId = p.StudentCourseId,
                    CourseId = p.StudentCourse != null ? p.StudentCourse.CourseId : 0,
                    CourseName = p.StudentCourse != null && p.StudentCourse.Course != null ? p.StudentCourse.Course.Name : null,
                    LecturerId = (long)(p.StudentCourse != null && p.StudentCourse.Group != null ? p.StudentCourse.Group.LecturerId : (p.StudentCourse != null && p.StudentCourse.LecturerId.HasValue ? p.StudentCourse.LecturerId.Value : 0)),
                    LecturerName = p.StudentCourse != null && p.StudentCourse.Group != null && p.StudentCourse.Group.Lecturer != null ? p.StudentCourse.Group.Lecturer.FullName : (p.StudentCourse != null && p.StudentCourse.Lecturer != null ? p.StudentCourse.Lecturer.FullName : null),
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Group = p.StudentCourse != null && p.StudentCourse.Group != null ? new GroupProjectDto
                    {
                        Id = p.StudentCourse.Group.Id,
                        Students = p.StudentCourse.Group.GroupMembers != null ? p.StudentCourse.Group.GroupMembers.Select(gm => new StudentDto
                        {
                            Id = gm.Student.Id,
                            FullName = gm.Student.FullName
                        }).ToList() : new List<StudentDto>()
                    } : null
                })
                .ToListAsync();
        }

        // Get project by ID
        public async Task<ProjectDto> GetProjectById(long id)
        {
            var project = await _context.Projects
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Course)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.GroupMembers)
                            .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return null;

            return new ProjectDto
            {
                Id = project.Id,
                ProjectCode = project.ProjectCode,
                Title = project.Title,
                StudentCourseId = project.StudentCourseId,
                CourseId = project.StudentCourse != null ? project.StudentCourse.CourseId : 0,
                CourseName = project.StudentCourse != null && project.StudentCourse.Course != null ? project.StudentCourse.Course.Name : null,
                LecturerId = (long)(project.StudentCourse != null && project.StudentCourse.Group != null ? project.StudentCourse.Group.LecturerId : (project.StudentCourse != null && project.StudentCourse.LecturerId.HasValue ? project.StudentCourse.LecturerId.Value : 0)),
                LecturerName = project.StudentCourse != null && project.StudentCourse.Group != null && project.StudentCourse.Group.Lecturer != null ? project.StudentCourse.Group.Lecturer.FullName : (project.StudentCourse != null && project.StudentCourse.Lecturer != null ? project.StudentCourse.Lecturer.FullName : null),
                Status = project.Status,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt,
                Group = project.StudentCourse != null && project.StudentCourse.Group != null ? new GroupProjectDto
                {
                    Id = project.StudentCourse.Group.Id,
                    Students = project.StudentCourse.Group.GroupMembers != null ? project.StudentCourse.Group.GroupMembers.Select(gm => new StudentDto
                    {
                        Id = gm.Student.Id,
                        FullName = gm.Student.FullName
                    }).ToList() : new List<StudentDto>()
                } : null
            };
        }

        // Get project by ID (raw entity)
        public async Task<Project> GetById(long id)
        {
            return await _context.Projects
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Course)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.Lecturer)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Create project
        public async Task<ProjectDto> CreateProject(Project project, long lecturerId)
        {
            // Validate ProjectCode uniqueness
            if (await _context.Projects.AnyAsync(p => p.ProjectCode == project.ProjectCode))
                throw new Exception("Mã đề tài đã tồn tại.");

            // Validate StudentCourse
            var studentCourse = await _context.StudentCourses
                .Include(sc => sc.Course)
                .Include(sc => sc.Lecturer)
                .Include(sc => sc.Group)
                .FirstOrDefaultAsync(sc => sc.Id == project.StudentCourseId);
            if (studentCourse == null)
                throw new Exception("StudentCourse không hợp lệ.");

            // Validate Lecturer
            if (!await _context.Users.AnyAsync(u => u.Id == lecturerId && (u.Role.Name == "LecturerGuide" || u.Role.Name == "Head")))
                throw new Exception("Giảng viên không hợp lệ.");

            // Create Group
            var group = new Group
            {
                Name = $"Group_{project.ProjectCode}",
                LecturerId = lecturerId,
                MaxMembers = 5,
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Batch operations
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Save Project
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                // Save Group with ProjectId
                group.ProjectId = project.Id;
                _context.Groups.Add(group);
                await _context.SaveChangesAsync();

                // Update StudentCourse with GroupId if not set
                if (studentCourse.GroupId == null)
                {
                    studentCourse.GroupId = group.Id;
                    studentCourse.UpdatedAt = DateTime.UtcNow;
                    _context.StudentCourses.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            // Fetch created project with related data
            var createdProject = await _context.Projects
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Course)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Lecturer)
                .Include(p => p.StudentCourse)
                    .ThenInclude(sc => sc.Group)
                        .ThenInclude(g => g.Lecturer)
                .FirstOrDefaultAsync(p => p.Id == project.Id);

            return new ProjectDto
            {
                Id = createdProject.Id,
                ProjectCode = createdProject.ProjectCode,
                Title = createdProject.Title,
                StudentCourseId = createdProject.StudentCourseId,
                CourseId = createdProject.StudentCourse != null ? createdProject.StudentCourse.CourseId : 0,
                CourseName = createdProject.StudentCourse != null && createdProject.StudentCourse.Course != null ? createdProject.StudentCourse.Course.Name : null,
                LecturerId = (long)(createdProject.StudentCourse != null && createdProject.StudentCourse.Group != null ? createdProject.StudentCourse.Group.LecturerId : (createdProject.StudentCourse != null && createdProject.StudentCourse.LecturerId.HasValue ? createdProject.StudentCourse.LecturerId.Value : 0)),
                LecturerName = createdProject.StudentCourse != null && createdProject.StudentCourse.Group != null && createdProject.StudentCourse.Group.Lecturer != null ? createdProject.StudentCourse.Group.Lecturer.FullName : (createdProject.StudentCourse != null && createdProject.StudentCourse.Lecturer != null ? createdProject.StudentCourse.Lecturer.FullName : null),
                Status = createdProject.Status,
                CreatedAt = createdProject.CreatedAt,
                UpdatedAt = createdProject.UpdatedAt,
                Group = createdProject.StudentCourse != null && createdProject.StudentCourse.Group != null ? new GroupProjectDto
                {
                    Id = createdProject.StudentCourse.Group.Id,
                    Students = createdProject.StudentCourse.Group.GroupMembers != null ? createdProject.StudentCourse.Group.GroupMembers.Select(gm => new StudentDto
                    {
                        Id = gm.Student.Id,
                        FullName = gm.Student.FullName
                    }).ToList() : new List<StudentDto>()
                } : null
            };
        }

        // Update project
        public async System.Threading.Tasks.Task UpdateProject(Project project, long lecturerId)
        {
            // Validate ProjectCode uniqueness
            if (await _context.Projects.AnyAsync(p => p.ProjectCode == project.ProjectCode && p.Id != project.Id))
                throw new Exception("Mã đề tài đã tồn tại.");

            // Validate StudentCourse
            var studentCourse = await _context.StudentCourses
                .Include(sc => sc.Course)
                .Include(sc => sc.Lecturer)
                .Include(sc => sc.Group)
                .FirstOrDefaultAsync(sc => sc.Id == project.StudentCourseId);
            if (studentCourse == null)
                throw new Exception("StudentCourse không hợp lệ.");

            // Validate Lecturer
            if (!await _context.Users.AnyAsync(u => u.Id == lecturerId && (u.Role.Name == "LecturerGuide" || u.Role.Name == "Head")))
                throw new Exception("Giảng viên không hợp lệ.");

            // Batch operations
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Update Project
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();

                // Update Group LecturerId
                var group = await _context.Groups.FirstOrDefaultAsync(g => g.ProjectId == project.Id);
                if (group != null)
                {
                    group.LecturerId = lecturerId;
                    group.UpdatedAt = DateTime.UtcNow;
                    _context.Groups.Update(group);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // Delete project
        public async System.Threading.Tasks.Task DeleteProject(long id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var project = await _context.Projects.FindAsync(id);
                if (project != null)
                {
                    // Remove associated Group
                    var group = await _context.Groups.FirstOrDefaultAsync(g => g.ProjectId == id);
                    if (group != null)
                    {
                        // Update StudentCourse to remove GroupId
                        var studentCourse = await _context.StudentCourses.FirstOrDefaultAsync(sc => sc.GroupId == group.Id);
                        if (studentCourse != null)
                        {
                            studentCourse.GroupId = null;
                            studentCourse.UpdatedAt = DateTime.UtcNow;
                            _context.StudentCourses.Update(studentCourse);
                        }
                        _context.Groups.Remove(group);
                    }

                    _context.Projects.Remove(project);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        // Log action
        public async System.Threading.Tasks.Task LogAction(long projectId, string action, string details, long userId)
        {
            if (!await _context.Users.AnyAsync(u => u.Id == userId))
                throw new Exception("Người dùng không hợp lệ.");

            var log = new Log
            {
                UserId = userId,
                Action = action,
                Details = details,
                CreatedAt = DateTime.UtcNow
            };
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
        }

        // StudentCourse operations
        public async Task<StudentCourse> GetStudentCourseById(long id)
        {
            return await _context.StudentCourses
                .Include(sc => sc.Course)
                .Include(sc => sc.Lecturer)
                .Include(sc => sc.Group)
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async System.Threading.Tasks.Task UpdateStudentCourse(StudentCourse studentCourse)
        {
            _context.StudentCourses.Update(studentCourse);
            await _context.SaveChangesAsync();
        }

        // Group operations
        public async Task<Group> GetGroupByProjectId(long projectId)
        {
            return await _context.Groups
                .Include(g => g.Lecturer)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(g => g.ProjectId == projectId);
        }

        public async Task<Group> CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async System.Threading.Tasks.Task UpdateGroup(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }
    }
}