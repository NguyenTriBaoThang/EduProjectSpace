using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using System;

[Route("api/[controller]")]
[ApiController]
public class HeadDefenseScheduleController : ControllerBase
{
    private readonly HeadDefenseScheduleService _service;

    public HeadDefenseScheduleController(HeadDefenseScheduleService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetDefenseSchedules()
    {
        try
        {
            var schedules = _service.GetDefenseSchedules();
            return Ok(schedules); // Đã bao gồm MeetingLocation (Google Meet link)
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi server: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult CreateDefenseSchedule([FromBody] CreateHeadDefenseScheduleDto dto)
    {
        try
        {
            var result = _service.CreateDefenseSchedule(dto); // Tạo Google Meet link trong service
            return CreatedAtAction(nameof(GetDefenseSchedules), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi server: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDefenseSchedule(long id, [FromBody] UpdateHeadDefenseScheduleDto dto)
    {
        try
        {
            var result = _service.UpdateDefenseSchedule(id, dto); // Cập nhật, giữ nguyên Google Meet link
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi server: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDefenseSchedule(long id)
    {
        try
        {
            _service.DeleteDefenseSchedule(id); // Xóa cả Google Meet event
            return Ok("Xóa lịch bảo vệ thành công");
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Lỗi server: {ex.Message}");
        }
    }
}