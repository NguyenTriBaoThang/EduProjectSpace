using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class HeadCourseAssignmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HeadCourseAssignmentService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

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
                    FacultyCode = c.Department.FacultyCode,
                    StudentCount = c.StudentCourses.Count(),
                    AssignedCount = c.StudentCourses.Count(sc => sc.LecturerId != null),
                    AssignedNullCount = c.StudentCourses.Count(sc => sc.LecturerId == null)
                })
                .ToListAsync();
            return courses;
        }

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

        public async Task<List<HeadCourseAssignmentStudentDto>> GetUnassignedStudentsAsync(long courseId)
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
                .Where(sc => sc.CourseId == courseId)
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
                .Include(sc => sc.Student)
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (studentCourse == null) throw new Exception("Sinh viên không đăng ký môn học này.");

            studentCourse.LecturerId = lecturer.Id;
            await _context.SaveChangesAsync();
            await SendAssignmentEmail(studentCourse.Student, lecturer, course);
        }

        public async Task<List<HeadCourseAssignmentLecturerDto>> GetAvailableLecturersAsync(long courseId)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

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
            if (lecturers.Count < 1) throw new Exception("Không đủ giảng viên để phân công.");
            return lecturers;
        }

        public async System.Threading.Tasks.Task AutoAssignLecturersAsync(long courseId, List<long> selectedLecturerIds)
        {
            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");

            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Role.Name == "ROLE_HEAD" && u.DepartmentId == course.DepartmentId);
            if (headLecturer == null) throw new Exception("Bạn không có quyền phân công môn học này.");

            if (selectedLecturerIds == null || selectedLecturerIds.Count < 1)
                throw new Exception("Vui lòng chọn ít nhất một giảng viên.");

            var lecturers = await _context.Users
                .Where(u => selectedLecturerIds.Contains(u.Id) && u.Role.Name == "ROLE_LECTURER_GUIDE")
                .ToListAsync();
            if (lecturers.Count != selectedLecturerIds.Count)
                throw new Exception("Một số giảng viên không hợp lệ.");

            var unassignedStudents = await _context.StudentCourses
                .Include(sc => sc.Student)
                    .ThenInclude(s => s.Department)
                .Include(sc => sc.Course)
                    .ThenInclude(c => c.Semester)
                .Where(sc => sc.CourseId == courseId && sc.LecturerId == null)
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
                    await SendAssignmentEmail(unassignedStudents[index].Student, lecturers[i], course);
                    index++;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task ImportAssignmentsAsync(IFormFile file, long courseId)
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
                    .FirstOrDefaultAsync(u => u.Username == studentCode);
                var lecturer = await _context.Users
                    .FirstOrDefaultAsync(u => u.FullName == lecturerName && u.Role.Name == "ROLE_LECTURER_GUIDE");

                if (student == null || lecturer == null) continue;

                var studentCourse = await _context.StudentCourses
                    .Include(sc => sc.Student)
                    .FirstOrDefaultAsync(sc => sc.StudentId == student.Id && sc.CourseId == courseId);
                if (studentCourse != null)
                {
                    studentCourse.LecturerId = lecturer.Id;
                    await SendAssignmentEmail(studentCourse.Student, lecturer, course);
                }
            }
            await _context.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task SendAssignmentEmail(User student, User lecturer, Course course)
        {
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUsername = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Lấy Semester nếu chưa được tải (nếu cần)
            if (course.Semester == null)
            {
                course = await _context.Courses
                    .Include(c => c.Semester)
                    .FirstOrDefaultAsync(c => c.Id == course.Id) ?? course;
            }

            var semesterName = course.Semester?.Name ?? "Chưa xác định";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                Subject = "Thông báo phân công giảng viên hướng dẫn",
                Body = $@"
                    <h3>Thông báo từ HUTECH EduProject</h3>
                    <p>Xin chào {student.FullName},</p>
                    <p>Bạn đã được phân công giảng viên hướng dẫn <strong>{lecturer.FullName}</strong> cho môn học <strong>{course.Name}</strong> (Mã: {course.CourseCode}) - Học kỳ: {semesterName}.</p>
                    <p>Thông tin chi tiết:</p>
                    <ul>
                        <li><strong>Môn học:</strong> {course.Name}</li>
                        <li><strong>Mã môn học:</strong> {course.CourseCode}</li>
                        <li><strong>Giảng viên hướng dẫn:</strong> {lecturer.FullName}</li>
                        <li><strong>Học kỳ:</strong> {semesterName}</li>
                    </ul>
                    <p>Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm} (Giờ Việt Nam)</p>
                    <p>Trân trọng,<br>Đội ngũ HUTECH - Team TAD Programmer</p>",
                        IsBodyHtml = true
            };
            mailMessage.To.Add(student.Email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}