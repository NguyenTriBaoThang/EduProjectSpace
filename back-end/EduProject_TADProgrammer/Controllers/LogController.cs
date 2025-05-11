using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class LogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentLogs()
        {
            var logs = await _context.Logs
                .OrderByDescending(l => l.CreatedAt)
                .Take(5)
                .Select(l => new { l.Id, l.Details, l.CreatedAt })
                .ToListAsync();
            return Ok(logs);
        }
    }
}