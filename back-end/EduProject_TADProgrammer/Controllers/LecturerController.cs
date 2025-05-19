// File: Controllers/LecturerController.cs
// Mục đích: Xử lý yêu cầu API để lấy danh sách giảng viên
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LecturerController : ControllerBase
    {
        private readonly LecturerService _service;

        public LecturerController(LecturerService service)
        {
            _service = service;
        }

        // GET: api/lecturers
        // Lấy danh sách giảng viên
        [HttpGet]
        public async Task<IActionResult> GetLecturers(long? courseCode)
        {
            var lecturers = await _service.GetLecturersAsyn(courseCode);
            return Ok(lecturers);
        }
    }
}