using System.Security.Claims;
using EduProject_TADProgrammer.Data;
using Microsoft.EntityFrameworkCore;

namespace EduProject_TADProgrammer.Services;

public sealed class PrivateFileAccessService(ApplicationDbContext db)
{
    public static string? ResolvePath(string root, string relativePath)
    {
        if (string.IsNullOrWhiteSpace(relativePath) || relativePath.Contains(':') ||
            relativePath.Contains('\\') || Path.IsPathRooted(relativePath)) return null;
        var segments = relativePath.Split('/');
        if (segments.Any(s => s is ".." or "." or "")) return null;
        var basePath = Path.GetFullPath(root).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        var fullPath = Path.GetFullPath(Path.Combine(basePath, relativePath));
        if (!fullPath.StartsWith(basePath, OperatingSystem.IsWindows() ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal)) return null;
        var current = basePath;
        foreach (var segment in segments)
        {
            current = Path.Combine(current, segment);
            if ((File.Exists(current) || Directory.Exists(current)) &&
                File.GetAttributes(current).HasFlag(FileAttributes.ReparsePoint)) return null;
        }
        return fullPath;
    }

    public async Task<bool> CanReadAsync(ClaimsPrincipal user, string path)
    {
        if (!long.TryParse(user.FindFirst("id")?.Value, out var id)) return false;
        if (!await db.Users.AnyAsync(u => u.Id == id && !u.Locked)) return false;
        if (user.IsInRole("ROLE_ADMIN")) return true;
        var aliases = new List<string> { path, "/" + path };
        if (path.StartsWith("resource/", StringComparison.Ordinal)) aliases.Add(path[9..]);
        var submission = await db.Submissions.Where(s => aliases.Contains(s.FilePath))
            .Select(s => new { s.StudentId, s.GroupId, s.ProjectId }).FirstOrDefaultAsync();
        if (submission == null)
            submission = await db.SubmissionVersions.Where(v => aliases.Contains(v.FilePath))
                .Select(v => new { v.Submission.StudentId, v.Submission.GroupId, v.Submission.ProjectId }).FirstOrDefaultAsync();
        if (submission != null)
            return submission.StudentId == id || await CanReadProjectAsync(user, id, submission.ProjectId, submission.GroupId);
        var resource = await db.Resources.Where(r => aliases.Contains(r.FilePath))
            .Select(r => new { r.CreatedBy, r.ProjectId, r.GroupId }).FirstOrDefaultAsync();
        if (resource == null) return false;
        if (resource.CreatedBy == id) return true;
        if (resource.ProjectId is long projectId)
            return await CanReadProjectAsync(user, id, projectId, resource.GroupId);
        return resource.GroupId.HasValue && await db.GroupMembers.AnyAsync(g => g.GroupId == resource.GroupId && g.StudentId == id);
    }

    private async Task<bool> CanReadProjectAsync(ClaimsPrincipal user, long id, long projectId, long? groupId)
    {
        if (user.IsInRole("ROLE_STUDENT"))
            return await db.GroupMembers.AnyAsync(g => g.StudentId == id &&
                ((groupId != null && g.GroupId == groupId) || g.Group.ProjectId == projectId));
        if (user.IsInRole("ROLE_HEAD"))
            return await db.Projects.AnyAsync(p => p.Id == projectId &&
                db.Users.Any(u => u.Id == id && u.DepartmentId != null && u.DepartmentId == p.Course.DepartmentId));
        if (user.IsInRole("ROLE_LECTURER_GUIDE"))
            return await db.Projects.AnyAsync(p => p.Id == projectId &&
                (p.Course.LecturerCourses.Any(l => l.LecturerId == id) ||
                 db.StudentCourses.Any(s => s.CourseId == p.CourseId && s.LecturerId == id)));
        return false;
    }
}
