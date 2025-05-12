using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "ROLE_ADMIN")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService; 
        
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        // Lấy danh sách tất cả người dùng.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] long[] roleIds)
        {
            var users = await _userService.GetAllUsers();
            if (roleIds != null && roleIds.Length > 0)
                users = users.Where(u => roleIds.Contains(u.RoleId)).ToList();
            return Ok(users);
        }

        // GET: api/User/5
        // Lấy thông tin một người dùng.
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/User
        // Tạo người dùng mới, Password mặc định bằng Username nếu không cung cấp.
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                RoleId = request.RoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password ?? request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _userService.LogAction(createdUser.Id, "CREATE_USER", $"User {createdUser.Username} created.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // POST: api/User/import
        // Nhập danh sách người dùng từ Excel.
        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportUsers([FromBody] List<CreateUserRequest> requests)
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
                        RoleId = request.RoleId,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Password ?? request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _userService.LogAction(createdUser.Id, "CREATE_USER", $"User {createdUser.Username} created via import.");
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

        // PUT: api/User/5
        // Cập nhật thông tin người dùng.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UpdateUserRequest request)
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
            user.RoleId = request.RoleId;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Locked = request.Locked;
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(user);
            await _userService.LogAction(id, "UPDATE_USER", $"User {user.Username} updated.");
            return NoContent();
        }

        // DELETE: api/User/5
        // Xóa người dùng.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            await _userService.DeleteUser(id);
            await _userService.LogAction(id, "DELETE_USER", $"User {user.Username} deleted.");
            return NoContent();
        }

        // GET: api/User/students
        // Lấy danh sách sinh viên (RoleId = 3).
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetStudents()
        {
            var students = await _userService.GetAllUsers();
            students = students.Where(u => u.RoleId == 3).ToList();
            return Ok(students);
        }

        // POST: api/User/students
        // Tạo sinh viên mới, Password mặc định bằng Username.
        [HttpPost("students")]
        public async Task<ActionResult<UserDto>> CreateStudent([FromBody] CreateStudentRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                RoleId = 3,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _userService.LogAction(createdUser.Id, "CREATE_STUDENT", $"Student {createdUser.Username} created.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // POST: api/User/students/import
        // Nhập danh sách sinh viên từ Excel.
        [HttpPost("students/import")]
        public async Task<ActionResult<ImportResult>> ImportStudents([FromBody] List<CreateStudentRequest> requests)
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
                        RoleId = 3,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _userService.LogAction(createdUser.Id, "CREATE_STUDENT", $"Student {createdUser.Username} created via import.");
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

        // PUT: api/User/students/5
        // Cập nhật thông tin sinh viên.
        [HttpPut("students/{id}")]
        public async Task<IActionResult> UpdateStudent(long id, [FromBody] UpdateStudentRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID không khớp.");

            var user = await _userService.GetById(id);
            if (user == null || user.RoleId != 3)
                return NotFound();

            user.Email = request.Email;
            user.FullName = request.FullName;
            user.ClassCode = request.ClassCode;
            user.Locked = request.Locked;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.RoleId = 3;
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(user);
            await _userService.LogAction(id, "UPDATE_STUDENT", $"Student {user.Username} updated.");
            return NoContent();
        }

        // DELETE: api/User/students/5
        // Xóa sinh viên.
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null || user.RoleId != 3)
                return NotFound();

            await _userService.DeleteUser(id);
            await _userService.LogAction(id, "DELETE_STUDENT", $"Student {user.Username} deleted.");
            return NoContent();
        }

        // GET: api/User/lecturers
        // Lấy danh sách giảng viên (RoleId = 2 hoặc 4).
        [HttpGet("lecturers")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetLecturers()
        {
            var lecturers = await _userService.GetAllUsers();
            lecturers = lecturers.Where(u => u.RoleId == 2 || u.RoleId == 4).ToList();
            return Ok(lecturers);
        }

        // POST: api/User/lecturers
        // Tạo giảng viên mới, Password mặc định bằng Username.
        [HttpPost("lecturers")]
        public async Task<ActionResult<UserDto>> CreateLecturer([FromBody] CreateLecturerRequest request)
        {
            if (request.RoleId != 2 && request.RoleId != 4)
                return BadRequest(new { message = "RoleId phải là 2 (Giảng viên hướng dẫn) hoặc 4 (Trưởng bộ môn)." });

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                ClassCode = request.ClassCode,
                RoleId = request.RoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                FailedLoginAttempts = 0,
                Locked = false
            };
            var createdUser = await _userService.CreateUser(user);
            await _userService.LogAction(createdUser.Id, "CREATE_LECTURER", $"Lecturer {createdUser.Username} created.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // POST: api/User/lecturers/import
        // Nhập danh sách giảng viên từ Excel.
        [HttpPost("lecturers/import")]
        public async Task<ActionResult<ImportResult>> ImportLecturers([FromBody] List<CreateLecturerRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    if (request.RoleId != 2 && request.RoleId != 4)
                        throw new Exception("RoleId phải là 2 (Giảng viên hướng dẫn) hoặc 4 (Trưởng bộ môn).");

                    var user = new User
                    {
                        Username = request.Username,
                        Email = request.Email,
                        FullName = request.FullName,
                        ClassCode = request.ClassCode,
                        RoleId = request.RoleId,
                        Password = BCrypt.Net.BCrypt.HashPassword(request.Username),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        FailedLoginAttempts = 0,
                        Locked = false
                    };
                    var createdUser = await _userService.CreateUser(user);
                    await _userService.LogAction(createdUser.Id, "CREATE_LECTURER", $"Lecturer {createdUser.Username} created via import.");
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

        // PUT: api/User/lecturers/5
        // Cập nhật thông tin giảng viên.
        [HttpPut("lecturers/{id}")]
        public async Task<IActionResult> UpdateLecturer(long id, [FromBody] UpdateLecturerRequest request)
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
            user.RoleId = request.RoleId;
            user.Locked = request.Locked;
            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(user);
            await _userService.LogAction(id, "UPDATE_LECTURER", $"Lecturer {user.Username} updated.");
            return NoContent();
        }

        // DELETE: api/User/lecturers/5
        // Xóa giảng viên.
        [HttpDelete("lecturers/{id}")]
        public async Task<IActionResult> DeleteLecturer(long id)
        {
            var user = await _userService.GetById(id);
            if (user == null || (user.RoleId != 2 && user.RoleId != 4))
                return NotFound();

            await _userService.DeleteUser(id);
            await _userService.LogAction(id, "DELETE_LECTURER", $"Lecturer {user.Username} deleted.");
            return NoContent();
        }
    }

    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateUserRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }

    public class CreateStudentRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
    }

    public class UpdateStudentRequest
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public bool Locked { get; set; }
        public string? Password { get; set; }
    }

    public class CreateLecturerRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateLecturerRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }

    public class ImportResult
    {
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<string> Errors { get; set; }
    }
}