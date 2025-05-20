using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class HeadCourseAssignmentService
    {
        private readonly ApplicationDbContext _context;

        public HeadCourseAssignmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy toàn bộ danh sách môn học cần phân công
        public async Task<List<HeadCourseAssignmentDto>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                .Select(c => new HeadCourseAssignmentDto
                {
                    CourseId = c.Id,
                    Name = c.Name,
                    Semester = c.Semester.Name,
                    // Lấy ClassCode từ StudentCourses -> Users (Student)
                    ClassCode = c.StudentCourses
                        .Select(sc => sc.Student.ClassCode)
                        .Distinct()
                        .FirstOrDefault() ?? "Unknown",
                    StudentCount = c.StudentCourses.Count(),
                    // Count projects with assigned lecturers via Group
                    AssignedCount = _context.Projects
                        .Where(p => p.CourseId == c.Id && p.Group != null && p.Group.LecturerId != null)
                        .Count(),
                    AssignedNullCount = _context.Projects
                        .Where(p => p.CourseId == c.Id && (p.Group == null || p.Group.LecturerId == null))
                        .Count()
                })
                .ToListAsync();

            return courses;
        }

        // Lấy danh sách giảng viên có vai trò ROLE_LECTURER_GUIDE
        public async Task<List<HeadCourseAssignmentLecturerDto>> GetLecturersAsyn(long? courseCode)
        {
            var query = _context.Users
            .Include(u => u.Role)
            .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE" && u.CourseId == courseCode);


            var lecturers = await query
                .Select(u => new HeadCourseAssignmentLecturerDto
                {
                    Id = u.Id,
                    FullName = u.FullName
                })
                .ToListAsync();

            return lecturers;
        }

        // Lấy danh sách sinh viên chưa có GVHD thuộc môn học
        public async Task<List<HeadCourseAssignmentStudentDto>> GetUnassignedStudentsAsync(long courseId, string semesterName, string classCode)
        {
            var students = await _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Where(sc => sc.Course.Id == courseId &&
                             sc.Course.Semester.Name == semesterName &&
                             sc.Student.ClassCode == classCode)
                .Select(sc => new
                {
                    sc.StudentId,
                    sc.Student.Username,
                    sc.Student.FullName,
                    sc.Course.CourseCode,
                    // Find lecturer through Project -> Group
                    LecturerName = _context.Projects
                        .Where(p => p.CourseId == sc.CourseId && p.Group != null && p.Group.GroupMembers.Any(gm => gm.StudentId == sc.StudentId))
                        .Select(p => p.Group.Lecturer != null ? p.Group.Lecturer.FullName : null)
                        .FirstOrDefault() ?? ""
                })
                //.Where(s => s.LecturerName == "") // Only unassigned students
                .Select(s => new HeadCourseAssignmentStudentDto
                {
                    Id = s.StudentId,
                    StudentCode = s.Username,
                    FullName = s.FullName,
                    CourseCode = s.CourseCode,
                    LecturerName = s.LecturerName
                })
                .ToListAsync();

            return students;
        }

        // Phân công thủ công một sinh viên
        public async System.Threading.Tasks.Task AssignLecturerAsync(long studentId, string lecturerName)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");
            if (lecturer == null)
                return;

            // Find the student's group through their project
            var groupMember = await _context.GroupMembers
                .Include(gm => gm.Group)
                    .ThenInclude(g => g.Project)
                .FirstOrDefaultAsync(gm => gm.StudentId == studentId && gm.Group.Project != null);

            if (groupMember != null && groupMember.Group.LecturerId == null)
            {
                groupMember.Group.LecturerId = lecturer.Id;
                await _context.SaveChangesAsync();
            }
        }

        // Phân công tự động
        public async System.Threading.Tasks.Task AutoAssignLecturersAsync(long courseId, string semesterName, string classCode)
        {
            var unassignedStudents = await GetUnassignedStudentsAsync(courseId, semesterName, classCode);
            var lecturers = await _context.Users
                .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE")
                .ToListAsync();

            if (unassignedStudents.Count == 0 || lecturers.Count == 0)
                return;

            // Find groups associated with the unassigned students
            var unassignedGroups = await _context.GroupMembers
                .Include(gm => gm.Group)
                    .ThenInclude(g => g.Project)
                .Where(gm => unassignedStudents.Select(s => s.Id).Contains(gm.StudentId) &&
                             gm.Group.Project != null &&
                             gm.Group.Project.CourseId == courseId &&
                             gm.Group.LecturerId == null)
                .Select(gm => gm.Group)
                .Distinct()
                .ToListAsync();

            if (unassignedGroups.Count == 0)
                return;

            int groupsPerLecturer = unassignedGroups.Count / lecturers.Count;
            int extraGroups = unassignedGroups.Count % lecturers.Count;

            int index = 0;
            for (int i = 0; i < lecturers.Count; i++)
            {
                int count = groupsPerLecturer + (i < extraGroups ? 1 : 0);
                for (int j = 0; j < count && index < unassignedGroups.Count; j++)
                {
                    var group = unassignedGroups[index];
                    group.LecturerId = lecturers[i].Id;
                    index++;
                }
            }
            await _context.SaveChangesAsync();
        }

        // Phân công từ file Excel
        public async System.Threading.Tasks.Task ImportAssignmentsAsync(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Bỏ qua header
            {
                var studentCode = worksheet.Cells[row, 1].Text;
                var lecturerName = worksheet.Cells[row, 2].Text;

                var student = await _context.Users
                    .FirstOrDefaultAsync(u => u.Username == studentCode && u.ClassCode != null);
                var lecturer = await _context.Users
                    .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

                if (student != null && lecturer != null)
                {
                    var groupMember = await _context.GroupMembers
                        .Include(gm => gm.Group)
                            .ThenInclude(g => g.Project)
                        .FirstOrDefaultAsync(gm => gm.StudentId == student.Id && gm.Group.LecturerId == null);

                    if (groupMember != null)
                    {
                        groupMember.Group.LecturerId = lecturer.Id;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}