// File: Controllers/AdminRolePermissionsController.cs
// Mục đích: Định nghĩa API controller để xử lý các yêu cầu HTTP cho quản lý quyền truy cập của vai trò.
// Hỗ trợ chức năng:
//   1: Phân quyền và bảo mật (xem và cập nhật quyền truy cập của vai trò).
//   4: Quản lý phân quyền (gán và cập nhật quyền cho vai trò).
// Ghi chú: Sử dụng RolePermissionDto đã cập nhật, chỉ admin truy cập được.

using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    // Định nghĩa route cơ bản cho API: /api/AdminRolePermissions
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminRolePermissionsController : ControllerBase
    {
        // Dịch vụ xử lý logic nghiệp vụ cho quyền truy cập
        private readonly AdminRolePermissionService _service;

        // Constructor: Tiêm dịch vụ AdminRolePermissionService thông qua dependency injection
        public AdminRolePermissionsController(AdminRolePermissionService service)
        {
            _service = service;
        }

        // Endpoint: GET /api/AdminRolePermissions
        // Mục đích: Lấy danh sách tất cả quyền truy cập của các vai trò
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRolePermissionDto>>> GetPermissions()
        {
            // Gọi dịch vụ để lấy danh sách quyền truy cập
            var permissions = await _service.GetAllPermissions();
            // Trả về danh sách AdminRolePermissionDto với mã trạng thái 200 OK
            return Ok(permissions);
        }

        // Endpoint: PUT /api/AdminRolePermissions/{roleId}
        // Mục đích: Cập nhật quyền truy cập cho một vai trò
        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdatePermission(long roleId, [FromBody] AdminRolePermissionDto request)
        {
            try
            {
                // Gọi dịch vụ để cập nhật quyền truy cập cho vai trò
                await _service.UpdatePermission(roleId, request);
                // Trả về 204 No Content nếu cập nhật thành công
                return NoContent();
            }
            catch (Exception ex)
            {
                // Trả về 400 nếu có lỗi (ví dụ: vai trò không tồn tại, dữ liệu không hợp lệ)
                return BadRequest(ex.Message);
            }
        }
    }
}