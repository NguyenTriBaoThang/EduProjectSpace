using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Data;

namespace EduProject_TADProgrammer.Services
{
    public class HeadLecturerService
    {
        private readonly ApplicationDbContext _context;

        public HeadLecturerService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy toàn bộ danh sách giảng viên hướng dẫn
        public async Task<List<LecturerDTO>> GetHeadLecturersAsync()
        {
            var query = from g in _context.Groups
                        join p in _context.Projects on g.ProjectId equals p.Id
                        join c in _context.Courses on p.CourseId equals c.Id
                        join s in _context.Semesters on c.SemesterId equals s.Id
                        join gm in _context.GroupMembers on g.Id equals gm.GroupId
                        join u in _context.Users on gm.StudentId equals u.Id
                        join lecturer in _context.Users on g.LecturerId equals lecturer.Id
                        where lecturer.Role.Name == "ROLE_LECTURER_GUIDE" // Chỉ lấy giảng viên hướng dẫn
                        group new { g, gm, u } by new
                        {
                            LecturerName = lecturer.FullName,
                            CourseCode = c.CourseCode,
                            SemesterName = s.Name,
                            ClassCode = u.ClassCode
                        } into grp
                        select new LecturerDTO
                        {
                            Lecturer = grp.Key.LecturerName,
                            CourseCode = grp.Key.CourseCode,
                            SemesterName = grp.Key.SemesterName,
                            ClassCode = grp.Key.ClassCode ?? "Unknown",
                            StudentCount = grp.Select(x => x.u.Id).Distinct().Count(), // Đếm số sinh viên duy nhất
                            GroupCount = grp.Select(x => x.g.Id).Distinct().Count() // Đếm số nhóm duy nhất
                        };

            return await query.ToListAsync();
        }
    }

    // DTO để trả về dữ liệu
    public class LecturerDTO
    {
        public string Lecturer { get; set; }
        public string CourseCode { get; set; }
        public string SemesterName { get; set; }
        public string ClassCode { get; set; }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }
    }
}