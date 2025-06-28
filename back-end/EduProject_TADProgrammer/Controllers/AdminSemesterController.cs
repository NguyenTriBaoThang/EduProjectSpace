using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Wordprocessing;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminSemesterController : ControllerBase
    {
        private readonly LogService _logService;
        private readonly AdminSemesterService _semesterService;

        public AdminSemesterController(AdminSemesterService semesterService, LogService logService)
        {
            _semesterService = semesterService;
            _logService = logService;
        }

        // GET: api/Semesters
        // Lấy danh sách tất cả kỳ học.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminSemesterDto>>> GetSemesters()
        {
            var semesters = await _semesterService.GetAllSemesters();
            return Ok(semesters);
        }

        // GET: api/Semesters/5
        // Lấy thông tin một kỳ học.
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminSemesterDto>> GetSemester(long id)
        {
            var semester = await _semesterService.GetSemesterById(id);
            if (semester == null)
                return NotFound();
            return Ok(semester);
        }

        // POST: api/Semesters
        // Tạo kỳ học mới.
        [HttpPost]
        public async Task<ActionResult<AdminSemesterDto>> CreateSemester([FromBody] CreateAdminSemesterRequest request)
        {
            var semester = new Semester
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreatedAt = DateTime.UtcNow,
                Description = request.Description
            };
            var createdSemester = await _semesterService.CreateSemester(semester);

            if (!long.TryParse(User.FindFirst("id")?.Value, out var userId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }
            var fullName = User.FindFirst("fullName")?.Value ?? "Không rõ tên";
            var userName = User.FindFirst("userName")?.Value ?? "Không rõ tài khoản";
            await _logService.LogAction(userId, "CREATE", $"Người dùng {fullName}({userName}) đã tạo học kì {request.Name}.");

            return CreatedAtAction(nameof(GetSemester), new { id = createdSemester.Id }, createdSemester);
        }

        // POST: api/Semesters/import
        // Nhập danh sách kỳ học từ Excel.
        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportSemesters([FromBody] List<CreateAdminSemesterRequest> requests)
        {
            if (!long.TryParse(User.FindFirst("id")?.Value, out var userId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }
            var fullName = User.FindFirst("fullName")?.Value ?? "Không rõ tên";
            var userName = User.FindFirst("userName")?.Value ?? "Không rõ tài khoản";

            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    var semester = new Semester
                    {
                        Name = request.Name,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        CreatedAt = DateTime.UtcNow,
                        Description = request.Description
                    };
                    var createdSemester = await _semesterService.CreateSemester(semester);

                    await _logService.LogAction(userId, "CREATE", $"Người dùng {fullName}({userName}) đã tạo học kì {request.Name} thông qua excel.");

                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập kỳ học {request.Name}: {ex.Message}");
                }
            }
            return Ok(result);
        }

        // PUT: api/Semesters/5
        // Cập nhật thông tin kỳ học.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemester(long id, [FromBody] UpdateAdminSemesterRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID không khớp.");

            var semester = await _semesterService.GetById(id);
            if (semester == null)
                return NotFound();

            semester.Name = request.Name;
            semester.StartDate = request.StartDate;
            semester.EndDate = request.EndDate;
            semester.Description = request.Description;
            //semester.UpdatedAt = DateTime.UtcNow;

            await _semesterService.UpdateSemester(semester);

            if (!long.TryParse(User.FindFirst("id")?.Value, out var userId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });
            }
            var fullName = User.FindFirst("fullName")?.Value ?? "Không rõ tên";
            var userName = User.FindFirst("userName")?.Value ?? "Không rõ tài khoản";
            await _logService.LogAction(userId, "UPDATE", $"Người dùng {fullName}({userName}) đã tạo cập nhật học kì {semester.Name}.");

            return NoContent();
        }

        // DELETE: api/Semesters/5
        // Xóa kỳ học.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(long id)
        {
            try
            {
                var semester = await _semesterService.GetById(id);
                if (semester == null)
                    return NotFound(new { message = "Không tìm thấy kỳ học." });

                await _semesterService.DeleteSemester(id);

                if (!long.TryParse(User.FindFirst("id")?.Value, out var userId))
                    return BadRequest(new { message = "ID người dùng không hợp lệ hoặc thiếu thông tin." });

                var fullName = User.FindFirst("fullName")?.Value ?? "Không rõ tên";
                var userName = User.FindFirst("userName")?.Value ?? "Không rõ tài khoản";
                await _logService.LogAction(userId, "DELETE", $"Người dùng {fullName}({userName}) đã xóa học kỳ {semester.Name}.");

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // GET: api/Semesters/export
        // Xuất danh sách kỳ học sang Excel.
        [HttpGet("export")]
        public async Task<IActionResult> ExportSemesters()
        {
            var fileStream = await _semesterService.ExportSemestersToExcelAsync();

            var idClaim = User.FindFirst("id");
            if (!long.TryParse(idClaim.Value, out var userId))
            {
                return BadRequest(new { message = "ID người dùng không hợp lệ." });
            }
            var fullName = User.FindFirst("fullName");
            var userName = User.FindFirst("userName");
            await _logService.LogAction(userId, "EXPORT_EXCEL", $"Người dùng {fullName}({userName}) đã tạo xuất học kì thông qua excel.");

            return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "danh_sach_ky_hoc.xlsx");
        }
    }
}