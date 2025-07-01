using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminCoursesController : ControllerBase
    {
        private readonly AdminCourseService _courseService;

        public AdminCoursesController(AdminCourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminCourseDto>>> GetCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("semesters")]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetSemesters()
        {
            var semesters = await _courseService.GetSemesters();
            return Ok(semesters);
        }

        [HttpGet("faculties")]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetFaculties()
        {
            var faculties = await _courseService.GetFaculties();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminCourseDto>> GetCourse(long id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<AdminCourseDto>> CreateCourse([FromBody] CreateAdminCourseRequest request)
        {
            var course = await _courseService.CreateCourse(request);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportCourses([FromBody] List<CreateAdminCourseRequest> requests)
        {
            var result = await _courseService.ImportCourses(requests);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(long id, [FromBody] UpdateAdminCourseRequest request)
        {
            if (id != request.Id) return BadRequest("ID không khớp.");
            await _courseService.UpdateCourse(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(long id)
        {
            await _courseService.DeleteCourse(id);
            return NoContent();
        }
    }
}