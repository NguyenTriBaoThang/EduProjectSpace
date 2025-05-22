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
    // Định nghĩa route cơ bản cho API: /api/AdminReports
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminReportsController : ControllerBase
    {
        // Dịch vụ xử lý logic nghiệp vụ cho báo cáo
        private readonly AdminReportService _service;

        // Constructor: Tiêm dịch vụ AdminReportService thông qua dependency injection
        public AdminReportsController(AdminReportService service)
        {
            _service = service;
        }

        // Endpoint: GET /api/AdminReports/semesters
        // Mục đích: Lấy danh sách tất cả kỳ học
        [HttpGet("semesters")]
        public async Task<ActionResult<IEnumerable<SemesterAdminReportDto>>> GetSemesters()
        {
            // Gọi dịch vụ để lấy danh sách kỳ học
            var semesters = await _service.GetSemesters();
            // Trả về danh sách SemesterAdminReportDto với mã trạng thái 200 OK
            return Ok(semesters);
        }

        // Endpoint: GET /api/AdminReports/departments
        // Mục đích: Lấy danh sách tất cả khoa/bộ môn
        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<DepartmentAdminReportDto>>> GetDepartments()
        {
            // Gọi dịch vụ để lấy danh sách khoa/bộ môn
            var departments = await _service.GetDepartments();
            // Trả về danh sách DepartmentAdminReportDto với mã trạng thái 200 OK
            return Ok(departments);
        }

        // Endpoint: GET /api/AdminReports?semesterCode=HK20251&facultyCode=CNTT&departmentCode=CNTT
        // Mục đích: Lấy dữ liệu báo cáo thống kê dựa trên bộ lọc (kỳ học, khoa, bộ môn)
        [HttpGet]
        public async Task<ActionResult<AdminReportResponseDto>> GetReport(
            [FromQuery] string semesterCode = null,
            [FromQuery] string facultyCode = null,
            [FromQuery] string departmentCode = null)
        {
            // Gọi dịch vụ để lấy báo cáo với các tham số bộ lọc
            var report = await _service.GetReport(semesterCode, facultyCode, departmentCode);
            // Trả về AdminReportResponseDto với mã trạng thái 200 OK
            return Ok(report);
        }
    }
}