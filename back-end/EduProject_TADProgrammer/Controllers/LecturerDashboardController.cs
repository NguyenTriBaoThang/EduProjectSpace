using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_LECTURER_GUIDE")] // Chỉ cho phép vai trò Giảng viên hướng dẫn
    public class LecturerDashboardController : ControllerBase
    {
        private readonly LecturerDashboardService _dashboardService;

        public LecturerDashboardController(LecturerDashboardService dashboardService)
        {
            _dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        }

        // GET: api/LecturerDashboard/summary
        // Mục đích: Lấy tổng quan số liệu cho Giảng viên
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary([FromQuery] long lecturerId)
        {
            try
            {
                var dashboardData = await _dashboardService.GetDashboardDataAsync(lecturerId);
                if (dashboardData == null) return NotFound("Không tìm thấy dữ liệu của User.");
                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi server: {ex.Message}" });
            }
        }
    }
}