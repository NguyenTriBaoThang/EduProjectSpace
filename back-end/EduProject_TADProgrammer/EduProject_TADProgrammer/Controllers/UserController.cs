// File: Controllers/UserController.cs
// Mục đích: Quản lý tài khoản người dùng (CRUD), chỉ Admin truy cập được.
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật (CRUD tài khoản, phân quyền).
//   3: Quản lý tài khoản.
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities; // Thêm namespace để dùng User
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        // Lấy danh sách người dùng.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: api/user/5
        // Lấy thông tin một người dùng.
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/user
        // Tạo người dùng mới, mã hóa mật khẩu bằng BCrypt.
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                FullName = request.FullName,
                RoleId = request.RoleId,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var createdUser = await _userService.CreateUser(user);
            await _userService.LogAction(createdUser.Id, "CREATE_USER", $"User {createdUser.Username} created.");
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/user/5
        // Cập nhật thông tin người dùng.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, [FromBody] UserDto userDto)
        {
            if (id != userDto.Id)
                return BadRequest();

            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.FullName = userDto.FullName;
            user.RoleId = userDto.RoleId;
            user.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateUser(user);
            await _userService.LogAction(id, "UPDATE_USER", $"User {user.Username} updated.");
            return NoContent();
        }

        // DELETE: api/user/5
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
    }

    // Model cho request tạo người dùng
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public long RoleId { get; set; }
    }
}