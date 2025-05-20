// File: Controllers/CourseOptionsController.cs
// Mục đích: Xử lý yêu cầu API để lấy danh sách môn học, học kỳ, và lớp
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseOptionsController : ControllerBase
    {
        private readonly CourseOptionsService _service;

        public CourseOptionsController(CourseOptionsService service)
        {
            _service = service;
        }

        // GET: api/courses/options
        // Lấy danh sách môn học, học kỳ, và lớp
        [HttpGet("options")]
        public async Task<IActionResult> GetCourseOptions()
        {
            var options = await _service.GetCourseOptionsAsync();
            return Ok(options);
        }
    }
}