// File: Controllers/AdminReportsController.cs
// Mục đích: Định nghĩa API controller để cung cấp dữ liệu báo cáo thống kê cho admin.
// Hỗ trợ chức năng:
//   Lấy danh sách kỳ học, khoa/bộ môn, và báo cáo thống kê dựa trên bộ lọc (kỳ học, khoa, bộ môn).
// Ghi chú: Chỉ người dùng có vai trò ROLE_ADMIN được truy cập.
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminReportsController : ControllerBase
    {
        private readonly AdminReportService _service;

        public AdminReportsController(AdminReportService service)
        {
            _service = service;
        }

        [HttpGet("semesters")]
        public async Task<ActionResult<IEnumerable<SemesterAdminReportDto>>> GetSemesters()
        {
            var semesters = await _service.GetSemesters();
            return Ok(semesters);
        }

        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<DepartmentAdminReportDto>>> GetDepartments()
        {
            var departments = await _service.GetDepartments();
            return Ok(departments);
        }

        [HttpGet]
        public async Task<ActionResult<AdminReportResponseDto>> GetReport(
            [FromQuery] string semesterCode = null,
            [FromQuery] string facultyCode = null)
        {
            var report = await _service.GetReport(semesterCode, facultyCode);
            return Ok(report);
        }
    }
}