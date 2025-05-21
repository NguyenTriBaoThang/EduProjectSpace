// File: Services/HeadCourseGradingService.cs
// Mục đích: Cung cấp logic nghiệp vụ để lấy danh sách môn học cần duyệt chấm điểm.
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class HeadCourseGradingService
    {
        private readonly ApplicationDbContext _context;

        public HeadCourseGradingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Đổi tên tham số từ headFullName thành headId để rõ nghĩa hơn
        public async Task<List<HeadCourseGradingDto>> GetCoursesForGradingAsync(long headId)
        {
            // Lấy thông tin trưởng bộ môn
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headId);

            if (headLecturer == null)
            {
                return new List<HeadCourseGradingDto>(); // Trả về danh sách rỗng nếu không tìm thấy trưởng bộ môn
            }

            // Lấy danh sách môn học do trưởng bộ môn phụ trách
            var courses = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Group)
                        .ThenInclude(g => g.Lecturer)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Grades)
                .Where(c => c.DepartmentId == headLecturer.DepartmentId)
                .ToListAsync();

            var courseDTOs = new List<HeadCourseGradingDto>();

            foreach (var course in courses)
            {
                // Lấy danh sách nhóm liên quan đến môn học
                var groups = course.Projects
                    .Select(p => p.Group)
                    .Where(g => g != null)
                    .ToList();

                // Tính số nhóm
                int groupCount = groups.Count;

                // Tính số nhóm đã chấm điểm (có ít nhất 1 Grade)
                int gradedCount = groups.Count(g => g.Project.Grades != null && g.Project.Grades.Any());

                // Tính số nhóm đã duyệt (Grade có trạng thái "Đã duyệt")
                int approvedCount = groups.Count(g => g.Project.Grades != null && g.Project.GradeSchedules.Any(grade => grade.Status == "COMPLETED"));

                var courseDTO = new HeadCourseGradingDto
                {
                    CourseId = course.CourseCode,
                    Name = course.Name, // Sửa từ course.Name thành CourseName để khớp với entity
                    Semester = course.Semester?.Name ?? "Chưa xác định",
                    FacultyCode = course.Department?.FacultyCode ?? "Không xác định",
                    Head = course.Projects.Any() && course.Projects.First().Group?.Lecturer != null
                        ? course.Projects.First().Group.Lecturer.FullName
                        : "Chưa phân công",
                    GroupCount = groupCount,
                    GradedCount = gradedCount,
                    ApprovedCount = approvedCount
                };

                courseDTOs.Add(courseDTO);
            }

            return courseDTOs;
        }
    }
}
