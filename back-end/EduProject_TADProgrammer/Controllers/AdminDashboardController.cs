// File: Controllers/AdminDashboardController.cs
// Mục đích: Định nghĩa API controller để cung cấp dữ liệu tổng quan và trạng thái đề tài cho bảng điều khiển quản trị (dashboard).
// Hỗ trợ chức năng:
//   Cung cấp thông tin tổng quan và trạng thái đề tài cho admin.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    // Định nghĩa route cơ bản cho API: /api/AdminDashboard
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminDashboardController : ControllerBase
    {
        // Dịch vụ xử lý logic cho bảng điều khiển
        private readonly AdminDashboardService _dashboardService;

        // Constructor: Tiêm dịch vụ AdminDashboardService thông qua dependency injection
        public AdminDashboardController(AdminDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // Endpoint: GET /api/AdminDashboard/summary
        // Mục đích: Trả về dữ liệu tổng quan cho bảng điều khiển
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            // Gọi dịch vụ để lấy dữ liệu tổng quan
            var summary = await _dashboardService.GetDashboardSummary();
            // Trả về kết quả với mã trạng thái 200 OK
            return Ok(summary);
        }

        // Endpoint: GET /api/AdminDashboard/project-status
        // Mục đích: Trả về trạng thái các đề tài
        [HttpGet("project-status")]
        public async Task<IActionResult> GetProjectStatus()
        {
            // Gọi dịch vụ để lấy trạng thái đề tài
            var status = await _dashboardService.GetProjectStatus();
            // Trả về kết quả với mã trạng thái 200 OK
            return Ok(status);
        }
    }
}