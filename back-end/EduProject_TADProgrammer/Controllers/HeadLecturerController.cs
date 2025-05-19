using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Services;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/head/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_HEAD")]
    public class HeadLecturerController : ControllerBase
    {
        private readonly HeadLecturerService _service;

        public HeadLecturerController(HeadLecturerService service)
        {
            _service = service;
        }

        // GET: api/head/lecturers
        [HttpGet]
        public async Task<IActionResult> GetLecturers()
        {
            var lecturers = await _service.GetHeadLecturersAsync();
            return Ok(lecturers);
        }
    }
}