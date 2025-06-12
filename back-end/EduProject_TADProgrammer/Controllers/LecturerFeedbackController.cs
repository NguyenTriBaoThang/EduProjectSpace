using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")]
    public class LecturerFeedbackController : ControllerBase
    {
        private readonly LecturerFeedbackService _lecturerFeedbackService;

        public LecturerFeedbackController(LecturerFeedbackService lecturerFeedbackService)
        {
            _lecturerFeedbackService = lecturerFeedbackService;
        }

        // Lấy danh sách môn học cần phản hồi của giảng viên
        // GET: api/LecturerFeedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseLecturerFeedbackDto>>> GetCoursesForFeedback()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courses = await _lecturerFeedbackService.GetCoursesForFeedbackAsync(lecturerId);
                return Ok(courses);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lấy danh sách đồ án cần phản hồi
        // GET: api/LecturerFeedback/projects?courseId=CS101
        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<ProjectLecturerFeedbackDto>>> GetProjectsForFeedback([FromQuery] string courseId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var projects = await _lecturerFeedbackService.GetProjectsForFeedbackAsync(lecturerId, courseId);
                return Ok(projects);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lấy chi tiết đồ án và bài nộp
        // GET: api/LecturerFeedback/projects/DT001
        [HttpGet("projects/{projectId}")]
        public async Task<ActionResult<ProjectDetailLecturerFeedbackDto>> GetProjectDetail(string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var projectDetail = await _lecturerFeedbackService.GetProjectDetailAsync(lecturerId, projectId);
                return Ok(projectDetail);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lưu phản hồi cho bài nộp
        // POST: api/LecturerFeedback/projects/DT001/feedback
        [HttpPost("projects/{projectId}/feedback")]
        public async Task<IActionResult> SaveFeedback(string projectId, [FromBody] List<LecturerFeedbackDto> feedbackDtos)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _lecturerFeedbackService.SaveFeedbackAsync(lecturerId, projectId, feedbackDtos);
                return Ok("Phản hồi đã được lưu");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}