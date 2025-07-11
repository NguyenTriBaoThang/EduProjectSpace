using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")]
    public class LecturerResourcesController : ControllerBase
    {
        private readonly LecturerResourcesService _lecturerResourcesService;
        private readonly IWebHostEnvironment _environment;

        public LecturerResourcesController(LecturerResourcesService lecturerResourcesService, IWebHostEnvironment environment)
        {
            _lecturerResourcesService = lecturerResourcesService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResourceDto>>> GetCoursesForResources()
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

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

        [HttpGet("resources")]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResources([FromQuery] string courseId)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

            try
            {
                var resources = await _lecturerResourcesService.GetResourcesAsync(lecturerId, courseId);
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

        [HttpPost("resources")]
        public async Task<IActionResult> AddResources([FromBody] AddResourceDto resourceDto)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

            try
            {
                await _lecturerResourcesService.AddResourcesAsync(lecturerId, resourceDto); // Gọi trực tiếp với một đối tượng
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

        [HttpPut("resources/{id}")]
        public async Task<IActionResult> UpdateResource(long id, [FromBody] UpdateResourceDto resourceDto)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var idUser) ? idUser : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

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

        [HttpDelete("resources/{id}")]
        public async Task<IActionResult> DeleteResource(long id)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var idUser) ? idUser : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

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

        [HttpPost("suggestions")]
        public async Task<ActionResult<IEnumerable<AISuggestionDto>>> GenerateSuggestions([FromBody] GenerateSuggestionDto suggestionDto)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

            try
            {
                var suggestions = await _lecturerResourcesService.GenerateSuggestionsAsync(lecturerId, suggestionDto);
                return Ok(suggestions);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        [HttpPost("save-suggestions")]
        public async Task<IActionResult> SaveSelectedSuggestions([FromBody] List<AISuggestionDto> selectedSuggestions)
        {
            var lecturerId = long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
            if (lecturerId == 0)
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

            try
            {
                await _lecturerResourcesService.SaveSelectedSuggestionsAsync(lecturerId, selectedSuggestions);
                return Ok(new { message = "Gợi ý đã được lưu thành công." });
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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string projectId, [FromForm] string title, [FromForm] string type)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var basePath = Path.Combine(_environment.WebRootPath, "resource");
            var subFolder = type.ToLower() == "pdf" ? "pdf" : "video";
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(basePath, subFolder, fileName);

            Directory.CreateDirectory(Path.Combine(basePath, subFolder));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = $"/resource/{subFolder}/{fileName}";
            return Ok(new { filePath = relativePath });
        }

    }
}