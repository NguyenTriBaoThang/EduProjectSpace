// File: Controllers/AdminRoleController.cs
// Mục đích: Định nghĩa API controller để quản lý vai trò người dùng (CRUD), chỉ Admin truy cập được.
// Hỗ trợ chức năng:
//   1: Phân quyền và bảo mật (CRUD vai trò).
//   4: Quản lý phân quyền (tạo, cập nhật, xóa vai trò).

using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using EduProject_TADProgrammer.Entities;

namespace EduProject_TADProgrammer.Controllers
{
    // Định nghĩa route cơ bản cho API: /api/AdminRole
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminRoleController : ControllerBase
    {
        // Dịch vụ xử lý logic nghiệp vụ cho vai trò
        private readonly AdminRoleService _roleService;

        // Constructor: Tiêm dịch vụ AdminRoleService thông qua dependency injection
        public AdminRoleController(AdminRoleService roleService)
        {
            _roleService = roleService;
        }

        // Endpoint: GET /api/AdminRole
        // Mục đích: Lấy danh sách tất cả vai trò
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRoleDto>>> GetRoles()
        {
            // Gọi dịch vụ để lấy danh sách vai trò
            var roles = await _roleService.GetAllRoles();
            // Trả về danh sách AdminRoleDto với mã trạng thái 200 OK
            return Ok(roles);
        }

        // Endpoint: GET /api/AdminRole/{id}
        // Mục đích: Lấy thông tin chi tiết một vai trò theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminRoleDto>> GetRole(long id)
        {
            // Gọi dịch vụ để lấy vai trò theo ID
            var role = await _roleService.GetRoleById(id);
            if (role == null)
            {
                // Trả về 404 nếu không tìm thấy vai trò
                return NotFound();
            }
            // Trả về AdminRoleDto với mã trạng thái 200 OK
            return Ok(role);
        }

        // Endpoint: POST /api/AdminRole
        // Mục đích: Tạo một vai trò mới
        [HttpPost]
        public async Task<ActionResult<AdminRoleDto>> CreateRole([FromBody] AdminRoleDto roleDto)
        {
            // Tạo entity Role từ dữ liệu yêu cầu
            var role = new Role
            {
                Name = roleDto.Name,
                Description = roleDto.Description
            };
            // Gọi dịch vụ để tạo vai trò
            var createdRole = await _roleService.CreateRole(role);
            // Trả về 201 Created với URL của vai trò mới và AdminRoleDto
            return CreatedAtAction(nameof(GetRole), new { id = createdRole.Id }, createdRole);
        }

        // Endpoint: PUT /api/AdminRole/{id}
        // Mục đích: Cập nhật thông tin một vai trò
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(long id, [FromBody] AdminRoleDto roleDto)
        {
            // Kiểm tra ID trong URL và request có khớp không
            if (id != roleDto.Id)
            {
                return BadRequest();
            }

            // Lấy entity Role theo ID
            var role = await _roleService.GetById(id);
            if (role == null)
            {
                // Trả về 404 nếu không tìm thấy vai trò
                return NotFound();
            }

            // Cập nhật thông tin vai trò
            role.Name = roleDto.Name;
            role.Description = roleDto.Description;
            // Gọi dịch vụ để lưu thay đổi
            await _roleService.UpdateRole(role);
            // Trả về 204 No Content nếu cập nhật thành công
            return NoContent();
        }

        // Endpoint: DELETE /api/AdminRole/{id}
        // Mục đích: Xóa một vai trò
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(long id)
        {
            // Lấy entity Role theo ID
            var role = await _roleService.GetById(id);
            if (role == null)
            {
                // Trả về 404 nếu không tìm thấy vai trò
                return NotFound();
            }

            // Gọi dịch vụ để xóa vai trò
            await _roleService.DeleteRole(id);
            // Trả về 204 No Content nếu xóa thành công
            return NoContent();
        }
    }
}