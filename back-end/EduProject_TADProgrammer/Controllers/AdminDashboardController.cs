using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly AdminDashboardService _dashboardService;

        public AdminDashboardController(AdminDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _dashboardService.GetDashboardSummary();
            return Ok(summary);
        }

        [HttpGet("project-status")]
        public async Task<IActionResult> GetProjectStatus()
        {
            var status = await _dashboardService.GetProjectStatus();
            return Ok(status);
        }
    }
}