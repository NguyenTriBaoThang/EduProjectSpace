﻿using EduProject_TADProgrammer.Models;
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
    [Authorize(Roles = "ROLE_LECTURER_GUIDE")]
    public class LecturerCourseGroupController : ControllerBase
    {
        private readonly LecturerCourseGroupService _service;

        public LecturerCourseGroupController(LecturerCourseGroupService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

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
            try
            {
                var group = await _service.AddGroupAsync(groupName, courseId);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("add-to-group")]
        public async Task<IActionResult> AddToGroup([FromQuery] string studentId, string groupId, int groupSize)
        {
            try
            {
                await _service.AddToGroupAsync(studentId, groupId, groupSize);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("remove-from-group")]
        public async Task<IActionResult> RemoveFromGroup([FromQuery] string studentId, string groupId)
        {
            try
            {
                await _service.RemoveFromGroupAsync(studentId, groupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("toggle-leader")]
        public async Task<IActionResult> ToggleLeader([FromQuery] string studentId, string groupId)
        {
            try
            {
                await _service.ToggleLeaderAsync(studentId, groupId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("assign-project")]
        public async Task<IActionResult> AssignProject([FromQuery] string groupId, string projectId)
        {
            try
            {
                await _service.AssignProjectAsync(groupId, projectId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("auto-group")]
        public async Task<IActionResult> AutoGroup([FromBody] AutoLecturerCourseGroupRequestDto request)
        {
            try
            {
                await _service.AutoGroupAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("export-excel")]
        public async Task<IActionResult> ExportGroupsToExcel(string courseId)
        {
            try
            {
                var fileContent = await _service.ExportGroupsToExcelAsync(courseId);
                var courseResponse = await _service.GetCoursesForGroupingAsync(long.Parse(User.FindFirst("id")?.Value));
                var course = courseResponse.Courses.Find(c => c.CourseId == courseId);
                var fileName = $"{course.Name}_{courseId}.xlsx";
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Lỗi server: {ex.Message}" });
            }
        }

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
                return BadRequest(new { message = ex.Message });
            }
        }

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
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("check-student")]
        public async Task<IActionResult> CheckStudentInCourse(string studentId, string courseId)
        {
            try
            {
                var isValid = await _service.CheckStudentInCourseAsync(studentId, courseId);
                return Ok(new { isValid });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("getIdByUsername")]
        public async Task<IActionResult> GetIdByUsername(string username)
        {
            try
            {
                var userId = await _service.GetIdByUsernameAsync(username);
                return Ok(new { id = userId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}