using System.Security.Claims;
using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Middleware;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace EduProject_TADProgrammer.Tests;

public class SecurityRegressionTests
{
    private static ApplicationDbContext Database() => new(new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString(), options => options.EnableNullChecks(false)).Options);
    private static ClaimsPrincipal Principal(long id, string role) => new(new ClaimsIdentity(new[]
    {
        new Claim("id", id.ToString()), new Claim(ClaimTypes.Role, role)
    }, "test"));
    private static NotificationService Notifications(ApplicationDbContext db) => new(db, new ConfigurationBuilder().Build());

    [Theory]
    [InlineData("../appsettings.json")]
    [InlineData("../wwwroot-other/secret.pdf")]
    [InlineData("submissions/../../appsettings.json")]
    [InlineData("/etc/passwd")]
    [InlineData("C:/Windows/win.ini")]
    [InlineData("submissions/file.pdf:secret")]
    [InlineData("submissions\\..\\secret")]
    public void FilePathsCannotEscapeStorage(string path) =>
        Assert.Null(PrivateFileAccessService.ResolvePath(Path.GetTempPath(), path));

    [Fact]
    public void ValidFilePathIsPreserved() => Assert.Equal(
        Path.Combine(Path.GetTempPath(), "submissions", "report.pdf"),
        PrivateFileAccessService.ResolvePath(Path.GetTempPath(), "submissions/report.pdf"));

    [Theory]
    [InlineData(typeof(HeadCourseGradingController))]
    [InlineData(typeof(HeadGradeCriteriaController))]
    [InlineData(typeof(HeadLecturerController))]
    [InlineData(typeof(HeadDefenseScheduleController))]
    public void SensitiveHeadControllersRequireHeadRole(Type controller) =>
        Assert.Contains(controller.GetCustomAttributes(typeof(AuthorizeAttribute), true).Cast<AuthorizeAttribute>(), a => a.Roles == "ROLE_HEAD");

    private static async System.Threading.Tasks.Task<ActionExecutingContext> RunHeadFilter(ApplicationDbContext db, ClaimsPrincipal principal, Dictionary<string, object?> arguments)
    {
        var action = new ActionContext(new DefaultHttpContext { User = principal }, new RouteData(), new ActionDescriptor());
        var controller = new HeadCourseGradingController(null!);
        var context = new ActionExecutingContext(action, new List<IFilterMetadata>(), arguments, controller);
        await new HeadScopeFilter(db).OnActionExecutionAsync(context,
            () => System.Threading.Tasks.Task.FromResult(new ActionExecutedContext(action, new List<IFilterMetadata>(), controller)));
        return context;
    }

    [Fact]
    public async System.Threading.Tasks.Task AnonymousHeadRequestIsDenied()
    {
        using var db = Database();
        Assert.IsType<ForbidResult>((await RunHeadFilter(db, new ClaimsPrincipal(), new())).Result);
    }

    [Fact]
    public async System.Threading.Tasks.Task HeadIdentityComesFromTokenAndCrossFacultyIsDenied()
    {
        using var db = Database();
        db.Users.Add(new User { Id = 1000, Role = new Role { Id = 1000, Name = "ROLE_HEAD" },
            Department = new Department { Id = 1000, FacultyCode = "CS" } });
        await db.SaveChangesAsync();
        var allowed = await RunHeadFilter(db, Principal(1000, "ROLE_HEAD"), new() { ["headId"] = 999L, ["facultyCode"] = "CS" });
        Assert.Null(allowed.Result);
        Assert.Equal(1000L, allowed.ActionArguments["headId"]);
        var denied = await RunHeadFilter(db, Principal(1000, "ROLE_HEAD"), new() { ["request"] = new ApproveGradeRequest { FacultyCode = "OTHER" } });
        Assert.IsType<ForbidResult>(denied.Result);
    }

    [Fact]
    public async System.Threading.Tasks.Task NotificationsAreScopedToRecipient()
    {
        using var db = Database();
        db.Notifications.AddRange(new Notification { Id = 1000, UserId = 1000, Title = "Own" },
            new Notification { Id = 1001, UserId = 1001, Title = "Other" });
        await db.SaveChangesAsync();
        var visible = await Notifications(db).GetNotificationsAsync(Principal(1000, "ROLE_STUDENT"));
        Assert.Single(visible.Notifications);
        Assert.Equal("Own", visible.Notifications[0].Title);
        Assert.DoesNotContain(await Notifications(db).GetRecentNotificationsAsync(Principal(1000, "ROLE_STUDENT")), n => n.UserId == 1001);
        Assert.Contains((await Notifications(db).GetNotificationsAsync(Principal(1000, "ROLE_ADMIN"))).Notifications, n => n.UserId == 1001);
    }

    [Fact]
    public async System.Threading.Tasks.Task SmtpSecretIsMaskedAndPreservedOnUpdate()
    {
        using var db = Database();
        var service = Notifications(db);
        await service.SaveConfigAsync(new NotificationConfigDto { SmtpConfig = new SmtpConfig { Host = "smtp.example.test", Password = "test-secret", Port = 587 } });
        var response = await new NotificationsController(service).GetConfigAsync();
        var config = Assert.IsType<NotificationConfigDto>(Assert.IsType<OkObjectResult>(response.Result).Value);
        Assert.Equal("", config.SmtpConfig.Password);
        await service.SaveConfigAsync(config);
        Assert.Equal("test-secret", (await service.GetConfigAsync()).SmtpConfig.Password);
    }

    [Fact]
    public async System.Threading.Tasks.Task IndividualReminderCreatesOnlyTheIntendedRecipient()
    {
        using var db = Database();
        db.Users.Add(new User { Id = 1000 });
        await db.SaveChangesAsync();
        var dto = new NotificationDto { RecipientType = "user", Title = "Deadline", Type = "Web" };
        typeof(NotificationDto).GetProperty(nameof(NotificationDto.UserId))!.SetValue(dto, 1000L);
        var result = await Notifications(db).CreateNotificationAsync(dto);
        var notification = await db.Notifications.FindAsync(result.Id);
        Assert.NotNull(notification);
        Assert.Equal(1000L, notification.UserId);
        Assert.Equal("Deadline", notification.Title);
    }

    [Fact]
    public async System.Threading.Tasks.Task UnrelatedStudentCannotReadResource()
    {
        using var db = Database();
        db.Users.AddRange(new User { Id = 1000 }, new User { Id = 1001 });
        db.Resources.Add(new Resource { Id = 1000, CreatedBy = 1000, FilePath = "resource/pdf/private.pdf" });
        await db.SaveChangesAsync();
        var access = new PrivateFileAccessService(db);
        Assert.True(await access.CanReadAsync(Principal(1000, "ROLE_STUDENT"), "resource/pdf/private.pdf"));
        Assert.False(await access.CanReadAsync(Principal(1001, "ROLE_STUDENT"), "resource/pdf/private.pdf"));
        Assert.False(await access.CanReadAsync(Principal(1000, "ROLE_STUDENT"), "resource/pdf/unregistered.pdf"));
    }
}
