using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Services;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_HEAD")]
    public class HeadLecturerController : ControllerBase
    {
        private readonly HeadLecturerService _service;

        public HeadLecturerController(HeadLecturerService service)
        {
            _service = service;
        }

        // GET: api/HeadLecturer
        [HttpGet]
        public async Task<IActionResult> GetLecturers([FromQuery] long headLecturer)
        {
            var lecturers = await _service.GetHeadLecturersAsync(headLecturer);
            return Ok(lecturers);
        }

        // GET: api/HeadLecturer/details
        [HttpGet("details")]
        public async Task<IActionResult> GetLecturerDetails(
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string facultyCode)
        {
            var details = await _service.GetLecturerDetailsAsync(lecturer, courseId, semester, facultyCode);
            if (details == null) return NotFound("Lecturer not found.");
            return Ok(details);
        }

        // GET: api/HeadLecturer/groups
        [HttpGet("groups")]
        public async Task<IActionResult> GetLecturerGroups(
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string facultyCode)
        {
            var groups = await _service.GetLecturerGroupsAsync(lecturer, courseId, semester, facultyCode);
            if (groups == null || !groups.Any()) return NotFound("No groups found.");
            return Ok(groups);
        }

        // GET: api/HeadLecturer/groupdetails
        [HttpGet("groupdetails")]
        public async Task<IActionResult> GetGroupDetails(
            [FromQuery] long groupId,
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string facultyCode)
        {
            var details = await _service.GetGroupDetailsAsync(groupId, lecturer, courseId, semester, facultyCode);
            if (details == null) return NotFound("Không tìm thấy thông tin nhóm.");
            return Ok(details);
        }
    }
}