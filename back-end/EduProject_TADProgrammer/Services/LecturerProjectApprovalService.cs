using DocumentFormat.OpenXml.InkML;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerProjectApprovalService
    {
        private readonly ApplicationDbContext _context;

        public LecturerProjectApprovalService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
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
            {
                throw new Exception("Reason is required for rejection.");
            }

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