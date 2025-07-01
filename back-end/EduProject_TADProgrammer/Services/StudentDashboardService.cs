using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class StudentDashboardService
    {
        private readonly ApplicationDbContext _context;

        public StudentDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy dữ liệu tổng quan cho dashboard
        public async Task<StudentDashboardDto> GetDashboardDataAsync(long studentId)
        {
            // Lấy danh sách đồ án của sinh viên
            var projects = await _context.GroupMembers
                .Include(gm => gm.Group)
                .ThenInclude(g => g.Project)
                .ThenInclude(p => p.Course)
                .Where(gm => gm.StudentId == studentId)
                .Select(gm => gm.Group.Project)
                .ToListAsync();

            // Tính tổng số bài nộp
            var submissions = await _context.Submissions
                .Where(s => s.GroupId != null)
                .ToListAsync();
            var totalSubmissions = submissions.Count(s => projects.Any(p => p.GroupId == s.GroupId));

            // Số bài nộp theo đồ án
            var submissionByProject = projects.GroupBy(p => p.ProjectCode)
                .ToDictionary(
                    g => g.Key,
                    g => submissions.Count(s => g.Any(p => p.GroupId == s.GroupId))
                );

            // Tiến độ đồ án
            var progressByProject = new Dictionary<string, int>();
            foreach (var group in projects.GroupBy(p => p.ProjectCode))
            {
                var projectId = group.First().Id;
                var doneTasks = await _context.Tasks
                    .Where(t => t.ProjectId == projectId && t.Status == "DONE")
                    .CountAsync();
                var totalTasks = await _context.Tasks
                    .Where(t => t.ProjectId == projectId)
                    .CountAsync();
                int progress = totalTasks > 0 ? (int)(doneTasks * 100.0 / totalTasks) : 0;
                progressByProject[group.Key] = progress;
            }

            // Số công việc chưa nộp
            var allTasks = await _context.Tasks
                .Where(t => t.Deadline >= DateTime.UtcNow)
                .ToListAsync();
            var pendingTasks = allTasks.Count(t => projects.Any(p => p.Id == t.ProjectId) &&
                                                 t.Deadline >= DateTime.UtcNow &&
                                                 t.Status != "DONE");

            // Số thông báo chưa đọc
            var unreadNotifications = await _context.Notifications
                .Where(n => n.UserId == studentId)
                .CountAsync();

            // Kiểm tra đề xuất đề tài (nếu có task với status TODO trong project đã đăng ký)
            var hasTodoProposal = allTasks.Any(t => projects.Any(p => p.Id == t.ProjectId) &&
                                                  t.Status == "TODO" &&
                                                  t.Title.Contains("Đăng ký đề tài"));

            return new StudentDashboardDto
            {
                TotalSubmissions = totalSubmissions,
                SubmissionByProject = submissionByProject,
                ProgressByProject = progressByProject,
                PendingTasks = pendingTasks,
                UnreadNotifications = unreadNotifications,
                HasTodoProposal = hasTodoProposal // Thêm thuộc tính mới
            };
        }

        // Lấy danh sách thông báo
        public async Task<IEnumerable<NotificationStudentDto>> GetNotificationsAsync(long studentId, int limit = 5)
        {
            return await _context.Notifications
                .Where(n => n.UserId == studentId)
                .OrderByDescending(n => n.CreatedAt)
                .Take(limit)
                .Select(n => new NotificationStudentDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    FullText = n.Content,
                    Date = n.CreatedAt
                })
                .ToListAsync();
        }

        // Lấy danh sách công việc
        public async Task<IEnumerable<TaskStudentDto>> GetTasksAsync(long studentId, string searchText = "", string status = "", int page = 1, int pageSize = 5)
        {
            var query = _context.Tasks
                .Include(t => t.Project)
                .ThenInclude(p => p.Course)
                .Where(t => _context.GroupMembers
                    .Any(gm => gm.StudentId == studentId && gm.GroupId == t.Project.GroupId));

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(t => t.Title.Contains(searchText));

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Chưa nộp")
                    query = query.Where(t => t.Status != "DONE" && t.Deadline >= DateTime.UtcNow);
                else if (status == "Đã nộp")
                    query = query.Where(t => t.Status == "DONE");
            }

            return await query
                .OrderBy(t => t.Deadline)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(t => new TaskStudentDto
                {
                    Id = t.Id,
                    Name = t.Title,
                    ProjectName = t.Project.ProjectCode,
                    Deadline = (DateTime)t.Deadline,
                    Status = t.Status == "DONE" ? "Đã nộp" : t.Deadline < DateTime.UtcNow ? "Hết hạn" : "Chưa nộp"
                })
                .ToListAsync();
        }

        // Lấy tổng số công việc
        public async Task<int> GetTasksCountAsync(long studentId, string searchText = "", string status = "")
        {
            var query = _context.Tasks
                .Where(t => _context.GroupMembers
                    .Any(gm => gm.StudentId == studentId && gm.GroupId == t.Project.GroupId));

            if (!string.IsNullOrEmpty(searchText))
                query = query.Where(t => t.Title.Contains(searchText));

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Chưa nộp")
                    query = query.Where(t => t.Status != "DONE" && t.Deadline >= DateTime.UtcNow);
                else if (status == "Đã nộp")
                    query = query.Where(t => t.Status == "DONE");
            }

            return await query.CountAsync();
        }

        // Lấy lịch cá nhân và nhóm
        public async Task<IEnumerable<CalendarStudentDto>> GetCalendarEventsAsync(long studentId)
        {
            return await _context.Calendars
                .Where(c => (c.UserId == studentId ||
                            _context.GroupMembers.Any(gm => gm.StudentId == studentId && gm.GroupId == c.GroupId)) &&
                            c.Status != "Cancelled")
                .OrderBy(c => c.StartTime)
                .Take(5)
                .Select(c => new CalendarStudentDto
                {
                    Id = c.Id,
                    EventTitle = c.EventTitle,
                    StartTime = c.StartTime,
                    Type = c.Type,
                    Status = c.Status
                })
                .ToListAsync();
        }
    }
}