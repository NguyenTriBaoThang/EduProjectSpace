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

        // Ghi chú: Lấy danh sách kỳ học
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

        // Ghi chú: Lấy danh sách khoa/bộ môn
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

        // Ghi chú: Lấy dữ liệu báo cáo dựa trên bộ lọc
        public async Task<AdminReportResponseDto> GetReport(string semesterCode, string facultyCode, string departmentCode)
        {
            // Ghi chú: Lấy danh sách sinh viên (RoleId = 3)
            var studentsQuery = _context.Users
                .Where(u => u.RoleId == 3)
                .Select(u => new StudentAdminReportDto
                {
                    Id = u.Id,
                    StudentId = u.Username,
                    Name = u.FullName,
                    ClassCode = u.ClassCode,
                    FacultyCode = _context.Departments
                        .Where(d => d.Id == u.Id)
                        .Select(d => d.FacultyCode)
                        .FirstOrDefault(),
                    SemesterCode = _context.Semesters
                        .Where(s => s.Id == u.Id)
                        .Select(s => s.Name)
                        .FirstOrDefault()
                });

            // Ghi chú: Lấy danh sách đề tài
            var projectsQuery = _context.Projects
                .Select(p => new ProjectAdminReportDto
                {
                    Id = p.Id,
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    StudentName = string.Join(", ", p.Group.GroupMembers.Select(gm => gm.Student.FullName)),
                    LecturerName = p.Group.Lecturer.FullName,
                    Status = p.Status,
                    SemesterCode = p.Course.Semester.Name,
                    FacultyCode = p.Course.Department.FacultyCode,
                    FacultyName = p.Course.Department.FacultyName
                });

            // Ghi chú: Lấy danh sách giảng viên (RoleId = 2 hoặc 4)
            var lecturersQuery = _context.Users
                .Where(u => u.RoleId == 2 || u.RoleId == 4)
                .Select(u => new LecturerAdminReportDto
                {
                    Id = u.Id,
                    LecturerId = u.Username,
                    Name = u.FullName,
                    FacultyCode = _context.Departments
                        .Where(d => d.Id == u.Id)
                        .Select(d => d.FacultyCode)
                        .FirstOrDefault()
                });

            // Ghi chú: Áp dụng bộ lọc
            if (!string.IsNullOrEmpty(semesterCode))
            {
                studentsQuery = studentsQuery
                    .Where(s => s.SemesterCode == semesterCode);
                projectsQuery = projectsQuery
                    .Where(p => p.SemesterCode == semesterCode);
            }

            if (!string.IsNullOrEmpty(facultyCode))
            {
                studentsQuery = studentsQuery
                    .Where(s => s.FacultyCode == facultyCode);
                projectsQuery = projectsQuery
                    .Where(p => p.FacultyCode == facultyCode);
                lecturersQuery = lecturersQuery
                    .Where(l => l.FacultyCode == facultyCode);
            }

            if (!string.IsNullOrEmpty(departmentCode))
            {
                studentsQuery = studentsQuery
                    .Where(s => s.DepartmentCode == departmentCode);
                lecturersQuery = lecturersQuery
                    .Where(l => l.DepartmentCode == departmentCode);
            }

            // Ghi chú: Thực thi truy vấn
            var students = await studentsQuery.ToListAsync();
            var projects = await projectsQuery.ToListAsync();
            var lecturers = await lecturersQuery.ToListAsync();

            // Ghi chú: Tính toán thống kê
            var summary = new AdminReportSummaryDto
            {
                StudentCount = students.Count,
                ApprovedProjects = projects.Count(p => p.Status == "Đã duyệt" || p.Status == "Hoàn thành"),
                PendingProjects = projects.Count(p => p.Status == "Chưa duyệt"),
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