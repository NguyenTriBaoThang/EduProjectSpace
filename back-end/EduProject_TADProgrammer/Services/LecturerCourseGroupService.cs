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
            try
            {
                var courses = await _context.Courses
                    .Include(c => c.Semester)
                    .Include(c => c.Department)
                    .Include(c => c.Lecturers)
                    .Where(c => c.Lecturers.Any(l => l.Id == lecturerId))
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
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách môn học: {ex.Message}", ex);
            }
        }

        public async Task<List<LecturerCourseGroupStudentDto>> GetUngroupedStudentsAsync(string courseId)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == courseId);

            if (course == null) return new List<LecturerCourseGroupStudentDto>();

            // Lấy tất cả sinh viên thuộc khóa học và vai trò là "ROLE_STUDENT"
            var students = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.Name == "ROLE_STUDENT" && u.StudentCourses.Any(sc => sc.CourseId == course.Id))
                .ToListAsync();

            // Lấy danh sách ID của sinh viên đã có nhóm trong khóa học
            var groupedStudentIds = await _context.GroupMembers
                .Where(gm => _context.Groups
                    .Any(g => g.Id == gm.GroupId && g.Project != null && g.Project.CourseId == course.Id))
                .Select(gm => gm.StudentId)
                .ToListAsync();

            // Lọc sinh viên chưa có nhóm
            var ungroupedStudents = students
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

            return ungroupedStudents;
        }

        public async Task<List<LecturerCourseGroupsDto>> GetGroupsAsync(string courseId)
        {
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == courseId);

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
                    ProjectId = g.ProjectId != 0 ? g.ProjectId.ToString() : null,
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
            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == courseId);

            if (course == null) return new List<LecturerCourseGroupProjectDto>();

            return await _context.Projects
                .Where(p => p.CourseId == course.Id)
                .Select(p => new LecturerCourseGroupProjectDto
                {
                    ProjectId = p.Id.ToString(),
                    Name = p.Title
                })
                .ToListAsync();
        }

        public async Task<LecturerCourseGroupsDto> AddGroupAsync(string groupName, string courseId)
        {
            if (string.IsNullOrEmpty(groupName) || string.IsNullOrEmpty(courseId))
                throw new ArgumentException("GroupName và CourseId không được để trống.");

            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == courseId);

            if (course == null) throw new Exception("Course not found.");

            var group = new Group
            {
                Name = groupName,
                ProjectId = 0, // Không gán đồ án khi tạo nhóm
                MaxMembers = 0,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return new LecturerCourseGroupsDto
            {
                Id = group.Id.ToString(),
                Name = group.Name,
                CourseId = courseId,
                ProjectId = null,
                Members = new List<LecturerCourseGroupStudentDto>()
            };
        }

        public async System.Threading.Tasks.Task AddToGroupAsync(string studentId, string groupId, int groupSize)
        {
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(groupId))
                throw new ArgumentException("StudentId và GroupId không được để trống.");

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

            // Lấy CourseId của nhóm hiện tại
            var courseId = await _context.Groups
                .Where(g => g.Id == parsedGroupId)
                .Select(g => g.Project != null ? g.Project.CourseId : (long?)null)
                .FirstOrDefaultAsync();

            if (courseId == null)
            {
                // Nếu nhóm chưa gán Project, lấy CourseId từ StudentCourses hoặc logic khác
                // Ở đây, giả định rằng nhóm phải thuộc một khóa học, cần xác định CourseId
                throw new Exception("Cannot determine CourseId for the group.");
            }

            // Kiểm tra xem sinh viên đã thuộc nhóm nào trong cùng môn học chưa
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
                // Nếu sinh viên đã thuộc nhóm khác trong cùng môn học, xóa khỏi nhóm cũ
                _context.GroupMembers.Remove(existingGroupMember.gm);
                await _context.SaveChangesAsync();
            }

            var groupMember = new GroupMember
            {
                GroupId = parsedGroupId,
                StudentId = parsedStudentId,
                IsLeader = group.GroupMembers.Count == 0, // Nếu là thành viên đầu tiên, tự động làm nhóm trưởng
                JoinedAt = DateTime.UtcNow
            };

            _context.GroupMembers.Add(groupMember);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveFromGroupAsync(string studentId, string groupId)
        {
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(groupId))
                throw new ArgumentException("StudentId và GroupId không được để trống.");

            long parsedStudentId, parsedGroupId;
            if (!long.TryParse(studentId, out parsedStudentId) || !long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("StudentId và GroupId phải là số hợp lệ.");

            var groupMember = await _context.GroupMembers
                .FirstOrDefaultAsync(gm => gm.StudentId == parsedStudentId && gm.GroupId == parsedGroupId);

            if (groupMember == null) throw new Exception("Group member not found.");

            _context.GroupMembers.Remove(groupMember);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task ToggleLeaderAsync(string studentId, string groupId)
        {
            if (string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(groupId))
                throw new ArgumentException("StudentId và GroupId không được để trống.");

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
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(projectId))
                throw new ArgumentException("GroupId và ProjectId không được để trống.");

            long parsedGroupId, parsedProjectId;
            if (!long.TryParse(groupId, out parsedGroupId) || !long.TryParse(projectId, out parsedProjectId))
                throw new ArgumentException("GroupId và ProjectId phải là số hợp lệ.");

            var group = await _context.Groups
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);

            if (group == null) throw new Exception("Group not found.");

            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.Id == parsedProjectId);

            if (project == null) throw new Exception("Project not found.");

            group.ProjectId = parsedProjectId;
            group.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task AutoGroupAsync(AutoLecturerCourseGroupRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.CourseId) || request.GroupSize <= 0)
                throw new ArgumentException("Dữ liệu yêu cầu không hợp lệ.");

            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.CourseCode == request.CourseId);

            if (course == null) throw new Exception("Course not found.");

            var ungroupedStudents = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.Name == "ROLE_STUDENT" &&
                            u.StudentCourses.Any(sc => sc.CourseId == course.Id) &&
                            !_context.GroupMembers.Any(gm => gm.StudentId == u.Id))
                .ToListAsync();

            var filteredGroups = await _context.Groups
                .Include(g => g.GroupMembers)
                .ToListAsync();

            _context.Groups.RemoveRange(filteredGroups.Where(g => !g.GroupMembers.Any()));
            await _context.SaveChangesAsync();

            long groupIndex = filteredGroups.Any() ? filteredGroups.Max(g => g.Id) + 1 : 1;
            var currentTime = DateTime.UtcNow;

            for (int i = 0; i < ungroupedStudents.Count; i += request.GroupSize)
            {
                var groupMembers = ungroupedStudents.Skip(i).Take(request.GroupSize).ToList();
                if (!groupMembers.Any()) continue;

                var newGroup = new Group
                {
                    Id = groupIndex++,
                    Name = $"Nhóm G{groupIndex}",
                    ProjectId = 0, // Không gán đồ án khi tạo nhóm tự động
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
                    IsLeader = index == 0, // Sinh viên đầu tiên tự động làm nhóm trưởng
                    JoinedAt = currentTime
                }).ToList();

                _context.GroupMembers.AddRange(groupMemberEntries);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<byte[]> ExportGroupsToExcelAsync(string courseId)
        {
            if (string.IsNullOrEmpty(courseId))
                throw new ArgumentException("CourseId không được để trống.");

            var groups = await GetGroupsAsync(courseId);
            var worksheetData = new List<string[]>
            {
                new[] { "Danh sách nhóm sinh viên - Hệ thống Sinh viên HUTECH" },
                new[] { $"Khóa học: {courseId}" },
                new[] { "" },
                new[] { "Mã nhóm", "Mã đồ án", "Tên nhóm", "Thành viên", "Nhóm trưởng" }
            };

            foreach (var group in groups)
            {
                var members = group.Members.Any() ? string.Join(", ", group.Members.Select(m => $"{m.Id} - {m.Name}{(m.IsLeader ? " (Nhóm trưởng)" : "")}")) : "Chưa có thành viên";
                var leader = group.Members.FirstOrDefault(m => m.IsLeader)?.Id ?? "Chưa chọn";
                worksheetData.Add(new[]
                {
                    group.Id,
                    group.ProjectId ?? "Chưa gán",
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
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(newGroupName))
                throw new ArgumentException("GroupId và newGroupName không được để trống.");

            long parsedGroupId;
            if (!long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("GroupId phải là số hợp lệ.");

            var group = await _context.Groups
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);

            if (group == null) throw new Exception("Group not found.");

            group.Name = newGroupName;
            group.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteGroupAsync(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentException("GroupId không được để trống.");

            long parsedGroupId;
            if (!long.TryParse(groupId, out parsedGroupId))
                throw new ArgumentException("GroupId phải là số hợp lệ.");

            var group = await _context.Groups
                .Include(g => g.GroupMembers)
                .FirstOrDefaultAsync(g => g.Id == parsedGroupId);

            if (group == null) throw new Exception("Group not found.");

            // Xóa tất cả thành viên khỏi nhóm (chuyển về trạng thái chưa có nhóm)
            if (group.GroupMembers.Any())
            {
                _context.GroupMembers.RemoveRange(group.GroupMembers);
                await _context.SaveChangesAsync();
            }

            // Xóa nhóm
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}