using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using EduProject_TADProgrammer.Entities;
using System.Security.Claims;
using EduProject_TADProgrammer.Models;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")] // Chỉ giảng viên được truy cập
    public class LecturerCoursesController : ControllerBase
    {
        private readonly LecturerCourseService _courseService;

        public LecturerCoursesController(LecturerCourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/LecturerCourses
        // Chú thích: Lấy danh sách tất cả môn học của giảng viên.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturerCourseDto>>> GetCourses()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            var courses = await _courseService.GetAllCourses(lecturerId);
            return Ok(courses);
        }

        // GET: api/LecturerCourses/export
        // Chú thích: Xuất danh sách môn học.
        [HttpGet("export")]
        public async Task<ActionResult<IEnumerable<LecturerCourseDto>>> ExportCourses()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            var courses = await _courseService.GetAllCoursesForExport(lecturerId);
            return Ok(courses);
        }

        // GET: api/LecturerCourses/projects
        // Lấy danh sách đồ án theo giảng viên, lọc theo courseId
        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<ProjectLecturerCourseDto>>> GetProjects([FromQuery] string courseId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            var projects = await _courseService.GetProjects(lecturerId, courseId);
            return Ok(projects);
        }

        // GET: api/LecturerCourses/projects/{projectId}
        [HttpGet("projects/{projectId}")]
        public async Task<ActionResult<ProjectLecturerCourseDto>> GetProjectDetails(string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            var project = await _courseService.GetProjectDetails(projectId, lecturerId);
            return Ok(project);
        }

        // GET: api/LecturerCourses/projects/{projectId}/tasks
        [HttpGet("projects/{projectId}/tasks")]
        public async Task<ActionResult<IEnumerable<LecturerCoursesTaskDto>>> GetProjectTasks(string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            var tasks = await _courseService.GetProjectTasks(projectId, lecturerId);
            return Ok(tasks);
        }

        // POST: api/LecturerCourses/projects/{projectId}/tasks/{taskId}/feedback
        [HttpPost("projects/{projectId}/tasks/{taskId}/feedback")]
        public async Task<IActionResult> UpdateFeedback(string projectId, long taskId, [FromBody] FeedbackLecturerCourseRequest feedbackRequest)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            await _courseService.UpdateFeedback(projectId, taskId, feedbackRequest.Feedback, lecturerId);
            return Ok();
        }

        // PUT: api/LecturerCourses/projects/{projectId}/tasks/{taskId}
        [HttpPut("projects/{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> UpdateTask(string projectId, long taskId, [FromBody] LecturerCoursesTaskDto taskDto)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            await _courseService.UpdateTask(projectId, taskId, taskDto, lecturerId);
            return Ok();
        }
    }
}