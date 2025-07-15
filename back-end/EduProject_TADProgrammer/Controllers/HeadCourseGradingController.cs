// File: Controllers/HeadCourseGradingController.cs
// Mục đích: Xử lý yêu cầu API để lấy danh sách môn học, nhóm và chi tiết nhóm cần duyệt chấm điểm.
// Ghi chú: Thêm endpoint mới để lấy chi tiết nhóm, cập nhật để hỗ trợ API thực thi.
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public async Task<IActionResult> GetCoursesForGrading(long headId)
        {
            var courses = await _courseGradingService.GetCoursesForGradingAsync(headId);
            return Ok(courses);
        }

        [HttpGet("groups-for-grading")]
        public async Task<IActionResult> GetGroupsForGrading(string courseId, string semester, string facultyCode)
        {
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(facultyCode))
                return BadRequest("Thông tin môn học, học kỳ và mã lớp không được để trống.");

            var groups = await _courseGradingService.GetGroupsForGradingAsync(courseId, semester, facultyCode);
            return Ok(groups);
        }

        [HttpGet("group-details")]
        public async Task<IActionResult> GetGroupGradingDetails(long groupId, string courseId, string semester, string facultyCode)
        {
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(semester) || string.IsNullOrEmpty(facultyCode))
                return BadRequest("Thông tin môn học, học kỳ và mã lớp không được để trống.");

            var groupDetails = await _courseGradingService.GetGroupGradingDetailsAsync(groupId, courseId, semester, facultyCode);
            return groupDetails != null ? Ok(groupDetails) : NotFound("Không tìm thấy thông tin nhóm.");
        }

        [HttpPost("approve-grade")]
        public async Task<IActionResult> ApproveGrade([FromBody] ApproveGradeRequest request)
        {
            if (string.IsNullOrEmpty(request.CourseId) || string.IsNullOrEmpty(request.Semester) || string.IsNullOrEmpty(request.FacultyCode))
                return BadRequest("Thông tin môn học, học kỳ và mã lớp không được để trống.");

            try
            {
                await _courseGradingService.ApproveGradesAsync(request.GroupId, request.CourseId, request.Semester, request.FacultyCode, request.CouncilFeedback);
                return Ok(new { Message = "Duyệt điểm thành công" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
    }

    public class ApproveGradeRequest
    {
        public long GroupId { get; set; }
        public string CourseId { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public string CouncilFeedback { get; set; }
    }
}