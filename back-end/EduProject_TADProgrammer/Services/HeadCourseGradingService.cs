using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Services
{
    public class HeadCourseGradingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HeadCourseGradingService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<HeadCourseGradingDto>> GetCoursesForGradingAsync(long headId)
        {
            var headLecturer = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == headId);

            if (headLecturer == null)
            {
                return new List<HeadCourseGradingDto>();
            }

            var courses = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Group)
                        .ThenInclude(g => g.Lecturer)
                .Include(c => c.Projects)
                    .ThenInclude(p => p.Grades)
                .Where(c => c.DepartmentId == headLecturer.DepartmentId)
                .ToListAsync();

            var courseDTOs = new List<HeadCourseGradingDto>();

            foreach (var course in courses)
            {
                var groups = course.Projects
                    .Select(p => p.Group)
                    .Where(g => g != null)
                    .ToList();

                int groupCount = groups.Count;
                int gradedCount = groups.Count(g => g.Project.Grades != null && g.Project.Grades.Any());
                int approvedCount = groups.Count(g => g.Project.Grades != null && g.Project.Grades.Any(g => g.Comment == "Đã duyệt"));

                var courseDTO = new HeadCourseGradingDto
                {
                    CourseId = course.CourseCode,
                    Name = course.Name,
                    Semester = course.Semester?.Name ?? "Chưa xác định",
                    FacultyCode = course.Department?.FacultyCode ?? "Không xác định",
                    Head = course.Projects.Any() && course.Projects.First().Group?.Lecturer != null
                        ? course.Projects.First().Group.Lecturer.FullName
                        : "Chưa phân công",
                    GroupCount = groupCount,
                    GradedCount = gradedCount,
                    ApprovedCount = approvedCount
                };

                courseDTOs.Add(courseDTO);
            }

            return courseDTOs;
        }

        public async Task<List<GroupHeadCourseGradingDto>> GetGroupsForGradingAsync(string courseId, string semester, string facultyCode)
        {
            var groups = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Include(g => g.Lecturer)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Grades)
                        .ThenInclude(g => g.Criteria)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Tasks)
                        .ThenInclude(t => t.Submissions)
                            .ThenInclude(s => s.Student)
                .Where(g => g.Project.Course.CourseCode == courseId &&
                            g.Project.Course.Semester.Name == semester &&
                            g.Project.Course.Department.FacultyCode == facultyCode)
                .ToListAsync();

            var groupDTOs = new List<GroupHeadCourseGradingDto>();

            foreach (var group in groups)
            {
                var members = group.GroupMembers?.Select(gm => gm.Student?.FullName).Where(name => name != null).ToList() ?? new List<string>();
                var membersString = string.Join(", ", members);

                float? totalScore = null;
                if (group.Project?.Grades != null && group.Project.Grades.Any())
                {
                    var projectCourseId = group.Project.CourseId;
                    var gradeCriteria = await _context.GradeCriteria
                        .Where(gc => gc.CourseId == projectCourseId)
                        .ToListAsync();

                    float scoreSum = 0f;
                    foreach (var grade in group.Project.Grades)
                    {
                        var matchingCriteria = gradeCriteria.FirstOrDefault(gc => gc.Id == grade.CriteriaId);
                        if (matchingCriteria != null)
                        {
                            scoreSum += grade.Score * matchingCriteria.Weight;
                        }
                    }
                    totalScore = scoreSum;
                }

                var approvedStatus = group.Project.Grades?.Any(g => g.Comment == "Đã duyệt") == true
                    ? "Đã duyệt"
                    : "Chưa duyệt";

                var finalReportTask = group.Project.Tasks?.FirstOrDefault(t => t.Title == "Báo cáo cuối kỳ");
                var reportFiles = finalReportTask?.Submissions?.Select(s => new FileSubmissionHeadCourseGradingDto
                {
                    FilePath = s.FilePath,
                    StudentCode = s.Student?.Username ?? "Unknown",
                    FullName = s.Student?.FullName ?? "Unknown"
                }).ToList() ?? new List<FileSubmissionHeadCourseGradingDto>();

                var gradeDetails = new HeadCourseGradeDetails
                {
                    TotalScore = totalScore,
                    CouncilFeedback = group.Project.Grades?.FirstOrDefault()?.Comment ?? "Chưa có phản hồi",
                    Approved = approvedStatus,
                    ReportFiles = reportFiles
                };

                var groupDTO = new GroupHeadCourseGradingDto
                {
                    Id = group.Id,
                    Name = group.Name,
                    ProjectId = group.Project?.ProjectCode ?? "Chưa có mã",
                    ProjectName = group.Project?.Title ?? "Chưa có đồ án",
                    Members = membersString,
                    Lecturer = group.Lecturer?.FullName ?? "Chưa xác định",
                    Grade = totalScore?.ToString("F1") ?? "Chưa chấm",
                    Status = group.Status ?? "Chưa xác định",
                    Approved = approvedStatus,
                    Grades = gradeDetails
                };

                groupDTOs.Add(groupDTO);
            }

            return groupDTOs;
        }

        public async Task<GroupHeadCourseGradingDetailDto> GetGroupGradingDetailsAsync(long groupId, string courseId, string semester, string facultyCode)
        {
            var group = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .Include(g => g.Lecturer)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Grades)
                        .ThenInclude(g => g.Criteria)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Tasks)
                        .ThenInclude(t => t.Submissions)
                            .ThenInclude(s => s.Student)
                .FirstOrDefaultAsync(g => g.Id == groupId &&
                                          g.Project.Course.CourseCode == courseId &&
                                          g.Project.Course.Semester.Name == semester &&
                                          g.Project.Course.Department.FacultyCode == facultyCode);

            if (group == null) return null;

            var members = group.GroupMembers?.Select(gm => new GroupMemberDetail
            {
                StudentId = gm.StudentId,
                FullName = gm.Student?.FullName ?? "Chưa xác định",
                TotalScore = group.Project.Grades
                    .Where(g => g.StudentId == gm.StudentId)
                    .Sum(g =>
                    {
                        var projectCourseId = group.Project.CourseId;
                        var gradeCriteria = _context.GradeCriteria
                            .Where(gc => gc.CourseId == projectCourseId)
                            .ToList();
                        var matchingCriteria = gradeCriteria.FirstOrDefault(gc => gc.Id == g.CriteriaId);
                        return matchingCriteria != null ? g.Score * matchingCriteria.Weight : 0f;
                    }),
                CouncilFeedback = group.Project.Grades
                    .FirstOrDefault(g => g.StudentId == gm.StudentId)?.Comment ?? "Chưa có phản hồi"
            }).ToList() ?? new List<GroupMemberDetail>();

            var finalReportTask = group.Project.Tasks?.FirstOrDefault(t => t.Title == "Báo cáo cuối kỳ");
            var reportFiles = finalReportTask?.Submissions?.Select(s => new FileSubmissionHeadCourseGradingDto
            {
                FilePath = s.FilePath,
                StudentCode = s.Student?.Username ?? "Unknown",
                FullName = s.Student?.FullName ?? "Unknown"
            }).ToList() ?? new List<FileSubmissionHeadCourseGradingDto>();

            float? totalGroupScore = null;
            if (group.Project.Grades != null && group.Project.Grades.Any())
            {
                var projectCourseId = group.Project.CourseId;
                var gradeCriteria = await _context.GradeCriteria
                    .Where(gc => gc.CourseId == projectCourseId)
                    .ToListAsync();

                float scoreSum = 0f;
                foreach (var grade in group.Project.Grades)
                {
                    var matchingCriteria = gradeCriteria.FirstOrDefault(gc => gc.Id == grade.CriteriaId);
                    if (matchingCriteria != null)
                    {
                        scoreSum += grade.Score * matchingCriteria.Weight;
                    }
                }
                totalGroupScore = scoreSum;
            }

            return new GroupHeadCourseGradingDetailDto
            {
                GroupId = group.Id,
                GroupName = group.Name,
                ProjectId = group.Project.ProjectCode,
                ProjectName = group.Project.Title,
                Members = members,
                Lecturer = group.Lecturer?.FullName ?? "Chưa xác định",
                Status = group.Status ?? "Chưa xác định",
                Grades = new HeadCourseGradeDetails
                {
                    TotalScore = totalGroupScore,
                    CouncilFeedback = group.Project.Grades?.FirstOrDefault()?.Comment ?? "Chưa có phản hồi",
                    Approved = group.Project.Grades?.Any(g => g.Comment == "Đã duyệt") == true
                        ? "Đã duyệt"
                        : "Chưa duyệt",
                    ReportFiles = reportFiles
                }
            };
        }

        public async System.Threading.Tasks.Task ApproveGradesAsync(long groupId, string courseId, string semester, string facultyCode, string councilFeedback)
        {
            var group = await _context.Groups
                .Include(g => g.Project)
                    .ThenInclude(p => p.Course)
                        .ThenInclude(c => c.Semester)
                .Include(g => g.Project)
                    .ThenInclude(p => p.Grades)
                        .ThenInclude(g => g.Criteria)
                .Include(g => g.GroupMembers)
                    .ThenInclude(gm => gm.Student)
                .FirstOrDefaultAsync(g => g.Id == groupId &&
                                          g.Project.Course.CourseCode == courseId &&
                                          g.Project.Course.Semester.Name == semester &&
                                          g.Project.Course.Department.FacultyCode == facultyCode);

            if (group == null)
                throw new KeyNotFoundException("Không tìm thấy nhóm hoặc thông tin môn học không hợp lệ");

            var grades = group.Project.Grades;
            if (grades == null || !grades.Any())
                throw new ValidationException("Nhóm chưa có điểm để duyệt");

            // Cập nhật trạng thái điểm thành "Đã duyệt" và thêm nhận xét
            foreach (var grade in grades)
            {
                grade.Comment = councilFeedback ?? "Đã duyệt";
                grade.GradedAt = DateTime.UtcNow;

                // Cập nhật GradeVersion
                var versionNumber = await _context.GradeVersions
                    .Where(gv => gv.Grade.ProjectId == group.Project.Id && gv.Grade.StudentId == grade.StudentId)
                    .CountAsync() + 1;

                _context.GradeVersions.Add(new GradeVersion
                {
                    GradeId = grade.Id,
                    Score = grade.Score,
                    Comment = $"{councilFeedback ?? "Đã duyệt"}, Phiên bản lần {versionNumber} (Đã duyệt)",
                    VersionNumber = versionNumber,
                    CreatedAt = DateTime.UtcNow
                });
            }

            await _context.SaveChangesAsync();

            // Gửi email thông báo đến tất cả sinh viên trong nhóm
            var gradeCriteria = await _context.GradeCriteria
                .Where(gc => gc.CourseId == group.Project.CourseId)
                .ToListAsync();

            foreach (var member in group.GroupMembers)
            {
                var student = member.Student;
                if (student != null && !string.IsNullOrEmpty(student.Email))
                {
                    var studentGrades = grades.Where(g => g.StudentId == student.Id).ToList();
                    await SendGradeApprovalEmail(student, group.Project, studentGrades, gradeCriteria, councilFeedback);
                }
            }
        }

        private async System.Threading.Tasks.Task SendGradeApprovalEmail(User student, Project project, List<Grade> studentGrades, List<GradeCriteria> criteria, string councilFeedback)
        {
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

            var totalScore = studentGrades.Sum(g =>
            {
                var criterion = criteria.FirstOrDefault(c => c.Id == g.CriteriaId);
                return criterion != null ? g.Score * criterion.Weight : 0f;
            });

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpUsername, "HUTECH EduProject"),
                Subject = $"Thông báo duyệt điểm đồ án {project.Title}",
                Body = $@"
                    <h3>Thông báo duyệt điểm đồ án</h3>
                    <p>Xin chào {student.FullName},</p>
                    <p>Điểm đánh giá cho đồ án <strong>{project.Title}</strong> (Mã đồ án: {project.ProjectCode}, Môn học: {project.Course.Name}, Học kỳ: {semesterName}) đã được Trưởng bộ môn duyệt.</p>
                    <h4>Chi tiết điểm:</h4>
                    <ul>
                        {string.Join("", studentGrades.Select(g =>
                {
                    var criterion = criteria.FirstOrDefault(c => c.Id == g.CriteriaId);
                    return $"<li>{criterion?.Name ?? "Unknown"}: {g.Score:F2} (Trọng số: {(criterion?.Weight * 100):F0}%)</li>";
                }))}
                    </ul>
                    <p><strong>Tổng điểm:</strong> {totalScore:F2}</p>
                    <p><strong>Nhận xét từ hội đồng:</strong> {councilFeedback ?? "Không có nhận xét"}</p>
                    <p><strong>Trạng thái:</strong> Đã duyệt</p>
                    <p>Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm} (Giờ Việt Nam)</p>
                    <p>Vui lòng kiểm tra hệ thống để biết thêm chi tiết hoặc liên hệ Trưởng bộ môn nếu có thắc mắc.</p>
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
    }
}