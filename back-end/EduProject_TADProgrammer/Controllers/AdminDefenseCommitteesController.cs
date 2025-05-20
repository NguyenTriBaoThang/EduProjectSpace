// File: Controllers/DefenseCommitteesController.cs
// Mục đích: Xử lý các yêu cầu HTTP cho quản lý hội đồng chấm điểm.
// Hỗ trợ chức năng: 
//   19: Admin - Thành lập hội đồng chấm điểm
// Ghi chú: Controller này cung cấp các endpoint để lấy danh sách, lấy chi tiết, tạo, cập nhật, và xóa hội đồng.
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
    [Authorize(Roles = "ROLE_ADMIN")] // Ghi chú: Chỉ admin được truy cập API này
    public class AdminDefenseCommitteesController : ControllerBase
    {
        private readonly AdminDefenseCommitteeService _service;

        // Ghi chú: Inject DefenseCommitteeService để xử lý logic nghiệp vụ
        public AdminDefenseCommitteesController(AdminDefenseCommitteeService service)
        {
            _service = service;
        }

        // GET: api/DefenseCommittees
        // Ghi chú: Lấy danh sách tất cả hội đồng chấm điểm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDefenseCommitteesDto>>> GetCommittees()
        {
            var committees = await _service.GetAllCommittees();
            return Ok(committees); // Ghi chú: Trả về danh sách DTO
        }

        // GET: api/DefenseCommittees/5
        // Ghi chú: Lấy thông tin chi tiết một hội đồng theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDefenseCommitteesDto>> GetCommittee(long id)
        {
            var committee = await _service.GetCommitteeById(id);
            if (committee == null)
                return NotFound(); // Ghi chú: Trả về 404 nếu không tìm thấy
            return Ok(committee); // Ghi chú: Trả về DTO của hội đồng
        }

        // POST: api/DefenseCommittees
        // Ghi chú: Tạo một hội đồng mới
        [HttpPost]
        public async Task<ActionResult<AdminDefenseCommitteesDto>> CreateCommittee([FromBody] CreateAdminDefenseCommitteeRequest request)
        {
            try
            {
                var committee = await _service.CreateCommittee(request);
                // Ghi chú: Trả về 201 Created với URL của hội đồng mới
                return CreatedAtAction(nameof(GetCommittee), new { id = committee.Id }, committee);
            }
            catch (Exception ex)
            {
                // Ghi chú: Trả về 400 nếu có lỗi (VD: tên hội đồng trùng, kỳ học không hợp lệ)
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DefenseCommittees/5
        // Ghi chú: Cập nhật thông tin một hội đồng
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommittee(long id, [FromBody] UpdateAdminDefenseCommitteeRequest request)
        {
            try
            {
                await _service.UpdateCommittee(id, request);
                return NoContent(); // Ghi chú: Trả về 204 nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                // Ghi chú: Trả về 400 nếu có lỗi
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/DefenseCommittees/5
        // Ghi chú: Xóa một hội đồng
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommittee(long id)
        {
            try
            {
                await _service.DeleteCommittee(id);
                return NoContent(); // Ghi chú: Trả về 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Ghi chú: Trả về 400 nếu có lỗi (VD: hội đồng không tồn tại)
                return BadRequest(ex.Message);
            }
        }
    }
}