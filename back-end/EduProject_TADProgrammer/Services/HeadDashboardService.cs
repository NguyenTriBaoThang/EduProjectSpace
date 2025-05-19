using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class HeadDashboardService
    {
        private readonly ApplicationDbContext _context;

        public HeadDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tổng quan số liệu
        public async Task<object> GetDashboardSummary(long userId)
        {
            var now = DateTime.UtcNow; // 06:00 PM +07, Sunday, May 18, 2025

            // Đếm số đề tài đã có giáo viên hướng dẫn (ROLE_LECTURER_GUIDE)
            var projectCount = await _context.Projects
                .Include(p => p.Group.Lecturer)
                .CountAsync(p => p.Group.Lecturer != null && p.Group.Lecturer.Role.Name == "ROLE_LECTURER_GUIDE");

            // Đếm số đề tài đã có giáo viên hướng dẫn và đã được duyệt
            var approvedProjects = await _context.Projects
                .Include(p => p.Group.Lecturer)
                .CountAsync(p => p.Group.Lecturer != null && p.Group.Lecturer.Role.Name == "ROLE_LECTURER_GUIDE" &&
                               (p.Status == "APPROVED" || p.Status == "GRADED"));

            // Đếm số đề tài đã có giáo viên hướng dẫn nhưng chưa được duyệt
            var pendingProjects = await _context.Projects
                .Include(p => p.Group.Lecturer)
                .CountAsync(p => p.Group.Lecturer != null && p.Group.Lecturer.Role.Name == "ROLE_LECTURER_GUIDE" &&
                               p.Status == "PENDING");

            return new
            {
                ProjectCount = projectCount,
                ApprovedProjects = approvedProjects,
                PendingProjects = pendingProjects,
            };
        }
    }
}