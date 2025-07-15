using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public LecturerReviewService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IEnumerable<CourseLecturerReviewDto>> GetCoursesForReviewAsync(long lecturerId)
        {
            return await _context.LecturerCourses
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Semester)
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Department)
                .Include(lc => lc.Course)
                .ThenInclude(c => c.Projects)
                .ThenInclude(p => p.Grades)
                .Where(lc => lc.LecturerId == lecturerId)
                .Select(lc => new CourseLecturerReviewDto
                {
                    CourseId = lc.Course.CourseCode,
                    Name = lc.Course.Name,
                    Semester = lc.Course.Semester != null ? lc.Course.Semester.Name : "Chưa xác định",
                    FacultyCode = lc.Course.Department != null ? lc.Course.Department.FacultyCode : "Chưa xác định",
                    ProjectCount = lc.Course.Projects.Count,
                    ReviewedCount = lc.Course.Projects.Count(p => p.Grades.Any(g => g.Score > 0))
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectLecturerReviewListDto>> GetProjectsForReviewAsync(long lecturerId, string courseId)
        {
            var course = await _context.Courses
                .Include(c => c.LecturerCourses)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                    .ThenInclude(s => s.Grades)
                    .ThenInclude(g => g.Criteria)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                    .ThenInclude(s => s.GradeAppeals)
                .Include(c => c.GradeCriteria)
                .FirstOrDefaultAsync(c => c.CourseCode == courseId && c.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (course == null)
                throw new KeyNotFoundException("Không tìm thấy môn học hoặc bạn không có quyền truy cập");

            var criteria = course.GradeCriteria?.ToList() ?? new List<GradeCriteria>();

            return course.Projects.Select(p =>
            {
                var students = p.Group?.GroupMembers.Select(gm => gm.Student).ToList() ?? new List<User>();
                var isFullyReviewed = students.All(s =>
                    criteria.All(c => s.Grades.Any(g => g.ProjectId == p.Id && g.CriteriaId == c.Id && g.Score > 0)) &&
                    !students.Any(s => s.Grades.Any(g => g.ProjectId == p.Id && g.Comment == "Chưa duyệt")));

                return new ProjectLecturerReviewListDto
                {
                    ProjectId = p.ProjectCode,
                    Name = p.Title,
                    GroupName = p.Group?.Name ?? "Chưa có nhóm",
                    GroupLeader = p.Group?.GroupMembers.FirstOrDefault(gm => gm.IsLeader)?.Student?.FullName ?? "Chưa có nhóm trưởng",
                    MemberCount = p.Group?.GroupMembers.Count ?? 0,
                    Status = p.Status ?? "Chưa xác định",
                    IsFullyReviewed = isFullyReviewed
                };
            }).ToList();
        }

        public async Task<ProjectLecturerReviewDto> GetProjectReviewDetailAsync(long lecturerId, string projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                    .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                    .ThenInclude(s => s.Grades)
                    .ThenInclude(g => g.Criteria)
                .Include(p => p.Group)
                    .ThenInclude(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                    .ThenInclude(s => s.GradeAppeals)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.Submissions)
                    .ThenInclude(s => s.Student)
                .Include(p => p.Tasks)
                    .ThenInclude(t => t.Submissions)
                    .ThenInclude(s => s.Feedbacks)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new KeyNotFoundException("Không tìm thấy đồ án hoặc bạn không có quyền truy cập");

            var criteria = project.Course.GradeCriteria?.ToList() ?? new List<GradeCriteria>();
            var students = project.Group?.GroupMembers?.Select(gm => gm.Student).ToList() ?? new List<User>();

            var studentGrades = students.Select(student => new StudentGradeLecturerReviewDto
            {
                StudentId = student.Id,
                FullName = student.FullName ?? "Unknown",
                CriteriaGrades = criteria.Select(c => new CriteriaGradeLecturerReviewDto
                {
                    CriteriaId = c.Id,
                    CriteriaName = c.Name ?? "Unknown",
                    Score = (decimal?)student.Grades.FirstOrDefault(g => g.ProjectId == project.Id && g.CriteriaId == c.Id)?.Score ?? 0,
                    Weight = c.Weight
                }).ToList(),
                HasPendingAppeal = student.Grades.Any(g => g.ProjectId == project.Id && g.GradeAppeals.Any(ga => ga.Status == "Pending")),
                TotalScore = criteria.Any(c => student.Grades.Any(g => g.ProjectId == project.Id && g.CriteriaId == c.Id))
                    ? (decimal)student.Grades
                        .Where(g => g.ProjectId == project.Id)
                        .Sum(g => g.Score * criteria.First(c => c.Id == g.CriteriaId).Weight)
                    : 0,
                GradeVersions = student.Grades
                    .Where(g => g.ProjectId == project.Id)
                    .SelectMany(g => g.GradeVersions)
                    .OrderBy(gv => gv.VersionNumber)
                    .Select(gv => new GradeVersionDto
                    {
                        StudentId = gv.Grade.StudentId ?? 0,
                        FullName = gv.Grade.Student?.FullName ?? "Unknown",
                        VersionNumber = gv.VersionNumber,
                        TotalScore = gv.Score,
                        Comment = gv.Comment,
                        CreatedAt = gv.CreatedAt
                    }).ToList()
            }).ToList();

            bool isFullyReviewed = studentGrades.All(sg =>
                !sg.HasPendingAppeal &&
                sg.CriteriaGrades.All(cg => cg.Score > 0));

            return new ProjectLecturerReviewDto
            {
                ProjectId = project.ProjectCode,
                Name = project.Title ?? "Chưa có tiêu đề",
                CourseId = project.Course.CourseCode,
                GroupName = project.Group?.Name ?? "Chưa có nhóm",
                GroupLeader = project.Group?.GroupMembers.FirstOrDefault(gm => gm.IsLeader)?.Student?.FullName ?? "Chưa có nhóm trưởng",
                GroupMembers = string.Join(", ", project.Group?.GroupMembers.Select(gm => gm.Student?.FullName ?? "Unknown") ?? new List<string>()),
                Status = project.Status ?? "Chưa xác định",
                IsFullyReviewed = isFullyReviewed,
                StudentGrades = studentGrades,
                Tasks = project.Tasks?.Select(t => new TaskLecturerReviewDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.Deadline?.ToString("yyyy-MM-dd"),
                    Submissions = t.Submissions?.Select(s => new SubmissionLecturerReviewDto
                    {
                        Id = s.Id,
                        FileName = s.FilePath.Split('/').Last(),
                        FilePath = s.FilePath,
                        SubmittedById = s.Student?.Username ?? "Unknown",
                        FullName = s.Student?.FullName ?? "Unknown",
                        Feedback = s.Feedbacks
                            .OrderByDescending(f => f.CreatedAt)
                            .FirstOrDefault()?.Content ?? ""
                    }).ToList() ?? new List<SubmissionLecturerReviewDto>()
                }).ToList() ?? new List<TaskLecturerReviewDto>()
            };
        }

        public async System.Threading.Tasks.Task SaveProjectGradesAsync(long lecturerId, string projectId, SaveGradesLecturerReviewDto saveGradesDto)
        {
            var project = await _context.Projects
                .Include(p => p.Course)
                .ThenInclude(c => c.LecturerCourses)
                .Include(p => p.Group)
                .ThenInclude(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Include(p => p.Course)
                .ThenInclude(c => c.GradeCriteria)
                .FirstOrDefaultAsync(p => p.ProjectCode == projectId && p.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId));

            if (project == null)
                throw new KeyNotFoundException("Không tìm thấy đồ án hoặc bạn không có quyền truy cập");

            var criteria = project.Course.GradeCriteria?.ToList() ?? new List<GradeCriteria>();
            var studentIds = project.Group?.GroupMembers.Select(gm => gm.StudentId).ToList() ?? new List<long>();

            if (saveGradesDto.StudentGrades.Any(sg => !studentIds.Contains(sg.StudentId)))
                throw new ValidationException("Có sinh viên không thuộc nhóm");
            if (saveGradesDto.StudentGrades.Any(sg => sg.CriteriaGrades.Count != criteria.Count ||
                sg.CriteriaGrades.Any(cg => !criteria.Any(c => c.Id == cg.CriteriaId))))
                throw new ValidationException("Danh sách tiêu chí không hợp lệ");

            foreach (var studentGrade in saveGradesDto.StudentGrades)
            {
                var student = await _context.Users.FindAsync(studentGrade.StudentId);
                if (student == null) continue;

                var existingGrades = await _context.Grades
                    .Where(g => g.ProjectId == project.Id && g.StudentId == studentGrade.StudentId)
                    .ToListAsync();

                int versionNumber = await _context.GradeVersions
                    .Where(gv => gv.Grade.ProjectId == project.Id && gv.Grade.StudentId == studentGrade.StudentId)
                    .CountAsync() + 1;

                string versionComment = string.IsNullOrEmpty(studentGrade.Comment)
                    ? $"Phiên bản lần {versionNumber} (Chưa được duyệt)"
                    : $"{studentGrade.Comment}, Phiên bản lần {versionNumber} (Chưa được duyệt)";

                foreach (var criteriaGrade in studentGrade.CriteriaGrades)
                {
                    var existingGrade = existingGrades.FirstOrDefault(g => g.CriteriaId == criteriaGrade.CriteriaId);
                    if (existingGrade != null)
                    {
                        existingGrade.Score = (float)criteriaGrade.Score;
                        existingGrade.Comment = studentGrade.Comment;
                        existingGrade.GradedAt = DateTime.UtcNow;
                        existingGrade.GradedBy = lecturerId;
                    }
                    else
                    {
                        _context.Grades.Add(new Grade
                        {
                            ProjectId = project.Id,
                            GroupId = project.GroupId,
                            StudentId = studentGrade.StudentId,
                            CriteriaId = criteriaGrade.CriteriaId,
                            Score = (float)criteriaGrade.Score,
                            Comment = studentGrade.Comment,
                            GradedAt = DateTime.UtcNow,
                            GradedBy = lecturerId
                        });
                    }

                    _context.GradeVersions.Add(new GradeVersion
                    {
                        GradeId = existingGrade?.Id ?? (_context.Grades
                            .Where(g => g.ProjectId == project.Id && g.StudentId == studentGrade.StudentId && g.CriteriaId == criteriaGrade.CriteriaId)
                            .OrderByDescending(g => g.Id)
                            .Select(g => g.Id)
                            .FirstOrDefault()),
                        Score = (float)criteriaGrade.Score,
                        Comment = versionComment,
                        VersionNumber = versionNumber,
                        CreatedAt = DateTime.UtcNow
                    });
                }

                // Gửi email thông báo điểm
                await SendGradeNotificationEmail(student, project, studentGrade, criteria);
            }

            await _context.SaveChangesAsync();
        }

        private async System.Threading.Tasks.Task SendGradeNotificationEmail(User student, Project project, StudentGradeInputLecturerReviewDto studentGrade, List<GradeCriteria> criteria)
        {
            if (string.IsNullOrEmpty(student.Email)) return;

            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUsername = _configuration["Smtp:Username"];
            var smtpPassword = _configuration["Smtp:Password"];

            using var smtpClient = new SmtpClient(smtpHost)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            // Lấy Semester nếu chưa được tải
            if (project.Course.Semester == null)
            {
                project.Course = await _context.Courses
                    .Include(c => c.Semester)
                    .FirstOrDefaultAsync(c => c.Id == project.Course.Id) ?? project.Course;
            }

            var semesterName = project.Course.Semester?.Name ?? "Chưa xác định";

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                Subject = $"Thông báo điểm đồ án {project.Title} (Chưa được duyệt)",
                Body = $@"
                    <h3>Thông báo điểm đồ án</h3>
                    <p>Xin chào {student.FullName},</p>
                    <p>Điểm đánh giá cho đồ án <strong>{project.Title}</strong> (Mã đồ án: {project.ProjectCode}, Môn học: {project.Course.Name}, Học kỳ: {semesterName}) đã được giảng viên hướng dẫn chấm. Lưu ý: Điểm này <strong>chưa được duyệt</strong> và cần được Trưởng bộ môn phê duyệt để chính thức.</p>
                    <h4>Chi tiết điểm:</h4>
                    <ul>
                        {string.Join("", studentGrade.CriteriaGrades.Select(cg =>
                {
                    var criterion = criteria.FirstOrDefault(c => c.Id == cg.CriteriaId);
                    return $"<li>{criterion?.Name ?? "Unknown"}: {cg.Score:F2} (Trọng số: {(criterion?.Weight * 100):F0}%)</li>";
                }))}
                    </ul>
                    <p><strong>Tổng điểm:</strong> {studentGrade.CriteriaGrades.Sum(cg => (float)cg.Score * (criteria.FirstOrDefault(c => c.Id == cg.CriteriaId)?.Weight ?? 0)):F2}</p>
                    <p><strong>Nhận xét:</strong> {studentGrade.Comment ?? "Không có nhận xét"}</p>
                    <p><strong>Trạng thái:</strong> Chưa được duyệt</p>
                    <p>Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm} (Giờ Việt Nam)</p>
                    <p>Vui lòng kiểm tra hệ thống để biết thêm chi tiết hoặc liên hệ giảng viên hướng dẫn nếu có thắc mắc.</p>
                    <p>Trân trọng,<br>Hệ thống Sinh viên HUTECH - Team TAD Programmer</p>",
                IsBodyHtml = true
            };
            mailMessage.To.Add(student.Email);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email cho {student.Email}: {ex.Message}");
            }
        }

        public async Task<IEnumerable<GradeVersionDto>> GetReviewHistoryAsync(long lecturerId, string projectId)
        {
            return await _context.GradeVersions
                .Include(gv => gv.Grade)
                .ThenInclude(g => g.Student)
                .Where(gv => gv.Grade.Project.ProjectCode == projectId && gv.Grade.Project.Course.LecturerCourses.Any(lc => lc.LecturerId == lecturerId))
                .Select(gv => new GradeVersionDto
                {
                    StudentId = gv.Grade.StudentId ?? 0,
                    FullName = gv.Grade.Student.FullName ?? "Unknown",
                    VersionNumber = gv.VersionNumber,
                    TotalScore = gv.Score,
                    Comment = gv.Comment,
                    CreatedAt = gv.CreatedAt
                })
                .ToListAsync();
        }
    }
}