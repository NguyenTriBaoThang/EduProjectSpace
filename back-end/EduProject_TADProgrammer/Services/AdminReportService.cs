// File: Services/ReportService.cs
// Mục đích: Xử lý logic nghiệp vụ cho báo cáo thống kê.
// Ghi chú: Cung cấp phương thức để lấy dữ liệu bộ lọc và báo cáo.
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminReportService
    {
        private readonly ApplicationDbContext _context;

        public AdminReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SemesterAdminReportDto>> GetSemesters()
        {
            return await _context.Semesters
                .Select(s => new SemesterAdminReportDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        public async Task<List<DepartmentAdminReportDto>> GetDepartments()
        {
            return await _context.Departments
                .Select(d => new DepartmentAdminReportDto
                {
                    Id = d.Id,
                    Name = d.FacultyName,
                    Code = d.FacultyCode
                })
                .ToListAsync();
        }

        public async Task<AdminReportResponseDto> GetReport(string semesterCode, string facultyCode)
        {
            var studentsQuery = _context.Users
                .Where(u => u.RoleId == 3) // Sinh viên
                .Select(u => new StudentAdminReportDto
                {
                    Id = u.Id,
                    StudentId = u.Username,
                    Name = u.FullName,
                    ClassCode = u.ClassCode,
                    FacultyCode = u.Department.FacultyCode ?? "",
                    SemesterCode = u.CoursesAsStudent.Any() ? u.CoursesAsStudent.First().Course.Semester.Name : ""
                });

            var projectsQuery = _context.Projects
                .Select(p => new ProjectAdminReportDto
                {
                    Id = p.Id,
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    StudentName = string.Join(", ", p.Group.GroupMembers.Select(gm => gm.Student.FullName)),
                    LecturerName = p.Group.Lecturer.FullName ?? "",
                    Status = p.Status,
                    SemesterCode = p.Course.Semester.Name,
                    FacultyCode = p.Course.Department.FacultyCode,
                    FacultyName = p.Course.Department.FacultyName
                });

            var lecturersQuery = _context.Users
                .Where(u => u.RoleId == 2 || u.RoleId == 4) // Giảng viên
                .Select(u => new LecturerAdminReportDto
                {
                    Id = u.Id,
                    LecturerId = u.Username,
                    Name = u.FullName,
                    FacultyCode = u.Department.FacultyCode ?? ""
                });

            if (!string.IsNullOrEmpty(semesterCode))
            {
                studentsQuery = studentsQuery.Where(s => s.SemesterCode == semesterCode);
                projectsQuery = projectsQuery.Where(p => p.SemesterCode == semesterCode);
            }

            if (!string.IsNullOrEmpty(facultyCode))
            {
                studentsQuery = studentsQuery.Where(s => s.FacultyCode == facultyCode);
                projectsQuery = projectsQuery.Where(p => p.FacultyCode == facultyCode);
                lecturersQuery = lecturersQuery.Where(l => l.FacultyCode == facultyCode);
            }

            var students = await studentsQuery.ToListAsync();
            var projects = await projectsQuery.ToListAsync();
            var lecturers = await lecturersQuery.ToListAsync();

            var summary = new AdminReportSummaryDto
            {
                StudentCount = students.Count,
                ApprovedProjects = projects.Count(p => p.Status == "APPROVED"),
                PendingProjects = projects.Count(p => p.Status == "PENDING"),
                LecturerCount = lecturers.Count
            };

            return new AdminReportResponseDto
            {
                Summary = summary,
                Students = students,
                Projects = projects,
                Lecturers = lecturers
            };
        }
    }
}