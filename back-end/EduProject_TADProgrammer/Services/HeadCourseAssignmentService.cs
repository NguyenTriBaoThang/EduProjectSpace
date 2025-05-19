// File: Services/HeadCourseAssignmentService.cs
// Mục đích: Cung cấp logic nghiệp vụ để lấy danh sách môn học cần phân công giảng viên hướng dẫn, phân công thủ công/tự động/từ Excel.
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Dtos;
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
        public async Task<List<CourseAssignmentDto>> GetAllCoursesAsync()
        {
            var courses = await _context.Courses
                .Select(c => new CourseAssignmentDto
                {
                    CourseId = c.Id,
                    Name = c.Name,
                    Semester = c.Semester.Name,
                    // Lấy ClassCode từ StudentCourses -> Users (Student)
                    ClassCode = _context.StudentCourses
                        .Where(sc => sc.CourseId == c.Id)
                        .Join(_context.Users,
                            sc => sc.StudentId,
                            u => u.Id,
                            (sc, u) => u.ClassCode)
                        .Distinct()
                        .FirstOrDefault() ?? "Unknown",
                    StudentCount = _context.StudentCourses.Count(sc => sc.CourseId == c.Id),
                    AssignedCount = _context.StudentCourses.Count(sc => sc.CourseId == c.Id && sc.LecturerId != null),
                    AssignedNullCount = _context.StudentCourses.Count(sc => sc.CourseId == c.Id && sc.LecturerId == null)
                })
                .ToListAsync();

            return courses;
        }

        // Lấy danh sách sinh viên chưa có GVHD thuộc môn học
        public async Task<List<StudentAssignmentDto>> GetUnassignedStudentsAsync(long courseCode, string semesterName, string classCode)
        {
            var students = await _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ThenInclude(c => c.Semester)
                .Include(sc => sc.Lecturer)
                .Where(sc => sc.Course.Id == courseCode &&
                             sc.Course.Semester.Name == semesterName &&
                             sc.Student.ClassCode == classCode 
                            )
                .Select(sc => new StudentAssignmentDto
                {
                    Id = sc.StudentId,
                    StudentCode = sc.Student.Username,
                    FullName = sc.Student.FullName,
                    CourseCode = sc.Course.CourseCode,
                    LecturerName = sc.Lecturer.FullName ?? ""
                })
                .ToListAsync();

            return students;
        }

        // Phân công thủ công một sinh viên
        public async Task AssignLecturerAsync(long studentId, string lecturerName)
        {
            var lecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");
            if (lecturer != null)
            {
                var studentCourse = await _context.StudentCourses
                    .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.LecturerId == null);
                if (studentCourse != null)
                {
                    studentCourse.LecturerId = lecturer.Id;
                    await _context.SaveChangesAsync();
                }
            }
        }

        // Phân công tự động
        public async Task AutoAssignLecturersAsync(long courseCode, string semesterName, string classCode)
        {
            var unassignedStudents = await GetUnassignedStudentsAsync(courseCode, semesterName, classCode);
            var lecturers = await _context.Users
                .Where(u => u.Role.Name == "ROLE_LECTURER_GUIDE")
                .ToListAsync();

            if (unassignedStudents.Count == 0 || lecturers.Count == 0) return;

            int studentsPerLecturer = unassignedStudents.Count / lecturers.Count;
            int extraStudents = unassignedStudents.Count % lecturers.Count;

            int index = 0;
            for (int i = 0; i < lecturers.Count; i++)
            {
                int count = studentsPerLecturer + (i < extraStudents ? 1 : 0);
                for (int j = 0; j < count; j++)
                {
                    var studentCourse = await _context.StudentCourses
                        .FirstOrDefaultAsync(sc => sc.StudentId == unassignedStudents[index].Id && sc.LecturerId == null);
                    if (studentCourse != null)
                    {
                        studentCourse.LecturerId = lecturers[i].Id;
                        index++;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        // Phân công từ file Excel
        public async Task ImportAssignmentsAsync(IFormFile file)
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
                    var studentCourse = await _context.StudentCourses
                        .Include(sc => sc.Course)
                        .FirstOrDefaultAsync(sc => sc.StudentId == student.Id && sc.LecturerId == null);
                    if (studentCourse != null)
                    {
                        studentCourse.LecturerId = lecturer.Id;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}