// File: Services/ProgressCoursesService.cs
// Mục đích: Cung cấp logic nghiệp vụ để lấy danh sách môn học cần theo dõi tiến độ từ cơ sở dữ liệu.
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

        // Constructor: Khởi tạo service với DbContext
        public HeadProgressCoursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hàm lấy danh sách môn học cần theo dõi tiến độ của trưởng bộ môn
        public async Task<List<HeadProgressCourseDto>> GetProgressCoursesAsync(long headLecturerName)
        {
            // Tìm trưởng bộ môn dựa trên tên và vai trò
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headLecturerName);

            if (headLecturer == null) return new List<HeadProgressCourseDto>();

            // Truy vấn danh sách môn học do trưởng bộ môn phụ trách
            // Include Project và Groups thông qua Project
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
                    GroupCount = c.Projects != null
                        ? c.Projects.Count(p => p.Group != null)
                        : 0,
                    CompletedCount = c.Projects != null
                        ? c.Projects.Count(p => p.Group != null && p.Group.Status == "Hoàn thành")
                        : 0
                })
                .ToListAsync();

            return courses;
        }

        // Hàm lấy danh sách tiến độ nhóm theo courseId, semester, và classId
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

        public async Task<HeadProgressCourseDetailDTO> GetProgressDetailsAsync(string courseId, string semester, string facultyCode, long groupId)
        {
            // Query the group with related data, including the ClassCode filter
            var group = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Include(g => g.Lecturer)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Submissions)
                        .ThenInclude(s => s.Feedbacks)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Grades)
                        .ThenInclude(g => g.Criteria)
                .FirstOrDefaultAsync(g => g.Id == groupId &&
                                          g.Project.Course.CourseCode == courseId &&
                                          g.Project.Course.Semester.Name == semester &&
                                          g.Project.Course.Department.FacultyCode == facultyCode);

            if (group == null) return null;

            // Ensure submissions and grades are not null
            var submissions = group.Project.Submissions?.OrderBy(s => s.SubmittedAt).ToList() ?? new List<Submission>();
            var grades = group.Project.Grades?.ToList() ?? new List<Grade>();

            var progressPhases = new List<HeadProgressCoursePhase>();
            foreach (var submission in submissions)
            {
                // Find the grade associated with this submission (if any)
                // Note: Since Grade does not have a direct SubmissionId in the schema, we assume a matching logic
                // This might need adjustment based on your actual database relationships
                var matchingGrade = grades.FirstOrDefault(g => g.ProjectId == submission.ProjectId && g.Id == submission.Id);

                var phase = new HeadProgressCoursePhase
                {
                    Phase = $"Tuần {GetWeekNumber(submission.SubmittedAt)}",
                    Description = submission.Feedbacks?.FirstOrDefault()?.Content ?? "Chưa có mô tả",
                    Files = new List<string> { submission.FilePath },
                    Date = submission.SubmittedAt.ToString("dd/MM/yyyy"),
                    Deadline = submission.SubmittedAt.AddDays(7).ToString("dd/MM/yyyy"), // Replace with actual deadline logic
                    Score = matchingGrade != null ? matchingGrade.Score.ToString("F1") : "Chưa chấm"
                };
                progressPhases.Add(phase);
            }

            return new HeadProgressCourseDetailDTO
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
            // Logic đơn giản để lấy số tuần (có thể thay bằng thư viện thực tế)
            return (date.DayOfYear / 7) + 1;
        }
    }
}