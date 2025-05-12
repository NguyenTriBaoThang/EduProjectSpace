// File: Controllers/NotificationsController.cs
// Mục đích: Xử lý yêu cầu HTTP để quản lý thông báo (CRUD).
// Hỗ trợ: Gửi thông báo cho tất cả, vai trò, cá nhân, nhóm qua web/email.
// Chức năng: Lấy danh sách, thông báo gần đây, tạo, cập nhật, xóa, xuất Excel, cấu hình.

using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationsController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications(string search = "", string status = "", int page = 1, int pageSize = 5)
        {
            var result = await _notificationService.GetNotificationsAsync(search, status, page, pageSize);
            return Ok(new { notifications = result.Notifications, totalItems = result.TotalItems });
        }

        // GET: api/notifications/recent
        // Mục đích: Lấy 5 thông báo gần đây (cho phép tất cả người dùng đã xác thực)
        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentNotificationsAsync()
        {
            var notifications = await _notificationService.GetRecentNotificationsAsync();
            return Ok(notifications);
        }

        [HttpPost]
        [Authorize(Roles = "ROLE_ADMIN,ROLE_LECTURER")]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDto notificationDto)
        {
            var createdNotification = await _notificationService.CreateNotificationAsync(notificationDto);
            return CreatedAtAction(nameof(GetNotifications), new { id = createdNotification.Id }, createdNotification);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ROLE_ADMIN,ROLE_LECTURER")]
        public async Task<IActionResult> UpdateNotification(long id, [FromBody] NotificationDto notificationDto)
        {
            await _notificationService.UpdateNotificationAsync(id, notificationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ROLE_ADMIN")]
        public async Task<IActionResult> DeleteNotification(long id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }

        [HttpPost("config")]
        [Authorize(Roles = "ROLE_ADMIN")]
        public async Task<IActionResult> SaveConfig([FromBody] NotificationConfigDto config)
        {
            await _notificationService.SaveConfigAsync(config);
            return Ok();
        }
    }
}