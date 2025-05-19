// File: Services/LecturerService.cs
// Mục đích: Xử lý logic nghiệp vụ để lấy danh sách giảng viên
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerService
    {
        private readonly ApplicationDbContext _context;

        public LecturerService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách giảng viên có vai trò ROLE_LECTURER_GUIDE
        public async Task<List<LecturerDto>> GetLecturersAsyn(long? courseCode)
        {
            var query = _context.Users
            .Include(u => u.Role)
            .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE" && u.CourseId == courseCode);


            var lecturers = await query
                .Select(u => new LecturerDto
                {
                    Id = u.Id,
                    FullName = u.FullName
                })
                .ToListAsync();

            return lecturers;
        }
    }
}