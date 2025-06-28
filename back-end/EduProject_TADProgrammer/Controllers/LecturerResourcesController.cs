using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_LECTURER_GUIDE")]
    public class LecturerResourcesController : ControllerBase
    {
        private readonly LecturerResourcesService _lecturerResourcesService;

        public LecturerResourcesController(LecturerResourcesService lecturerResourcesService)
        {
            _lecturerResourcesService = lecturerResourcesService;
        }

        // GET: api/LecturerResources
        // Lấy danh sách môn học cần gợi ý tài liệu của giảng viên
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResourceDto>>> GetCoursesForResources()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courses = await _lecturerResourcesService.GetCoursesForResourcesAsync(lecturerId);
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

        // GET: api/LecturerResources/resources?courseId=CS101&semester=HK1-2025&classId=CNTT01
        // Lấy danh sách tài liệu cho một môn học
        [HttpGet("resources")]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResources([FromQuery] string courseId, [FromQuery] string semester, [FromQuery] string classId)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var resources = await _lecturerResourcesService.GetResourcesAsync(lecturerId, courseId, semester, classId);
                return Ok(resources);
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

        // POST: api/LecturerResources/resources
        // Thêm danh sách tài liệu mới
        [HttpPost("resources")]
        public async Task<IActionResult> AddResources([FromBody] List<AddResourceDto> resourceDtos)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _lecturerResourcesService.AddResourcesAsync(lecturerId, resourceDtos);
                return Ok(new { message = "Tài liệu đã được thêm thành công." });
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

        // PUT: api/LecturerResources/resources/{id}
        // Sửa thông tin tài liệu
        [HttpPut("resources/{id}")]
        public async Task<IActionResult> UpdateResource(long id, [FromBody] UpdateResourceDto resourceDto)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _lecturerResourcesService.UpdateResourceAsync(lecturerId, id, resourceDto);
                return Ok(new { message = "Tài liệu đã được cập nhật." });
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

        // DELETE: api/LecturerResources/resources/{id}
        // Xóa tài liệu
        [HttpDelete("resources/{id}")]
        public async Task<IActionResult> DeleteResource(long id)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                await _lecturerResourcesService.DeleteResourceAsync(lecturerId, id);
                return Ok(new { message = "Tài liệu đã được xóa." });
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

        // POST: api/LecturerResources/suggestions
        // Tạo gợi ý tài liệu bằng AI
        [HttpPost("suggestions")]
        public async Task<ActionResult<IEnumerable<AISuggestionDto>>> GenerateSuggestions([FromBody] GenerateSuggestionDto suggestionDto)
        {
            try
            {
                long lecturerId = 4;
                Console.WriteLine($"⏳ Gọi GenerateSuggestions với ProjectId: {suggestionDto.ProjectId}, Keywords: {suggestionDto.Keywords}");

                var suggestions = await _lecturerResourcesService.GenerateSuggestionsAsync(lecturerId, suggestionDto);

                Console.WriteLine($"✅ Gợi ý trả về: {suggestions.Count()} dòng");
                return Ok(suggestions);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("❌ Lỗi truy cập: " + ex.Message);
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi hệ thống: " + ex.Message);
                return BadRequest(new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }
    }
}