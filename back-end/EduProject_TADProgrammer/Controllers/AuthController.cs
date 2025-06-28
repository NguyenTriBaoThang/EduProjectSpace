using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Data;
using System.Linq;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LogService _logService;
        private readonly JwtService _jwtService;
        private readonly AdminUserService _userService;

        public AuthController(AdminUserService userService, JwtService jwtService, LogService logService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _logService = logService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.Authenticate(request.Username, request.Password);
            if (user == null)
            {
                var failedUser = await _userService.GetByUsername(request.Username);
                if (failedUser != null)
                {
                    failedUser.FailedLoginAttempts++;
                    if (failedUser.FailedLoginAttempts >= 5)
                        failedUser.Locked = true;
                    await _userService.UpdateUser(failedUser.Id, failedUser);
                    await _logService.LogAction(failedUser.Id, "LOGIN", $"Người dùng {failedUser.FullName} đăng nhập hệ thống thất bại.");
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
                    return BadRequest(new { message = "Không thể tạo token." });
                }

                Response.Cookies.Append("token", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddHours(1)
                });

                await _logService.LogAction(user.Id, "LOGIN", $"Người dùng {user.FullName} đăng nhập hệ thống.");

                return Ok(new
                {
                    user = new AdminUserDto
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
                return StatusCode(500, new { message = "Lỗi server khi tạo token." });
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (!long.TryParse(User.FindFirst("id")?.Value, out var userId))
                {
                    return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
                }
                var fullName = User.FindFirst("fullName")?.Value ?? "Không rõ tên";
                var userName = User.FindFirst("userName")?.Value ?? "Không rõ tài khoản";
                await _logService.LogAction(userId, "LOGOUT", $"Người dùng {fullName}({userName}) đã đăng xuất hệ thống.");

                Response.Cookies.Append("token", "", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(-1)
                });

                return Ok(new { message = "Đăng xuất thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi server khi đăng xuất." });
            }
        }
    }
}