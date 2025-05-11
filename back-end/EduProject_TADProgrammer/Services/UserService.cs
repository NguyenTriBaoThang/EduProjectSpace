// File: Services/UserService.cs
// Mục đích: Xử lý logic nghiệp vụ liên quan đến tài khoản người dùng (xác thực, CRUD, ghi nhật ký).
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật (xác thực, quản lý tài khoản, ghi nhật ký).
//   3: Quản lý tài khoản.
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Xác thực người dùng, kiểm tra mật khẩu bằng BCrypt.
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;

            return user;
        }

        // Lấy tất cả người dùng, ánh xạ sang UserDto.
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    FullName = u.FullName,
                    RoleId = u.RoleId,
                    RoleName = u.Role.Name,
                    FailedLoginAttempts = u.FailedLoginAttempts,
                    Locked = u.Locked,
                    CreatedAt = u.CreatedAt,
                    UpdatedAt = u.UpdatedAt
                })
                .ToListAsync();
        }

        // Lấy người dùng theo ID, ánh xạ sang UserDto.
        public async Task<UserDto> GetUserById(long id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name,
                FailedLoginAttempts = user.FailedLoginAttempts,
                Locked = user.Locked,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        // Lấy người dùng theo ID (entity).
        public async Task<User> GetById(long id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // Lấy người dùng theo username (cho kiểm tra đăng nhập sai).
        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        // Tạo người dùng mới.
        public async Task<UserDto> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var createdUser = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            return new UserDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                FullName = createdUser.FullName,
                RoleId = createdUser.RoleId,
                RoleName = createdUser.Role?.Name,
                FailedLoginAttempts = createdUser.FailedLoginAttempts,
                Locked = createdUser.Locked,
                CreatedAt = createdUser.CreatedAt,
                UpdatedAt = createdUser.UpdatedAt
            };
        }

        // Cập nhật thông tin người dùng.
        public async System.Threading.Tasks.Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Xóa người dùng.
        public async System.Threading.Tasks.Task DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // Ghi nhật ký hành động vào bảng Logs.
        public async System.Threading.Tasks.Task LogAction(long userId, string action, string details)
        {
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
    }
}