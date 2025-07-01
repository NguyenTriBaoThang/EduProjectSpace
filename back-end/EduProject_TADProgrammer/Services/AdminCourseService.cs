using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminCourseService
    {
        private readonly ApplicationDbContext _context;

        public AdminCourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdminCourseDto>> GetAllCourses()
        {
            return await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .Select(c => new AdminCourseDto
                {
                    Id = c.Id,
                    CourseCode = c.CourseCode,
                    Name = c.Name,
                    SemesterName = c.Semester.Name,
                    FacultyCode = c.Department.FacultyCode,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    DefenseDate = c.DefenseDate
                })
                .ToListAsync();
        }

        public async Task<List<SemesterDto>> GetSemesters()
        {
            return await _context.Semesters
                .Select(s => new SemesterDto { Name = s.Name })
                .ToListAsync();
        }

        public async Task<List<FacultyDto>> GetFaculties()
        {
            return await _context.Departments
                .Select(d => new FacultyDto { Code = d.FacultyCode, Name = d.FacultyName })
                .Distinct()
                .ToListAsync();
        }

        public async Task<AdminCourseDto> GetCourseById(long id)
        {
            var course = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;
            return new AdminCourseDto
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                Name = course.Name,
                SemesterName = course.Semester.Name,
                FacultyCode = course.Department.FacultyCode
            };
        }

        public async Task<AdminCourseDto> CreateCourse(CreateAdminCourseRequest request)
        {
            string courseCode = GenerateCourseCode(request.Name, request.SemesterName);
            if (await _context.Courses.AnyAsync(c => c.CourseCode == courseCode))
                throw new Exception("Mã môn học đã tồn tại.");

            var course = new Course
            {
                CourseCode = courseCode,
                Name = request.Name,
                SemesterId = await _context.Semesters
                    .Where(s => s.Name == request.SemesterName)
                    .Select(s => s.Id)
                    .FirstAsync(),
                DepartmentId = await _context.Departments
                    .Where(d => d.FacultyCode == request.FacultyCode)
                    .Select(d => d.Id)
                    .FirstAsync(),
                StartDate = request.StartDate ?? DateTime.UtcNow,
                EndDate = request.EndDate ?? DateTime.UtcNow.AddMonths(6),
                DefenseDate = DateTime.UtcNow,
                Status = "OPEN",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return await GetCourseById(course.Id);
        }

        public async Task<ImportResult> ImportCourses(List<CreateAdminCourseRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    await CreateCourse(request);
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập {request.Name}: {ex.Message}");
                }
            }
            return result;
        }

        public async System.Threading.Tasks.Task UpdateCourse(UpdateAdminCourseRequest request)
        {
            var course = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            course.Name = request.Name;
            course.SemesterId = await _context.Semesters
                .Where(s => s.Name == request.SemesterName)
                .Select(s => s.Id)
                .FirstAsync();
            course.DepartmentId = await _context.Departments
                .Where(d => d.FacultyCode == request.FacultyCode)
                .Select(d => d.Id)
                .FirstAsync();
            course.StartDate = request.StartDate ?? course.StartDate;
            course.EndDate = request.EndDate ?? course.EndDate;
            course.DefenseDate = request.DefenseDate;
            course.UpdatedAt = DateTime.UtcNow;


            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteCourse(long id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        private string GenerateCourseCode(string name, string semesterName)
        {
            // Lấy các chữ cái đầu tiên của từng từ trong tên môn học và in hoa
            string baseCode = string.Join("", name.ToUpper()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word[0]));

            // Kết hợp với semesterName, thay '-' bằng '_'
            return $"{baseCode}_{semesterName.Replace("-", "_")}";
        }
    }
}