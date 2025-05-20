// File: Controllers/RolePermissionsController.cs
// Mục đích: Xử lý các yêu cầu HTTP cho quản lý quyền truy cập
// Ghi chú: Không thay đổi, sử dụng RolePermissionDto đã cập nhật
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminRolePermissionsController : ControllerBase
    {
        private readonly AdminRolePermissionService _service;

        public AdminRolePermissionsController(AdminRolePermissionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRolePermissionDto>>> GetPermissions()
        {
            var permissions = await _service.GetAllPermissions();
            return Ok(permissions);
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdatePermission(long roleId, [FromBody] AdminRolePermissionDto request)
        {
            try
            {
                await _service.UpdatePermission(roleId, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}