using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerDashboardService
    {
        private readonly ApplicationDbContext _context;

        public LecturerDashboardService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Lấy thông tin tổng quan cho Giảng viên
        public async Task<LecturerDashboardDto> GetDashboardDataAsync(long lecturerId)
        {
            try
            {
                // Lấy danh sách đề tài do giảng viên hướng dẫn
                var projects = await _context.Projects
                    .Include(p => p.Group)
                    .Where(p => p.Group.LecturerId == lecturerId)
                    .ToListAsync();

                // Đếm tổng số đề tài
                var projectCount = projects.Count;

                // Đếm số đề tài đã duyệt (APPROVED hoặc GRADED)
                var approvedProjects = projects.Count(p => p.Status == "APPROVED");

                // Đếm số đề tài chờ duyệt (PENDING)
                var pendingProjects = projects.Count(p => p.Status == "PENDING");

                var notification = await _context.Notifications
                    .Where(n => n.UserId == lecturerId).ToArrayAsync();

                var notificationCount = notification.Count();

                // Lấy danh sách thông báo gần đây cho giảng viên
                var notifications = await _context.Notifications
                    .Where(n => n.UserId == lecturerId)
                    .OrderByDescending(n => n.CreatedAt)
                    .Take(5)
                    .Select(n => new NotificationDto
                    {
                        Id = n.Id,
                        UserId = n.UserId,
                        GroupId = n.GroupId,
                        Title = n.Title,
                        Content = n.Content,
                        Type = n.Type,
                        Status = n.Status,
                        CreatedAt = n.CreatedAt
                    })
                    .ToListAsync();

                return new LecturerDashboardDto
                {
                    ProjectCount = projectCount,
                    ApprovedProjects = approvedProjects,
                    PendingProjects = pendingProjects,
                    NotificationCount = notificationCount,
                    Notifications = notifications
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy dữ liệu tổng quan: {ex.Message}", ex);
            }
        }
    }
}