using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")]
    public class LecturerReviewController : ControllerBase
    {
        private readonly LecturerReviewService _lecturerReviewService;

        public LecturerReviewController(LecturerReviewService lecturerReviewService)
        {
            _lecturerReviewService = lecturerReviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseLecturerReviewDto>>> GetCoursesForReview()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courses = await _lecturerReviewService.GetCoursesForReviewAsync(lecturerId);
                return Ok(courses);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("courses/{courseId}/projects")]
        public async Task<ActionResult<IEnumerable<ProjectLecturerReviewListDto>>> GetProjectsForCourse(string courseId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var projects = await _lecturerReviewService.GetProjectsForReviewAsync(lecturerId, courseId);
                return Ok(projects);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("projects/{projectId}")]
        public async Task<ActionResult<ProjectLecturerReviewDto>> GetProjectReviewDetail(string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var projectDetail = await _lecturerReviewService.GetProjectReviewDetailAsync(lecturerId, projectId);
                return Ok(projectDetail);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("projects/{projectId}/grades")]
        public async Task<ActionResult> SaveProjectGrades(string projectId, [FromBody] SaveGradesLecturerReviewDto saveGradesDto)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _lecturerReviewService.SaveProjectGradesAsync(lecturerId, projectId, saveGradesDto);
                return Ok("Đã lưu điểm thành công");
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("projects/{projectId}/history")]
        public async Task<ActionResult<IEnumerable<GradeVersionDto>>> GetReviewHistory(string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var history = await _lecturerReviewService.GetReviewHistoryAsync(lecturerId, projectId);
                return Ok(history);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}