using EduProject_TADProgrammer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EduProject_TADProgrammer.Middleware;

// Bind head identity to the authenticated account, never to a query parameter.
public sealed class HeadScopeFilter(ApplicationDbContext db) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.Controller.GetType().Name.StartsWith("Head", StringComparison.Ordinal))
        {
            await next();
            return;
        }

        var principal = context.HttpContext.User;
        if (!principal.IsInRole("ROLE_HEAD") || !long.TryParse(principal.FindFirst("id")?.Value, out var userId))
        {
            context.Result = new ForbidResult();
            return;
        }
        var head = await db.Users.Where(u => u.Id == userId && !u.Locked && u.Role.Name == "ROLE_HEAD")
            .Select(u => new { u.DepartmentId, u.Department.FacultyCode }).FirstOrDefaultAsync();
        if (head?.DepartmentId == null)
        {
            context.Result = new ForbidResult();
            return;
        }
        foreach (var key in new[] { "headId", "headLecturer", "headLecturerId" })
            if (context.ActionArguments.ContainsKey(key)) context.ActionArguments[key] = userId;

        var values = context.ActionArguments.ToList();
        foreach (var value in context.ActionArguments.Values.Where(v => v != null && v.GetType().Namespace == "EduProject_TADProgrammer.Controllers"))
            values.AddRange(value!.GetType().GetProperties().Select(p => new KeyValuePair<string, object?>(p.Name, p.GetValue(value))));

        foreach (var (name, value) in values)
        {
            var permitted = true;
            if (name.Equals("facultyCode", StringComparison.OrdinalIgnoreCase) && value is string faculty)
                permitted = faculty == head.FacultyCode;
            if (name.Equals("groupId", StringComparison.OrdinalIgnoreCase) && value is long groupId)
                permitted = await db.Groups.AnyAsync(g => g.Id == groupId && g.Project.Course.DepartmentId == head.DepartmentId);
            if (name.Equals("courseId", StringComparison.OrdinalIgnoreCase) && value is long courseId)
                permitted = await db.Courses.AnyAsync(c => c.Id == courseId && c.DepartmentId == head.DepartmentId);
            if (!permitted)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
        await next();
    }
}
