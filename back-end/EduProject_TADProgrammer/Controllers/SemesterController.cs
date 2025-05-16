using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class SemestersController : ControllerBase
    {
        private readonly SemesterService _semesterService;

        public SemestersController(SemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        // GET: api/Semesters
        // Lấy danh sách tất cả kỳ học.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetSemesters()
        {
            var semesters = await _semesterService.GetAllSemesters();
            return Ok(semesters);
        }

        // GET: api/Semesters/5
        // Lấy thông tin một kỳ học.
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetSemester(long id)
        {
            var semester = await _semesterService.GetSemesterById(id);
            if (semester == null)
                return NotFound();
            return Ok(semester);
        }

        // POST: api/Semesters
        // Tạo kỳ học mới.
        [HttpPost]
        public async Task<ActionResult<SemesterDto>> CreateSemester([FromBody] CreateSemesterRequest request)
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
            //await _semesterService.LogAction(createdSemester.Id, "CREATE_SEMESTER", $"Semester {createdSemester.Name} created.");
            return CreatedAtAction(nameof(GetSemester), new { id = createdSemester.Id }, createdSemester);
        }

        // POST: api/Semesters/import
        // Nhập danh sách kỳ học từ Excel.
        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportSemesters([FromBody] List<CreateSemesterRequest> requests)
        {
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
                    //await _semesterService.LogAction(createdSemester.Id, "CREATE_SEMESTER", $"Semester {createdSemester.Name} created via import.");
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
        public async Task<IActionResult> UpdateSemester(long id, [FromBody] UpdateSemesterRequest request)
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
            //await _semesterService.LogAction(id, "UPDATE_SEMESTER", $"Semester {semester.Name} updated.");
            return NoContent();
        }

        // DELETE: api/Semesters/5
        // Xóa kỳ học.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(long id)
        {
            var semester = await _semesterService.GetById(id);
            if (semester == null)
                return NotFound();

            await _semesterService.DeleteSemester(id);
            //await _semesterService.LogAction(id, "DELETE_SEMESTER", $"Semester {semester.Name} deleted.");
            return NoContent();
        }

        // GET: api/Semesters/export
        // Xuất danh sách kỳ học sang Excel.
        [HttpGet("export")]
        public async Task<IActionResult> ExportSemesters()
        {
            var fileStream = await _semesterService.ExportSemestersToExcelAsync();
            return File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "danh_sach_ky_hoc.xlsx");
        }
    }

    public class CreateSemesterRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateSemesterRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
    }
}