// File: Controllers/ProgressCoursesController.cs
// Mục đích: Định nghĩa API endpoint để cung cấp dữ liệu danh sách môn học cho frontend.
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/head/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_HEAD")]
    public class HeadProgressCoursesController : ControllerBase
    {
        private readonly HeadProgressCoursesService _service;

        // Constructor: Khởi tạo controller với service
        public HeadProgressCoursesController(HeadProgressCoursesService service)
        {
            _service = service;
        }

        // API: GET api/head/HeadProgressCourses
        // Mục đích: Lấy danh sách môn học cần theo dõi tiến độ của trưởng bộ môn
        [HttpGet]
        public async Task<IActionResult> GetProgressCourses([FromQuery] long headLecturer)
        {
            var courses = await _service.GetProgressCoursesAsync(headLecturer);
            if (courses == null || !courses.Any()) return NotFound("Không tìm thấy môn học nào.");
            return Ok(courses);
        }
    }
}
