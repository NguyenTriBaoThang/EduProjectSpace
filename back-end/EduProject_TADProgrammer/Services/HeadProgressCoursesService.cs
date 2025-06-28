using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class HeadProgressCoursesService
    {
        private readonly ApplicationDbContext _context;

        public HeadProgressCoursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeadProgressCourseDto>> GetProgressCoursesAsync(long headLecturerName)
        {
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headLecturerName);

            if (headLecturer == null) return new List<HeadProgressCourseDto>();

            var courses = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Semester)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Group)
                    .ThenInclude(g => g.Lecturer)
                .Include(c => c.Department)
                .Where(c => c.DepartmentId == headLecturer.DepartmentId)
                .Select(c => new HeadProgressCourseDto
                {
                    CourseId = c.CourseCode,
                    Name = c.Name,
                    Semester = c.Semester.Name,
                    Head = c.Projects.Any() ? c.Projects.First().Group.Lecturer.FullName : "Chưa phân công",
                    FacultyCode = c.Department.FacultyCode ?? "Không xác định",
                    GroupCount = c.Projects != null ? c.Projects.Count(p => p.Group != null) : 0,
                    CompletedCount = c.Projects != null ? c.Projects.Count(p => p.Group != null && p.Group.Status == "Hoàn thành") : 0
                })
                .ToListAsync();

            return courses;
        }

        public async Task<List<HeadProgressCourseGroupDto>> GetProgressGroupsAsync(string courseId, string semester, string facultyCode)
        {
            var groups = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Group)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Where(g => g.Project.Course.CourseCode == courseId &&
                            g.Project.Course.Semester.Name == semester &&
                            g.Project.Course.Department.FacultyCode == facultyCode)
                .Select(g => new HeadProgressCourseGroupDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    ProjectId = g.Project.ProjectCode,
                    ProjectName = g.Project.Title,
                    Members = string.Join(", ", g.GroupMembers.Select(gm => gm.Student.FullName)),
                    Lecturer = g.Lecturer != null ? g.Lecturer.FullName : "Chưa xác định",
                    Status = g.Status ?? "Chưa xác định"
                })
                .ToListAsync();

            return groups ?? new List<HeadProgressCourseGroupDto>();
        }

        public async Task<HeadProgressCourseDetailDto> GetProgressDetailsAsync(string courseId, string semester, string facultyCode, long groupId)
        {
            var group = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Include(g => g.Lecturer)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Tasks)
                        .ThenInclude(t => t.Submissions)
                            .ThenInclude(s => s.Student) // Include Student for User details
                .FirstOrDefaultAsync(g => g.Id == groupId &&
                                          g.Project.Course.CourseCode == courseId &&
                                          g.Project.Course.Semester.Name == semester &&
                                          g.Project.Course.Department.FacultyCode == facultyCode);

            if (group == null) return null;

            var tasks = group.Project.Tasks?.OrderBy(t => t.CreatedAt).ToList() ?? new List<Entities.Task>();

            var progressPhases = new List<HeadProgressCoursePhase>();
            foreach (var task in tasks)
            {
                // Get all submissions for the task
                var submissions = task.Submissions?.ToList() ?? new List<Submission>();

                var phase = new HeadProgressCoursePhase
                {
                    Phase = task.Title,
                    Description = task.Description ?? "Chưa có mô tả",
                    Files = submissions.Select(s => new FileSubmission
                    {
                        FilePath = s.FilePath,
                        StudentCode = s.Student?.Username ?? "Unknown",
                        FullName = s.Student?.FullName ?? "Unknown"
                    }).ToList(),
                    Date = submissions.Any() ? submissions.Max(s => s.SubmittedAt).ToString("dd/MM/yyyy") : "Chưa nộp",
                    Deadline = task.Deadline?.ToString("dd/MM/yyyy") ?? "Không có hạn"
                };
                progressPhases.Add(phase);
            }

            return new HeadProgressCourseDetailDto
            {
                GroupId = group.Id,
                GroupName = group.Name,
                ProjectId = group.Project.ProjectCode,
                ProjectName = group.Project.Title,
                Members = string.Join(", ", group.GroupMembers.Select(gm => gm.Student.FullName)),
                Lecturer = group.Lecturer?.FullName ?? "Chưa xác định",
                Status = group.Status ?? "Chưa xác định",
                Phases = progressPhases
            };
        }

        private int GetWeekNumber(DateTime date)
        {
            return (date.DayOfYear / 7) + 1;
        }
    }
}