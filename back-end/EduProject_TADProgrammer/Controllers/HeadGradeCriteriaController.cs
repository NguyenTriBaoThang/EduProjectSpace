using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_HEAD")]
    public class HeadGradeCriteriaController : ControllerBase
    {
        private readonly HeadGradeCriteriaService _gradeCriteriaService;

        public HeadGradeCriteriaController(HeadGradeCriteriaService gradeCriteriaService)
        {
            _gradeCriteriaService = gradeCriteriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGradeCriteria([FromQuery] long headLecturer, [FromQuery] long? courseId)
        {
            try
            {
                var criteria = await _gradeCriteriaService.GetAllGradeCriteriaAsync(headLecturer, courseId);
                return Ok(criteria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách tiêu chí: {ex.Message}");
            }
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses([FromQuery] long headLecturer)
        {
            try
            {
                var courses = await _gradeCriteriaService.GetCoursesAsync(headLecturer);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách môn học: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGradeCriteria([FromQuery] long headLecturer, [FromBody] GradeCriteria gradeCriteria)
        {
            try
            {
                var createdCriteria = await _gradeCriteriaService.CreateGradeCriteriaAsync(headLecturer, gradeCriteria);
                return CreatedAtAction(nameof(GetGradeCriteria), new { headLecturer, id = createdCriteria.Id }, createdCriteria);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi tạo tiêu chí: {ex.Message}");
            }
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportGradeCriteria([FromQuery] long headLecturer, [FromBody] List<GradeCriteria> gradeCriteriaList)
        {
            try
            {
                if (gradeCriteriaList == null || gradeCriteriaList.Count == 0)
                    return BadRequest("Danh sách tiêu chí không hợp lệ.");
                var result = await _gradeCriteriaService.ImportGradeCriteriaAsync(headLecturer, gradeCriteriaList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi nhập tiêu chí: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGradeCriteria(long id, [FromQuery] long headLecturer, [FromBody] GradeCriteria gradeCriteria)
        {
            try
            {
                if (id != gradeCriteria.Id) return BadRequest("ID không khớp.");
                await _gradeCriteriaService.UpdateGradeCriteriaAsync(headLecturer, gradeCriteria);
                return Ok("Cập nhật tiêu chí thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi cập nhật tiêu chí: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradeCriteria(long id, [FromQuery] long headLecturer)
        {
            try
            {
                await _gradeCriteriaService.DeleteGradeCriteriaAsync(headLecturer, id);
                return Ok("Xóa tiêu chí thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi xóa tiêu chí: {ex.Message}");
            }
        }
    }
}