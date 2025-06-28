using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Data;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminUserController : ControllerBase
    {
        private readonly LogService _logService;
        private readonly AdminUserService _userService;

        public AdminUserController(AdminUserService userService, LogService logService)
        {
            _userService = userService;
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminUserDto>>> GetUsers([FromQuery] long[] roleIds)
        {
            var users = await _userService.GetAllUsers();
            if (roleIds != null && roleIds.Length > 0)
                users = users.Where(u => roleIds.Contains(u.RoleId)).ToList();
            return Ok(users);
        }

        [HttpGet("department")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _userService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminUserDto>> GetUser(long id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<AdminUserDto>> CreateUser([FromBody] CreateAdminUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                DepartmentId = request.DepartmentId,
                RoleId = request.RoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password ?? request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _logService.LogAction(createdUser.Id, "CREATE", $"Tạo người dùng {createdUser.Username}.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportUsers([FromBody] List<CreateAdminUserRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    var user = new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        FullName = request.FullName,
                        ClassCode = request.ClassCode,
                        DepartmentId = request.DepartmentId,
                        RoleId = request.RoleId,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Password ?? request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _logService.LogAction(createdUser.Id, "CREATE", $"Người dùng {createdUser.Username} được tạo thông qua excel.");
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập người dùng {request.Username}: {ex.Message}");
                }
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateAdminUserRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID không khớp.");

            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            user.Username = request.Username;
            user.Email = request.Email;
            user.FullName = request.FullName;
            user.ClassCode = request.ClassCode;
            user.DepartmentId = request.DepartmentId;
            user.RoleId = request.RoleId;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Locked = request.Locked;
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(id, user);
            await _logService.LogAction(id, "UPDATE", $"Người dùng {user.Username} đã cập nhật.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            try
            {
                await _userService.DeleteUser(id);
                await _logService.LogAction(id, "DELETE", $"Người dùng {user.Username} đã bị xóa.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<AdminUserDto>>> GetStudents()
        {
            var students = await _userService.GetAllUsers();
            students = students.Where(u => u.RoleId == 3).ToList();
            return Ok(students);
        }

        [HttpPost("students")]
        public async Task<ActionResult<AdminUserDto>> CreateStudent([FromBody] CreateAdminUserStudentRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                DepartmentId = request.DepartmentId,
                RoleId = 3,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _logService.LogAction(createdUser.Id, "CREATE", $"Tạo sinh viên: {createdUser.Username}.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost("students/import")]
        public async Task<ActionResult<ImportResult>> ImportStudents([FromBody] List<CreateAdminUserStudentRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    var user = new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        FullName = request.FullName,
                        ClassCode = request.ClassCode,
                        DepartmentId = request.DepartmentId,
                        RoleId = 3,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _logService.LogAction(createdUser.Id, "CREATE", $"Sinh viên được tạo thông qua excel: {createdUser.Username}.");
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập sinh viên {request.Username}: {ex.Message}");
                }
            }
            return Ok(result);
        }

        [HttpPut("students/update/{id}")]
        public async Task<IActionResult> UpdateStudent(long id, [FromBody] UpdateAdminUserStudentRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID không khớp.");

            var user = await _userService.GetById(id);
            if (user == null || user.RoleId != 3)
                return NotFound();

            user.Email = request.Email;
            user.FullName = request.FullName;
            user.ClassCode = request.ClassCode;
            user.DepartmentId = request.DepartmentId;
            user.Locked = request.Locked;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.RoleId = 3;
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(id, user);
            await _logService.LogAction(id, "UPDATE", $"Sinh viên đã cập nhật: {user.FullName}.");
            return NoContent();
        }

        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null || user.RoleId != 3)
                return NotFound();

            try
            {
                await _userService.DeleteUser(id);
                await _logService.LogAction(id, "DELETE", $"Sinh viên đã xóa: {user.FullName}.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("lecturers")]
        public async Task<ActionResult<IEnumerable<AdminUserDto>>> GetLecturers()
        {
            var lecturers = await _userService.GetAllUsers();
            lecturers = lecturers.Where(u => u.RoleId == 2 || u.RoleId == 4).ToList();
            return Ok(lecturers);
        }

        [HttpPost("lecturers")]
        public async Task<ActionResult<AdminUserDto>> CreateLecturer([FromBody] CreateAdminUserLecturerRequest request)
        {
            if (request.RoleId != 2 && request.RoleId != 4)
                return BadRequest(new { message = "RoleId phải là 2 (Giảng viên hướng dẫn) hoặc 4 (Trưởng bộ môn)." });

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                DepartmentId = request.DepartmentId,
                RoleId = request.RoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _logService.LogAction(createdUser.Id, "CREATE", $"Giảng viên {createdUser.Username} đã được tạo.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost("lecturers/import")]
        public async Task<ActionResult<ImportResult>> ImportLecturers([FromBody] List<CreateAdminUserLecturerRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    if (request.RoleId != 2 && request.RoleId != 4)
                        throw new Exception("RoleId không hợp lệ.");

                    var user = new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        FullName = request.FullName,
                        ClassCode = request.ClassCode,
                        DepartmentId = request.DepartmentId,
                        RoleId = request.RoleId,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _logService.LogAction(createdUser.Id, "CREATE", $"Giảng viên được tạo thông qua excel: {createdUser.Username}.");
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập giảng viên {request.Username}: {ex.Message}");
                }
            }
            return Ok(result);
        }

        [HttpPut("lecturers/update/{id}")]
        public async Task<IActionResult> UpdateLecturer(long id, [FromBody] UpdateAdminUserLecturerRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID không khớp.");

            var user = await _userService.GetById(id);
            if (user == null || (user.RoleId != 2 && user.RoleId != 4))
                return NotFound();

            if (request.RoleId != 2 && request.RoleId != 4)
                return BadRequest(new { message = "RoleId phải là 2 (Giảng viên hướng dẫn) hoặc 4 (Trưởng bộ môn)." });

            user.Username = request.Username;
            user.Email = request.Email;
            user.FullName = request.FullName;
            user.ClassCode = request.ClassCode;
            user.DepartmentId = request.DepartmentId;
            user.RoleId = request.RoleId;
            user.Locked = request.Locked;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(id, user);
            await _logService.LogAction(id, "UPDATE", $"Giảng viên {user.FullName} đã được cập nhật.");
            return NoContent();
        }

        [HttpDelete("lecturers/{id}")]
        public async Task<IActionResult> DeleteLecturer(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null || (user.RoleId != 2 && user.RoleId != 4))
                return NotFound();

            try
            {
                await _userService.DeleteUser(id);
                await _logService.LogAction(id, "DELETE", $"Giảng viên {user.Username} đã bị xóa.");
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}