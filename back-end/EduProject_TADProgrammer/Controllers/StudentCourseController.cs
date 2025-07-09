using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_STUDENT")]
    public class StudentCourseController : ControllerBase
    {
        private readonly StudentCourseService _courseService;

        public StudentCourseController(StudentCourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<StudentCourseDto>>> GetCourses()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var studentId))
                return BadRequest(new { message = "ID người dùng không hợp lệ." });

            try
            {
                var courses = await _courseService.GetCoursesAsync(studentId);
                var totalCount = await _courseService.GetCoursesCountAsync(studentId);
                return Ok(new PagedResult<StudentCourseDto> { Items = courses, TotalCount = totalCount });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}