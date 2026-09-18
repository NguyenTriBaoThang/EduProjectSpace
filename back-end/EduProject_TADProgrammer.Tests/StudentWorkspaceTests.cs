using System.Net;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Services;
using EduProject_TADProgrammer.Middleware;
using EduProject_TADProgrammer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;

namespace EduProject_TADProgrammer.Tests;

public sealed class StudentWorkspaceTests
{
    private sealed class Fixture : IAsyncDisposable
    {
        public required WebApplication App { get; init; }
        public required HttpClient Client { get; init; }
        public required string Root { get; init; }
        public async ValueTask DisposeAsync() { Client.Dispose(); await App.DisposeAsync(); Directory.Delete(Root, true); }
    }

    private static async System.Threading.Tasks.Task<Fixture> Start()
    {
        var root = Path.Combine(Path.GetTempPath(), "edu-student-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = root });
        builder.Logging.ClearProviders();
        builder.WebHost.UseTestServer();
        var name = Guid.NewGuid().ToString();
        builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase(name, b => b.EnableNullChecks(false)));
        builder.Services.AddAuthentication("test").AddScheme<AuthenticationSchemeOptions, Authentication>("test", _ => { });
        builder.Services.AddAuthorization();
        builder.Services.AddScoped<HeadGradeCriteriaService>();
        builder.Services.AddControllers(o => o.Filters.Add<HeadScopeFilter>()).AddApplicationPart(typeof(StudentWorkspaceController).Assembly);
        var app = builder.Build(); app.UseAuthentication(); app.UseAuthorization(); app.MapControllers();
        using (var scope = app.Services.CreateScope()) {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            db.Users.AddRange(new User { Id = 100, FullName = "Student A" }, new User { Id = 200, FullName = "Student B" });
            db.Courses.Add(new Course { Id = 1, Name = "Software" });
            db.Groups.AddRange(new Group { Id = 10, ProjectId = 1, Name = "A" }, new Group { Id = 20, ProjectId = 2, Name = "B" });
            db.Projects.AddRange(new Project { Id = 1, GroupId = 10, CourseId = 1, Title = "Own project", Description = "Own description", ProjectCode = "P1", Status = "PROPOSED", ApprovalStatus = "PENDING" }, new Project { Id = 2, GroupId = 20, CourseId = 1, Title = "Private project", ProjectCode = "P2", ApprovalStatus = "APPROVED" });
            db.GroupMembers.AddRange(new GroupMember { Id = 1, StudentId = 100, GroupId = 10 }, new GroupMember { Id = 2, StudentId = 200, GroupId = 20 });
            db.GradeCriteria.Add(new GradeCriteria { Id = 1, CourseId = 1, Name = "Report", Weight = 1 });
            db.Grades.AddRange(new Grade { Id = 1, ProjectId = 1, GroupId = 10, StudentId = 100, CriteriaId = 1, Score = 8, GradedBy = 100 }, new Grade { Id = 2, ProjectId = 1, GroupId = 10, StudentId = 200, CriteriaId = 1, Score = 4, GradedBy = 100 });
            db.Submissions.Add(new Submission { Id = 2, ProjectId = 2, GroupId = 20, StudentId = 200, FilePath = "submissions/private.pdf", Status = "Submitted" });
            db.Tasks.AddRange(new Entities.Task { Id = 1, ProjectId = 1, GroupId = 10, Title = "Expired", Deadline = DateTime.UtcNow.AddDays(-1) }, new Entities.Task { Id = 2, ProjectId = 2, GroupId = 20, Title = "Private" });
            await db.SaveChangesAsync();
        }
        await app.StartAsync(); var client = app.GetTestClient(); client.DefaultRequestHeaders.Add("X-Student", "100");
        return new Fixture { App = app, Client = client, Root = root };
    }

    [Fact]
    public async System.Threading.Tasks.Task ListsOnlyOwnProjectsAndPersonalGrades()
    {
        await using var fixture = await Start();
        var projects = await fixture.Client.GetFromJsonAsync<JsonElement>("/api/student/projects");
        Assert.Single(projects.EnumerateArray()); Assert.Equal(1, projects[0].GetProperty("id").GetInt64());
        var grades = await fixture.Client.GetFromJsonAsync<JsonElement>("/api/student/grades");
        Assert.Single(grades.EnumerateArray()); Assert.Equal(8, grades[0].GetProperty("score").GetSingle());
    }

    [Theory]
    [InlineData("/api/student/projects/2")]
    [InlineData("/api/student/submissions/2")]
    [InlineData("/api/student/grades?projectId=2")]
    [InlineData("/api/student/submissions?projectId=2")]
    public async System.Threading.Tasks.Task CannotReadOtherGroups(string path)
    {
        await using var fixture = await Start();
        Assert.Equal(HttpStatusCode.NotFound, (await fixture.Client.GetAsync(path)).StatusCode);
    }

    [Fact]
    public async System.Threading.Tasks.Task ProposalPersistsAndKeepsHistory()
    {
        await using var fixture = await Start();
        var response = await fixture.Client.PutAsJsonAsync("/api/student/projects/1/proposal", new { title = "New proposal", description = "A real project description" });
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var data = await fixture.Client.GetFromJsonAsync<JsonElement>("/api/student/projects/1");
        Assert.Equal("New proposal", data.GetProperty("project").GetProperty("title").GetString());
        Assert.Equal("Own project", data.GetProperty("versions")[0].GetProperty("title").GetString());
        Assert.Equal(HttpStatusCode.NotFound, (await fixture.Client.PutAsJsonAsync("/api/student/projects/2/proposal", new { title = "Attack", description = "Other group's data" })).StatusCode);
    }

    [Fact]
    public async System.Threading.Tasks.Task InvalidProposalIsRejected()
    {
        await using var fixture = await Start();
        Assert.Equal(HttpStatusCode.BadRequest, (await fixture.Client.PutAsJsonAsync("/api/student/projects/1/proposal", new { title = "", description = "" })).StatusCode);
    }

    private static MultipartFormDataContent Upload(long projectId, long? taskId = null, string filename = "report.pdf")
    {
        var form = new MultipartFormDataContent(); form.Add(new StringContent(projectId.ToString()), "projectId");
        if (taskId.HasValue) form.Add(new StringContent(taskId.ToString()!), "taskId");
        form.Add(new ByteArrayContent("%PDF-1.7 test"u8.ToArray()), "file", filename); return form;
    }

    [Fact]
    public async System.Threading.Tasks.Task UploadChecksApprovalGroupTaskDeadlineAndFileType()
    {
        await using var fixture = await Start();
        using (var form = Upload(1)) Assert.Equal(HttpStatusCode.Conflict, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        using (var scope = fixture.App.Services.CreateScope()) {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            (await db.Projects.FindAsync(1L))!.ApprovalStatus = "APPROVED"; await db.SaveChangesAsync();
        }
        using (var form = Upload(2)) Assert.Equal(HttpStatusCode.NotFound, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        using (var form = Upload(1, 2)) Assert.Equal(HttpStatusCode.BadRequest, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        using (var form = Upload(1, 1)) Assert.Equal(HttpStatusCode.Conflict, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        using (var form = Upload(1, filename: "attack.html")) Assert.Equal(HttpStatusCode.BadRequest, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        using (var form = Upload(1)) Assert.Equal(HttpStatusCode.Created, (await fixture.Client.PostAsync("/api/student/submissions", form)).StatusCode);
        var rows = await fixture.Client.GetFromJsonAsync<JsonElement>("/api/student/submissions");
        Assert.Single(rows.EnumerateArray());
        var path = rows[0].GetProperty("filePath").GetString()!;
        Assert.True(File.Exists(Path.Combine(fixture.Root, path)));
    }

    [Fact]
    public async System.Threading.Tasks.Task AnonymousAndWrongRoleAreRejected()
    {
        await using var fixture = await Start(); fixture.Client.DefaultRequestHeaders.Remove("X-Student");
        Assert.Equal(HttpStatusCode.Unauthorized, (await fixture.Client.GetAsync("/api/student/projects")).StatusCode);
        fixture.Client.DefaultRequestHeaders.Add("X-Student", "100"); fixture.Client.DefaultRequestHeaders.Add("X-Role", "ROLE_ADMIN");
        Assert.Equal(HttpStatusCode.Forbidden, (await fixture.Client.GetAsync("/api/student/projects")).StatusCode);
    }

    private static async System.Threading.Tasks.Task ConfigureHead(Fixture fixture)
    {
        fixture.Client.DefaultRequestHeaders.Add("X-Role", "ROLE_HEAD");
        using var scope = fixture.App.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Roles.Add(new Role { Id = 4, Name = "ROLE_HEAD" });
        db.Departments.AddRange(new Department { Id = 1, FacultyName = "Own department", FacultyCode = "CS" }, new Department { Id = 2, FacultyName = "Other department", FacultyCode = "OTHER" });
        (await db.Users.FindAsync(100L))!.DepartmentId = 1; (await db.Users.FindAsync(100L))!.RoleId = 4;
        (await db.Courses.FindAsync(1L))!.DepartmentId = 1;
        db.Courses.Add(new Course { Id = 2, Name = "Private course", DepartmentId = 2 });
        (await db.Projects.FindAsync(2L))!.CourseId = 2;
        await db.SaveChangesAsync();
    }

    [Fact]
    public async System.Threading.Tasks.Task DefenseCanBeCreatedEditedAndDeletedWithDepartmentScope()
    {
        await using var fixture = await Start(); await ConfigureHead(fixture);
        var start = DateTime.UtcNow.AddDays(3);
        var request = new { projectId = 1, startTime = start, endTime = start.AddHours(1), room = "A101" };
        var response = await fixture.Client.PostAsJsonAsync("/api/head/defenses", request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var id = (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt64();
        Assert.Equal(HttpStatusCode.OK, (await fixture.Client.PutAsJsonAsync($"/api/head/defenses/{id}", new { projectId = 1, startTime = start, endTime = start.AddHours(2), room = "B101" })).StatusCode);
        var list = await fixture.Client.GetFromJsonAsync<JsonElement>("/api/head/defenses");
        Assert.Equal("B101", list[0].GetProperty("room").GetString());
        Assert.Equal(HttpStatusCode.NotFound, (await fixture.Client.PostAsJsonAsync("/api/head/defenses", new { projectId = 2, startTime = start, endTime = start.AddHours(1), room = "C101" })).StatusCode);
        Assert.Equal(HttpStatusCode.NoContent, (await fixture.Client.DeleteAsync($"/api/head/defenses/{id}")).StatusCode);
    }

    [Fact]
    public async System.Threading.Tasks.Task MeetingRejectsOverlapAndPreservesDefenseReference()
    {
        await using var fixture = await Start(); await ConfigureHead(fixture);
        var start = DateTime.UtcNow.AddDays(2);
        var request = new { name = "Review", groupId = 10, startTime = start, endTime = start.AddHours(1), location = "https://meet.google.com/abc-defg-hij" };
        var response = await fixture.Client.PostAsJsonAsync("/api/head/meetings", request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var id = (await response.Content.ReadFromJsonAsync<JsonElement>()).GetProperty("id").GetInt64();
        Assert.Equal(HttpStatusCode.Conflict, (await fixture.Client.PostAsJsonAsync("/api/head/meetings", request)).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await fixture.Client.PostAsJsonAsync("/api/head/defenses", new { projectId = 1, startTime = start, endTime = start.AddHours(1), room = "A", meetingId = id })).StatusCode);
        Assert.Equal(HttpStatusCode.Conflict, (await fixture.Client.DeleteAsync($"/api/head/meetings/{id}")).StatusCode);
    }

    [Fact]
    public async System.Threading.Tasks.Task CriteriaCannotMoveToAnotherDepartment()
    {
        await using var fixture = await Start(); await ConfigureHead(fixture);
        var response = await fixture.Client.PutAsJsonAsync("/api/head/criteria/1", new { courseId = 2, name = "Cross department", weight = 0.5, description = "test" });
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
        using var scope = fixture.App.Services.CreateScope();
        Assert.Equal(1, (await scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().GradeCriteria.FindAsync(1L))!.CourseId);
    }

    [Fact]
    public async System.Threading.Tasks.Task FirstGradeAndRevisionUseRealForeignKeysAndSequentialVersions()
    {
        await using var fixture = await Start();
        using var scope = fixture.App.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Grades.RemoveRange(db.Grades);
        db.LecturerCourses.Add(new LecturerCourses { LecturerId = 200, CourseId = 1 });
        await db.SaveChangesAsync();
        var service = new LecturerReviewService(db, new ConfigurationBuilder().Build());
        var dto = new SaveGradesLecturerReviewDto { StudentGrades = new() { new StudentGradeInputLecturerReviewDto { StudentId = 100, Comment = "First score", CriteriaGrades = new() { new CriteriaGradeInputLecturerReviewDto { CriteriaId = 1, Score = 0 } } } } };
        await service.SaveProjectGradesAsync(200, "P1", dto);
        var grade = await db.Grades.SingleAsync(); var first = await db.GradeVersions.SingleAsync();
        Assert.Equal(grade.Id, first.GradeId); Assert.NotEqual(0, first.GradeId); Assert.Equal(1, first.VersionNumber);
        dto.StudentGrades[0].CriteriaGrades[0].Score = 8;
        await service.SaveProjectGradesAsync(200, "P1", dto);
        Assert.Equal(new[] { 1, 2 }, await db.GradeVersions.OrderBy(v => v.VersionNumber).Select(v => v.VersionNumber).ToArrayAsync());
        Assert.Equal(8, grade.Score); Assert.Equal(2, await db.Notifications.CountAsync());
    }

    [Fact]
    public async System.Threading.Tasks.Task GradesRejectDuplicateCriteriaAndOutOfRangeScores()
    {
        await using var fixture = await Start();
        using var scope = fixture.App.Services.CreateScope(); var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.LecturerCourses.Add(new LecturerCourses { LecturerId = 200, CourseId = 1 }); await db.SaveChangesAsync();
        var service = new LecturerReviewService(db, new ConfigurationBuilder().Build());
        var dto = new SaveGradesLecturerReviewDto { StudentGrades = new() { new StudentGradeInputLecturerReviewDto { StudentId = 100, Comment = "Invalid", CriteriaGrades = new() { new CriteriaGradeInputLecturerReviewDto { CriteriaId = 1, Score = 11 } } } } };
        await Assert.ThrowsAsync<System.ComponentModel.DataAnnotations.ValidationException>(() => service.SaveProjectGradesAsync(200, "P1", dto));
        dto.StudentGrades[0].CriteriaGrades[0].Score = 8; dto.StudentGrades[0].CriteriaGrades.Add(dto.StudentGrades[0].CriteriaGrades[0]);
        await Assert.ThrowsAsync<System.ComponentModel.DataAnnotations.ValidationException>(() => service.SaveProjectGradesAsync(200, "P1", dto));
    }

    private sealed class Authentication(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
        : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        protected override System.Threading.Tasks.Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var id = Request.Headers["X-Student"].ToString();
            if (string.IsNullOrEmpty(id)) return System.Threading.Tasks.Task.FromResult(AuthenticateResult.NoResult());
            var role = Request.Headers["X-Role"].FirstOrDefault() ?? "ROLE_STUDENT";
            var principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("id", id), new Claim(ClaimTypes.Role, role) }, Scheme.Name));
            return System.Threading.Tasks.Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name)));
        }
    }
}
