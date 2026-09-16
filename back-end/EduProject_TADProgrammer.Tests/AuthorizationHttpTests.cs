using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;
using EduProject_TADProgrammer.Controllers;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Middleware;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;

namespace EduProject_TADProgrammer.Tests;

public class AuthorizationHttpTests
{
    [Theory]
    [InlineData("POST", "/api/HeadCourseGrading/approve-grade", null, HttpStatusCode.Unauthorized)]
    [InlineData("GET", "/api/HeadGradeCriteria?headLecturer=1", null, HttpStatusCode.Unauthorized)]
    [InlineData("GET", "/resource/pdf/sample.pdf", null, HttpStatusCode.Unauthorized)]
    [InlineData("GET", "/submissions/sample.zip", null, HttpStatusCode.Unauthorized)]
    [InlineData("GET", "/api/Notifications/config", "ROLE_STUDENT", HttpStatusCode.Forbidden)]
    [InlineData("POST", "/api/Notifications/config", "ROLE_STUDENT", HttpStatusCode.Forbidden)]
    [InlineData("POST", "/api/Notifications", "ROLE_STUDENT", HttpStatusCode.Forbidden)]
    [InlineData("DELETE", "/api/Notifications/1", "ROLE_STUDENT", HttpStatusCode.Forbidden)]
    [InlineData("POST", "/api/HeadCourseGrading/approve-grade", "ROLE_STUDENT", HttpStatusCode.Forbidden)]
    [InlineData("GET", "/api/Notifications/config", "ROLE_ADMIN", HttpStatusCode.OK)]
    public async System.Threading.Tasks.Task HttpAuthorizationIsEnforced(string method, string path, string? role, HttpStatusCode expected)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAuthentication("test").AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>("test", _ => { });
        builder.Services.AddAuthorization(o => o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
        var database = Guid.NewGuid().ToString();
        builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase(database, b => b.EnableNullChecks(false)));
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddControllers(o => o.Filters.Add<HeadScopeFilter>()).AddApplicationPart(typeof(NotificationsController).Assembly);
        await using var app = builder.Build();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        await app.StartAsync();
        using var client = app.GetTestClient();
        using var request = new HttpRequestMessage(new HttpMethod(method), path);
        if (role != null) request.Headers.Add("X-Test-Role", role);
        using var response = await client.SendAsync(request);
        Assert.Equal(expected, response.StatusCode);
    }

    // Only registered inside the isolated TestServer, never in the application.
    private sealed class TestAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger, UrlEncoder encoder) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        protected override System.Threading.Tasks.Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var role = Request.Headers["X-Test-Role"].ToString();
            if (string.IsNullOrEmpty(role)) return System.Threading.Tasks.Task.FromResult(AuthenticateResult.NoResult());
            var principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("id", "1000"), new Claim(ClaimTypes.Role, role) }, Scheme.Name));
            return System.Threading.Tasks.Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name)));
        }
    }
}
