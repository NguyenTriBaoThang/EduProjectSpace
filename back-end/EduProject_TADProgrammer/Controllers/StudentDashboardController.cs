using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_STUDENT")]
    public class StudentDashboardController : ControllerBase
    {
        private readonly StudentDashboardService _dashboardService;

        public StudentDashboardController(StudentDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // Lấy dữ liệu dashboard
        [HttpGet]
        public async Task<ActionResult<StudentDashboardDto>> GetDashboardData()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var studentId))
                return BadRequest(new { message = "ID người dùng không hợp lệ." });

            try
            {
                var dashboardData = await _dashboardService.GetDashboardDataAsync(studentId);
                return Ok(dashboardData);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Lấy danh sách thông báo
        [HttpGet("notifications")]
        public async Task<ActionResult<IEnumerable<NotificationStudentDto>>> GetNotifications([FromQuery] int limit = 5)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var studentId))
                return BadRequest(new { message = "ID người dùng không hợp lệ." });

            try
            {
                var notifications = await _dashboardService.GetNotificationsAsync(studentId, limit);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Lấy danh sách công việc
        [HttpGet("tasks")]
        public async Task<ActionResult<IEnumerable<TaskStudentDto>>> GetTasks(
            [FromQuery] string searchText = "",
            [FromQuery] string status = "",
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 5)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var studentId))
                return BadRequest(new { message = "ID người dùng không hợp lệ." });

            try
            {
                var tasks = await _dashboardService.GetTasksAsync(studentId, searchText, status, page, pageSize);
                var totalCount = await _dashboardService.GetTasksCountAsync(studentId, searchText, status);
                return Ok(new { tasks, totalCount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Lấy sự kiện lịch
        [HttpGet("calendar")]
        public async Task<ActionResult<IEnumerable<CalendarStudentDto>>> GetCalendarEvents()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var studentId))
                return BadRequest(new { message = "ID người dùng không hợp lệ." });

            try
            {
                var calendarEvents = await _dashboardService.GetCalendarEventsAsync(studentId);
                return Ok(calendarEvents);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}