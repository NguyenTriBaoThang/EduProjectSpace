using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduProject_TADProgrammer.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class FileController(IWebHostEnvironment environment, PrivateFileAccessService access) : ControllerBase
{
    [HttpGet("files/{*filePath}")]
    public async Task<IActionResult> GetFile(string filePath, [FromQuery] bool download = false)
    {
        if (filePath.StartsWith("/resource/", StringComparison.Ordinal) || filePath.StartsWith("/submissions/", StringComparison.Ordinal))
            filePath = filePath.TrimStart('/');
        var fullPath = PrivateFileAccessService.ResolvePath(environment.WebRootPath, filePath);
        if (fullPath == null) return BadRequest("Invalid file path.");
        if (!await access.CanReadAsync(User, filePath)) return Forbid();
        if (!System.IO.File.Exists(fullPath)) return NotFound();
        var contentType = Path.GetExtension(filePath).ToLowerInvariant() switch
        {
            ".pdf" => "application/pdf",
            ".mp4" => "video/mp4",
            ".avi" => "video/x-msvideo",
            ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".java" or ".cs" => "text/plain",
            ".zip" => "application/zip",
            _ => "application/octet-stream"
        };
        Response.Headers["X-Content-Type-Options"] = "nosniff";
        Response.Headers.CacheControl = "private, no-store";
        return PhysicalFile(fullPath, contentType, download ? Path.GetFileName(fullPath) : null, enableRangeProcessing: true);
    }

    // Existing URLs share the same authorization checks as API downloads.
    [HttpGet("~/resource/{*filePath}")]
    public Task<IActionResult> GetResource(string filePath, [FromQuery] bool download = false) => GetFile("resource/" + filePath, download);

    [HttpGet("~/submissions/{*filePath}")]
    public Task<IActionResult> GetSubmission(string filePath, [FromQuery] bool download = false) => GetFile("submissions/" + filePath, download);
}
