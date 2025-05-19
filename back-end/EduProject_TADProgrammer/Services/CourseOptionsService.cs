// File: Services/CourseOptionsService.cs
// Mục đích: Xử lý logic nghiệp vụ để lấy danh sách môn học, học kỳ, và lớp
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class CourseOptionsService
    {
        private readonly ApplicationDbContext _context;

        public CourseOptionsService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách môn học, học kỳ, và lớp
        public async Task<CourseOptionsDto> GetCourseOptionsAsync()
        {
            var options = new CourseOptionsDto
            {
                Courses = await _context.Courses
                    .Select(c => new CourseOption
                    {
                        Code = c.CourseCode,
                        Name = c.Name
                    })
                    .ToListAsync(),
                Semesters = await _context.Semesters
                    .Select(s => new SemesterOption
                    {
                        Name = s.Name
                    })
                    .ToListAsync(),
                Classes = await _context.Users
                    .Where(u => u.ClassCode != null)
                    .Select(u => u.ClassCode)
                    .Distinct()
                    .ToListAsync()
            };

            return options;
        }
    }
}