using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerFeedbackService
    {
        private readonly ApplicationDbContext _context;

        public LecturerFeedbackService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách môn học cần phản hồi của giảng viên
        public async Task<IEnumerable<CourseLecturerFeedbackDto>> GetCoursesForFeedbackAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(c => c.Course.Department)
                .Include(lc => lc.Course.Projects)
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => new CourseLecturerFeedbackDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester.Name,
                    FacultyCode = lc.Course.Department.FacultyCode,
                    ProjectCount = lc.Course.Projects
                        .Count(p => p.Course.LecturerCourses.Any(lcp => lcp.LecturerId == lecturerId && lcp.Course.Department.FacultyCode == lc.Course.Department.FacultyCode))
                }).ToListAsync();
        }

        // Lấy danh sách đồ án cần phản hồi
        public async Task<IEnumerable<ProjectLecturerFeedbackDto>> GetProjectsForFeedbackAsync(long lecturerId, string courseId)
        {
            return await _context.Projects
                .Include(p => p.Course)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Course.LecturerCourses)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId && p.Course.CourseCode == courseId))
                .Select(p => new ProjectLecturerFeedbackDto
                {
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    GroupName = p.Group.Name,
                    Members = string.Join("\n", p.Group.GroupMembers.Select(gm => gm.Student.FullName)),
                    Status = p.Status
                }).ToListAsync();
        }

        // Lấy chi tiết đồ án và bài nộp
        public async Task<ProjectDetailLecturerFeedbackDto> GetProjectDetailAsync(long lecturerId, string projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Course)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Course.LecturerCourses)
                .Include(p => p.Submissions)
                .ThenInclude(s => s.Feedbacks)
                .ThenInclude(f => f.Lecturer)
                .Include(p => p.Submissions)
                .ThenInclude(s => s.Task)
                .Include(p => p.Submissions)
                .ThenInclude(s => s.Student)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new KeyNotFoundException("Không tìm thấy đồ án hoặc bạn không có quyền truy cập");

            // Nhóm Submissions theo TaskId
            var taskSubmissionGroups = project.Submissions
                .GroupBy(s => s.TaskId ?? 0) // TaskId có thể null, gán 0 cho các Submission không có Task
                .Select(g => new TaskSubmissionGroupLecturerFeedbackDto
                {
                    TaskId = g.Key,
                    TaskTitle = g.Key == 0 ? "Không thuộc nhiệm vụ cụ thể" : g.First().Task?.Title ?? "Nhiệm vụ không xác định",
                    TaskDescription = g.Key == 0 ? "" : g.First().Task?.Description ?? "Không có mô tả",
                    Submissions = g.Select(s => new SubmissionLecturerFeedbackDto
                    {
                        SubmissionId = s.Id,
                        FileName = s.FilePath,
                        Title = s.Task?.Title ?? "Không có tiêu đề",
                        SubmittedBy = s.Student?.FullName ?? "Không xác định",
                        SubmittedAt = s.SubmittedAt.ToString("dd/MM/yyyy"),
                        Description = s.Task?.Description ?? "Không có mô tả",
                        Feedback = s.Feedbacks.FirstOrDefault(f => f.LecturerId == lecturerId)?.Content ?? ""
                    }).ToList()
                }).ToList();

            return new ProjectDetailLecturerFeedbackDto
            {
                ProjectId = project.ProjectCode,
                Name = project.Title,
                CourseId = project.Course.CourseCode,
                GroupName = project.Group.Name,
                GroupLeader = project.Group.GroupMembers.FirstOrDefault(gm => gm.IsLeader)?.Student.FullName ?? "Chưa có nhóm trưởng",
                GroupMembers = string.Join(", ", project.Group.GroupMembers.Select(gm => gm.Student.FullName)),
                Status = project.Status,
                TaskSubmissionGroups = taskSubmissionGroups
            };
        }

        // Lưu phản hồi cho bài nộp
        public async System.Threading.Tasks.Task SaveFeedbackAsync(long lecturerId, string projectId, List<LecturerFeedbackDto> feedbackDtos)
        {
            var project = await _context.Projects
                .Include(p => p.Course.LecturerCourses)
                .Include(p => p.Submissions)
                .ThenInclude(s => s.Feedbacks)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new KeyNotFoundException("Không tìm thấy đồ án hoặc bạn không có quyền truy cập");

            foreach (var feedbackDto in feedbackDtos)
            {
                var submission = project.Submissions.FirstOrDefault(s => s.Id == feedbackDto.SubmissionId);
                if (submission == null)
                    continue;

                var existingFeedback = submission.Feedbacks.FirstOrDefault(f => f.LecturerId == lecturerId);
                if (existingFeedback != null)
                {
                    existingFeedback.Content = feedbackDto.Content?.Trim();
                    existingFeedback.CreatedAt = DateTime.UtcNow;
                }
                else if (!string.IsNullOrEmpty(feedbackDto.Content))
                {
                    submission.Feedbacks.Add(new Feedback
                    {
                        SubmissionId = submission.Id,
                        LecturerId = lecturerId,
                        Content = feedbackDto.Content.Trim(),
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}