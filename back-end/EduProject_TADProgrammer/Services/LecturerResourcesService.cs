using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerResourcesService
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _huggingFaceApiKey;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public LecturerResourcesService(ApplicationDbContext context, HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _context = context;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
            _huggingFaceApiKey = configuration["HuggingFace:ApiKey"] ?? Environment.GetEnvironmentVariable("HUGGINGFACE_API_KEY");
            _configuration = configuration;
            _environment = environment;
            if (string.IsNullOrEmpty(_huggingFaceApiKey))
                throw new InvalidOperationException("Hugging Face API key is not configured.");
        }

        public async Task<IEnumerable<CourseResourceDto>> GetCoursesForResourcesAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(lc => lc.Course.Department)
                .Include(lc => lc.Course.Projects)
                .ThenInclude(p => p.Resources)
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => new CourseResourceDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester.Name,
                    FacultyCode = lc.Lecturer.Department.FacultyCode,
                    ProjectCount = lc.Course.Projects.Count(p => p.CourseId == lc.CourseId),
                    ResourceCount = lc.Course.Projects.SelectMany(p => p.Resources).Count(r => r.Project.CourseId == lc.CourseId)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ResourceDto>> GetResourcesAsync(long lecturerId, string courseId)
        {
            var course = await _context.Courses
                .Include(c => c.LecturerCourses)
                .FirstOrDefaultAsync(c => c.CourseCode == courseId);

            if (course == null || !course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException("Bạn không có quyền truy cập môn học này.");

            return await _context.Resources
                .Include(r => r.Project)
                .Include(r => r.Group)
                .Where(r => r.Project.CourseId == course.Id)
                .Select(r => new ResourceDto
                {
                    Id = r.Id,
                    ProjectId = r.Project.ProjectCode,
                    ProjectName = r.Project.Title,
                    GroupName = r.Group.Name,
                    Title = r.Title,
                    Type = r.Type,
                    Link = r.FilePath // Sử dụng FilePath trực tiếp
                })
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task AddResourcesAsync(long lecturerId, AddResourceDto resourceDto)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == resourceDto.ProjectId);

            if (project == null)
                throw new ArgumentException($"Project with ID {resourceDto.ProjectId} not found.");
            if (!project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException($"You do not have permission to add resources for project {resourceDto.ProjectId}.");

            var resource = new Resource
            {
                ProjectId = project.Id,
                GroupId = project.GroupId,
                Title = resourceDto.Title,
                Type = resourceDto.Type,
                FilePath = resourceDto.Link,
                CreatedBy = lecturerId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Resources.Add(resource);

            var suggestion = new AISuggestion
            {
                UserId = null,
                ProjectId = project.Id,
                Type = "Resource",
                Content = $"Tài liệu đề xuất: {resourceDto.Title} (Link: {resourceDto.Link})",
                CreatedAt = DateTime.UtcNow
            };
            _context.AISuggestions.Add(suggestion);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database error: {ex.InnerException?.Message}");
                throw new Exception("An error occurred while saving the entity changes. See logs for details.", ex);
            }
        }

        public async System.Threading.Tasks.Task UpdateResourceAsync(long lecturerId, long id, UpdateResourceDto resourceDto)
        {
            var resource = await _context.Resources
                .Include(r => r.Project)
                .ThenInclude(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resource == null)
                throw new KeyNotFoundException("Không tìm thấy tài liệu.");
            if (!resource.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException("Bạn không có quyền sửa tài liệu này.");

            var basePath = Path.Combine(_environment.WebRootPath, "resource");
            var subFolder = resourceDto.Type.ToLower() == "pdf" ? "pdf" : "video";
            var fileName = Path.GetFileName(resourceDto.Link);

            if (resourceDto.Type != "Website" && !string.IsNullOrEmpty(resource.FilePath) && System.IO.File.Exists(Path.Combine(_environment.WebRootPath, resource.FilePath)))
                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, resource.FilePath));

            if (resourceDto.Type != "Website")
            {
                var fullPath = Path.Combine(basePath, subFolder, fileName);
                Directory.CreateDirectory(Path.Combine(basePath, subFolder));
                if (!System.IO.File.Exists(fullPath))
                    System.IO.File.Copy(resourceDto.Link, fullPath, true);
            }

            resource.Title = resourceDto.Title;
            resource.Type = resourceDto.Type;
            resource.FilePath = resourceDto.Type == "Website" ? resourceDto.Link : Path.Combine(subFolder, fileName).Replace("\\", "/");

            var suggestion = await _context.AISuggestions
                .FirstOrDefaultAsync(s => s.ProjectId == resource.ProjectId && s.Type == "Resource" && s.Content.Contains(resource.Title));
            if (suggestion != null)
            {
                suggestion.Content = $"Tài liệu đề xuất: {resourceDto.Title} (Link: {fileName})";
                suggestion.CreatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteResourceAsync(long lecturerId, long id)
        {
            var resource = await _context.Resources
                .Include(r => r.Project)
                .ThenInclude(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (resource == null)
                throw new KeyNotFoundException("Không tìm thấy tài liệu.");
            if (!resource.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException("Bạn không có quyền xóa tài liệu này.");

            if (!string.IsNullOrEmpty(resource.FilePath) && System.IO.File.Exists(Path.Combine(_environment.WebRootPath, resource.FilePath)))
                System.IO.File.Delete(Path.Combine(_environment.WebRootPath, resource.FilePath));

            _context.Resources.Remove(resource);

            var suggestion = await _context.AISuggestions
                .FirstOrDefaultAsync(s => s.ProjectId == resource.ProjectId && s.Type == "Resource" && s.Content.Contains(resource.Title));
            if (suggestion != null)
                _context.AISuggestions.Remove(suggestion);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AISuggestionDto>> GenerateSuggestionsAsync(long lecturerId, GenerateSuggestionDto suggestionDto)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == suggestionDto.ProjectId);

            if (project == null || !project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException("Bạn không có quyền tạo gợi ý cho đồ án này.");

            var suggestions = await GenerateAISuggestions(project, suggestionDto.Keywords);

            return suggestions.Select(s => new AISuggestionDto
            {
                Id = 0,
                ProjectId = project.ProjectCode,
                Type = "Resource",
                Content = s.Content
            }).ToList();
        }

        public async System.Threading.Tasks.Task SaveSelectedSuggestionsAsync(long lecturerId, List<AISuggestionDto> selectedSuggestions)
        {
            foreach (var suggestionDto in selectedSuggestions)
            {
                var project = await _context.Projects
                    .Include(p => p.Course)
                    .ThenInclude(c => c.LecturerCourses)
                    .FirstOrDefaultAsync(p => p.ProjectCode == suggestionDto.ProjectId);

                if (project == null || !project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                    throw new UnauthorizedAccessException($"Bạn không có quyền lưu gợi ý cho đồ án {suggestionDto.ProjectId}.");

                var parts = suggestionDto.Content.Split(" (Link: ");
                if (parts.Length < 2) continue;
                var title = parts[0].Replace("Tài liệu đề xuất: ", "").Trim();
                var link = parts[1].Replace(")", "").Trim();

                var resource = new Resource
                {
                    ProjectId = project.Id,
                    GroupId = null,
                    Title = title,
                    Type = "AI_Generated",
                    FilePath = link,
                    CreatedBy = lecturerId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Resources.Add(resource);

                var suggestion = new AISuggestion
                {
                    UserId = null,
                    ProjectId = project.Id,
                    Type = "Resource",
                    Content = suggestionDto.Content,
                    CreatedAt = DateTime.UtcNow
                };
                _context.AISuggestions.Add(suggestion);
            }

            await _context.SaveChangesAsync();
        }

        private async Task<List<AISuggestion>> GenerateAISuggestions(Project project, string keywords)
        {
            try
            {
                var suggestions = new List<AISuggestion>();

                var existingResources = await _context.Resources
                    .Where(r => r.Project.CourseId == project.CourseId)
                    .Select(r => new { r.Title, r.FilePath })
                    .ToListAsync();

                if (existingResources.Any())
                {
                    var resourceTitles = existingResources.Select(r => r.Title).ToList();
                    var query = $"{project.Title} {project.Description ?? string.Empty} {keywords}".Trim();
                    var topResource = await CallSentenceTransformers(query, resourceTitles);
                    if (!string.IsNullOrEmpty(topResource))
                    {
                        var resource = existingResources.FirstOrDefault(r => r.Title == topResource);
                        suggestions.Add(new AISuggestion
                        {
                            Content = $"Tài liệu đề xuất: {topResource} (Link: {resource?.FilePath ?? "/resources/default.pdf"})",
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }

                var prompt = $"You are an AI assistant. Your task is to suggest exactly 3 documents for a project about \"{project.Title}\" in the course \"{project.Course.Name}\". Use keywords: {keywords}. Return **only** a JSON array of 3 objects, each with \"title\" and \"link\" fields. Example: [{{\"title\": \"Java for AI in Healthcare\", \"link\": \"https://example.com/java-ai-healthcare.pdf\"}}, {{\"title\": \"AI Healthcare Applications with Java\", \"link\": \"https://example.com/ai-healthcare-java.pdf\"}}, {{\"title\": \"Java in Medical AI\", \"link\": \"https://example.com/medical-ai-java.pdf\"}}]. Do not include any text, explanations, or formatting outside the JSON array.";
                var aiResponse = await CallHuggingFaceAPI(prompt);
                suggestions.AddRange(aiResponse);

                if (!suggestions.Any())
                    return FallbackSuggestions();

                return suggestions;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GenerateAISuggestions: {ex.Message}");
                return FallbackSuggestions();
            }
        }

        private async Task<string> CallSentenceTransformers(string query, List<string> resources)
        {
            try
            {
                var requestContent = new { query, resources };
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/find_similar", requestContent);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var jsonResult = JsonSerializer.Deserialize<Dictionary<string, object>>(result);
                return jsonResult?.GetValueOrDefault("top_resource")?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sentence Transformers error: {ex.Message}");
                return null;
            }
        }

        private async Task<List<AISuggestion>> CallHuggingFaceAPI(string prompt)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api-inference.huggingface.co/models/mistralai/Mixtral-8x7B-Instruct-v0.1");
                request.Headers.Add("Authorization", $"Bearer {_huggingFaceApiKey}");
                request.Content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        inputs = prompt,
                        parameters = new { max_new_tokens = 300, temperature = 0.7, return_full_text = false }
                    }),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Lỗi HTTP: {response.StatusCode}, Nội dung: {errorContent}");
                    throw new HttpRequestException($"API trả về mã lỗi {response.StatusCode}: {errorContent}");
                }

                var rawText = await response.Content.ReadAsStringAsync();
                var parsedList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(rawText);
                var generatedText = parsedList?.FirstOrDefault()?["generated_text"]?.ToString();

                if (string.IsNullOrWhiteSpace(generatedText))
                    return FallbackSuggestions();

                generatedText = generatedText.Trim();
                int startIdx = generatedText.IndexOf('[');
                int endIdx = generatedText.LastIndexOf(']');

                if (startIdx >= 0 && endIdx > startIdx)
                {
                    var jsonPart = generatedText.Substring(startIdx, endIdx - startIdx + 1);
                    var jsonDocs = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonPart);
                    return jsonDocs
                        .Where(doc => doc.ContainsKey("title") && doc.ContainsKey("link") && !string.IsNullOrEmpty(doc["title"]) && !string.IsNullOrEmpty(doc["link"]))
                        .Select(doc => new AISuggestion
                        {
                            Content = $"Tài liệu đề xuất: {doc["title"]} (Link: {doc["link"]})",
                            CreatedAt = DateTime.UtcNow
                        }).ToList();
                }

                return FallbackSuggestions();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi Hugging Face API: {ex.Message}");
                return FallbackSuggestions();
            }
        }

        private List<AISuggestion> FallbackSuggestions()
        {
            return new List<AISuggestion>
            {
                new AISuggestion { Content = "Tài liệu đề xuất: Default Resource 1 (Link: https://example.com/default1.pdf)", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Content = "Tài liệu đề xuất: Default Resource 2 (Link: https://example.com/default2.pdf)", CreatedAt = DateTime.UtcNow }
            };
        }
    }
}