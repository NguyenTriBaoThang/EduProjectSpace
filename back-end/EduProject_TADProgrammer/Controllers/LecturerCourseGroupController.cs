using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")] // Chỉ cho phép vai trò Giảng viên hướng dẫn
    public class LecturerCourseGroupController : ControllerBase
    {
        private readonly LecturerCourseGroupService _service;

        public LecturerCourseGroupController(LecturerCourseGroupService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/LecturerCourseGroup/courses
        // Mục đích: Lấy danh sách môn học cần chia nhóm cho Giảng viên
        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var lecturerId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }

            try
            {
                var courseData = await _service.GetCoursesForGroupingAsync(lecturerId);
                return Ok(courseData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi server: {ex.Message}" });
            }
        }

        [HttpGet("ungrouped-students")]
        public async Task<IActionResult> GetUngroupedStudents(string courseId)
        {
            var students = await _service.GetUngroupedStudentsAsync(courseId);
            return Ok(students);
        }

        [HttpGet("groups")]
        public async Task<IActionResult> GetGroups(string courseId)
        {
            var groups = await _service.GetGroupsAsync(courseId);
            return Ok(groups);
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects(string courseId)
        {
            var projects = await _service.GetProjectsAsync(courseId);
            return Ok(projects);
        }

        [HttpPost("add-group")]
        public async Task<IActionResult> AddGroup([FromQuery] string groupName, string courseId)
        {
            var group = await _service.AddGroupAsync(groupName, courseId);
            return Ok(group);
        }

        [HttpPost("add-to-group")]
        public async Task<IActionResult> AddToGroup([FromQuery] string studentId, string groupId, int groupSize)
        {
            await _service.AddToGroupAsync(studentId, groupId, groupSize);
            return Ok();
        }

        [HttpPost("remove-from-group")]
        public async Task<IActionResult> RemoveFromGroup([FromQuery] string studentId, string groupId)
        {
            await _service.RemoveFromGroupAsync(studentId, groupId);
            return Ok();
        }

        [HttpPost("toggle-leader")]
        public async Task<IActionResult> ToggleLeader([FromQuery] string studentId, string groupId)
        {
            await _service.ToggleLeaderAsync(studentId, groupId);
            return Ok();
        }

        [HttpPost("assign-project")]
        public async Task<IActionResult> AssignProject([FromQuery] string groupId, string projectId)
        {
            await _service.AssignProjectAsync(groupId, projectId);
            return Ok();
        }

        [HttpPost("auto-group")]
        public async Task<IActionResult> AutoGroup([FromBody] AutoLecturerCourseGroupRequestDto request)
        {
            await _service.AutoGroupAsync(request);
            return Ok();
        }

        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportGroupsToExcel(string courseId)
        {
            var fileContent = await _service.ExportGroupsToExcelAsync(courseId);
            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"nhom_sinh_vien_{courseId}.xlsx");
        }

        // POST: api/LecturerCourseGroup/update-group-name
        // Mục đích: Cập nhật tên nhóm
        [HttpPost("update-group-name")]
        public async Task<IActionResult> UpdateGroupName([FromQuery] string groupId, string newGroupName)
        {
            try
            {
                await _service.UpdateGroupNameAsync(groupId, newGroupName);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi server: {ex.Message}" });
            }
        }

        // POST: api/LecturerCourseGroup/delete-group
        // Mục đích: Xóa nhóm và chuyển các thành viên về chưa có nhóm
        [HttpPost("delete-group")]
        public async Task<IActionResult> DeleteGroup([FromQuery] string groupId)
        {
            try
            {
                await _service.DeleteGroupAsync(groupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi server: {ex.Message}" });
            }
        }
    }
}