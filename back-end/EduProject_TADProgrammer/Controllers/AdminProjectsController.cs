// File: Controllers/AdminProjectsController.cs
// Mục đích: Định nghĩa API controller để xử lý các yêu cầu HTTP cho quản lý đề tài đồ án.
// Hỗ trợ chức năng:
//   Quản lý đề tài đồ án (xem, tạo, cập nhật, xóa, nhập hàng loạt đề tài, lấy danh sách môn học).
//   Ghi nhật ký hành động (log) cho các thao tác tạo, cập nhật, xóa đề tài.

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EduProject_TADProgrammer.Controllers
{
    // Định nghĩa route cơ bản cho API: /api/AdminProjects
    [Route("api/[controller]")]
    [ApiController]
    // Chỉ cho phép người dùng có vai trò ROLE_ADMIN truy cập
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminProjectsController : ControllerBase
    {
        // Dịch vụ xử lý logic nghiệp vụ cho đề tài đồ án
        private readonly AdminProjectService _projectService;

        // Constructor: Tiêm dịch vụ AdminProjectService thông qua dependency injection
        public AdminProjectsController(AdminProjectService projectService)
        {
            _projectService = projectService;
        }

        // Endpoint: GET /api/AdminProjects
        // Mục đích: Lấy danh sách tất cả đề tài đồ án
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminProjectDto>>> GetProjects()
        {
            // Gọi dịch vụ để lấy danh sách đề tài
            var projects = await _projectService.GetAllProjects();
            // Trả về danh sách AdminProjectDto với mã trạng thái 200 OK
            return Ok(projects);
        }

        // Endpoint: GET /api/AdminProjects/courses
        // Mục đích: Lấy danh sách tất cả môn học
        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            // Gọi dịch vụ để lấy danh sách môn học
            var courses = await _projectService.GetAllCoursesAsync();
            if (courses == null || !courses.Any())
            {
                // Trả về 404 nếu không tìm thấy môn học nào
                return NotFound("Không tìm thấy môn học nào.");
            }
            // Trả về danh sách môn học với mã trạng thái 200 OK
            return Ok(courses);
        }

        // Endpoint: GET /api/AdminProjects/{id}
        // Mục đích: Lấy thông tin chi tiết một đề tài theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminProjectDto>> GetProject(long id)
        {
            // Gọi dịch vụ để lấy đề tài theo ID
            var project = await _projectService.GetProjectById(id);
            if (project == null)
            {
                // Trả về 404 nếu không tìm thấy đề tài
                return NotFound();
            }
            // Trả về AdminProjectDto với mã trạng thái 200 OK
            return Ok(project);
        }

        // Endpoint: POST /api/AdminProjects
        // Mục đích: Tạo một đề tài đồ án mới
        [HttpPost]
        public async Task<ActionResult<AdminProjectDto>> CreateProject([FromBody] CreateAdminProjectRequest request)
        {
            // Tạo entity Project từ dữ liệu yêu cầu
            var project = new Project
            {
                ProjectCode = request.ProjectCode,
                Title = request.Title,
                CourseId = request.CourseId,
                Status = request.Status ?? "PENDING", // Mặc định là PENDING nếu không cung cấp
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            // Gọi dịch vụ để tạo đề tài
            var createdProject = await _projectService.CreateProject(project);
            // Ghi log hành động tạo đề tài
            await _projectService.LogAction(createdProject.Id, "CREATE_PROJECT", $"Project {createdProject.ProjectCode} created.");
            // Trả về 201 Created với URL của đề tài mới và AdminProjectDto
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        // Endpoint: POST /api/AdminProjects/import
        // Mục đích: Nhập hàng loạt đề tài đồ án từ danh sách yêu cầu
        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportProjects([FromBody] List<CreateAdminProjectRequest> requests)
        {
            // Khởi tạo kết quả nhập dữ liệu
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    // Tạo entity Project từ dữ liệu yêu cầu
                    var project = new Project
                    {
                        ProjectCode = request.ProjectCode,
                        Title = request.Title,
                        CourseId = request.CourseId,
                        Status = request.Status ?? "PENDING", // Mặc định là PENDING nếu không cung cấp
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    // Gọi dịch vụ để tạo đề tài
                    var createdProject = await _projectService.CreateProject(project);
                    // Ghi log hành động tạo đề tài qua import
                    await _projectService.LogAction(createdProject.Id, "CREATE_PROJECT", $"Project {createdProject.ProjectCode} created via import.");
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    // Thêm thông báo lỗi chi tiết vào danh sách
                    result.Errors.Add($"Lỗi khi nhập đề tài {request.ProjectCode}: {ex.Message}");
                }
            }
            // Trả về kết quả nhập dữ liệu với mã trạng thái 200 OK
            return Ok(result);
        }

        // Endpoint: PUT /api/AdminProjects/{id}
        // Mục đích: Cập nhật thông tin một đề tài đồ án
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(long id, [FromBody] UpdateAdminProjectRequest request)
        {
            // Kiểm tra ID trong URL và request có khớp không
            if (id != request.Id)
            {
                return BadRequest("ID không khớp.");
            }

            // Lấy entity Project theo ID
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                // Trả về 404 nếu không tìm thấy đề tài
                return NotFound();
            }

            // Cập nhật thông tin đề tài
            project.ProjectCode = request.ProjectCode;
            project.Title = request.Title;
            project.CourseId = request.CourseId;
            project.Status = request.Status;
            project.UpdatedAt = DateTime.UtcNow;

            // Gọi dịch vụ để lưu thay đổi
            await _projectService.UpdateProject(project);
            // Ghi log hành động cập nhật đề tài
            await _projectService.LogAction(id, "UPDATE_PROJECT", $"Project {project.ProjectCode} updated.");
            // Trả về 204 No Content nếu cập nhật thành công
            return NoContent();
        }

        // Endpoint: DELETE /api/AdminProjects/{id}
        // Mục đích: Xóa một đề tài đồ án
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            // Lấy entity Project theo ID
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                // Trả về 404 nếu không tìm thấy đề tài
                return NotFound();
            }

            // Gọi dịch vụ để xóa đề tài
            await _projectService.DeleteProject(id);
            // Ghi log hành động xóa đề tài
            await _projectService.LogAction(id, "DELETE_PROJECT", $"Project {project.ProjectCode} deleted.");
            // Trả về 204 No Content nếu xóa thành công
            return NoContent();
        }
    }
}