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
            var projects = _context.Projects.Where(p => _context.Users.Any(u => u.Id == userId && u.DepartmentId != null && u.DepartmentId == p.Course.DepartmentId));
            var projectCount = await projects.CountAsync();
            var approvedProjects = await projects.CountAsync(p => p.ApprovalStatus == "APPROVED");
            var pendingProjects = await projects.CountAsync(p => p.ApprovalStatus == "PENDING");

            return new
            {
                ProjectCount = projectCount,
                ApprovedProjects = approvedProjects,
                PendingProjects = pendingProjects,
            };
        }
    }
}