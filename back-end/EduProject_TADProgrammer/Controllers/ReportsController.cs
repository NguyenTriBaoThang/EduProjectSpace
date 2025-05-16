// File: Controllers/ReportsController.cs
// Mục đích: Cung cấp API để lấy dữ liệu báo cáo thống kê.
// Ghi chú: API hỗ trợ lấy kỳ học, khoa, bộ môn và báo cáo, chỉ admin truy cập.
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
    //[Authorize(Roles = "ROLE_ADMIN")] // Ghi chú: Chỉ admin được truy cập
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _service;

        public ReportsController(ReportService service)
        {
            _service = service;
        }

        // GET: api/Reports/semesters
        // Ghi chú: Lấy danh sách kỳ học
        [HttpGet("semesters")]
        public async Task<ActionResult<IEnumerable<SemesterReportDto>>> GetSemesters()
        {
            var semesters = await _service.GetSemesters();
            return Ok(semesters);
        }

        // GET: api/Reports/departments
        // Ghi chú: Lấy danh sách khoa/bộ môn
        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<DepartmentReportDto>>> GetDepartments()
        {
            var departments = await _service.GetDepartments();
            return Ok(departments);
        }

        // GET: api/Reports?semesterCode=HK20251&facultyCode=CNTT&departmentCode=CNTT
        // Ghi chú: Lấy dữ liệu báo cáo dựa trên bộ lọc
        [HttpGet]
        public async Task<ActionResult<ReportResponseDto>> GetReport(
            [FromQuery] string semesterCode = null,
            [FromQuery] string facultyCode = null,
            [FromQuery] string departmentCode = null)
        {
            var report = await _service.GetReport(semesterCode, facultyCode, departmentCode);
            return Ok(report);
        }
    }
}