using EduProject_TADProgrammer.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminDashboardService
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetDashboardSummary()
        {
            var studentCount = await _context.Users
                .Include(u => u.Role)
                .CountAsync(u => u.Role != null && u.Role.Name == "ROLE_STUDENT");
            var submittedProjects = await _context.Projects
                .CountAsync(p => p.Status == "SUBMITTED");
            var pendingTopics = await _context.Projects
                .CountAsync(p => p.Status == "PENDING");
            var recentNotifications = await _context.Notifications
                .CountAsync(n => n.CreatedAt >= System.DateTime.UtcNow.AddDays(-7));

            return new
            {
                studentCount,
                submittedProjects,
                pendingTopics,
                recentNotifications
            };
        }

        public async Task<object> GetProjectStatus()
        {
            var notSubmitted = await _context.Projects
                .CountAsync(p => p.Status == "NOT_SUBMITTED");
            var submitted = await _context.Projects
                .CountAsync(p => p.Status == "SUBMITTED");
            var graded = await _context.Projects
                .CountAsync(p => p.Status == "GRADED");

            return new
            {
                notSubmitted,
                submitted,
                graded
            };
        }
    }
}