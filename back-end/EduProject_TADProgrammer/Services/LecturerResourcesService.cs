using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerResourcesService
    {
        string _huggingFaceApiKey; // Lưu API key
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _httpClient;

        public LecturerResourcesService(ApplicationDbContext context, HttpClient httpClient, IConfiguration configuration)
        {
            _context = context;
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(30); // Add timeout
            _huggingFaceApiKey = configuration["HuggingFace:ApiKey"] ?? Environment.GetEnvironmentVariable("HUGGINGFACE_API_KEY");
            if (string.IsNullOrEmpty(_huggingFaceApiKey))
            {
                throw new InvalidOperationException("Hugging Face API key is not configured.");
            }
            Console.WriteLine($"🔑 Hugging Face API Key (ẩn bớt): {_huggingFaceApiKey?.Substring(0, 10)}...");

        }

        // Lấy danh sách môn học cần gợi ý tài liệu
        public async Task<IEnumerable<CourseResourceDto>> GetCoursesForResourcesAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(lc => lc.Course.Department)
                .Include(lc => lc.Course.Projects)
                .ThenInclude(p => p.Resources) // Đổi từ lc => lc.Resources thành p => p.Resources để đúng ngữ cảnh
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => new CourseResourceDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester.Name,
                    FacultyCode = lc.Lecturer.Department.FacultyCode, // Đổi ClassId thành FacultyCode và lấy từ lc.FacultyCode
                    ProjectCount = lc.Course.Projects.Count(p => p.CourseId == lc.CourseId),
                    ResourceCount = lc.Course.Projects.SelectMany(p => p.Resources).Count(r => r.Project.CourseId == lc.CourseId) // Sửa ResourceCount để lấy từ Projects.Resources
                })
                .ToListAsync();
        }

        // Lấy danh sách tài liệu cho một môn học
        public async Task<IEnumerable<ResourceDto>> GetResourcesAsync(long lecturerId, string courseId, string semester, string facultyCode) // Đổi classId thành facultyCode
        {
            var course = await _context.Courses
                .Include(c => c.LecturerCourses)
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(c => c.CourseCode == courseId && c.Semester.Name == semester);

            if (course == null || !course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId && lc.Lecturer.Department.FacultyCode == facultyCode)) // Đổi ClassCode thành FacultyCode
                throw new UnauthorizedAccessException("Bạn không có quyền truy cập môn học này.");

            return await _context.Resources
                .Include(r => r.Project)
                .Include(r => r.Group)
                .Where(r => r.Project.CourseId == course.Id && r.Project.Course.Semester.Name == semester && r.Project.Course.Department.FacultyCode == facultyCode) // Đổi ClassCode thành FacultyCode
                .Select(r => new ResourceDto
                {
                    Id = r.Id,
                    ProjectId = r.Project.ProjectCode,
                    GroupName = r.Group.Name,
                    Title = r.Title,
                    Type = r.Type,
                    Link = r.FilePath
                })
                .ToListAsync();
        }

        // Thêm danh sách tài liệu mới
        public async System.Threading.Tasks.Task AddResourcesAsync(long lecturerId, List<AddResourceDto> resourceDtos)
        {
            foreach (var dto in resourceDtos)
            {
                var project = await _context.Projects
                    .Include(p => p.Course)
                    .ThenInclude(c => c.LecturerCourses)
                    .FirstOrDefaultAsync(p => p.ProjectCode == dto.ProjectId);

                if (project == null || !project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                    throw new UnauthorizedAccessException($"Bạn không có quyền thêm tài liệu cho đồ án {dto.ProjectId}.");

                var resource = new Resource
                {
                    ProjectId = project.Id,
                    GroupId = dto.GroupId,
                    Title = dto.Title,
                    Type = dto.Type,
                    FilePath = dto.Link,
                    CreatedBy = lecturerId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Resources.Add(resource);

                // Lưu vào AISuggestion
                var suggestion = new AISuggestion
                {
                    UserId = null, // Gợi ý cho nhóm, không gắn với sinh viên cụ thể
                    ProjectId = project.Id,
                    Type = "Resource",
                    Content = $"Tài liệu đề xuất: {dto.Title} (Link: {dto.Link})",
                    CreatedAt = DateTime.UtcNow
                };
                _context.AISuggestions.Add(suggestion);
            }

            await _context.SaveChangesAsync();
        }

        // Sửa thông tin tài liệu
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

            resource.Title = resourceDto.Title;
            resource.Type = resourceDto.Type;
            resource.FilePath = resourceDto.Link;
            //resource.UpdatedAt = DateTime.UtcNow;

            // Cập nhật AISuggestion
            var suggestion = await _context.AISuggestions
                .FirstOrDefaultAsync(s => s.ProjectId == resource.ProjectId && s.Type == "Resource" && s.Content.Contains(resource.Title));
            if (suggestion != null)
            {
                suggestion.Content = $"Tài liệu đề xuất: {resourceDto.Title} (Link: {resourceDto.Link})";
                suggestion.CreatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        // Xóa tài liệu
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

            _context.Resources.Remove(resource);

            // Xóa AISuggestion liên quan
            var suggestion = await _context.AISuggestions
                .FirstOrDefaultAsync(s => s.ProjectId == resource.ProjectId && s.Type == "Resource" && s.Content.Contains(resource.Title));
            if (suggestion != null)
                _context.AISuggestions.Remove(suggestion);

            await _context.SaveChangesAsync();
        }

        // Tạo gợi ý tài liệu bằng AI
        public async Task<IEnumerable<AISuggestionDto>> GenerateSuggestionsAsync(long lecturerId, GenerateSuggestionDto suggestionDto)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .FirstOrDefaultAsync(p => p.ProjectCode == suggestionDto.ProjectId);

            if (project == null || !project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                throw new UnauthorizedAccessException("Bạn không có quyền tạo gợi ý cho đồ án này.");

            // Gọi AI để tạo gợi ý
            var suggestions = await GenerateAISuggestions(project, suggestionDto.Keywords);

            var result = new List<AISuggestionDto>();
            foreach (var suggestion in suggestions)
            {
                var aiSuggestion = new AISuggestion
                {
                    UserId = null,
                    ProjectId = project.Id,
                    Type = "Resource",
                    Content = suggestion.Content,
                    CreatedAt = DateTime.UtcNow
                };
                _context.AISuggestions.Add(aiSuggestion);
                result.Add(new AISuggestionDto
                {
                    Id = aiSuggestion.Id,
                    ProjectId = project.ProjectCode,
                    Type = aiSuggestion.Type,
                    Content = aiSuggestion.Content
                });
            }

            await _context.SaveChangesAsync();
            return result;
        }

        // Hàm gọi AI (Sentence Transformers + Grok/Hugging Face)
        private async Task<List<AISuggestion>> GenerateAISuggestions(Project project, string keywords)
        {
            var suggestions = new List<AISuggestion>();

            // 1. Sentence Transformers: Tìm tài liệu tương đồng
            var existingResources = await _context.Resources
                    .Where(r => r.Project.CourseId == project.CourseId)
                    .Select(r => new { r.Title, r.FilePath })
                    .ToListAsync();
            Console.WriteLine($"Found {existingResources.Count} resources for CourseId {project.CourseId}");

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

            // 2. Hugging Face: Sinh gợi ý mới
            var prompt = $"Suggest a document (title and link) for the project \"{project.Title}\" in course \"{project.Course.Name}\" with keywords: {keywords}. Respond with a JSON object like: {{ \"title\": \"...\", \"link\": \"...\" }}.";
            var aiResponse = await CallHuggingFaceAPI(prompt);
            suggestions.Add(new AISuggestion
            {
                Content = $"Tài liệu đề xuất: {aiResponse.Title} (Link: {aiResponse.Link})",
                CreatedAt = DateTime.UtcNow
            });

            return suggestions;
        }

        private async Task<string> CallSentenceTransformers(string query, List<string> resources)
        {
            try
            {
                Console.WriteLine($"Calling Sentence Transformers with query: '{query}', resources: {string.Join(", ", resources)}");
                var requestContent = new { query, resources };
                var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/find_similar", requestContent);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Sentence Transformers raw response: {result}");
                var jsonResult = JsonSerializer.Deserialize<Dictionary<string, object>>(result);
                var topResource = jsonResult?.GetValueOrDefault("top_resource")?.ToString();
                Console.WriteLine($"Parsed top_resource: {topResource ?? "null"}");
                return topResource;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Sentence Transformers HTTP error: {ex.Message}, Status: {ex.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sentence Transformers general error: {ex.Message}");
                return null;
            }
        }

        private async Task<(string Title, string Link)> CallHuggingFaceAPI(string prompt)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post,
                    "https://api-inference.huggingface.co/models/bigscience/bloomz-560m");

                request.Headers.Add("Authorization", $"Bearer {_huggingFaceApiKey}");
                Console.WriteLine($"🔐 API Key: {_huggingFaceApiKey?.Substring(0, 10)}...");

                request.Headers.Add("Authorization", $"Bearer {_huggingFaceApiKey}");
                request.Content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        inputs = prompt,
                        parameters = new { max_new_tokens = 200, temperature = 0.7 }
                    }),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var rawText = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"🔥 Hugging Face raw response:\n{rawText}");

                var parsedList = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(rawText);
                var generatedText = parsedList?.FirstOrDefault()?["generated_text"]?.ToString();

                if (!string.IsNullOrWhiteSpace(generatedText))
                {
                    // Thử tách đoạn JSON trong văn bản
                    int startIdx = generatedText.IndexOf('{');
                    int endIdx = generatedText.LastIndexOf('}');

                    if (startIdx >= 0 && endIdx > startIdx)
                    {
                        var jsonPart = generatedText.Substring(startIdx, endIdx - startIdx + 1);
                        Console.WriteLine($"🔍 JSON trích được: {jsonPart}");

                        using var doc = JsonDocument.Parse(jsonPart);
                        var root = doc.RootElement;
                        var title = root.TryGetProperty("title", out var titleProp) ? titleProp.GetString() : "AI Resource";
                        var link = root.TryGetProperty("link", out var linkProp) ? linkProp.GetString() : "https://example.com";

                        return (title, link);
                    }
                    else
                    {
                        // Không có JSON → dùng luôn đoạn văn bản làm tiêu đề
                        return (generatedText.Trim(), "https://example.com");
                    }
                }

                Console.WriteLine("❗ Không nhận được văn bản từ Hugging Face");
                return ("Không có phản hồi từ AI", "https://example.com/default.pdf");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"🚫 Lỗi HTTP khi gọi Hugging Face: {ex.Message}");
                return ("Lỗi gọi Hugging Face", "https://example.com/default.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Lỗi hệ thống: {ex.Message}");
                return ("Lỗi hệ thống", "https://example.com/default.pdf");
            }
        }


    }
}