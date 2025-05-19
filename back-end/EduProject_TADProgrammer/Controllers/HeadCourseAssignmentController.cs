// File: Controllers/HeadCourseAssignmentController.cs
// Mục đích: Xử lý yêu cầu HTTP để lấy danh sách môn học cần phân công giảng viên hướng dẫn.

using EduProject_TADProgrammer.Dtos;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/head/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_HEAD")]
    public class HeadCourseAssignmentController : ControllerBase
    {
        private readonly HeadCourseAssignmentService _service;

        // Constructor: Tiêm HeadCourseAssignmentService để xử lý logic
        public HeadCourseAssignmentController(HeadCourseAssignmentService service)
        {
            _service = service;
        }

        // GET: api/head/course-assignments
        // Lấy toàn bộ danh sách môn học cần phân công
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                // Gọi service để lấy danh sách môn học
                var courses = await _service.GetAllCoursesAsync();
                return Ok(new { Courses = courses });
            }
            catch
            {
                return StatusCode(500, "Lỗi khi lấy danh sách môn học.");
            }
        }

        // GET: api/HeadCourseAssignment/students
        // Lấy danh sách sinh viên chưa phân công GVHD
        [HttpGet("students")]
        public async Task<IActionResult> GetUnassignedStudents([FromQuery] long courseCode, [FromQuery] string semesterName, [FromQuery] string classCode)
        {
            var students = await _service.GetUnassignedStudentsAsync(courseCode, semesterName, classCode);
            return Ok(students);
        }

        // POST: api/HeadCourseAssignment/assign
        // Phân công GVHD thủ công
        [HttpPost("assign")]
        public async Task<IActionResult> AssignLecturer([FromBody] AssignRequest request)
        {
            await _service.AssignLecturerAsync(request.StudentId, request.LecturerName);
            return Ok();
        }

        // POST: api/HeadCourseAssignment/auto-assign
        // Phân công GVHD tự động
        [HttpPost("auto-assign")]
        public async Task<IActionResult> AutoAssignLecturers([FromQuery] long courseCode, [FromQuery] string semesterName, [FromQuery] string classCode)
        {
            await _service.AutoAssignLecturersAsync(courseCode, semesterName, classCode);
            return Ok();
        }

        // POST: api/HeadCourseAssignment/import
        // Phân công từ file Excel
        [HttpPost("import")]
        public async Task<IActionResult> ImportAssignments([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("File không hợp lệ");
            await _service.ImportAssignmentsAsync(file);
            return Ok();
        }

    }

    public class AssignRequest
    {
        public long StudentId { get; set; }
        public string LecturerName { get; set; }
    }
}