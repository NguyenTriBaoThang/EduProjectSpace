using ClosedXML.Excel;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class LecturerCourseGroupService
    {
        private readonly ApplicationDbContext _context;

        public LecturerCourseGroupService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<LecturerCourseGroupDto> GetCoursesForGroupingAsync(long lecturerId)
        {
            var courses = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Department)
                .Include(c => c.LecturerCourses)
                .Where(c => c.LecturerCourses.Any(l => l.LecturerId == lecturerId))
                .Select(c => new LecturerCourseSummaryDto
                {
                    Id = c.Id,
                    CourseId = c.CourseCode,
                    Name = c.Name,
                    Semester = c.Semester != null ? c.Semester.Name : "Chưa xác định",
                    FacultyCode = c.Department.FacultyCode,
                    StudentCount = _context.StudentCourses.Count(sc => sc.CourseId == c.Id),
                    GroupCount = _context.Groups.Count(g => g.Project != null && g.Project.CourseId == c.Id)
                })
                .ToListAsync();

            return new LecturerCourseGroupDto { Courses = courses };
        }

        public async Task<List<LecturerCourseGroupStudentDto>> GetUngroupedStudentsAsync(string courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) return new List<LecturerCourseGroupStudentDto>();

            var students = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.Name == "ROLE_STUDENT" && u.CoursesAsStudent.Any(sc => sc.CourseId == course.Id))
                .ToListAsync();

            var groupedStudentIds = await _context.GroupMembers
                .Where(gm => _context.Groups.Any(g => g.Id == gm.GroupId && g.Project != null && g.Project.CourseId == course.Id))
                .Select(gm => gm.StudentId)
                .ToListAsync();

            return students
                .Where(u => !groupedStudentIds.Contains(u.Id))
                .Select(s => new LecturerCourseGroupStudentDto
                {
                    Id = s.Id.ToString(),
                    Username = s.Username,
                    Name = s.FullName,
                    GroupId = null,
                    IsLeader = false
                })
                .ToList();
        }

        public async Task<List<LecturerCourseGroupsDto>> GetGroupsAsync(string courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) return new List<LecturerCourseGroupsDto>();

            return await _context.Groups
                .Include(g => g.Project)
                .Include(g => g.GroupMembers)
                .ThenInclude(gm => gm.Student)
                .Where(g => g.Project != null && g.Project.CourseId == course.Id)
                .Select(g => new LecturerCourseGroupsDto
                {
                    Id = g.Id.ToString(),
                    Name = g.Name,
                    CourseId = courseId,
                    ProjectId = g.Project.ProjectCode,
                    ProjectName = g.Project.Title,
                    Members = g.GroupMembers.Select(m => new LecturerCourseGroupStudentDto
                    {
                        Id = m.StudentId.ToString(),
                        Username = m.Student.Username,
                        Name = m.Student.FullName,
                        GroupId = g.Id.ToString(),
                        IsLeader = m.IsLeader
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<List<LecturerCourseGroupProjectDto>> GetProjectsAsync(string courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) return new List<LecturerCourseGroupProjectDto>();

            return await _context.Projects
                .Where(p => p.CourseId == course.Id)
                .Select(p => new LecturerCourseGroupProjectDto
                {
                    ProjectId = p.ProjectCode,
                    Name = p.Title
                })
                .ToListAsync();
        }

        public async Task<LecturerCourseGroupsDto> AddGroupAsync(string groupName, string courseId)
        {
            if (string.IsNullOrEmpty(groupName) || string.IsNullOrEmpty(courseId))
                throw new ArgumentException("GroupName và CourseId không được để trống.");

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) throw new Exception("Course not found.");

            var existingGroup = await _context.Groups
                .Where(g => g.Project != null && g.Project.CourseId == course.Id && g.Name == groupName)
                .FirstOrDefaultAsync();
            if (existingGroup != null) throw new Exception("Tên nhóm đã tồn tại trong môn học này.");

            var lecturerCourse = await _context.LecturerCourses
                .Include(lc => lc.Lecturer)
                .ThenInclude(l => l.Role)
                .Where(lc => lc.CourseId == course.Id && lc.Lecturer.Role.Name == "ROLE_LECTURER_GUIDE")
                .FirstOrDefaultAsync();
            if (lecturerCourse == null) throw new Exception("No lecturer with ROLE_LECTURER_GUIDE assigned to this course.");

            var project = new Project
            {
                ProjectCode = await GenerateUniqueProjectCode(),
                Title = "Chưa có tên đồ án",
                Description = "Chưa có tên đồ án",
                CourseId = course.Id,
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            var group = new Group
            {
                Name = groupName,
                ProjectId = project.Id,
                LecturerId = lecturerCourse.LecturerId,
                MaxMembers = 0,
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            project.GroupId = group.Id;
            await _context.SaveChangesAsync();

            return new LecturerCourseGroupsDto
            {
                Id = group.Id.ToString(),
                Name = group.Name,
                CourseId = courseId,
                ProjectId = project.ProjectCode,
                ProjectName = project.Title,
                Members = new List<LecturerCourseGroupStudentDto>()
            };
        }

        public async System.Threading.Tasks.Task AddToGroupAsync(string studentId, string groupId, int groupSize)
        {
            long parsedStudentId, parsedGroupId;
            if (!long.TryParse(studentId, out parsedStudentId) || !long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("StudentId và GroupId phải là số hợp lệ.");

            var group = await _context.Groups
                .Include(g => g.GroupMembers)
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);
            if (group == null) throw new Exception("Group not found.");

            if (group.GroupMembers.Count >= groupSize) throw new Exception("Group is full.");

            var student = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == parsedStudentId && u.Role.Name == "ROLE_STUDENT");
            if (student == null) throw new Exception("Student not found.");

            var courseId = await _context.Projects
                .Where(p => p.Id == group.ProjectId)
                .Select(p => p.CourseId)
                .FirstOrDefaultAsync();
            if (courseId == 0) throw new Exception("Cannot determine CourseId for the group.");

            var existingGroupMember = await _context.GroupMembers
                .Where(gm => gm.StudentId == parsedStudentId)
                .Join(_context.Groups,
                      gm => gm.GroupId,
                      g => g.Id,
                      (gm, g) => new { gm, g })
                .Where(joined => joined.g.Project != null && joined.g.Project.CourseId == courseId)
                .FirstOrDefaultAsync();

            if (existingGroupMember != null)
            {
                _context.GroupMembers.Remove(existingGroupMember.gm);
                await _context.SaveChangesAsync();
            }

            var groupMember = new GroupMember
            {
                GroupId = parsedGroupId,
                StudentId = parsedStudentId,
                IsLeader = group.GroupMembers.Count == 0,
                JoinedAt = DateTime.UtcNow
            };
            _context.GroupMembers.Add(groupMember);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveFromGroupAsync(string studentId, string groupId)
        {
            long parsedStudentId, parsedGroupId;
            if (!long.TryParse(studentId, out parsedStudentId) || !long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("StudentId và GroupId phải là số hợp lệ.");

            var groupMember = await _context.GroupMembers
                .FirstOrDefaultAsync(gm => gm.StudentId == parsedStudentId && gm.GroupId == parsedGroupId);
            if (groupMember == null) throw new Exception("Group member not found.");

            _context.GroupMembers.Remove(groupMember);
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetIdByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username không được để trống.");

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Role.Name == "ROLE_STUDENT");
            if (user == null)
                throw new Exception("Sinh viên không tồn tại.");

            return user.Id.ToString();
        }

        public async System.Threading.Tasks.Task ToggleLeaderAsync(string studentId, string groupId)
        {
            long parsedStudentId, parsedGroupId;
            if (!long.TryParse(studentId, out parsedStudentId) || !long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("StudentId và GroupId phải là số hợp lệ.");

            var groupMember = await _context.GroupMembers
                .FirstOrDefaultAsync(gm => gm.StudentId == parsedStudentId && gm.GroupId == parsedGroupId);
            if (groupMember == null) throw new Exception("Group member not found.");

            var group = await _context.Groups
                .Include(g => g.GroupMembers)
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);
            if (group == null) throw new Exception("Group not found.");

            var currentLeader = group.GroupMembers.FirstOrDefault(gm => gm.IsLeader);
            if (currentLeader != null)
            {
                currentLeader.IsLeader = false;
            }

            groupMember.IsLeader = !groupMember.IsLeader;

            if (!groupMember.IsLeader && group.GroupMembers.Count > 1)
            {
                var firstMember = group.GroupMembers.FirstOrDefault(gm => gm.StudentId != parsedStudentId);
                if (firstMember != null)
                {
                    firstMember.IsLeader = true;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AssignProjectAsync(string groupId, string projectId)
        {
            long parsedGroupId;
            if (!long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("GroupId phải là số hợp lệ.");

            var group = await _context.Groups.FirstOrDefaultAsync(g => g.Id == parsedGroupId);
            if (group == null) throw new Exception("Group not found.");

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectCode == projectId);
            if (project == null) throw new Exception("Project not found.");

            group.ProjectId = project.Id;
            group.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AutoGroupAsync(AutoLecturerCourseGroupRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.CourseId) || request.GroupSize <= 0)
                throw new ArgumentException("Dữ liệu yêu cầu không hợp lệ.");

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == request.CourseId);
            if (course == null) throw new Exception("Course not found.");

            var lecturerCourse = await _context.LecturerCourses
                .Include(lc => lc.Lecturer)
                .ThenInclude(l => l.Role)
                .Where(lc => lc.CourseId == course.Id && lc.Lecturer.Role.Name == "ROLE_LECTURER_GUIDE")
                .FirstOrDefaultAsync();
            if (lecturerCourse == null) throw new Exception("No lecturer with ROLE_LECTURER_GUIDE assigned to this course.");

            var ungroupedStudents = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.Name == "ROLE_STUDENT" &&
                            u.CoursesAsStudent.Any(sc => sc.CourseId == course.Id) &&
                            !_context.GroupMembers.Any(gm => gm.StudentId == u.Id &&
                                                            _context.Groups.Any(g => g.Id == gm.GroupId &&
                                                                                    g.Project != null &&
                                                                                    g.Project.CourseId == course.Id)))
                .ToListAsync();

            var filteredGroups = await _context.Groups
                .Include(g => g.GroupMembers)
                .Where(g => g.Project != null && g.Project.CourseId == course.Id)
                .ToListAsync();

            _context.Groups.RemoveRange(filteredGroups.Where(g => !g.GroupMembers.Any()));
            await _context.SaveChangesAsync();

            long groupIndex = filteredGroups.Any() ? filteredGroups.Max(g => g.Id) + 1 : 1;
            var currentTime = DateTime.UtcNow;

            for (int i = 0; i < ungroupedStudents.Count; i += request.GroupSize)
            {
                var groupMembers = ungroupedStudents.Skip(i).Take(request.GroupSize).ToList();
                if (!groupMembers.Any()) continue;

                var project = new Project
                {
                    ProjectCode = await GenerateUniqueProjectCode(),
                    Title = "Chưa có tên đồ án",
                    CourseId = course.Id,
                    Status = "Pending",
                    CreatedAt = currentTime,
                    UpdatedAt = currentTime
                };
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                var newGroup = new Group
                {
                    Id = groupIndex++,
                    Name = $"Nhóm G{groupIndex}",
                    ProjectId = project.Id,
                    LecturerId = lecturerCourse.LecturerId,
                    MaxMembers = request.GroupSize,
                    Status = "Pending",
                    CreatedAt = currentTime,
                    UpdatedAt = currentTime
                };
                _context.Groups.Add(newGroup);
                await _context.SaveChangesAsync();

                var groupMemberEntries = groupMembers.Select((student, index) => new GroupMember
                {
                    GroupId = newGroup.Id,
                    StudentId = student.Id,
                    IsLeader = index == 0,
                    JoinedAt = currentTime
                }).ToList();

                _context.GroupMembers.AddRange(groupMemberEntries);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<byte[]> ExportGroupsToExcelAsync(string courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) throw new Exception("Course not found.");

            var groups = await GetGroupsAsync(courseId);
            var worksheetData = new List<string[]>
            {
                new[] { "Danh sách nhóm sinh viên - Hệ thống Sinh viên HUTECH" },
                new[] { $"Khóa học: {courseId}" },
                new[] { $"Tên môn học: {course.Name}" },
                new[] { "" },
                new[] { "Mã nhóm", "Mã đồ án", "Tên đồ án", "Tên nhóm", "Thành viên", "Nhóm trưởng" }
            };

            foreach (var group in groups)
            {
                var leaderMember = group.Members.FirstOrDefault(m => m.IsLeader);
                var leader = leaderMember != null
                    ? $"{leaderMember.Username} - {leaderMember.Name}"
                    : "Chưa chọn";
                var members = group.Members.Any()
                    ? string.Join(", ", group.Members.Select(m => $"{m.Username} - {m.Name}{(m.IsLeader ? " (Nhóm trưởng)" : "")}"))
                    : "Chưa có thành viên";
                worksheetData.Add(new[]
                {
                    group.Id,
                    group.ProjectId ?? "Chưa gán",
                    group.ProjectName ?? "Chưa gán",
                    group.Name,
                    members,
                    leader
                });
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("NhomSinhVien");
                for (int i = 0; i < worksheetData.Count; i++)
                {
                    for (int j = 0; j < worksheetData[i].Length; j++)
                    {
                        worksheet.Cell(i + 1, j + 1).Value = worksheetData[i][j];
                    }
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public async System.Threading.Tasks.Task UpdateGroupNameAsync(string groupId, string newGroupName)
        {
            long parsedGroupId;
            if (!long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("GroupId phải là số hợp lệ.");

            var group = await _context.Groups
                .Include(g => g.Project)
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);
            if (group == null) throw new Exception("Group not found.");

            var courseId = await _context.Projects
                .Where(p => p.Id == group.ProjectId)
                .Select(p => p.CourseId)
                .FirstOrDefaultAsync();
            var existingGroup = await _context.Groups
                .Where(g => g.Project != null && g.Project.CourseId == courseId && g.Name == newGroupName && g.Id != parsedGroupId)
                .FirstOrDefaultAsync();
            if (existingGroup != null) throw new Exception("Tên nhóm đã tồn tại trong môn học này.");

            group.Name = newGroupName;
            group.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteGroupAsync(string groupId)
        {
            long parsedGroupId;
            if (!long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("GroupId phải là số hợp lệ.");

            var group = await _context.Groups
                .Include(g => g.GroupMembers)
                .Include(g => g.Project)
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);
            if (group == null) throw new Exception("Group not found.");

            if (group.GroupMembers.Any())
            {
                _context.GroupMembers.RemoveRange(group.GroupMembers);
            }

            if (group.Project != null)
            {
                _context.Projects.Remove(group.Project);
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckStudentInCourseAsync(string studentId, string courseId)
        {
            long parsedStudentId;
            if (!long.TryParse(studentId, out parsedStudentId))
                throw new ArgumentException("StudentId phải là số hợp lệ.");

            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseCode == courseId);
            if (course == null) throw new Exception("Course not found.");

            var student = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == parsedStudentId && u.Role.Name == "ROLE_STUDENT" && u.CoursesAsStudent.Any(sc => sc.CourseId == course.Id));
            return student != null;
        }

        private async Task<string> GenerateUniqueProjectCode()
        {
            string code;
            bool exists;
            var random = new Random();
            do
            {
                var timestamp = DateTime.UtcNow.ToString("yyyyMMdd");
                var randomNum = random.Next(1000, 9999);
                code = $"PROJ-{timestamp}-{randomNum}";
                exists = await _context.Projects.AnyAsync(p => p.ProjectCode == code);
            } while (exists);
            return code;
        }
    }
}