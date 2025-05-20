using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using EduProject_TADProgrammer.Services;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/head/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_HEAD")]
    public class HeadLecturerController : ControllerBase
    {
        private readonly HeadLecturerService _service;

        public HeadLecturerController(HeadLecturerService service)
        {
            _service = service;
        }

        // GET: api/head/Headlecturer
        [HttpGet]
        public async Task<IActionResult> GetLecturers([FromQuery] long headLecturer)
        {
            var lecturers = await _service.GetHeadLecturersAsync(headLecturer);
            return Ok(lecturers);
        }

        // GET: api/head/Headlecturer/details
        // Purpose: Retrieve lecturer summary details
        [HttpGet("details")]
        public async Task<IActionResult> GetLecturerDetails(
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string classId)
        {
            var details = await _service.GetLecturerDetailsAsync(lecturer, courseId, semester, classId);
            if (details == null) return NotFound("Lecturer not found.");
            return Ok(details);
        }

        // GET: api/head/Headlecturer/groups
        // Purpose: Retrieve group details for a specific lecturer
        [HttpGet("groups")]
        public async Task<IActionResult> GetLecturerGroups(
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string classId)
        {
            var groups = await _service.GetLecturerGroupsAsync(lecturer, courseId, semester, classId);
            if (groups == null || !groups.Any()) return NotFound("No groups found.");
            return Ok(groups);
        }

        // API: GET api/head/Headlecturer/groupdetails
        // Mục đích: Lấy thông tin chi tiết nhóm dựa trên các tham số query
        [HttpGet("groupdetails")]
        public async Task<IActionResult> GetGroupDetails(
            [FromQuery] long groupId,
            [FromQuery] string lecturer,
            [FromQuery] string courseId,
            [FromQuery] string semester,
            [FromQuery] string classId)
        {
            var details = await _service.GetGroupDetailsAsync(groupId, lecturer, courseId, semester, classId);
            if (details == null) return NotFound("Không tìm thấy thông tin nhóm.");
            return Ok(details);
        }
    }
}