using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Services;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_HEAD")] // Chỉ cho phép vai trò Trưởng bộ môn
    public class HeadDashboardController : ControllerBase
    {
        private readonly HeadDashboardService _headDashboardService;

        public HeadDashboardController(HeadDashboardService headDashboardService)
        {
            _headDashboardService = headDashboardService;
        }

        // GET: api/HeadDashboard/summary
        // Mục đích: Lấy tổng quan số liệu (số đề tài, đã duyệt, chờ duyệt, thông báo)
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                return Unauthorized(new { message = "Không tìm thấy thông tin người dùng trong token." });
            }

            if (!long.TryParse(idClaim.Value, out var userId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ." });
            }

            var summary = await _headDashboardService.GetDashboardSummary(userId);
            return Ok(summary);
        }
    }
}