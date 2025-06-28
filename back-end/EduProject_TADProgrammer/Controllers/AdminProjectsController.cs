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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ROLE_ADMIN")]
    public class AdminProjectsController : ControllerBase
    {
        private readonly AdminProjectService _projectService;

        public AdminProjectsController(AdminProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminProjectDto>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _projectService.GetAllCoursesAsync();
            if (courses == null || !courses.Any())
            {
                return NotFound("Không tìm thấy môn học nào.");
            }
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminProjectDto>> GetProject(long id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<AdminProjectDto>> CreateProject([FromBody] CreateAdminProjectRequest request)
        {
            var project = new Project
            {
                ProjectCode = request.ProjectCode,
                Title = request.Title,
                Description = request.Description,
                CourseId = request.CourseId,
                Status = request.Status ?? "PENDING",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var createdProject = await _projectService.CreateProject(project);
            await _projectService.LogAction(createdProject.Id, "CREATE_PROJECT", $"Project {createdProject.ProjectCode} created.");
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        [HttpPost("import")]
        public async Task<ActionResult<ImportResult>> ImportProjects([FromBody] List<CreateAdminProjectRequest> requests)
        {
            var result = new ImportResult { SuccessCount = 0, FailedCount = 0, Errors = new List<string>() };
            foreach (var request in requests)
            {
                try
                {
                    var project = new Project
                    {
                        ProjectCode = request.ProjectCode,
                        Title = request.Title,
                        Description = request.Description,
                        CourseId = request.CourseId,
                        Status = request.Status ?? "PENDING",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };
                    var createdProject = await _projectService.CreateProject(project);
                    await _projectService.LogAction(createdProject.Id, "CREATE_PROJECT", $"Project {createdProject.ProjectCode} created via import.");
                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailedCount++;
                    result.Errors.Add($"Lỗi khi nhập đề tài {request.ProjectCode}: {ex.Message}");
                }
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(long id, [FromBody] UpdateAdminProjectRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("ID không khớp.");
            }

            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Title = request.Title;
            project.Description = request.Description;
            project.Status = request.Status;
            project.UpdatedAt = DateTime.UtcNow;

            await _projectService.UpdateProject(project);
            await _projectService.LogAction(id, "UPDATE_PROJECT", $"Project {project.ProjectCode} updated.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            var project = await _projectService.GetById(id);
            if (project == null)
            {
                return NotFound();
            }

            await _projectService.DeleteProject(id);
            await _projectService.LogAction(id, "DELETE_PROJECT", $"Project {project.ProjectCode} deleted.");
            return NoContent();
        }
    }
}