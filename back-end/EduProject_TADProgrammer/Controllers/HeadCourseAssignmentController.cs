using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_HEAD")]
    public class HeadCourseAssignmentController : ControllerBase
    {
        private readonly HeadCourseAssignmentService _service;

        public HeadCourseAssignmentController(HeadCourseAssignmentService service)
        {
            _service = service;
        }

        // GET: api/HeadCourseAssignment
        [HttpGet]
        public async Task<IActionResult> GetAllCourses([FromQuery] long headLecturer)
        {
            try
            {
                var courses = await _service.GetAllCoursesAsync(headLecturer);
                return Ok(new { Courses = courses });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách môn học: {ex.Message}");
            }
        }

        // GET: api/HeadCourseAssignment/students
        [HttpGet("students")]
        public async Task<IActionResult> GetUnassignedStudents([FromQuery] long courseId, [FromQuery] string semesterName, [FromQuery] string facultyCode)
        {
            try
            {
                var students = await _service.GetUnassignedStudentsAsync(courseId, semesterName, facultyCode);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách sinh viên: {ex.Message}");
            }
        }

        // GET: api/HeadCourseAssignment/lecturers
        [HttpGet("lecturers")]
        public async Task<IActionResult> GetLecturers([FromQuery] long? courseId)
        {
            try
            {
                var lecturers = await _service.GetLecturersAsync(courseId);
                return Ok(lecturers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi lấy danh sách giảng viên: {ex.Message}");
            }
        }

        // POST: api/HeadCourseAssignment/assign
        [HttpPost("assign")]
        public async Task<IActionResult> AssignLecturer([FromBody] HeadCourseAssignmentRequest request, [FromQuery] long courseId)
        {
            try
            {
                await _service.AssignLecturerAsync(request.StudentId, request.LecturerName, courseId);
                return Ok("Phân công thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi phân công: {ex.Message}");
            }
        }

        // POST: api/HeadCourseAssignment/auto-assign
        [HttpPost("auto-assign")]
        public async Task<IActionResult> AutoAssignLecturers([FromQuery] long courseId, [FromQuery] string semesterName, [FromQuery] string facultyCode)
        {
            try
            {
                await _service.AutoAssignLecturersAsync(courseId, semesterName, facultyCode);
                return Ok("Phân công tự động thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi phân công tự động: {ex.Message}");
            }
        }

        // POST: api/HeadCourseAssignment/import
        [HttpPost("import")]
        public async Task<IActionResult> ImportAssignments([FromForm] IFormFile file, [FromQuery] long courseId, [FromQuery] string semesterName, [FromQuery] string facultyCode)
        {
            try
            {
                if (file == null || file.Length == 0) return BadRequest("File không hợp lệ.");
                await _service.ImportAssignmentsAsync(file, courseId, semesterName, facultyCode);
                return Ok("Nhập phân công từ Excel thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi nhập phân công: {ex.Message}");
            }
        }
    }
}