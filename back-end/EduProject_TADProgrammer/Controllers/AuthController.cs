// File: Controllers/AuthController.cs
// Mục đích: Xử lý đăng nhập, đăng xuất, tạo JWT token, ghi nhật ký đăng nhập vào Logs.
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật (xác thực JWT, giới hạn đăng nhập sai, ghi nhật ký).
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(UserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        // Đăng nhập, set token vào HttpOnly cookie, tăng FailedLoginAttempts nếu sai, khóa tài khoản sau 5 lần thất bại.
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            Console.WriteLine($"Attempting login for username: {request.Username}");
            var user = await _userService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                Console.WriteLine($"Authentication failed for {request.Username}");
                var failedUser = await _userService.GetByUsername(request.Username);
                if (failedUser != null)
                {
                    failedUser.FailedLoginAttempts++;
                    if (failedUser.FailedLoginAttempts >= 5)
                        failedUser.Locked = true;
                    await _userService.UpdateUser(failedUser);
                }
                return Unauthorized(new { message = "Tên đăng nhập hoặc mật khẩu không đúng." });
            }

            if (user.Locked)
                return Unauthorized(new { message = "Tài khoản đã bị khóa." });

            try
            {
                var token = _jwtService.GenerateToken(user);
                if (string.IsNullOrEmpty(token))
                {
                    Console.WriteLine("Token generation failed");
                    return BadRequest(new { message = "Không thể tạo token." });
                }
                Console.WriteLine($"Token created: {token}");

                Response.Cookies.Append("token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddHours(1)
                });
                Console.WriteLine("Cookie set successfully");

                await _userService.LogAction(user.Id, "LOGIN", $"User {user.Username} logged in.");

                return Ok(new
                {
                    user = new UserDto
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Email = user.Email,
                        FullName = user.FullName,
                        RoleId = user.RoleId,
                        RoleName = user.Role.Name,
                        FailedLoginAttempts = user.FailedLoginAttempts,
                        Locked = user.Locked,
                        CreatedAt = user.CreatedAt,
                        UpdatedAt = user.UpdatedAt
                    },
                    token
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in login: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi tạo token." });
            }
        }

        // POST: api/auth/logout
        // Ghi nhật ký đăng xuất và xóa HttpOnly cookie.
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var idClaim = User.FindFirst("id");
            if (idClaim == null)
            {
                return Unauthorized(new { message = "Không tìm thấy thông tin người dùng trong token." });
            }

            var userId = long.Parse(User.FindFirst("id")?.Value);
            await _userService.LogAction(userId, "LOGOUT", $"User logged out.");

            // Xóa cookie
            Response.Cookies.Append("token", "", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(-1)
            });

            return Ok(new { message = "Đăng xuất thành công." });
        }
    }

    // Model cho request đăng nhập
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}