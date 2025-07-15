using DocumentFormat.OpenXml.InkML;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerProjectApprovalService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LecturerProjectApprovalService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<LecturerProjectApprovalDto>> GetCoursesForLecturerAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Projects)
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => new LecturerProjectApprovalDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester != null ? lc.Course.Semester.Name : "Chưa xác định",
                    FacultyCode = lc.Course.Department.FacultyCode,
                    ProposalCount = lc.Course.Projects.Count
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectLecturerProjectApprovalDto>> GetCoursesForApproval(long lecturerId, string courseId)
        {
            return await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.Submissions)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId) &&
                            p.Course.CourseCode == courseId)
                .Select(p => new ProjectLecturerProjectApprovalDto
                {
                    Id = p.Id,
                    CourseId = p.Course.CourseCode,
                    Semester = p.Course.Semester != null ? p.Course.Semester.Name : "Chưa xác định",
                    FacultyCode = p.Course.Department.FacultyCode,
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    GroupId = p.GroupId,
                    GroupName = p.Group != null ? p.Group.Name : "Chưa có nhóm",
                    LecturerName = p.Course.LecturerCourses
                        .Where(lc => lc.LecturerId == lecturerId)
                        .Select(lc => lc.Lecturer.FullName)
                        .FirstOrDefault() ?? "Chưa xác định",
                    Description = p.Description ?? "Chưa có",
                    DescriptionFilePath = p.Tasks.FirstOrDefault(t => t.Title == "Đăng ký đề tài") != null
                        ? p.Tasks.FirstOrDefault(t => t.Title == "Đăng ký đề tài").Submissions
                            .Select(s => s.FilePath).ToList()
                        : new List<string>(),
                    ApprovalStatus = p.ApprovalStatus,
                    ApprovalReason = p.ApprovalReason ?? "",
                    Students = p.Group != null && p.Group.GroupMembers.Any()
                        ? p.Group.GroupMembers.Select(gm => new StudentLecturerProjectApprovalDto
                        {
                            Id = gm.StudentId,
                            Username = gm.Student.Username,
                            FullName = gm.Student.FullName,
                            IsLeader = gm.IsLeader
                        }).ToList()
                        : new List<StudentLecturerProjectApprovalDto>()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectLecturerProjectApprovalDto>> GetProjectsForApproval(long lecturerId, string projectId)
        {
            return await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.Submissions)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId) &&
                            p.ProjectCode == projectId)
                .Select(p => new ProjectLecturerProjectApprovalDto
                {
                    Id = p.Id,
                    CourseId = p.Course.CourseCode,
                    Semester = p.Course.Semester != null ? p.Course.Semester.Name : "Chưa xác định",
                    FacultyCode = p.Course.Department.FacultyCode,
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    GroupId = p.GroupId,
                    GroupName = p.Group != null ? p.Group.Name : "Chưa có nhóm",
                    LecturerName = p.Course.LecturerCourses
                        .Where(lc => lc.LecturerId == lecturerId)
                        .Select(lc => lc.Lecturer.FullName)
                        .FirstOrDefault() ?? "Chưa xác định",
                    Description = p.Description ?? "Chưa có",
                    DescriptionFilePath = p.Tasks.FirstOrDefault(t => t.Title == "Đăng ký đề tài") != null
                        ? p.Tasks.FirstOrDefault(t => t.Title == "Đăng ký đề tài").Submissions
                            .Select(s => s.FilePath).ToList()
                        : new List<string>(),
                    ApprovalStatus = p.ApprovalStatus,
                    ApprovalReason = p.ApprovalReason ?? "",
                    Students = p.Group != null && p.Group.GroupMembers.Any()
                        ? p.Group.GroupMembers.Select(gm => new StudentLecturerProjectApprovalDto
                        {
                            Id = gm.StudentId,
                            Username = gm.Student.Username,
                            FullName = gm.Student.FullName,
                            IsLeader = gm.IsLeader
                        }).ToList()
                        : new List<StudentLecturerProjectApprovalDto>()
                })
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateApprovalStatus(string projectId, long lecturerId, string approvalStatus, string approvalReason)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Course)
                .ThenInclude(c => c.Semester)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId &&
                                         p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new Exception("Project not found or not authorized.");

            // Check if group has members
            if (project.Group == null || !project.Group.GroupMembers.Any())
                throw new Exception("Cannot approve or reject project: Group has no members.");

            if (approvalStatus == "REJECTED" && string.IsNullOrEmpty(approvalReason))
                throw new Exception("Reason is required for rejection.");

            if (!new[] { "PENDING", "APPROVED", "REJECTED" }.Contains(approvalStatus))
                throw new Exception("Invalid approval status.");

            // Update ProjectCode if APPROVED
            if (approvalStatus == "APPROVED")
            {
                string newProjectCode = await GenerateProjectCode(project.Title, project.Course.Semester?.Name);
                project.ProjectCode = newProjectCode;
            }

            project.ApprovalStatus = approvalStatus;
            project.ApprovalReason = approvalStatus == "REJECTED" ? approvalReason : null;

            await _context.SaveChangesAsync();

            // Send email notification to all students in the group
            foreach (var member in project.Group.GroupMembers)
            {
                var student = member.Student;
                if (student != null && !string.IsNullOrEmpty(student.Email))
                {
                    await SendApprovalEmail(student, project, approvalStatus, approvalReason);
                }
            }
        }

        private async System.Threading.Tasks.Task SendApprovalEmail(User student, Project project, string approvalStatus, string approvalReason)
        {
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUsername = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Load Semester if not already loaded
            if (project.Course.Semester == null)
            {
                project.Course = await _context.Courses
                    .Include(c => c.Semester)
                    .FirstOrDefaultAsync(c => c.Id == project.Course.Id) ?? project.Course;
            }

            var semesterName = project.Course.Semester?.Name ?? "Chưa xác định";
            var statusText = approvalStatus == "APPROVED" ? "Đã duyệt" : "Bị từ chối";
            var reasonText = approvalStatus == "REJECTED" ? $"<p><strong>Lý do từ chối:</strong> {approvalReason}</p>" : "";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                Subject = $"Thông báo trạng thái duyệt đề tài {project.Title}",
                Body = $@"
                    <h3>Thông báo trạng thái duyệt đề tài</h3>
                    <p>Xin chào {student.FullName},</p>
                    <p>Đề tài <strong>{project.Title}</strong> (Mã đề tài: {project.ProjectCode}, Môn học: {project.Course.Name}, Học kỳ: {semesterName}) đã được Giảng viên hướng dẫn xem xét.</p>
                    <p><strong>Trạng thái:</strong> {statusText}</p>
                    {reasonText}
                    <p>Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm} (Giờ Việt Nam)</p>
                    <p>Vui lòng kiểm tra hệ thống để biết thêm chi tiết hoặc liên hệ Giảng viên hướng dẫn nếu có thắc mắc.</p>
                    <p>Trân trọng,<br>Hệ thống Sinh viên HUTECH - Team TAD Programmer</p>",
                IsBodyHtml = true
            };
            mailMessage.To.Add(student.Email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email cho {student.Email}: {ex.Message}");
            }
        }

        private async Task<string> GenerateProjectCode(string title, string semester)
        {
            // Abbreviate title: Take first letter of each word, remove diacritics, max 10 chars
            string normalizedTitle = RemoveDiacritics(title.ToUpper());
            string[] words = normalizedTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string abbreviation = string.Concat(words.Select(word => word[0])).Substring(0, Math.Min(10, string.Concat(words.Select(word => word[0])).Length));

            // Use semester (e.g., HK2_2025) or fallback
            string semesterCode = semester != null ? semester.Replace(" ", "_") : "UNKNOWN";

            string baseCode = $"{abbreviation}_{semesterCode}";
            string newCode = baseCode;
            int counter = 1;

            // Ensure uniqueness
            while (await _context.Projects.AnyAsync(p => p.ProjectCode == newCode))
            {
                newCode = $"{baseCode}_{counter++}";
            }

            return newCode;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            string normalized = text.Normalize(NormalizationForm.FormD);
            var regex = new Regex("\\p{IsCombiningDiacriticalMarks}");
            string withoutDiacritics = regex.Replace(normalized, string.Empty);
            return withoutDiacritics.Normalize(NormalizationForm.FormC)
                .Replace("Đ", "D").Replace("đ", "d");
        }
    }
}