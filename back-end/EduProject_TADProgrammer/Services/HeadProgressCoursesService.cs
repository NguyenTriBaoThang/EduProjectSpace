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
        public async Task<List<HeadProgressCourseDTO>> GetProgressCoursesAsync(long headLecturerName)
        {
            // Tìm trưởng bộ môn dựa trên tên và vai trò
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headLecturerName);

            if (headLecturer == null) return new List<HeadProgressCourseDTO>();

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
                .Select(c => new HeadProgressCourseDTO
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
    }
}