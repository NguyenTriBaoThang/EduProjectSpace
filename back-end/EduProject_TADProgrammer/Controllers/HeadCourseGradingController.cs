// File: Controllers/HeadCourseGradingController.cs
// Mục đích: Xử lý yêu cầu API để lấy danh sách môn học cần duyệt chấm điểm.
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadCourseGradingController : ControllerBase
    {
        private readonly HeadCourseGradingService _courseGradingService;

        public HeadCourseGradingController(HeadCourseGradingService courseGradingService)
        {
            _courseGradingService = courseGradingService;
        }

        [HttpGet("courses-for-grading")]
        public async Task<IActionResult> GetCoursesForGrading(long headFullName)
        {
            var courses = await _courseGradingService.GetCoursesForGradingAsync(headFullName);
            return Ok(courses);
        }
    }
}
