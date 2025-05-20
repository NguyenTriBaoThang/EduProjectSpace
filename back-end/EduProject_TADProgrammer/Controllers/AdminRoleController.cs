// File: Controllers/RoleController.cs
// Mục đích: Quản lý vai trò (CRUD), chỉ Admin truy cập được.
// Chức năng hỗ trợ: 
//   1: Phân quyền và bảo mật (CRUD vai trò).
//   4: Quản lý phân quyền.
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using EduProject_TADProgrammer.Entities;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminRoleController : ControllerBase
    {
        private readonly AdminRoleService _roleService;

        public AdminRoleController(AdminRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/role
        // Lấy danh sách vai trò.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminRoleDto>>> GetRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }

        // GET: api/role/5
        // Lấy thông tin một vai trò.
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminRoleDto>> GetRole(long id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
                return NotFound();
            return Ok(role);
        }

        // POST: api/role
        // Tạo vai trò mới.
        [HttpPost]
        public async Task<ActionResult<AdminRoleDto>> CreateRole([FromBody] AdminRoleDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
                Description = roleDto.Description
            };
            var createdRole = await _roleService.CreateRole(role);
            return CreatedAtAction(nameof(GetRole), new { id = createdRole.Id }, createdRole);
        }

        // PUT: api/role/5
        // Cập nhật vai trò.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(long id, [FromBody] AdminRoleDto roleDto)
        {
            if (id != roleDto.Id)
                return BadRequest();

            var role = await _roleService.GetById(id);
            if (role == null)
                return NotFound();

            role.Name = roleDto.Name;
            role.Description = roleDto.Description;
            await _roleService.UpdateRole(role);
            return NoContent();
        }

        // DELETE: api/role/5
        // Xóa vai trò.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(long id)
        {
            var role = await _roleService.GetById(id);
            if (role == null)
                return NotFound();

            await _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}