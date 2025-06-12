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
    public class LecturerTaskController : ControllerBase
    {
        private readonly LecturerTaskService _taskService;

        public LecturerTaskController(LecturerTaskService taskService)
        {
            _taskService = taskService;
        }

        // Lấy danh sách công việc của giảng viên
        // GET: api/Task?courseId=CS101&projectId=DT001&semester=HK1_2023-2024&status=Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LecturerTaskDto>>> GetTasks(
            [FromQuery] string? courseId,
            [FromQuery] string? projectId,
            [FromQuery] string? semester,
            [FromQuery] string? status)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var tasks = await _taskService.GetTasksForLecturerAsync(lecturerId, courseId, projectId, semester, status);
                return Ok(tasks);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (Exception ex){ return BadRequest(ex.Message); }
        }

        // Lấy danh sách học kỳ của giảng viên
        // GET: api/Task/Semesters
        [HttpGet("semesters")]
        public async Task<ActionResult<IEnumerable<string>>> GetSemesters()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var semesters = await _taskService.GetSemestersForLecturerAsync(lecturerId);
                return Ok(semesters);
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // Thêm công việc mới
        // POST: api/Task
        [HttpPost]
        public async Task<ActionResult<LecturerTaskDto>> AddTask([FromBody] CreateLecturerTaskDto createTaskDto)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var task = await _taskService.AddTaskAsync(lecturerId, createTaskDto);
                return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
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

        // Cập nhật công việc
        // PUT: api/Task/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(long id, [FromBody] UpdateLecturerTaskDto updateTaskDto)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _taskService.UpdateTaskAsync(lecturerId, id, updateTaskDto);
                return Ok("Cập nhật công việc thành công");
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

        // Xóa công việc
        // DELETE: api/Task/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _taskService.DeleteTaskAsync(lecturerId, id);
                return Ok("Xóa công việc thành công");
            }
            catch (UnauthorizedAccessException ex) { return Unauthorized(ex.Message); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}