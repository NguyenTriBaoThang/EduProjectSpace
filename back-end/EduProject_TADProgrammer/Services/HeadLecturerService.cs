using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Models;

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
        public async Task<List<HeadLecturerDto>> GetHeadLecturersAsync(long headLecturerName)
        {
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headLecturerName);

            var query = from g in _context.Groups
                        join p in _context.Projects on g.ProjectId equals p.Id
                        join c in _context.Courses on p.CourseId equals c.Id
                        join s in _context.Semesters on c.SemesterId equals s.Id
                        join gm in _context.GroupMembers on g.Id equals gm.GroupId
                        join u in _context.Users on gm.StudentId equals u.Id
                        join lecturer in _context.Users on g.LecturerId equals lecturer.Id
                        where lecturer.Role.Name == "ROLE_LECTURER_GUIDE" && c.DepartmentId == headLecturer.DepartmentId // Chỉ lấy giảng viên hướng dẫn
                        group new { g, gm, u } by new
                        {
                            LecturerName = lecturer.FullName,
                            CourseCode = c.CourseCode,
                            SemesterName = s.Name,
                            ClassCode = u.ClassCode
                        } into grp
                        select new HeadLecturerDto
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

        // Get lecturer summary details
        public async Task<HeadLecturerDto> GetLecturerDetailsAsync(string lecturerName, string courseId, string semesterName, string classCode)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return null;

            var query = from g in _context.Groups
                        join p in _context.Projects on g.ProjectId equals p.Id
                        join c in _context.Courses on p.CourseId equals c.Id
                        join s in _context.Semesters on c.SemesterId equals s.Id
                        join gm in _context.GroupMembers on g.Id equals gm.GroupId
                        join u in _context.Users on gm.StudentId equals u.Id
                        where g.LecturerId == lecturer.Id &&
                              c.CourseCode == courseId &&
                              s.Name == semesterName &&
                              u.ClassCode == classCode
                        group new { g, gm, u } by new { LecturerName = lecturer.FullName, CourseCode = c.CourseCode, SemesterName = s.Name, ClassCode = u.ClassCode } into grp
                        select new HeadLecturerDto
                        {
                            Lecturer = grp.Key.LecturerName,
                            CourseCode = grp.Key.CourseCode,
                            SemesterName = grp.Key.SemesterName,
                            ClassCode = grp.Key.ClassCode ?? "Unknown",
                            StudentCount = grp.Select(x => x.u.Id).Distinct().Count(),
                            GroupCount = grp.Select(x => x.g.Id).Distinct().Count()
                        };

            return await query.FirstOrDefaultAsync();
        }

        // Get group details for a specific lecturer
        public async Task<List<HeadLecturerGroupDetailDto>> GetLecturerGroupsAsync(string lecturerName, string courseId, string semesterName, string classCode)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return new List<HeadLecturerGroupDetailDto>();

            var groups = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                    .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Where(g => g.LecturerId == lecturer.Id &&
                            g.Project.Course.CourseCode == courseId &&
                            g.Project.Course.Semester.Name == semesterName &&
                            g.GroupMembers.Any(gm => gm.Student.ClassCode == classCode))
                .ToListAsync();

            var result = new List<HeadLecturerGroupDetailDto>();
            int index = 1;
            foreach (var group in groups)
            {
                var studentIds = string.Join(", ", group.GroupMembers.Select(gm => gm.Student.Username));
                var studentNames = string.Join(", ", group.GroupMembers.Select(gm => gm.Student.FullName));
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == group.ProjectId);
                result.Add(new HeadLecturerGroupDetailDto
                {
                    Index = index++,
                    StudentIds = studentIds,
                    StudentNames = studentNames,
                    GroupName = group.Name,
                    ProjectName = project?.Title ?? "Chưa có đồ án"
                });
            }

            return result;
        }

        // Hàm lấy thông tin chi tiết nhóm dựa trên groupId, lecturerName, courseId, semesterName, classCode
        public async Task<HeadLecturerGroupDetailsDto> GetGroupDetailsAsync(long groupId, string lecturerName, string courseId, string semesterName, string classCode)
        {
            // Tìm giảng viên dựa trên tên và vai trò
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return null;

            // Truy vấn thông tin nhóm và các thông tin liên quan
            var group = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                    .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(g => g.Id == groupId &&
                                          g.LecturerId == lecturer.Id &&
                                          g.Project.Course.CourseCode == courseId &&
                                          g.Project.Course.Semester.Name == semesterName &&
                                          g.GroupMembers.Any(gm => gm.Student.ClassCode == classCode));

            if (group == null) return null;

            // Lấy thông tin dự án
            var project = group.Project;

            // Lấy danh sách tài nguyên (Resources) liên quan đến project này
            // Chỉ lấy các tài nguyên có ProjectId khớp với project.Id
            var resources = await _context.Resources
                .Where(r => r.ProjectId == project.Id)
                .Select(r => r.FilePath)
                .ToListAsync();

            // Tạo DTO để trả về
            var result = new HeadLecturerGroupDetailsDto
            {
                LecturerName = lecturerName,
                CourseInfo = $"{courseId} - {project.Course.Name} ({classCode} - {semesterName})",
                GroupName = group.Name,
                Members = group.GroupMembers.Select(gm => new HeadLecturerMemberGroupDetailDto
                {
                    StudentId = gm.Student.Username,
                    StudentName = gm.Student.FullName
                }).ToList(),
                ProjectName = project?.Title ?? "Chưa có đồ án",
                StartDate = project?.CreatedAt.ToString("dd/MM/yyyy") ?? "Chưa xác định",
                EndDate = project?.UpdatedAt.ToString("dd/MM/yyyy") ?? "Chưa xác định",
                GradingDate = project?.Course?.DefenseDate?.ToString("dd/MM/yyyy") ?? "Chưa xác định",
                Description = project?.Description ?? "Chưa có mô tả",
                FileUrls = resources.Any() ? resources : new List<string> { "Chưa có file" } // Sử dụng danh sách tài nguyên đã lọc
            };

            return result;
        }

    }
}