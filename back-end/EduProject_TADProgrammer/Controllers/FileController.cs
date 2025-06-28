using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("files/{*filePath}")]
        public IActionResult GetFile(string filePath, [FromQuery] bool download = false)
        {
            var fullPath = Path.GetFullPath(Path.Combine(_environment.WebRootPath, filePath)).Replace("..", "");
            if (!fullPath.StartsWith(_environment.WebRootPath))
                return BadRequest("Invalid file path.");

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found.");

            try
            {
                var fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                var fileExtension = Path.GetExtension(filePath).ToLower();
                var contentType = fileExtension switch
                {
                    ".pdf" => "application/pdf",
                    ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                    ".jpg" => "image/jpeg",
                    ".png" => "image/png",
                    ".java" => "text/plain",
                    ".cs" => "text/x-csharp",
                    ".zip" => "application/zip",
                    _ => "application/octet-stream"
                };

                if (download)
                    return File(fileStream, contentType, Path.GetFileName(filePath));
                return File(fileStream, contentType);
            }
            catch (IOException)
            {
                return StatusCode(500, "Error reading file.");
            }
        }
    }
}