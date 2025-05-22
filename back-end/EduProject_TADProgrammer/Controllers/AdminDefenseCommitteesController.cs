// File: Controllers/DefenseCommitteesController.cs
// Mục đích: Định nghĩa API controller để xử lý các yêu cầu HTTP cho quản lý hội đồng chấm điểm.
// Hỗ trợ chức năng:
//   19: Admin - Thành lập hội đồng chấm điểm (tạo, xem, cập nhật, xóa hội đồng).
// Ghi chú: Controller cung cấp các endpoint để lấy danh sách, lấy chi tiết, tạo, cập nhật, và xóa hội đồng.

using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Controllers
{
    // Định nghĩa route cơ bản cho API: /api/AdminDefenseCommittees
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminDefenseCommitteesController : ControllerBase
    {
        // Dịch vụ xử lý logic nghiệp vụ cho hội đồng chấm điểm
        private readonly AdminDefenseCommitteeService _service;

        // Constructor: Tiêm dịch vụ AdminDefenseCommitteeService thông qua dependency injection
        public AdminDefenseCommitteesController(AdminDefenseCommitteeService service)
        {
            _service = service;
        }

        // Endpoint: GET /api/AdminDefenseCommittees
        // Mục đích: Lấy danh sách tất cả hội đồng chấm điểm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDefenseCommitteesDto>>> GetCommittees()
        {
            // Gọi dịch vụ để lấy danh sách hội đồng
            var committees = await _service.GetAllCommittees();
            // Trả về danh sách DTO với mã trạng thái 200 OK
            return Ok(committees);
        }

        // Endpoint: GET /api/AdminDefenseCommittees/{id}
        // Mục đích: Lấy thông tin chi tiết một hội đồng theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDefenseCommitteesDto>> GetCommittee(long id)
        {
            // Gọi dịch vụ để lấy hội đồng theo ID
            var committee = await _service.GetCommitteeById(id);
            if (committee == null)
            {
                // Trả về 404 nếu không tìm thấy hội đồng
                return NotFound();
            }
            // Trả về DTO của hội đồng với mã trạng thái 200 OK
            return Ok(committee);
        }

        // Endpoint: POST /api/AdminDefenseCommittees
        // Mục đích: Tạo một hội đồng chấm điểm mới
        [HttpPost]
        public async Task<ActionResult<AdminDefenseCommitteesDto>> CreateCommittee([FromBody] CreateAdminDefenseCommitteeRequest request)
        {
            try
            {
                // Gọi dịch vụ để tạo hội đồng mới
                var committee = await _service.CreateCommittee(request);
                // Trả về 201 Created với URL của hội đồng mới và DTO
                return CreatedAtAction(nameof(GetCommittee), new { id = committee.Id }, committee);
            }
            catch (Exception ex)
            {
                // Trả về 400 nếu có lỗi (ví dụ: tên hội đồng trùng, kỳ học không hợp lệ)
                return BadRequest(ex.Message);
            }
        }

        // Endpoint: PUT /api/AdminDefenseCommittees/{id}
        // Mục đích: Cập nhật thông tin một hội đồng chấm điểm
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommittee(long id, [FromBody] UpdateAdminDefenseCommitteeRequest request)
        {
            try
            {
                // Gọi dịch vụ để cập nhật hội đồng
                await _service.UpdateCommittee(id, request);
                // Trả về 204 No Content nếu cập nhật thành công
                return NoContent();
            }
            catch (Exception ex)
            {
                // Trả về 400 nếu có lỗi (ví dụ: hội đồng không tồn tại, dữ liệu không hợp lệ)
                return BadRequest(ex.Message);
            }
        }

        // Endpoint: DELETE /api/AdminDefenseCommittees/{id}
        // Mục đích: Xóa một hội đồng chấm điểm
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommittee(long id)
        {
            try
            {
                // Gọi dịch vụ để xóa hội đồng
                await _service.DeleteCommittee(id);
                // Trả về 204 No Content nếu xóa thành công
                return NoContent();
            }
            catch (Exception ex)
            {
                // Trả về 400 nếu có lỗi (ví dụ: hội đồng không tồn tại)
                return BadRequest(ex.Message);
            }
        }
    }
}