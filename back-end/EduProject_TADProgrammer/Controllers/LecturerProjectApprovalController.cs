using EduProject_TADProgrammer.Entities;
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
    public class LecturerProjectApprovalController : ControllerBase
    {
        private readonly LecturerProjectApprovalService _approvalService;

        public LecturerProjectApprovalController(LecturerProjectApprovalService approvalService)
        {
            _approvalService = approvalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturerProjectApprovalDto>>> GetCoursesForLecturer()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courses = await _approvalService.GetCoursesForLecturerAsync(lecturerId);
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

        [HttpGet("course")]
        public async Task<ActionResult<IEnumerable<ProjectLecturerProjectApprovalDto>>> GetCoursesForApproval([FromQuery] string courseId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courses = await _approvalService.GetCoursesForApproval(lecturerId, courseId);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("project")]
        public async Task<ActionResult<IEnumerable<ProjectLecturerProjectApprovalDto>>> GetProjectsForApproval([FromQuery] string projectId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var projects = await _approvalService.GetProjectsForApproval(lecturerId, projectId);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateApprovalStatus(string projectId, [FromBody] LecturerProjectApprovalRequestDto request)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _approvalService.UpdateApprovalStatus(projectId, lecturerId, request.ApprovalStatus, request.ApprovalReason);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}