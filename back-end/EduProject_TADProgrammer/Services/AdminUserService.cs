using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminUserService
    {
        private readonly ApplicationDbContext _context;

        public AdminUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users.Include(u => u.Role)
                                          .FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                Console.WriteLine($"User not found: {username}");
                return null;
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                Console.WriteLine($"Password incorrect for {username}");
                return null;
            }
            Console.WriteLine($"User authenticated: {username}");
            return user;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _context.Departments
                .AsNoTracking()
                .ToListAsync();
        }   

        public async Task<List<AdminUserDto>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Select(u => new AdminUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    FullName = u.FullName,
                    ClassCode = u.ClassCode,
                    FacultyCode = u.Department.FacultyCode,
                    DepartmentId = u.DepartmentId,
                    RoleId = u.RoleId,
                    RoleName = u.Role.Name,
                    FailedLoginAttempts = u.FailedLoginAttempts,
                    Locked = u.Locked,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<AdminUserDto> GetUserById(long id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            return new AdminUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                ClassCode = user.ClassCode,
                DepartmentId = user.DepartmentId,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name,
                FailedLoginAttempts = user.FailedLoginAttempts,
                Locked = user.Locked,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<AdminUserDto> CreateUser(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                throw new System.Exception("Mã sinh viên hoặc Username đã tồn tại.");
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                throw new System.Exception("Email đã tồn tại.");
            if (!await IsValidRoleId(user.RoleId))
                throw new System.Exception("RoleId không hợp lệ.");
            if (user.RoleId == 3 && (string.IsNullOrEmpty(user.ClassCode) || !user.DepartmentId.HasValue))
                throw new System.Exception("Sinh viên phải có Mã lớp và Khoa.");
            if ((user.RoleId == 2 || user.RoleId == 4) && !user.DepartmentId.HasValue)
                throw new System.Exception("Giảng viên phải có Khoa.");
            if (user.DepartmentId.HasValue && !await _context.Departments.AnyAsync(d => d.Id == user.DepartmentId))
                throw new System.Exception("Khoa không hợp lệ.");

            user.FailedLoginAttempts = 0;
            user.Locked = false;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var createdUser = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            return new AdminUserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                FullName = createdUser.FullName,
                ClassCode = createdUser.ClassCode,
                DepartmentId = createdUser.DepartmentId,
                RoleId = createdUser.RoleId,
                RoleName = createdUser.Role?.Name,
                FailedLoginAttempts = createdUser.FailedLoginAttempts,
                Locked = createdUser.Locked,
                CreatedAt = createdUser.CreatedAt,
                UpdatedAt = createdUser.UpdatedAt
            };
        }

        public async System.Threading.Tasks.Task UpdateUser(long id, User user)
        {
            if (!await IsValidRoleId(user.RoleId))
                throw new System.Exception("RoleId không hợp lệ.");
            if (await _context.Users.AnyAsync(u => u.Email == user.Email && u.Id != user.Id))
                throw new System.Exception("Email đã tồn tại.");
            if (user.RoleId == 3 && (string.IsNullOrEmpty(user.ClassCode) || !user.DepartmentId.HasValue))
                throw new System.Exception("Sinh viên phải có Mã lớp và Khoa.");
            if ((user.RoleId == 2 || user.RoleId == 4) && !user.DepartmentId.HasValue)
                throw new System.Exception("Giảng viên phải có Khoa.");
            if (user.DepartmentId.HasValue && !await _context.Departments.AnyAsync(d => d.Id == user.DepartmentId))
                throw new System.Exception("Khoa không hợp lệ.");

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                throw new System.Exception("Người dùng không tồn tại.");

            // Kiểm tra liên kết dữ liệu
            if (await HasRelatedData(id))
                throw new System.Exception("Tài khoản đang có liên kết với dữ liệu, không thể xóa.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> HasRelatedData(long userId)
        {
            return await _context.GroupMembers.AnyAsync(gm => gm.StudentId == userId) ||
                   await _context.GroupRequests.AnyAsync(gr => gr.StudentId == userId) ||
                   await _context.Submissions.AnyAsync(s => s.StudentId == userId) ||
                   await _context.Grades.AnyAsync(g => g.StudentId == userId) ||
                   await _context.GradeAppeals.AnyAsync(ga => ga.StudentId == userId) ||
                   await _context.Notifications.AnyAsync(n => n.UserId == userId) ||
                   await _context.Meetings.AnyAsync(m => m.CreatedBy == userId) ||
                   await _context.Resources.AnyAsync(r => r.CreatedBy == userId) ||
                   await _context.SkillAssessments.AnyAsync(sa => sa.StudentId == userId) ||
                   await _context.AISuggestions.AnyAsync(ai => ai.UserId == userId) ||
                   await _context.TimeTrackings.AnyAsync(tt => tt.StudentId == userId) ||
                   await _context.Logs.AnyAsync(l => l.UserId == userId) ||
                   await _context.GradeLogs.AnyAsync(gl => gl.LecturerId == userId) ||
                   await _context.GradeSchedules.AnyAsync(gs => gs.LecturerId == userId) ||
                   await _context.Discussions.AnyAsync(d => d.UserId == userId) ||
                   await _context.Feedbacks.AnyAsync(f => f.LecturerId == userId) ||
                   await _context.FeedbackSurveys.AnyAsync(fs => fs.UserId == userId) ||
                   await _context.CommitteeMembers.AnyAsync(cm => cm.LecturerId == userId) ||
                   await _context.Questions.AnyAsync(q => q.CreatedBy == userId) ||
                   await _context.Calendars.AnyAsync(c => c.UserId == userId) ||
                   await _context.PeerReviews.AnyAsync(pr => pr.ReviewerId == userId || pr.RevieweeId == userId) ||
                   await _context.StudentCourses.AnyAsync(sc => sc.StudentId == userId) ||
                   await _context.LecturerCourses.AnyAsync(lc => lc.LecturerId == userId);
        }

        public async Task<bool> IsValidRoleId(long roleId)
        {
            return await _context.Roles.AnyAsync(r => r.Id == roleId);
        }
    }
}