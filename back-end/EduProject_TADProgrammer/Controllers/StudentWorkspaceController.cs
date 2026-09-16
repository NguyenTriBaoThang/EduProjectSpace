using System.ComponentModel.DataAnnotations;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduProject_TADProgrammer.Controllers;

[ApiController]
[Route("api/student")]
[Authorize(Roles = "ROLE_STUDENT")]
public sealed class StudentWorkspaceController(ApplicationDbContext db, IWebHostEnvironment environment) : ControllerBase
{
    private long StudentId => long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
    private IQueryable<GroupMember> Memberships => db.GroupMembers.Where(m => m.StudentId == StudentId && StudentId > 0);
    private IQueryable<Project> Projects => db.Projects.Where(p => Memberships.Any(m => m.GroupId == p.GroupId && m.Group.ProjectId == p.Id));
    private IQueryable<Submission> Submissions => db.Submissions.Where(s => Projects.Any(p => p.Id == s.ProjectId && p.GroupId == s.GroupId));

    [HttpGet("projects")]
    public async Task<IActionResult> GetProjects(CancellationToken ct) => Ok(await Projects.AsNoTracking()
        .OrderByDescending(p => p.UpdatedAt)
        .Select(p => new {
            p.Id, p.Title, p.Description, p.ProjectCode, p.CourseId, CourseName = p.Course.Name,
            p.GroupId, GroupName = p.Group.Name, p.Status, p.ApprovalStatus, p.ApprovalReason,
            p.UpdatedAt,
            TotalTasks = p.Tasks.Count(t => t.GroupId == null || t.GroupId == p.GroupId),
            DoneTasks = p.Tasks.Count(t => (t.GroupId == null || t.GroupId == p.GroupId) && t.Status.ToUpper() == "DONE")
        }).ToListAsync(ct));

    [HttpGet("projects/{id:long}")]
    public async Task<IActionResult> GetProject(long id, CancellationToken ct)
    {
        var project = await Projects.AsNoTracking().Where(p => p.Id == id).Select(p => new {
            p.Id, p.Title, p.Description, p.ProjectCode, p.CourseId, CourseName = p.Course.Name,
            p.GroupId, GroupName = p.Group.Name, p.Status, p.ApprovalStatus, p.ApprovalReason,
            p.UpdatedAt
        }).SingleOrDefaultAsync(ct);
        if (project == null) return NotFound();
        var tasks = await db.Tasks.AsNoTracking().Where(t => t.ProjectId == id && (t.GroupId == null || t.GroupId == project.GroupId))
            .OrderBy(t => t.Deadline).Select(t => new { t.Id, t.Title, t.Description, t.Status, t.Deadline }).ToListAsync(ct);
        var members = await Memberships.Where(m => m.GroupId == project.GroupId)
            .SelectMany(m => m.Group.GroupMembers).Select(m => new { m.StudentId, m.Student.FullName, m.IsLeader }).ToListAsync(ct);
        var versions = await db.ProjectVersions.AsNoTracking().Where(v => v.ProjectId == id)
            .OrderByDescending(v => v.VersionNumber).Select(v => new { v.Id, v.Title, v.Description, v.VersionNumber, v.CreatedAt }).ToListAsync(ct);
        return Ok(new { project, tasks, members, versions });
    }

    public sealed class ProposalRequest
    {
        [Required, StringLength(255, MinimumLength = 3)] public string Title { get; set; } = "";
        [Required, StringLength(10000, MinimumLength = 10)] public string Description { get; set; } = "";
    }

    // Groups are allocated by lecturers. A proposal edits that group's allocated project,
    // never accepts an arbitrary group/student/course supplied by the browser.
    [HttpPut("projects/{id:long}/proposal")]
    public async Task<IActionResult> Propose(long id, ProposalRequest request, CancellationToken ct)
    {
        var project = await Projects.SingleOrDefaultAsync(p => p.Id == id, ct);
        if (project == null) return NotFound();
        if (project.ApprovalStatus.Equals("APPROVED", StringComparison.OrdinalIgnoreCase) || project.Status.Equals("COMPLETED", StringComparison.OrdinalIgnoreCase))
            return Conflict(new { message = "Đề tài đã được duyệt. Liên hệ giảng viên để thay đổi." });
        if (request.Title.Trim().Length < 3 || request.Description.Trim().Length < 10)
            return BadRequest(new { message = "Vui lòng nhập tiêu đề và mô tả đầy đủ." });
        // Every revision is retained; version IDs need not be supplied by the client.
        db.ProjectVersions.Add(new ProjectVersion {
            ProjectId = id, Title = project.Title, Description = project.Description,
            VersionNumber = (await db.ProjectVersions.Where(v => v.ProjectId == id).MaxAsync(v => (int?)v.VersionNumber, ct) ?? 0) + 1
        });
        project.Title = request.Title.Trim(); project.Description = request.Description.Trim();
        project.ApprovalStatus = "PENDING"; project.ApprovalReason = null; project.Status = "PROPOSED";
        project.UpdatedAt = DateTime.UtcNow;
        await db.SaveChangesAsync(ct);
        return Ok(new { project.Id, project.Title, project.ApprovalStatus });
    }

    [HttpGet("submissions")]
    public async Task<IActionResult> GetSubmissions([FromQuery] long? projectId, CancellationToken ct)
    {
        if (projectId.HasValue && !await Projects.AnyAsync(p => p.Id == projectId, ct)) return NotFound();
        return Ok(await Submissions.AsNoTracking().Where(s => projectId == null || s.ProjectId == projectId)
            .OrderByDescending(s => s.SubmittedAt).Select(s => new {
                s.Id, s.ProjectId, ProjectTitle = s.Project.Title, s.TaskId, TaskTitle = s.TaskId == null ? "Báo cáo đồ án" : s.Task.Title,
                s.FilePath, s.Version, s.Status, s.SubmittedAt, StudentName = s.Student.FullName
            }).ToListAsync(ct));
    }

    [HttpGet("submissions/{id:long}")]
    public async Task<IActionResult> GetSubmission(long id, CancellationToken ct)
    {
        var submission = await Submissions.AsNoTracking().Where(s => s.Id == id).Select(s => new {
            s.Id, s.ProjectId, ProjectTitle = s.Project.Title, s.TaskId, TaskTitle = s.TaskId == null ? "Báo cáo đồ án" : s.Task.Title,
            s.FilePath, s.Version, s.Status, s.SubmittedAt, StudentName = s.Student.FullName
        }).SingleOrDefaultAsync(ct);
        if (submission == null) return NotFound();
        var versions = await db.SubmissionVersions.Where(v => v.SubmissionId == id).OrderByDescending(v => v.VersionNumber)
            .Select(v => new { v.Id, v.FilePath, v.VersionNumber, v.CreatedAt }).ToListAsync(ct);
        var feedback = await db.Feedbacks.Where(f => f.SubmissionId == id).OrderByDescending(f => f.CreatedAt)
            .Select(f => new { f.Id, f.Content, f.CreatedAt, LecturerName = f.Lecturer.FullName }).ToListAsync(ct);
        return Ok(new { submission, versions, feedback });
    }

    public sealed class SubmissionRequest
    {
        [Range(1, long.MaxValue)] public long ProjectId { get; set; }
        public long? TaskId { get; set; }
        [Required] public IFormFile File { get; set; } = null!;
    }

    [HttpPost("submissions")]
    [RequestSizeLimit(21 * 1024 * 1024)]
    public async Task<IActionResult> Submit([FromForm] SubmissionRequest request, CancellationToken ct)
    {
        var project = await Projects.SingleOrDefaultAsync(p => p.Id == request.ProjectId, ct);
        if (project == null) return NotFound();
        if (!project.ApprovalStatus.Equals("APPROVED", StringComparison.OrdinalIgnoreCase))
            return Conflict(new { message = "Đề tài cần được duyệt trước khi nộp bài." });
        if (request.TaskId.HasValue) {
            var task = await db.Tasks.SingleOrDefaultAsync(t => t.Id == request.TaskId && t.ProjectId == project.Id && (t.GroupId == null || t.GroupId == project.GroupId), ct);
            if (task == null) return BadRequest(new { message = "Nhiệm vụ không thuộc đồ án của bạn." });
            if (task.Deadline.HasValue && task.Deadline < DateTime.UtcNow) return Conflict(new { message = "Đã hết hạn nộp. Liên hệ giảng viên để gia hạn." });
        }
        var extension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
        if (request.File.Length is <= 0 or > 20 * 1024 * 1024 || !new[] { ".pdf", ".docx", ".xlsx", ".zip", ".txt", ".png", ".jpg", ".jpeg" }.Contains(extension))
            return BadRequest(new { message = "Chấp nhận PDF, DOCX, XLSX, ZIP, TXT hoặc ảnh; tối đa 20 MB." });
        var relative = $"submissions/{Guid.NewGuid():N}{extension}";
        var fullPath = PrivateFileAccessService.ResolvePath(environment.WebRootPath, relative);
        if (fullPath == null) return Problem("Không thể tạo đường dẫn lưu bài nộp.");
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        try {
            await using (var stream = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                await request.File.CopyToAsync(stream, ct);
            // Separate immutable submission records avoid overwriting another member's upload.
            var submission = new Submission { ProjectId = project.Id, GroupId = project.GroupId, StudentId = StudentId,
                TaskId = request.TaskId, FilePath = relative, Version = 1, Status = "Submitted" };
            db.Submissions.Add(submission);
            await db.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetSubmission), new { id = submission.Id }, new { submission.Id });
        } catch { System.IO.File.Delete(fullPath); throw; }
    }

    [HttpGet("grades")]
    public async Task<IActionResult> GetGrades([FromQuery] long? projectId, CancellationToken ct)
    {
        if (projectId.HasValue && !await Projects.AnyAsync(p => p.Id == projectId, ct)) return NotFound();
        return Ok(await db.Grades.AsNoTracking().Where(g => Projects.Any(p => p.Id == g.ProjectId && p.GroupId == g.GroupId)
            && (g.StudentId == null || g.StudentId == StudentId) && (projectId == null || g.ProjectId == projectId))
            .OrderByDescending(g => g.GradedAt).Select(g => new { g.Id, g.ProjectId, ProjectTitle = g.Project.Title,
                Criteria = g.Criteria.Name, g.Criteria.Weight, g.Score, g.Comment, g.GradedAt, LecturerName = g.GradedByUser.FullName }).ToListAsync(ct));
    }

    [HttpGet("schedule")]
    public async Task<IActionResult> GetSchedule(CancellationToken ct)
    {
        var meetings = await db.Meetings.AsNoTracking().Where(m => Memberships.Any(g => g.GroupId == m.GroupId))
            .Select(m => new { m.Id, m.Title, m.StartTime, m.EndTime, m.Location, Kind = "meeting" }).ToListAsync(ct);
        var defenses = await db.DefenseSchedules.AsNoTracking().Where(d => Projects.Any(p => p.Id == d.ProjectId))
            .Select(d => new { d.Id, Title = d.Project.Title, d.StartTime, d.EndTime, Location = d.Room, Kind = "defense" }).ToListAsync(ct);
        return Ok(meetings.Concat(defenses).OrderBy(e => e.StartTime));
    }
}
