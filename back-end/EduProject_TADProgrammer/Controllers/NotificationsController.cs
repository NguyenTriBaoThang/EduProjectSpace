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
        public async Task<IActionResult> GetNotifications()
        {
            var result = await _notificationService.GetNotificationsAsync();
            return Ok(new { notifications = result.Notifications, totalItems = result.TotalItems });
        }

        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetRecentNotificationsAsync()
        {
            var notifications = await _notificationService.GetRecentNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("config")]
       // [Authorize(Roles = "ROLE_ADMIN")]
        public async Task<ActionResult<NotificationConfigDto>> GetConfigAsync()
        {
            var config = await _notificationService.GetConfigAsync();
            return Ok(config);
        }

        // [Authorize(Roles = "ROLE_ADMIN,ROLE_LECTURER")]
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDtoWrapper wrapper)
        {
            if (wrapper?.notificationDto == null)
                return BadRequest(new { errors = new { notificationDto = new[] { "The notificationDto field is required." } } });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdNotification = await _notificationService.CreateNotificationAsync(wrapper.notificationDto);
            return CreatedAtAction(nameof(GetNotifications), new { id = createdNotification.Id }, createdNotification);
        }

        public class NotificationDtoWrapper
        {
            public NotificationDto notificationDto { get; set; }
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "ROLE_ADMIN,ROLE_LECTURER")]
        public async Task<IActionResult> UpdateNotification(long id, [FromBody] NotificationDto notificationDto)
        {
            await _notificationService.UpdateNotificationAsync(id, notificationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
      //  [Authorize(Roles = "ROLE_ADMIN")]
        public async Task<IActionResult> DeleteNotification(long id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }

        [HttpPost("config")]
       // [Authorize(Roles = "ROLE_ADMIN")]
        public async Task<IActionResult> SaveConfig([FromBody] NotificationConfigDto config)
        {
            await _notificationService.SaveConfigAsync(config);
            return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserNotificationDto>>> GetUsersAsync([FromQuery] int? roleId)
        {
            var users = await _notificationService.GetUsersByRoleAsync(roleId ?? 0);
            return Ok(users);
        }

        [HttpGet("groups")]
        public async Task<ActionResult<IEnumerable<GroupNotificationDto>>> GetGroupsAsync()
        {
            var groups = await _notificationService.GetGroupsAsync();
            return Ok(groups);
        }
    }
}