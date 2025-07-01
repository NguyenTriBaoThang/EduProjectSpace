using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
 
    public class LecturerTaskService 
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LecturerTaskService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Lấy danh sách công việc của giảng viên
        public async Task<IEnumerable<LecturerTaskDto>> GetTasksForLecturerAsync(long lecturerId, string? courseId, string? projectId, string? semester, string? status)
        {
            var query = _context.Tasks
                .Include(t => t.Project)
                .ThenInclude(p => p.Course)
                .ThenInclude(c => c.Semester)
                .Include(t => t.Project.Course.LecturerCourses)
                .Where(t => t.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            // Lọc theo courseId
            if (!string.IsNullOrEmpty(courseId))
                query = query.Where(t => t.Project.Course.CourseCode == courseId);

            // Lọc theo projectId
            if (!string.IsNullOrEmpty(projectId))
                query = query.Where(t => t.Project.ProjectCode == projectId);

            // Lọc theo semester
            if (!string.IsNullOrEmpty(semester))
                query = query.Where(t => t.Project.Course.Semester.Name == semester);

            // Lọc theo status
            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Quá hạn")
                    query = query.Where(t => t.Deadline < DateTime.UtcNow && t.Status != "DONE");
                else
                    query = query.Where(t => t.Status == (status == "Đã hoàn thành" ? "DONE" : "IN_PROGRESS"));
            }

            // Chuyển thành TaskDto
            return await query.Select(t => new LecturerTaskDto
            {
                Id = t.Id,
                CourseId = t.Project.Course.CourseCode,
                ProjectId = t.Project.ProjectCode,
                TaskDescription = t.Title,
                Semester = t.Project.Course.Semester.Name,
                StartDate = t.CreatedAt,
                DueDate = t.Deadline,
                Status = t.Status == "DONE" ? "Đã hoàn thành" : t.Deadline < DateTime.UtcNow ? "Quá hạn" : "Chưa hoàn thành"
            }).ToListAsync();
        }

        // Lấy danh sách học kỳ của giảng viên
        public async Task<IEnumerable<string>> GetSemestersForLecturerAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => lc.Course.Semester.Name)
                .Distinct()
                .ToListAsync();
        }

        // Thêm công việc mới
        public async Task<LecturerTaskDto> AddTaskAsync(long lecturerId, CreateLecturerTaskDto createTaskDto)
        {
            // Kiểm tra dự án thuộc giảng viên
            var project = await _context.Projects
                .Include(t => t.Course)
                .ThenInclude(p => p.LecturerCourses)
                .Include(lc => lc.Course.Department)
                .Include(p => p.Group) // Đảm bảo tải Group
                .ThenInclude(g => g.GroupMembers) // Tải GroupMembers
                .ThenInclude(gm => gm.Student) // Tải Student trong GroupMember
                .FirstOrDefaultAsync(p => p.ProjectCode == createTaskDto.ProjectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new KeyNotFoundException("Dự án không tồn tại hoặc không thuộc giảng viên");

            // Tạo công việc mới
            var task = new Entities.Task
            {
                ProjectId = project.Id,
                GroupId = project.GroupId,
                Title = createTaskDto.TaskDescription,
                Description = createTaskDto.TaskDescription,
                CreatedAt = DateTime.UtcNow,
                Deadline = createTaskDto.DueDate,
                Status = "TODO"
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Gửi email thông báo cho sinh viên trong nhóm qua GroupMember
            await SendEmailToStudents(project.Group.GroupMembers.Select(gm => gm.Student).ToList(), task);

            // Trả về TaskDto
            return new LecturerTaskDto
            {
                Id = task.Id,
                CourseId = project.Course.CourseCode,
                ProjectId = project.ProjectCode,
                TaskDescription = task.Title,
                Semester = project.Course?.Semester?.Name ?? "Không rõ học kỳ",
                StartDate = task.CreatedAt,
                DueDate = task.Deadline,
                Status = "Chưa hoàn thành"
            };
        }

        // Phương thức gửi email
        private async System.Threading.Tasks.Task SendEmailToStudents(ICollection<User> students, Entities.Task task)
        {
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUsername = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
            };

            var course = await _context.Courses
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(c => c.Id == task.Project.CourseId);

            foreach (var student in students)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                    Subject = $"Thông báo: Công việc mới cho đồ án {task.Project.ProjectCode}",
                    Body = $@"
                        <h3>Thông báo từ HUTECH EduProject</h3>
                        <p>Xin chào {student.FullName},</p>
                        <p>Một công việc mới đã được giao cho nhóm của bạn trong môn học <strong>{course.Name}</strong> (Học kỳ: {course.Semester.Name}):</p>
                        <ul>
                            <li><strong>Công việc:</strong> {task.Title}</li>
                            <li><strong>Thời gian bắt đầu:</strong> {task.CreatedAt:dd/MM/yyyy}</li>
                            <li><strong>Thời hạn:</strong> {task.Deadline:dd/MM/yyyy}</li>
                        </ul>
                        <p>Vui lòng hoàn thành đúng hạn. Liên hệ giảng viên hướng dẫn nếu cần hỗ trợ!</p>
                        <p>Trân trọng,<br>Đội ngũ HUTECH EduProject</p>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(student.Email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        // Cập nhật công việc
        public async System.Threading.Tasks.Task UpdateTaskAsync(long lecturerId, long taskId, UpdateLecturerTaskDto updateTaskDto)
        {
            // Tìm công việc
            var task = await _context.Tasks
                .Include(t => t.Project)
                .ThenInclude(t => t.Course)
                .ThenInclude(p => p.LecturerCourses)
                .FirstOrDefaultAsync(t => t.Id == taskId && t.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (task == null)
                throw new KeyNotFoundException("Công việc không tồn tại hoặc không thuộc giảng viên");

            // Cập nhật thông tin
            task.Title = updateTaskDto.TaskDescription;
            task.Deadline = updateTaskDto.DueDate;
            task.Status = updateTaskDto.Status == "Đã hoàn thành" ? "Done" : "Todo";

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        // Xóa công việc
        public async System.Threading.Tasks.Task DeleteTaskAsync(long lecturerId, long taskId)
        {
            // Tìm công việc
            var task = await _context.Tasks
                .Include(t => t.Project)
                .ThenInclude(t => t.Course)
                .ThenInclude(p => p.LecturerCourses)
                .FirstOrDefaultAsync(t => t.Id == taskId && t.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (task == null)
                throw new KeyNotFoundException("Công việc không tồn tại hoặc không thuộc giảng viên");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}