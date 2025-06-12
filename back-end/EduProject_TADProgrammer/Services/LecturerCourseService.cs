using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Models;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerCourseService
    {
        private readonly ApplicationDbContext _context;

        public LecturerCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách môn học của giảng viên
        public async Task<List<LecturerCourseDto>> GetAllCourses(long lecturerId)
        {
            return await _context.LecturerCourses
                .Where(lc => lc.LecturerId == lecturerId)
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(lc => lc.Course.Department)
                .Include(lc => lc.Course.Projects)
                .Select(lc => new LecturerCourseDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester.Name,
                    FacultyCode = lc.Course.Department != null ? lc.Course.Department.FacultyCode : "N/A",
                    ProjectCount = lc.Course.Projects.Count
                })
                .ToListAsync();
        }

        // Lấy danh sách môn học để xuất Excel
        public async Task<List<LecturerCourseDto>> GetAllCoursesForExport(long lecturerId)
        {
            return await GetAllCourses(lecturerId);
        }

        // Ghi nhật ký hành động
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

        // Lấy danh sách đồ án theo giảng viên và mã môn học
        public async Task<List<ProjectLecturerCourseDto>> GetProjects(long lecturerId, string courseId = null)
        {
            var query = _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (!string.IsNullOrEmpty(courseId))
                query = query.Where(p => p.Course.CourseCode == courseId);

            return await query.Select(p => new ProjectLecturerCourseDto
            {
                Id = p.Id,
                CourseId = p.Course.CourseCode,
                ProjectId = p.ProjectCode,
                Name = p.Title,
                GroupId = p.GroupId,
                GroupName = p.Group.Name,
                LecturerName = p.Course.LecturerCourses
                    .FirstOrDefault(lc => lc.LecturerId == lecturerId).Lecturer.FullName,
                Status = p.Status,
                Students = p.Group.GroupMembers.Select(gm => new StudentLecturerCourseDto
                {
                    Id = gm.StudentId,
                    Username = gm.Student.Username,
                    FullName = gm.Student.FullName,
                    IsLeader = gm.IsLeader
                }).ToList()
            }).ToListAsync();
        }

        // Lấy chi tiết đồ án
        public async Task<ProjectLecturerCourseDto> GetProjectDetails(string projectId, long lecturerId)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .ThenInclude(lc => lc.Lecturer)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId);

            if (project == null)
                throw new Exception("Không tìm thấy đồ án");

            if (!project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new Exception("Không có quyền truy cập đồ án này");

            return new ProjectLecturerCourseDto
            {
                Id = project.Id,
                CourseId = project.Course.CourseCode,
                ProjectId = project.ProjectCode,
                Name = project.Title,
                GroupId = project.GroupId,
                GroupName = project.Group.Name,
                LecturerName = project.Course.LecturerCourses
                    .FirstOrDefault(lc => lc.LecturerId == lecturerId).Lecturer.FullName,
                Status = project.Status,
                Students = project.Group.GroupMembers.Select(gm => new StudentLecturerCourseDto
                {
                    Id = gm.StudentId,
                    Username = gm.Student.Username,
                    FullName = gm.Student.FullName,
                    IsLeader = gm.IsLeader
                }).ToList()
            };
        }

        // Lấy danh sách nhiệm vụ của đồ án
        public async Task<List<LecturerCoursesTaskDto>> GetProjectTasks(string projectId, long lecturerId)
        {
            var project = await _context.Projects
                .Include(p => p.Course.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId);

            if (project == null)
                throw new Exception("Không tìm thấy đồ án");

            if (!project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new Exception("Không có quyền truy cập đồ án này");

            var tasks = await _context.Tasks
                .Include(t => t.Submissions)
                .ThenInclude(s => s.Feedbacks)
                .Include(t => t.Submissions)
                .ThenInclude(s => s.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Where(t => t.ProjectId == project.Id)
                .ToListAsync();

            return tasks.Select(t => new LecturerCoursesTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Deadline = t.Deadline,
                Status = t.Status,
                Feedback = t.Submissions.SelectMany(s => s.Feedbacks)
                    .FirstOrDefault() != null
                    ? t.Submissions.SelectMany(s => s.Feedbacks).FirstOrDefault().Content
                    : "",
                Submissions = t.Submissions.Select(s => new SubmissionLecturerCourseDto
                {
                    Id = s.Id,
                    FilePath = s.FilePath,
                    SubmittedBy = s.Group.GroupMembers.FirstOrDefault(gm => gm.IsLeader) != null
                        ? s.Group.GroupMembers.FirstOrDefault(gm => gm.IsLeader).Student.Username
                        : "Unknown"
                }).ToList()
            }).ToList();
        }

        // Cập nhật phản hồi cho nhiệm vụ
        public async System.Threading.Tasks.Task UpdateFeedback(string projectId, long taskId, string feedback, long lecturerId)
        {
            var task = await _context.Tasks
                .Include(t => t.Submissions)
                .FirstOrDefaultAsync(t => t.Id == taskId && t.Project.ProjectCode == projectId);

            if (task == null)
                throw new Exception("Không tìm thấy nhiệm vụ");

            var project = await _context.Projects
                .Include(p => p.Course.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId);

            if (!project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new Exception("Không có quyền cập nhật");

            var submission = task.Submissions.FirstOrDefault();
            if (submission != null)
            {
                var existingFeedback = await _context.Feedbacks
                    .FirstOrDefaultAsync(f => f.SubmissionId == submission.Id);

                if (existingFeedback != null)
                {
                    existingFeedback.Content = feedback;
                    _context.Feedbacks.Update(existingFeedback);
                }
                else
                {
                    var newFeedback = new Feedback
                    {
                        SubmissionId = submission.Id,
                        LecturerId = lecturerId,
                        Content = feedback,
                        CreatedAt = DateTime.UtcNow
                    };
                    _context.Feedbacks.Add(newFeedback);
                }
            }

            await _context.SaveChangesAsync();
            await LogAction(lecturerId, "UPDATE_FEEDBACK", $"Cập nhật phản hồi cho nhiệm vụ {taskId} của đồ án {projectId}");
        }

        // Cập nhật nhiệm vụ
        public async System.Threading.Tasks.Task UpdateTask(string projectId, long taskId, LecturerCoursesTaskDto taskDto, long lecturerId)
        {
            var task = await _context.Tasks
                .Include(t => t.Submissions)
                .FirstOrDefaultAsync(t => t.Id == taskId && t.Project.ProjectCode == projectId);

            if (task == null)
                throw new Exception("Không tìm thấy nhiệm vụ");

            var project = await _context.Projects
                .Include(p => p.Course.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId);

            if (!project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new Exception("Không có quyền cập nhật");

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Deadline = taskDto.Deadline;
            task.Status = taskDto.Status;

            // Xóa submissions cũ
            _context.Submissions.RemoveRange(task.Submissions);

            // Thêm submissions mới
            task.Submissions = taskDto.Submissions
                .Where(s => !string.IsNullOrEmpty(s.FilePath) && !string.IsNullOrEmpty(s.SubmittedBy))
                .Select(s => new Submission
                {
                    ProjectId = project.Id,
                    GroupId = project.GroupId,
                    TaskId = task.Id,
                    FilePath = s.FilePath,
                    Version = 1,
                    Status = "Submitted",
                    SubmittedAt = DateTime.UtcNow
                }).ToList();

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            await LogAction(lecturerId, "UPDATE_TASK", $"Cập nhật nhiệm vụ {taskId} của đồ án {projectId}");
        }
    }
}