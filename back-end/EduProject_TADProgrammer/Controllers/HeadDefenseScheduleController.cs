using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using System;
using DocumentFormat.OpenXml.VariantTypes;
using EduProject_TADProgrammer.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadDefenseScheduleController : ControllerBase
    {
        private readonly HeadDefenseScheduleService _scheduleService;

        public HeadDefenseScheduleController(HeadDefenseScheduleService serviceService)
        {
            _scheduleService = serviceService;
        }

        [HttpGet("courses")]
        public IActionResult GetCoursesForDefense([FromQuery] long headId)
        {
            try
            {
                var courses = _scheduleService.GetCoursesForDefense(headId);
                return Ok(courses);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        /// Lấy danh sách lịch bảo vệ theo môn học, học kỳ, lớp.
        [HttpGet]
        public async Task<IActionResult> GetDefenseSchedules([FromQuery] string courseId, [FromQuery] string semester, [FromQuery] string classId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var headId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var schedules = await _scheduleService.GetDefenseSchedulesAsync(headId, courseId, semester, classId);
                return Ok(schedules);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return StatusCode(500, $"Server error: {ex.Message}"); }
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetAvailableProjects([FromQuery] string courseId, [FromQuery] string semester, [FromQuery] string classId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out long headId))
                return BadRequest("Invalid head ID.");

            try
            {
                var projects = await _scheduleService.GetAvailableProjectsAsync(headId, courseId, semester, classId);
                return Ok(projects);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return StatusCode(500, $"Server error: {ex.Message}"); }
        }

        /// <summary>
        /// Tạo lịch bảo vệ mới
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateDefenseSchedule([FromBody] CreateDefenseScheduleDto dto)
        {
            if (dto == null) return BadRequest("Invalid request body.");
            if (!long.TryParse(User.FindFirst("Id")?.Value, out long headId))
                return BadRequest("Invalid head ID.");

            try
            {
                var schedule = await _scheduleService.CreateDefenseScheduleAsync(headId, dto);
                return Ok(schedule);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (Exception) { return StatusCode(500, "Server error."); }
        }

        /// <summary>
        /// Lấy danh sách tất cả meeting
        /// </summary>
        [HttpGet("meeting")]
        public async Task<IActionResult> GetMeetings()
        {
            var meetings = await _scheduleService.GetAllMeetingsAsync();
            return Ok(meetings);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefenseSchedule(long id)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out long headId))
                return BadRequest("Invalid head ID.");

            try
            {
                await _scheduleService.DeleteDefenseScheduleAsync(headId, id);
                return Ok("Defense schedule deleted.");
            }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
            catch (Exception ex) { return StatusCode(500, $"Server error: {ex.Message}"); }
        }

    }
}