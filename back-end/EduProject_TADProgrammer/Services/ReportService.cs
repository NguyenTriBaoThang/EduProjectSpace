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
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Ghi chú: Lấy danh sách kỳ học
        public async Task<List<SemesterReportDto>> GetSemesters()
        {
            return await _context.Semesters
                .Select(s => new SemesterReportDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }

        // Ghi chú: Lấy danh sách khoa/bộ môn
        public async Task<List<DepartmentReportDto>> GetDepartments()
        {
            return await _context.Departments
                .Select(d => new DepartmentReportDto
                {
                    Id = d.Id,
                    Name = d.FacultyName,
                    Code = d.FacultyCode
                })
                .ToListAsync();
        }

        // Ghi chú: Lấy dữ liệu báo cáo dựa trên bộ lọc
        public async Task<ReportResponseDto> GetReport(string semesterCode, string facultyCode, string departmentCode)
        {
            // Ghi chú: Lấy danh sách sinh viên (RoleId = 3)
            var studentsQuery = _context.Users
                .Where(u => u.RoleId == 3)
                .Select(u => new StudentReportDto
                {
                    Id = u.Id,
                    StudentId = u.Username,
                    Name = u.FullName,
                    ClassCode = u.ClassCode,
                    FacultyCode = _context.Departments
                        .Where(d => d.Id == u.Id)
                        .Select(d => d.FacultyCode)
                        .FirstOrDefault(),
                    DepartmentCode = _context.Departments
                        .Where(d => d.Id == u.Id)
                        .Select(d => d.DepartmentCode)
                        .FirstOrDefault(),
                    SemesterCode = _context.Semesters
                        .Where(s => s.Id == u.Id)
                        .Select(s => s.Name)
                        .FirstOrDefault()
                });

            // Ghi chú: Lấy danh sách đề tài
            var projectsQuery = _context.Projects
                .Select(p => new ProjectReportDto
                {
                    Id = p.Id,
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    StudentName = string.Join(", ", p.Group.GroupMembers.Select(gm => gm.Student.FullName)),
                    LecturerName = p.Lecturer.FullName,
                    Status = p.Status,
                    SemesterCode = p.Course.Semester.Name,
                    FacultyCode = p.Course.Department.FacultyCode,
                    DepartmentCode = p.Course.Department.DepartmentCode
                });

            // Ghi chú: Lấy danh sách giảng viên (RoleId = 2 hoặc 4)
            var lecturersQuery = _context.Users
                .Where(u => u.RoleId == 2 || u.RoleId == 4)
                .Select(u => new LecturerReportDto
                {
                    Id = u.Id,
                    LecturerId = u.Username,
                    Name = u.FullName,
                    DepartmentCode = _context.Departments
                        .Where(d => d.Id == u.Id)
                        .Select(d => d.DepartmentCode)
                        .FirstOrDefault(),
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
                projectsQuery = projectsQuery
                    .Where(p => p.DepartmentCode == departmentCode);
                lecturersQuery = lecturersQuery
                    .Where(l => l.DepartmentCode == departmentCode);
            }

            // Ghi chú: Thực thi truy vấn
            var students = await studentsQuery.ToListAsync();
            var projects = await projectsQuery.ToListAsync();
            var lecturers = await lecturersQuery.ToListAsync();

            // Ghi chú: Tính toán thống kê
            var summary = new ReportSummaryDto
            {
                StudentCount = students.Count,
                ApprovedProjects = projects.Count(p => p.Status == "Đã duyệt" || p.Status == "Hoàn thành"),
                PendingProjects = projects.Count(p => p.Status == "Chưa duyệt"),
                LecturerCount = lecturers.Count
            };

            return new ReportResponseDto
            {
                Summary = summary,
                Students = students,
                Projects = projects,
                Lecturers = lecturers
            };
        }
    }
}