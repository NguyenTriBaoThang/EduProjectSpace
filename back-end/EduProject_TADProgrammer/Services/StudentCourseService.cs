using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class StudentCourseService
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<StudentCourseDto>> GetCoursesAsync(long studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("StudentId không hợp lệ.", nameof(studentId));

            var courses = await _context.StudentCourses
                .Include(sc => sc.Course)
                .ThenInclude(c => c.Lecturers)
                .Include(sc => sc.Lecturer)
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => new StudentCourseDto
                {
                    Id = sc.Course.Id,
                    Name = sc.Course.Name,
                    Instructor = sc.Lecturer.FullName ?? (sc.Course.Lecturers.FirstOrDefault().FullName ?? "Chưa có giảng viên"),
                    Status = sc.Status ?? "Chưa xác định",
                    Progress = 0 // Thêm logic nếu có trường Progress, hiện tại giả định 0
                })
                .ToListAsync();

            return courses;
        }

        public async Task<int> GetCoursesCountAsync(long studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("StudentId không hợp lệ.", nameof(studentId));

            var count = await _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .CountAsync();

            return count;
        }
    }
}