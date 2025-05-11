// File: Data/SeedData.cs
// Mục đích: Khởi tạo dữ liệu mẫu cho 39 bảng trong hệ thống quản lý đồ án.
// Hỗ trợ chức năng: Tất cả chức năng liên quan (1, 3, 4, 6, 7, 8, 9, 10, ..., 90).

using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Entities;
using System;

namespace EduProject_TADProgrammer.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Mật khẩu mẫu đã mã hóa (password123)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123");

            // 1. Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "ROLE_ADMIN", Description = "Quản trị viên" },
                new Role { Id = 2, Name = "ROLE_LECTURER_GUIDE", Description = "Giảng viên hướng dẫn" },
                new Role { Id = 3, Name = "ROLE_STUDENT", Description = "Sinh viên" },
                new Role { Id = 4, Name = "ROLE_HEAD", Description = "Trưởng bộ môn" }
            );

            // 2. User
            modelBuilder.Entity<User>().HasData(
                // Admin
                new User { Id = 1, Username = "admin", Password = hashedPassword, Email = "admin@hutech.edu.vn", FullName = "Quản trị viên", RoleId = 1, ClassCode=null,AvatarUrl="/static/medit/imgUser/avatar.jpg",FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Trưởng bộ môn
                new User { Id = 2, Username = "head1", Password = hashedPassword, Email = "head1@hutech.edu.vn", FullName = "Nguyễn Văn Hùng", RoleId = 4, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 3, Username = "head2", Password = hashedPassword, Email = "head2@hutech.edu.vn", FullName = "Trần Thị Lan", RoleId = 4, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Giảng viên hướng dẫn
                new User { Id = 4, Username = "lecturer1", Password = hashedPassword, Email = "lecturer1@hutech.edu.vn", FullName = "Lê Văn Nam", RoleId = 2, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 5, Username = "lecturer2", Password = hashedPassword, Email = "lecturer2@hutech.edu.vn", FullName = "Phạm Thị Mai", RoleId = 2, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 6, Username = "lecturer3", Password = hashedPassword, Email = "lecturer3@hutech.edu.vn", FullName = "Hoàng Văn Tùng", RoleId = 2, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Sinh viên
                new User { Id = 7, Username = "student1", Password = hashedPassword, Email = "student1@hutech.edu.vn", FullName = "Nguyễn Tri Bão Thắng", RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 8, Username = "student2", Password = hashedPassword, Email = "student2@hutech.edu.vn", FullName = "Trần Văn Bình", RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 9, Username = "student3", Password = hashedPassword, Email = "student3@hutech.edu.vn", FullName = "Lê Thị Cẩm", RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 10, Username = "student4", Password = hashedPassword, Email = "student4@hutech.edu.vn", FullName = "Phạm Văn Đức", RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 11, Username = "student5", Password = hashedPassword, Email = "student5@hutech.edu.vn", FullName = "Hoàng Thị Em", RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 3. Course
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Đồ án Tốt nghiệp CNTT", Semester = "HK2-2025", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CreatedAt = DateTime.UtcNow },
                new Course { Id = 2, Name = "Đồ án Cơ sở CNTT", Semester = "HK2-2025", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CreatedAt = DateTime.UtcNow }
            );

            // 4. Project
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "Ứng dụng AI trong y tế", Description = "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", CourseId = 1, LecturerId = 4, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 2, Title = "Hệ thống quản lý đồ án", Description = "Xây dựng hệ thống quản lý đồ án sinh viên.", CourseId = 1, LecturerId = 5, Status = "PENDING", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 3, Title = "Ứng dụng thương mại điện tử", Description = "Phát triển website bán hàng trực tuyến.", CourseId = 2, LecturerId = 6, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 5. ProjectVersion
            modelBuilder.Entity<ProjectVersion>().HasData(
                new ProjectVersion { Id = 1, ProjectId = 1, Title = "Ứng dụng AI trong y tế", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 2, ProjectId = 1, Title = "Ứng dụng AI trong y tế (Cập nhật)", Description = "Cập nhật mô tả.", VersionNumber = 2, CreatedAt = DateTime.UtcNow.AddDays(-1) }
            );

            // 6. Group
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Nhóm 1", ProjectId = 1, CreatedAt = DateTime.UtcNow },
                new Group { Id = 2, Name = "Nhóm 2", ProjectId = 2, CreatedAt = DateTime.UtcNow },
                new Group { Id = 3, Name = "Nhóm 3", ProjectId = 3, CreatedAt = DateTime.UtcNow }
            );

            // 7. GroupMember
            modelBuilder.Entity<GroupMember>().HasData(
                new GroupMember { Id = 1, GroupId = 1, StudentId = 7, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 2, GroupId = 1, StudentId = 8, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 3, GroupId = 2, StudentId = 9, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 4, GroupId = 3, StudentId = 10, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 5, GroupId = 3, StudentId = 11, JoinedAt = DateTime.UtcNow }
            );

            // 8. GroupRequest
            modelBuilder.Entity<GroupRequest>().HasData(
                new GroupRequest { Id = 1, GroupId = 1, StudentId = 9, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 2, GroupId = 2, StudentId = 10, Status = "APPROVED", CreatedAt = DateTime.UtcNow }
            );

            // 9. Task
            modelBuilder.Entity<Entities.Task>().HasData(
                new Entities.Task { Id = 1, ProjectId = 1, GroupId = 1, Title = "Phân tích yêu cầu", Description = "Phân tích yêu cầu hệ thống AI.", Deadline = new DateTime(2025, 2, 15), Status = "TODO", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 2, ProjectId = 2, StudentId = 9, Title = "Thiết kế giao diện", Description = "Thiết kế giao diện quản lý đồ án.", Deadline = new DateTime(2025, 2, 20), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow }
            );

            // 10. Submission
            modelBuilder.Entity<Submission>().HasData(
                new Submission { Id = 1, ProjectId = 1, GroupId = 1, FilePath = "submissions/dt001.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 2, ProjectId = 2, GroupId = 2, FilePath = "submissions/dt002.pdf", Version = 1, Status = "VALIDATED", SubmittedAt = DateTime.UtcNow }
            );

            // 11. SubmissionVersion
            modelBuilder.Entity<SubmissionVersion>().HasData(
                new SubmissionVersion { Id = 1, SubmissionId = 1, FilePath = "submissions/dt001_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 2, SubmissionId = 1, FilePath = "submissions/dt001_v2.pdf", VersionNumber = 2, CreatedAt = DateTime.UtcNow.AddDays(-1) }
            );

            // 12. Feedback
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, SubmissionId = 1, LecturerId = 4, Content = "Cần cải thiện phần phân tích dữ liệu.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 2, SubmissionId = 2, LecturerId = 5, Content = "Tốt, nhưng cần bổ sung tài liệu tham khảo.", CreatedAt = DateTime.UtcNow }
            );

            // 13. CodeRun
            modelBuilder.Entity<CodeRun>().HasData(
                new CodeRun { Id = 1, SubmissionId = 1, Code = "print('Hello World')", Language = "Python", Result = "Success", PlagiarismScore = 0.1f, CreatedAt = DateTime.UtcNow },
                new CodeRun { Id = 2, SubmissionId = 2, Code = "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", Language = "Java", Result = "Success", PlagiarismScore = 0.2f, CreatedAt = DateTime.UtcNow }
            );

            // 14. GradeCriteria
            modelBuilder.Entity<GradeCriteria>().HasData(
                new GradeCriteria { Id = 1, CourseId = 1, Name = "Nội dung", Weight = 0.4f, Description = "Chất lượng nội dung đồ án." },
                new GradeCriteria { Id = 2, CourseId = 1, Name = "Trình bày", Weight = 0.3f, Description = "Cách trình bày báo cáo." },
                new GradeCriteria { Id = 3, CourseId = 1, Name = "Bảo vệ", Weight = 0.3f, Description = "Kỹ năng bảo vệ." }
            );

            // 15. Grade
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, ProjectId = 1, GroupId = 1, CriteriaId = 1, Score = 8.5f, Comment = "Nội dung tốt.", GradedAt = DateTime.UtcNow, GradedBy = 4 },
                new Grade { Id = 2, ProjectId = 1, GroupId = 1, CriteriaId = 2, Score = 8.0f, Comment = "Trình bày rõ ràng.", GradedAt = DateTime.UtcNow, GradedBy = 4 }
            );

            // 16. GradeVersion
            modelBuilder.Entity<GradeVersion>().HasData(
                new GradeVersion { Id = 1, GradeId = 1, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new GradeVersion { Id = 2, GradeId = 1, Score = 8.5f, Comment = "Cập nhật điểm.", VersionNumber = 2, CreatedAt = DateTime.UtcNow }
            );

            // 17. GradeLog
            modelBuilder.Entity<GradeLog>().HasData(
                new GradeLog { Id = 1, GradeId = 1, LecturerId = 4, Action = "CREATE", Details = "Tạo điểm cho nhóm 1.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 2, GradeId = 1, LecturerId = 4, Action = "UPDATE", Details = "Cập nhật điểm nhóm 1.", CreatedAt = DateTime.UtcNow }
            );

            // 18. GradeSchedule
            modelBuilder.Entity<GradeSchedule>().HasData(
                new GradeSchedule { Id = 1, ProjectId = 1, LecturerId = 4, Deadline = new DateTime(2025, 3, 1), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 2, ProjectId = 2, LecturerId = 5, Deadline = new DateTime(2025, 3, 2), Status = "PENDING", CreatedAt = DateTime.UtcNow }
            );

            // 19. GradeAppeal
            modelBuilder.Entity<GradeAppeal>().HasData(
                new GradeAppeal { Id = 1, GradeId = 1, StudentId = 7, Reason = "Điểm nội dung chưa hợp lý.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow }
            );

            // 20. DefenseCommittee
            modelBuilder.Entity<DefenseCommittee>().HasData(
                new DefenseCommittee { Id = 1, Name = "Hội đồng 1", CreatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 2, Name = "Hội đồng 2", CreatedAt = DateTime.UtcNow }
            );

            // 21. CommitteeMember
            modelBuilder.Entity<CommitteeMember>().HasData(
                new CommitteeMember { Id = 1, CommitteeId = 1, LecturerId = 2, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 2, CommitteeId = 1, LecturerId = 4, Role = "Thành viên", CreatedAt = DateTime.UtcNow }
            );

            // 22. DefenseSchedule
            modelBuilder.Entity<DefenseSchedule>().HasData(
                new DefenseSchedule { Id = 1, ProjectId = 1, StartTime = new DateTime(2025, 3, 1, 8, 0, 0), EndTime = new DateTime(2025, 3, 1, 9, 0, 0), Room = "A101", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 2, ProjectId = 2, StartTime = new DateTime(2025, 3, 2, 8, 0, 0), EndTime = new DateTime(2025, 3, 2, 9, 0, 0), Room = "A102", CreatedAt = DateTime.UtcNow }
            );

            // 23. Meeting
            modelBuilder.Entity<Meeting>().HasData(
                new Meeting { Id = 1, GroupId = 1, Title = "Họp nhóm tuần 1", StartTime = new DateTime(2025, 2, 10, 14, 0, 0), EndTime = new DateTime(2025, 2, 10, 15, 0, 0), Location = "Phòng B101", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 2, GroupId = 2, Title = "Họp nhóm tuần 2", StartTime = new DateTime(2025, 2, 17, 14, 0, 0), EndTime = new DateTime(2025, 2, 17, 15, 0, 0), Location = "Online", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 24. MeetingRecord
            modelBuilder.Entity<MeetingRecord>().HasData(
                new MeetingRecord { Id = 1, MeetingId = 1, FilePath = "records/meeting1.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 2, MeetingId = 2, FilePath = "records/meeting2.mp4", CreatedAt = DateTime.UtcNow }
            );

            // 25. Notification
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, UserId = 7, Title = "Hạn nộp đồ án", Content = "Hạn nộp là 28/02/2025.", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 2, UserId = 9, Title = "Phản hồi bài nộp", Content = "Bài nộp đã được phản hồi.", Type = "EMAIL", Status = "SENT", CreatedAt = DateTime.UtcNow }
            );

            // 26. PeerReview
            modelBuilder.Entity<PeerReview>().HasData(
                new PeerReview { Id = 1, GroupId = 1, ReviewerId = 7, RevieweeId = 8, Score = 8, Comment = "Làm việc tốt.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 2, GroupId = 1, ReviewerId = 8, RevieweeId = 7, Score = 7, Comment = "Cần cải thiện giao tiếp.", CreatedAt = DateTime.UtcNow }
            );

            // 27. Resource
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1, ProjectId = 1, Title = "Tài liệu AI", FilePath = "resources/ai_doc.pdf", Type = "REFERENCE", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 2, GroupId = 2, Title = "Mẫu báo cáo", FilePath = "resources/report_template.docx", Type = "SAMPLE", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 28. Question
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, ProjectId = 1, Content = "Ứng dụng AI của bạn giải quyết vấn đề gì?", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Question { Id = 2, ProjectId = 2, Content = "Hệ thống quản lý đồ án có những tính năng gì?", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 29. FAQ
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { Id = 1, Question = "Làm thế nào để nộp đồ án?", Answer = "Đăng nhập, vào mục Nộp bài, tải file lên.", Category = "Nộp bài", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 2, Question = "Thời gian bảo vệ là khi nào?", Answer = "Xem lịch bảo vệ trong mục Lịch.", Category = "Bảo vệ", CreatedAt = DateTime.UtcNow }
            );

            // 30. Discussion
            modelBuilder.Entity<Discussion>().HasData(
                new Discussion { Id = 1, ProjectId = 1, UserId = 7, Title = "Hỏi về AI trong y tế", Content = "Có ai biết cách tích hợp AI vào ứng dụng y tế?", Votes = 5, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 2, UserId = 9, Title = "Thắc mắc về thiết kế giao diện", Content = "Nên dùng framework nào cho giao diện?", Votes = 3, CreatedAt = DateTime.UtcNow }
            );

            // 31. FeedbackSurvey
            modelBuilder.Entity<FeedbackSurvey>().HasData(
                new FeedbackSurvey { Id = 1, UserId = 7, Content = "Hệ thống dễ sử dụng.", Rating = 4, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 2, UserId = 8, Content = "Cần cải thiện tốc độ tải.", Rating = 3, CreatedAt = DateTime.UtcNow }
            );

            // 32. SkillAssessment
            modelBuilder.Entity<SkillAssessment>().HasData(
                new SkillAssessment { Id = 1, StudentId = 7, Skill = "Lập trình Python", Score = 8, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 2, StudentId = 8, Skill = "Thiết kế giao diện", Score = 7, CreatedAt = DateTime.UtcNow }
            );

            // 33. TimeTracking
            modelBuilder.Entity<TimeTracking>().HasData(
                new TimeTracking { Id = 1, StudentId = 7, ProjectId = 1, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow, Duration = 120, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 2, StudentId = 8, ProjectId = 1, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow, Duration = 60, CreatedAt = DateTime.UtcNow }
            );

            // 34. SystemConfig
            modelBuilder.Entity<SystemConfig>().HasData(
                new SystemConfig { Id = 1, Key = "LOGO_URL", Value = "images/hutech_logo.png", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 2, Key = "THEME_COLOR", Value = "#1976d2", CreatedAt = DateTime.UtcNow }
            );

            // 35. SystemMetric
            modelBuilder.Entity<SystemMetric>().HasData(
                new SystemMetric { Id = 1, MetricType = "CPU", Value = 45.5f, CreatedAt = DateTime.UtcNow },
                new SystemMetric { Id = 2, MetricType = "RAM", Value = 60.0f, CreatedAt = DateTime.UtcNow }
            );

            // 36. Calendar
            modelBuilder.Entity<Calendar>().HasData(
                new Calendar { Id = 1, UserId = 7, EventTitle = "Họp nhóm", StartTime = new DateTime(2025, 2, 10, 14, 0, 0), EndTime = new DateTime(2025, 2, 10, 15, 0, 0), CreatedAt = DateTime.UtcNow },
                new Calendar { Id = 2, UserId = 2, GroupId = 1, EventTitle = "Nộp bài", StartTime = new DateTime(2025, 2, 28, 23, 59, 0), EndTime = new DateTime(2025, 2, 28, 23, 59, 0), CreatedAt = DateTime.UtcNow }
            );

            // 37. AISuggestion
            modelBuilder.Entity<AISuggestion>().HasData(
                new AISuggestion { Id = 1, UserId = 7, Type = "PROJECT", Content = "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 2, ProjectId = 1, Type = "GRADE", Content = "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", CreatedAt = DateTime.UtcNow }
            );

            // 38. Log
            modelBuilder.Entity<Log>().HasData(
                new Log { Id = 1, UserId = 1, Action = "LOGIN", Details = "Admin đăng nhập hệ thống.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 2, UserId = 7, Action = "SUBMISSION", Details = "Sinh viên nộp bài cho đồ án 1.", CreatedAt = DateTime.UtcNow }
            );

            // 39. Backup
            modelBuilder.Entity<Backup>().HasData(
                new Backup { Id = 1, FilePath = "backups/db_backup_2025_02_01.sql", CreatedAt = DateTime.UtcNow },
                new Backup { Id = 2, FilePath = "backups/db_backup_2025_02_02.sql", CreatedAt = DateTime.UtcNow.AddDays(-1) }
            );
        }
    }
}