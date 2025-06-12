using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả log, ánh xạ sang định dạng cần thiết cho controller
        public async Task<List<LogDto>> GetAllLogs()
        {
            return await _context.Logs
                .Include(l => l.User)
                .ThenInclude(u => u.Role)
                .Select(log => new LogDto
                {
                    Id = log.Id,
                    UserId = log.User.Id,
                    FullName = log.User.FullName,
                    RoleName = log.User.Role.Name,
                    Action = log.Action,
                    Details = log.Details,
                    CreatedAt = log.CreatedAt
                })
                .ToListAsync();
        }

        // Lấy log theo ID, ánh xạ sang LogDto
        public async Task<LogDto> GetLogById(long id)
        {
            var log = await _context.Logs
                .Include(l => l.User)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(l => l.Id == id);
            if (log == null)
                return null;

            return new LogDto
            {
                Id = log.Id,
                UserId = log.UserId,
                FullName = log.User.FullName,
                Action = log.Action,
                Details = log.Details,
                CreatedAt = log.CreatedAt
            };
        }

        // Lấy log theo ID (entity)
        public async Task<Log> GetById(long id)
        {
            return await _context.Logs
                .Include(l => l.User)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        // Tạo log mới
        public async Task<LogDto> CreateLog(Log log)
        {
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            var createdLog = await _context.Logs
                .Include(l => l.User)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync(l => l.Id == log.Id);
            return new LogDto
            {
                Id = createdLog.Id,
                UserId = createdLog.UserId,
                Action = createdLog.Action,
                Details = createdLog.Details,
                CreatedAt = createdLog.CreatedAt
            };
        }

        // Cập nhật log
        public async System.Threading.Tasks.Task UpdateLog(Log log)
        {
            _context.Logs.Update(log);
            await _context.SaveChangesAsync();
        }

        // Xóa log
        public async System.Threading.Tasks.Task DeleteLog(long id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        // Lấy 5 log gần nhất
        public async Task<List<object>> GetRecentLogs()
        {
            return await _context.Logs
                .OrderByDescending(l => l.CreatedAt)
                .Take(5)
                .Select(l => new
                {
                    l.Id,
                    l.Details,
                    l.CreatedAt
                })
                .ToListAsync<object>();
        }

        // Lấy danh sách log để xuất Excel, với bộ lọc
        public async Task<List<LogDto>> GetLogsForExport(string search = "", string roleFilter = "", string actionFilter = "")
        {
            var query = _context.Logs
                .Include(l => l.User)
                .ThenInclude(u => u.Role)
                .Select(log => new LogDto
                {
                    Id = log.Id,
                    UserId = log.User.Id,
                    FullName = log.User.FullName,
                    RoleName = log.User.Role.Name,
                    Action = log.Action,
                    Details = log.Details,
                    CreatedAt = log.CreatedAt
                }).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(l =>
                    l.FullName.ToLower().Contains(search) ||
                    l.Action.ToLower().Contains(search) ||
                    l.Details.ToLower().Contains(search));
            }

            if (!string.IsNullOrEmpty(roleFilter))
            {
                query = query.Where(l => l.RoleName == roleFilter);
            }

            if (!string.IsNullOrEmpty(actionFilter))
            {
                query = query.Where(l => l.Action == actionFilter);
            }

            return await query.OrderBy(l => l.CreatedAt).ToListAsync();
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