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

        // Lấy danh sách môn học thuộc khoa của Trưởng bộ môn
        public async Task<List<HeadCourseAssignmentDto>> GetAllCoursesAsync(long headLecturerId)
        {
            var headLecturer = await _context.Users.FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null) throw new Exception("Trưởng bộ môn không tồn tại.");

            var courses = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                        .ThenInclude(s => s.Department)
                .Where(c => c.DepartmentId == headLecturer.DepartmentId)
                .Select(c => new HeadCourseAssignmentDto
                {
                    CourseId = c.Id,
                    Name = c.Name,
                    Semester = c.Semester.Name,
                    FacultyCode = c.StudentCourses
                        .Select(sc => sc.Student.Department.FacultyCode)
                        .Distinct()
                        .FirstOrDefault() ?? "Unknown",
                    StudentCount = c.StudentCourses.Count(),
                    AssignedCount = c.StudentCourses.Count(sc => sc.LecturerId != null),
                    AssignedNullCount = c.StudentCourses.Count(sc => sc.LecturerId == null)
                })
                .ToListAsync();
            return courses;
        }

        // Lấy danh sách giảng viên dạy môn học thuộc khoa
        public async Task<List<HeadCourseAssignmentLecturerDto>> GetLecturersAsync(long? courseId)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền truy cập môn học này.");

            var lecturers = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.LecturerCourses)
                .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE" && u.LecturerCourses.Any(lc => lc.CourseId == courseId))
                .Select(u => new HeadCourseAssignmentLecturerDto
                {
                    Id = u.Id,
                    FullName = u.FullName
                })
                .ToListAsync();
            return lecturers;
        }

        // Lấy danh sách sinh viên thuộc môn học
        public async Task<List<HeadCourseAssignmentStudentDto>> GetUnassignedStudentsAsync(long courseId, string semesterName, string facultyCode)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền truy cập môn học này.");

            var students = await _context.StudentCourses
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.Department)
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Include(sc => sc.Lecturer)
                .Where(sc => sc.Course.Id == courseId &&
                             sc.Course.Semester.Name == semesterName &&
                             sc.Student.Department.FacultyCode == facultyCode)
                .Select(sc => new HeadCourseAssignmentStudentDto
                {
                    Id = sc.StudentId,
                    StudentCode = sc.Student.Username,
                    FullName = sc.Student.FullName,
                    CourseCode = sc.Course.CourseCode,
                    LecturerName = sc.Lecturer != null ? sc.Lecturer.FullName : "Chưa phân công"
                })
                .ToListAsync();
            return students;
        }

        // Phân công thủ công một sinh viên
        public async System.Threading.Tasks.Task AssignLecturerAsync(long studentId, string lecturerName, long courseId)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền phân công môn học này.");

            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");
            if (lecturer == null) throw new Exception("Giảng viên không tồn tại.");

            var studentCourse = await _context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (studentCourse == null) throw new Exception("Sinh viên không đăng ký môn học này.");

            studentCourse.LecturerId = lecturer.Id;
            await _context.SaveChangesAsync();
        }

        // Phân công tự động
        public async System.Threading.Tasks.Task AutoAssignLecturersAsync(long courseId, string semesterName, string facultyCode)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền phân công môn học này.");

            var unassignedStudents = await _context.StudentCourses
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.Department)
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Where(sc => sc.CourseId == courseId &&
                             sc.Course.Semester.Name == semesterName &&
                             sc.Student.Department.FacultyCode == facultyCode &&
                             sc.LecturerId == null)
                .ToListAsync();

            var lecturers = await _context.Users
                .Include(u => u.LecturerCourses)
                .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE" && u.LecturerCourses.Any(lc => lc.CourseId == courseId))
                .ToListAsync();

            if (unassignedStudents.Count == 0 || lecturers.Count == 0) return;

            int studentsPerLecturer = unassignedStudents.Count / lecturers.Count;
            int extraStudents = unassignedStudents.Count % lecturers.Count;
            int index = 0;

            for (int i = 0; i < lecturers.Count; i++)
            {
                int count = studentsPerLecturer + (i < extraStudents ? 1 : 0);
                for (int j = 0; j < count && index < unassignedStudents.Count; j++)
                {
                    unassignedStudents[index].LecturerId = lecturers[i].Id;
                    index++;
                }
            }
            await _context.SaveChangesAsync();
        }

        // Phân công từ file Excel
        public async System.Threading.Tasks.Task ImportAssignmentsAsync(IFormFile file, long courseId, string semesterName, string facultyCode)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền phân công môn học này.");

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var package = new ExcelPackage(stream);
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                var studentCode = worksheet.Cells[row, 1].Text;
                var lecturerName = worksheet.Cells[row, 2].Text;

                var student = await _context.Users
                    .Include(u => u.Department)
                    .FirstOrDefaultAsync(u => u.Username == studentCode && u.Department.FacultyCode == facultyCode);
                var lecturer = await _context.Users
                    .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

                if (student == null || lecturer == null) continue;

                var studentCourse = await _context.StudentCourses
                    .FirstOrDefaultAsync(sc => sc.StudentId == student.Id && sc.CourseId == courseId &&
                                              sc.Course.Semester.Name == semesterName);
                if (studentCourse != null)
                {
                    studentCourse.LecturerId = lecturer.Id;
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}