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

        public async Task<List<HeadLecturerDto>> GetHeadLecturersAsync(long headLecturerId)
        {
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headLecturerId && u.Role.Name == "ROLE_HEAD");

            if (headLecturer == null) return new List<HeadLecturerDto>();

            var query = from sc in _context.StudentCourses
                        join c in _context.Courses on sc.CourseId equals c.Id
                        join s in _context.Semesters on c.SemesterId equals s.Id
                        join u in _context.Users on sc.StudentId equals u.Id
                        join lecturer in _context.Users on sc.LecturerId equals lecturer.Id
                        join d in _context.Departments on c.DepartmentId equals d.Id
                        join gm in _context.GroupMembers on sc.StudentId equals gm.StudentId into groupMembers
                        from gm in groupMembers.DefaultIfEmpty()
                        join g in _context.Groups on gm.GroupId equals g.Id into groups
                        from g in groups.DefaultIfEmpty()
                        where lecturer.Role.Name == "ROLE_LECTURER_GUIDE" &&
                              c.DepartmentId == headLecturer.DepartmentId &&
                              d.FacultyCode != null
                        group new { sc, u, c, s, lecturer, g } by new
                        {
                            LecturerName = lecturer.FullName,
                            CourseCode = c.CourseCode,
                            SemesterName = s.Name,
                            FacultyCode = d.FacultyCode
                        } into grp
                        select new HeadLecturerDto
                        {
                            Lecturer = grp.Key.LecturerName,
                            CourseCode = grp.Key.CourseCode,
                            SemesterName = grp.Key.SemesterName,
                            FacultyCode = grp.Key.FacultyCode ?? "Unknown",
                            StudentCount = grp.Select(x => x.u.Id).Distinct().Count(),
                            GroupCount = grp.Select(x => x.g != null ? x.g.Id : 0).Distinct().Count(id => id != 0)
                        };

            return await query.ToListAsync();
        }

        public async Task<HeadLecturerDto> GetLecturerDetailsAsync(string lecturerName, string courseId, string semesterName, string facultyCode)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return null;

            var query = from sc in _context.StudentCourses
                        join c in _context.Courses on sc.CourseId equals c.Id
                        join s in _context.Semesters on c.SemesterId equals s.Id
                        join u in _context.Users on sc.StudentId equals u.Id
                        join d in _context.Departments on c.DepartmentId equals d.Id
                        join gm in _context.GroupMembers on sc.StudentId equals gm.StudentId into groupMembers
                        from gm in groupMembers.DefaultIfEmpty()
                        join g in _context.Groups on gm.GroupId equals g.Id into groups
                        from g in groups.DefaultIfEmpty()
                        where sc.LecturerId == lecturer.Id &&
                              c.CourseCode == courseId &&
                              s.Name == semesterName &&
                              d.FacultyCode == facultyCode &&
                              c.DepartmentId == lecturer.DepartmentId
                        group new { sc, u, g } by new
                        {
                            LecturerName = lecturer.FullName,
                            CourseCode = c.CourseCode,
                            SemesterName = s.Name,
                            FacultyCode = d.FacultyCode
                        } into grp
                        select new HeadLecturerDto
                        {
                            Lecturer = grp.Key.LecturerName,
                            CourseCode = grp.Key.CourseCode,
                            SemesterName = grp.Key.SemesterName,
                            FacultyCode = grp.Key.FacultyCode ?? "Unknown",
                            StudentCount = grp.Select(x => x.u.Id).Distinct().Count(),
                            GroupCount = grp.Select(x => x.g != null ? x.g.Id : 0).Distinct().Count(id => id != 0)
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<HeadLecturerGroupDetailDto>> GetLecturerGroupsAsync(string lecturerName, string courseId, string semesterName, string facultyCode)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return new List<HeadLecturerGroupDetailDto>();

            var groups = await _context.StudentCourses
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Include(sc => sc.Student)
                .Join(_context.Departments,
                    sc => sc.Course.DepartmentId,
                    d => d.Id,
                    (sc, d) => new { sc, d })
                .Join(_context.GroupMembers,
                    scd => scd.sc.StudentId,
                    gm => gm.StudentId,
                    (scd, gm) => new { scd.sc, scd.d, gm })
                .Join(_context.Groups,
                    scdgm => scdgm.gm.GroupId,
                    g => g.Id,
                    (scdgm, g) => new { scdgm.sc, scdgm.d, g })
                .Join(_context.Projects,
                    scdg => scdg.g.ProjectId,
                    p => p.Id,
                    (scdg, p) => new { scdg.sc, scdg.d, scdg.g, p })
                .Where(x => x.sc.LecturerId == lecturer.Id &&
                            x.sc.Course.CourseCode == courseId &&
                            x.sc.Course.Semester.Name == semesterName &&
                            x.d.FacultyCode == facultyCode &&
                            x.sc.Course.DepartmentId == lecturer.DepartmentId &&
                            x.g != null)
                .GroupBy(x => x.g.Id)
                .Select(g => new
                {
                    GroupId = g.Key,
                    GroupName = g.First().g.Name,
                    Project = g.First().p,
                    StudentIds = string.Join(", ", g.Select(x => x.sc.Student.Username)),
                    StudentNames = string.Join(", ", g.Select(x => x.sc.Student.FullName))
                })
                .ToListAsync();

            return groups.Select(g => new HeadLecturerGroupDetailDto
            {
                GroupId = g.GroupId,
                StudentIds = g.StudentIds,
                StudentNames = g.StudentNames,
                GroupName = g.GroupName,
                ProjectName = g.Project != null ? g.Project.Title : "Chưa có đồ án"
            }).ToList();
        }

        public async Task<HeadLecturerGroupDetailsDto> GetGroupDetailsAsync(long groupId, string lecturerName, string courseId, string semesterName, string facultyCode)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

            if (lecturer == null) return null;

            var groupData = await _context.StudentCourses
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Include(sc => sc.Student)
                .Join(_context.Departments,
                    sc => sc.Course.DepartmentId,
                    d => d.Id,
                    (sc, d) => new { sc, d })
                .Join(_context.GroupMembers,
                    scd => scd.sc.StudentId,
                    gm => gm.StudentId,
                    (scd, gm) => new { scd.sc, scd.d, gm })
                .Join(_context.Groups,
                    scdgm => scdgm.gm.GroupId,
                    g => g.Id,
                    (scdgm, g) => new { scdgm.sc, scdgm.d, g })
                .Join(_context.Projects,
                    scdg => scdg.g.ProjectId,
                    p => p.Id,
                    (scdg, p) => new { scdg.sc, scdg.d, scdg.g, p })
                .Where(x => x.g.Id == groupId &&
                            x.sc.LecturerId == lecturer.Id &&
                            x.sc.Course.CourseCode == courseId &&
                            x.sc.Course.Semester.Name == semesterName &&
                            x.d.FacultyCode == facultyCode &&
                            x.sc.Course.DepartmentId == lecturer.DepartmentId)
                .ToListAsync();

            if (!groupData.Any()) return null;

            var firstRecord = groupData.First();
            var project = firstRecord.p;
            var resources = await _context.Submissions
                .Include(s => s.Student) // Include Student for User details
                .Where(r => r.ProjectId == project.Id && r.Task.Title == "Đăng ký đề tài")
                .Select(r => new FileSubmissionHeadLecturerDto
                {
                    FilePath = r.FilePath,
                    StudentCode = r.Student != null ? r.Student.Username : "Unknown",
                    FullName = r.Student != null ? r.Student.FullName : "Unknown"
                })
                .ToListAsync();

            return new HeadLecturerGroupDetailsDto
            {
                LecturerName = lecturerName,
                CourseInfo = $"{courseId} - {firstRecord.sc.Course.Name} ({facultyCode} - {semesterName})",
                GroupName = firstRecord.g != null ? firstRecord.g.Name : "Chưa có nhóm",
                Members = groupData.Select(x => new HeadLecturerMemberGroupDetailDto
                {
                    StudentId = x.sc.Student.Username,
                    StudentName = x.sc.Student.FullName
                }).ToList(),
                ProjectName = project != null ? project.Title : "Chưa có đồ án",
                StartDate = project != null ? project.CreatedAt.ToString("dd/MM/yyyy") : "Chưa xác định",
                EndDate = project != null ? project.UpdatedAt.ToString("dd/MM/yyyy") : "Chưa xác định",
                GradingDate = firstRecord.sc.Course != null && firstRecord.sc.Course.DefenseDate.HasValue ? firstRecord.sc.Course.DefenseDate.Value.ToString("dd/MM/yyyy") : "Chưa xác định",
                Description = project != null ? project.Description : "Chưa có mô tả",
                Files = resources.Any() ? resources : new List<FileSubmissionHeadLecturerDto> { new FileSubmissionHeadLecturerDto { FilePath = "Chưa có file", StudentCode = "", FullName = "" } }
            };
        }
    }
}