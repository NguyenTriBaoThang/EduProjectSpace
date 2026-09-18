using System.ComponentModel.DataAnnotations;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduProject_TADProgrammer.Controllers;

[ApiController, Route("api/head"), Authorize(Roles = "ROLE_HEAD")]
public sealed class HeadWorkspaceController(ApplicationDbContext db, HeadGradeCriteriaService criteriaService) : ControllerBase
{
    private long HeadId => long.TryParse(User.FindFirst("id")?.Value, out var id) ? id : 0;
    private IQueryable<Project> Projects => db.Projects.Where(p => db.Users.Any(u => u.Id == HeadId && !u.Locked && u.DepartmentId != null && u.DepartmentId == p.Course.DepartmentId));
    private IQueryable<DefenseSchedule> Defenses => db.DefenseSchedules.Where(d => Projects.Any(p => p.Id == d.ProjectId));

    [HttpGet("defenses")]
    public async Task<IActionResult> GetDefenses([FromQuery] string? courseId, CancellationToken ct) => Ok(await Defenses
        .Where(d => courseId == null || d.Project.Course.CourseCode == courseId).OrderBy(d => d.StartTime)
        .Select(d => new { d.Id, d.ProjectId, ProjectName = d.Project.Title, GroupName = d.Project.Group.Name, d.StartTime, d.EndTime, d.Room, d.MeetingId }).ToListAsync(ct));

    [HttpGet("defenses/projects")]
    public async Task<IActionResult> GetProjects(CancellationToken ct) => Ok(await Projects.Select(p => new { p.Id, Name = p.Title }).ToListAsync(ct));

    [HttpGet("meetings")]
    public async Task<IActionResult> GetMeetings(CancellationToken ct) => Ok(await db.Meetings
        .Where(m => Projects.Any(p => p.GroupId == m.GroupId)).Select(m => new { m.Id, Name = m.Title, m.GroupId, GroupName = m.Group.Name, m.Location, m.StartTime, m.EndTime }).ToListAsync(ct));

    [HttpGet("groups")]
    public async Task<IActionResult> GetGroups(CancellationToken ct) => Ok(await db.Groups.Where(g => Projects.Any(p => p.Id == g.ProjectId && p.GroupId == g.Id))
        .Select(g => new { g.Id, g.Name }).ToListAsync(ct));

    public sealed class MeetingRequest
    {
        [Required, StringLength(255)] public string Name { get; set; } = "";
        [Range(1, long.MaxValue)] public long GroupId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required, StringLength(255)] public string Location { get; set; } = "";
    }
    [HttpPost("meetings")]
    public Task<IActionResult> CreateMeeting(MeetingRequest request, CancellationToken ct) => SaveMeeting(null, request, ct);
    [HttpPut("meetings/{id:long}")]
    public Task<IActionResult> UpdateMeeting(long id, MeetingRequest request, CancellationToken ct) => SaveMeeting(id, request, ct);
    private async Task<IActionResult> SaveMeeting(long? id, MeetingRequest request, CancellationToken ct)
    {
        if (!await Projects.AnyAsync(p => p.GroupId == request.GroupId, ct)) return NotFound();
        var item = id.HasValue ? await db.Meetings.SingleOrDefaultAsync(m => m.Id == id && Projects.Any(p => p.GroupId == m.GroupId), ct) : new Meeting { CreatedBy = HeadId };
        if (item == null) return NotFound();
        if (request.StartTime == default || request.StartTime >= request.EndTime) return BadRequest(new { message = "Thời gian họp không hợp lệ." });
        if (Uri.TryCreate(request.Location, UriKind.Absolute, out var uri) && uri.Scheme is not ("http" or "https")) return BadRequest(new { message = "Liên kết họp phải dùng HTTPS hoặc HTTP." });
        if (await db.Meetings.AnyAsync(m => (id == null || m.Id != id) && m.GroupId == request.GroupId && request.StartTime < m.EndTime && request.EndTime > m.StartTime, ct)) return Conflict(new { message = "Nhóm đã có cuộc họp trong thời gian này." });
        if (id.HasValue && item.GroupId != request.GroupId && await db.DefenseSchedules.AnyAsync(d => d.MeetingId == id, ct)) return Conflict(new { message = "Cuộc họp đang liên kết với lịch bảo vệ; không thể đổi nhóm." });
        item.Title = request.Name.Trim(); item.GroupId = request.GroupId; item.StartTime = request.StartTime;
        item.EndTime = request.EndTime; item.Location = request.Location.Trim();
        if (!id.HasValue) db.Meetings.Add(item);
        await db.SaveChangesAsync(ct); return Ok(new { item.Id });
    }
    [HttpDelete("meetings/{id:long}")]
    public async Task<IActionResult> DeleteMeeting(long id, CancellationToken ct)
    {
        var item = await db.Meetings.SingleOrDefaultAsync(m => m.Id == id && Projects.Any(p => p.GroupId == m.GroupId), ct);
        if (item == null) return NotFound();
        if (await db.DefenseSchedules.AnyAsync(d => d.MeetingId == id, ct)) return Conflict(new { message = "Cuộc họp đang được dùng cho lịch bảo vệ." });
        db.Meetings.Remove(item); await db.SaveChangesAsync(ct); return NoContent();
    }

    public sealed class DefenseRequest
    {
        [Range(1, long.MaxValue)] public long ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Required, StringLength(50)] public string Room { get; set; } = "";
        public long? MeetingId { get; set; }
    }

    [HttpPost("defenses")]
    public Task<IActionResult> CreateDefense(DefenseRequest request, CancellationToken ct) => SaveDefense(null, request, ct);
    [HttpPut("defenses/{id:long}")]
    public Task<IActionResult> UpdateDefense(long id, DefenseRequest request, CancellationToken ct) => SaveDefense(id, request, ct);

    private async Task<IActionResult> SaveDefense(long? id, DefenseRequest request, CancellationToken ct)
    {
        var project = await Projects.SingleOrDefaultAsync(p => p.Id == request.ProjectId, ct);
        if (project == null) return NotFound();
        var item = id.HasValue ? await Defenses.SingleOrDefaultAsync(d => d.Id == id, ct) : new DefenseSchedule();
        if (item == null) return NotFound();
        if (request.StartTime == default || request.StartTime >= request.EndTime || string.IsNullOrWhiteSpace(request.Room))
            return BadRequest(new { message = "Vui lòng kiểm tra thời gian và phòng bảo vệ." });
        if (await db.DefenseSchedules.AnyAsync(d => (id == null || d.Id != id) && d.ProjectId == project.Id, ct))
            return Conflict(new { message = "Đề tài đã có lịch bảo vệ." });
        if (await db.DefenseSchedules.AnyAsync(d => (id == null || d.Id != id) && d.Room == request.Room.Trim() && request.StartTime < d.EndTime && request.EndTime > d.StartTime, ct))
            return Conflict(new { message = "Phòng đã có lịch trong khoảng thời gian này." });
        if (request.MeetingId.HasValue && !await db.Meetings.AnyAsync(m => m.Id == request.MeetingId && m.GroupId == project.GroupId, ct))
            return BadRequest(new { message = "Cuộc họp không thuộc nhóm đồ án này." });
        item.ProjectId = project.Id; item.StartTime = request.StartTime; item.EndTime = request.EndTime;
        item.Room = request.Room.Trim(); item.MeetingId = request.MeetingId;
        if (!id.HasValue) db.DefenseSchedules.Add(item);
        await db.SaveChangesAsync(ct); return Ok(new { item.Id });
    }

    [HttpDelete("defenses/{id:long}")]
    public async Task<IActionResult> DeleteDefense(long id, CancellationToken ct)
    {
        var item = await Defenses.SingleOrDefaultAsync(d => d.Id == id, ct);
        if (item == null) return NotFound();
        db.DefenseSchedules.Remove(item); await db.SaveChangesAsync(ct); return NoContent();
    }

    public sealed class CriteriaRequest
    {
        public long Id { get; set; }
        [Range(1, long.MaxValue)] public long CourseId { get; set; }
        [Required, StringLength(100)] public string Name { get; set; } = "";
        [Range(0.001, 1)] public float Weight { get; set; }
        [StringLength(500)] public string Description { get; set; } = "";
        public GradeCriteria ToEntity() => new() { Id = Id, CourseId = CourseId, Name = Name.Trim(), Weight = Weight, Description = Description };
    }
    [HttpGet("criteria")]
    public async Task<IActionResult> GetCriteria() => Ok(await criteriaService.GetAllGradeCriteriaAsync(HeadId));
    [HttpPost("criteria")]
    public async Task<IActionResult> CreateCriteria(CriteriaRequest request)
    {
        try { request.Id = 0; return Ok(await criteriaService.CreateGradeCriteriaAsync(HeadId, request.ToEntity())); }
        catch (Exception e) { return BadRequest(new { message = e.Message }); }
    }
    [HttpPut("criteria/{id:long}")]
    public async Task<IActionResult> UpdateCriteria(long id, CriteriaRequest request)
    {
        try { request.Id = id; await criteriaService.UpdateGradeCriteriaAsync(HeadId, request.ToEntity()); return NoContent(); }
        catch (Exception e) { return BadRequest(new { message = e.Message }); }
    }
    [HttpDelete("criteria/{id:long}")]
    public async Task<IActionResult> DeleteCriteria(long id)
    {
        try { await criteriaService.DeleteGradeCriteriaAsync(HeadId, id); return NoContent(); }
        catch (Exception e) { return BadRequest(new { message = e.Message }); }
    }
}
