using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Calendar.v3.Data;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace EduProject_TADProgrammer.Services
{
    public class HeadDefenseScheduleService
    {
        private readonly ApplicationDbContext _context;

        public HeadDefenseScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<HeadCourseDefenseDto> GetCoursesForDefense(long headId)
        {
            if (headId <= 0)
                throw new ArgumentException("ID trưởng bộ môn không hợp lệ.");

            return _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Projects)
                .ThenInclude(p => p.Group)
                .Include(c => c.Projects)
                .ThenInclude(p => p.DefenseSchedules)
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .Include(c => c.LecturerCourses)
                .Where(c => c.LecturerCourses.Any(lc => lc.LecturerId == headId)) // Lọc môn học do trưởng bộ môn quản lý
                .Select(c => new HeadCourseDefenseDto
                {
                    CourseId = c.CourseCode,
                    Name = c.Name,
                    Semester = c.Semester != null ? c.Semester.Name : "Không xác định",
                    ClassId = c.StudentCourses.Any() ? c.StudentCourses.First().Student.ClassCode ?? "Không xác định" : "Không xác định",
                    GroupCount = c.Projects.Where(p => p.GroupId != null).Select(p => p.GroupId).Distinct().Count(),
                    ScheduledCount = c.Projects.Count(p => p.DefenseSchedules.Any())
                })
                .OrderBy(c => c.Semester)
                .ThenBy(c => c.CourseId)
                .ToList();
        }

        /// Lấy danh sách lịch bảo vệ theo môn học, học kỳ, lớp.
        public async Task<List<HeadDefenseScheduleDto>> GetDefenseSchedulesAsync(long headId, string courseId, string semester, string classId)
        {
            if (headId <= 0) throw new ArgumentException("ID trưởng bộ môn không hợp lệ.");
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(classId))
                throw new ArgumentException("Thiếu thông tin môn học, học kỳ hoặc lớp.");

            var query = _context.Projects
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(ug => ug.Student)
                .Include(p => p.DefenseSchedules)
                .Include(p => p.Course)
                .ThenInclude(c => c.Semester)
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.Course)
                .ThenInclude(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == headId) && // Trưởng bộ môn quản lý môn học
                            p.Course.CourseCode == courseId); // Lớp của sinh viên trong nhóm

            return await query.Select(p => new HeadDefenseScheduleDto
            {
                Id = p.DefenseSchedules.Any() ? p.DefenseSchedules.First().Id : (long?)null,
                ProjectId = p.ProjectCode,
                GroupName = p.Group != null ? p.Group.Name : "Không xác định",
                Members = p.Group != null && p.Group.GroupMembers.Any() ? string.Join(", ", p.Group.GroupMembers.Select(ug => ug.Student.FullName)) : "Không có thành viên",
                Date = p.DefenseSchedules.Any() ? p.DefenseSchedules.First().StartTime.ToString("dd/MM/yyyy") : "Chưa xếp lịch",
                Location = p.DefenseSchedules.Any() ? p.DefenseSchedules.First().Room : "",
                Council = p.DefenseSchedules.Any() ? "Chưa có" : ""
            }).ToListAsync();
        }

        /// Lấy danh sách dự án chưa có lịch bảo vệ cho dropdown.
        public async Task<List<dynamic>> GetAvailableProjectsAsync(long headId, string courseId, string semester, string classId)
        {
            if (headId <= 0) throw new ArgumentException("ID trưởng bộ môn không hợp lệ.");
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(classId))
                throw new ArgumentException("Thiếu thông tin môn học, học kỳ hoặc lớp.");

            return await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.Course)
                .ThenInclude(c => c.Semester)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(ug => ug.Student)
                .Include(p => p.DefenseSchedules)
                .Where(p => p.Course.LecturerCourses.Any(lc => lc.LecturerId == headId) &&
                            p.Course.CourseCode == courseId &&
                            p.Course.Semester.Name == semester &&
                            p.Group.GroupMembers.Any(ug => ug.Student.ClassCode == classId) &&
                            !p.DefenseSchedules.Any()) // Chỉ lấy dự án chưa có lịch
                .Select(p => new
                {
                    Id = p.Id,
                    ProjectId = p.ProjectCode,
                    Name = p.Group != null ? p.Group.Name : "Không xác định",
                    Members = p.Group != null && p.Group.GroupMembers.Any() ? string.Join(", ", p.Group.GroupMembers.Select(ug => ug.Student.FullName)) : "Không có thành viên",
                    Status = "Chưa tạo"
                })
                .ToListAsync<dynamic>();
        }

        /// <summary>
        /// Tạo lịch bảo vệ mới
        /// </summary>
        public async Task<CreateDefenseScheduleDto> CreateDefenseScheduleAsync(long headId, CreateDefenseScheduleDto dto)
        {
            if (headId <= 0) throw new ArgumentException("Invalid head ID.");
            if (dto.StartTime >= dto.EndTime) throw new ArgumentException("StartTime must be earlier than EndTime.");

            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.DefenseSchedules)
                .FirstOrDefaultAsync(p => p.Id == dto.ProjectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == headId));
            if (project == null) throw new ArgumentException("Project not found or not managed by head.");
            if (project.DefenseSchedules.Any()) throw new ArgumentException("Project already has a defense schedule.");

            var conflict = await _context.DefenseSchedules
                .AnyAsync(ds => ds.Room == dto.Room &&
                               ((dto.StartTime >= ds.StartTime && dto.StartTime < ds.EndTime) ||
                                (dto.EndTime > ds.StartTime && dto.EndTime <= ds.EndTime) ||
                                (dto.StartTime <= ds.StartTime && dto.EndTime >= ds.EndTime)));
            if (conflict) throw new ArgumentException("Room is already booked.");

            Meeting meeting = null;
            if (dto.MeetingId != 0)
            {
                meeting = await _context.Meetings.FirstOrDefaultAsync(m => m.Id == dto.MeetingId);
                if (meeting == null)
                    throw new ArgumentException("Invalid MeetingId.");
            }

            var defenseSchedule = new DefenseSchedule
            {
                ProjectId = dto.ProjectId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Room = dto.Room,
                MeetingId = dto.MeetingId,
                CreatedAt = DateTime.UtcNow
            };

            _context.DefenseSchedules.Add(defenseSchedule);
            await _context.SaveChangesAsync();

            return dto;
        }


        /// Lấy danh sách tất cả meeting
        /// </summary>
        public async Task<List<MeetingDto>> GetAllMeetingsAsync()
        {
            return await _context.Meetings
                .Select(m => new MeetingDto
                {
                    MeetingId = m.Id,
                    Link = m.Location
                })
                .ToListAsync();
        }

        /// Xóa lịch bảo vệ.
        public async System.Threading.Tasks.Task DeleteDefenseScheduleAsync(long headId, long id)
        {
            if (headId <= 0) throw new ArgumentException("ID trưởng bộ môn không hợp lệ.");
            if (id <= 0) throw new ArgumentException("ID lịch bảo vệ không hợp lệ.");

            var defenseSchedule = await _context.DefenseSchedules
                .Include(ds => ds.Project)
                .ThenInclude(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(ds => ds.Id == id &&
                                          ds.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == headId));

            if (defenseSchedule == null)
                throw new KeyNotFoundException("Lịch bảo vệ không tồn tại hoặc không thuộc trưởng bộ môn.");

            _context.DefenseSchedules.Remove(defenseSchedule);
            await _context.SaveChangesAsync();
        }
    }
}