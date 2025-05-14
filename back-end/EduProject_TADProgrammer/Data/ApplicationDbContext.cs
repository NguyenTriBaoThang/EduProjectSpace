// File: Data/ApplicationDbContext.cs
// Mục đích: Cấu hình DbContext để ánh xạ 39 bảng cơ sở dữ liệu với Entity Framework Core.
// Hỗ trợ: Kết nối cơ sở dữ liệu và quản lý tất cả 90 chức năng của Hệ thống Quản lý Đồ án.

using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Entities;

namespace EduProject_TADProgrammer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Định nghĩa DbSet cho từng bảng
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectVersion> ProjectVersions { get; set; }
        public DbSet<Entities.Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupRequest> GroupRequests { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionVersion> SubmissionVersions { get; set; }
        public DbSet<GradeCriteria> GradeCriteria { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeVersion> GradeVersions { get; set; }
        public DbSet<GradeAppeal> GradeAppeals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingRecord> MeetingRecords { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<CodeRun> CodeRuns { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackSurvey> FeedbackSurveys { get; set; }
        public DbSet<DefenseSchedule> DefenseSchedules { get; set; }
        public DbSet<DefenseCommittee> DefenseCommittees { get; set; }
        public DbSet<CommitteeMember> CommitteeMembers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<SkillAssessment> SkillAssessments { get; set; }
        public DbSet<AISuggestion> AISuggestions { get; set; }
        public DbSet<TimeTracking> TimeTrackings { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<GradeLog> GradeLogs { get; set; }
        public DbSet<GradeSchedule> GradeSchedules { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Backup> Backups { get; set; }
        public DbSet<SystemMetric> SystemMetrics { get; set; }
        public DbSet<Entities.Calendar> Calendars { get; set; }
        public DbSet<PeerReview> PeerReviews { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi seeding dữ liệu
            SeedData.Seed(modelBuilder);

            // 1. Users: Liên kết với Roles, Course (cho giảng viên), chỉ mục cho Username và Email
            // Hỗ trợ chức năng: 1, 3, 4, 6, 9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany() // Định nghĩa tập hợp ngược lại
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Role nếu User còn tồn tại
            modelBuilder.Entity<User>()
                .HasOne(u => u.Course) // Liên kết với Course cho giảng viên
                .WithMany() // Tập hợp giảng viên thuộc Course
                .HasForeignKey(u => u.CourseId)
                .OnDelete(DeleteBehavior.SetNull); // Nếu Course bị xóa, CourseId của User thành null
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // 2. Semesters: Không có khóa ngoại, chỉ mục cho Name
            modelBuilder.Entity<Semester>()
                .HasIndex(s => s.Name)
                .IsUnique();

            // 3. Courses: Liên kết với Semesters
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Semester)
                .WithMany() // Tập hợp Course thuộc Semester
                .HasForeignKey(c => c.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.SemesterId);

            // 4. StudentCourses: Liên kết giữa Users (sinh viên) và Courses
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany() // Tập hợp Course mà sinh viên đăng ký
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany() // Tập hợp sinh viên thuộc Course
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasIndex(sc => new { sc.StudentId, sc.CourseId })
                .IsUnique(); // Đảm bảo một sinh viên chỉ đăng ký một Course một lần

            // 5. Projects: Liên kết với Courses và Users (Lecturer), ràng buộc CourseId và Lecturer.CourseId
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Course)
                .WithMany() // Tập hợp Project thuộc Course
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Lecturer)
                .WithMany() // Tập hợp Project mà giảng viên hướng dẫn
                .HasForeignKey(p => p.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.CourseId);

            // 6. ProjectVersions: Liên kết với Projects
            modelBuilder.Entity<ProjectVersion>()
                .HasOne(pv => pv.Project)
                .WithMany() // Tập hợp phiên bản thuộc Project
                .HasForeignKey(pv => pv.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProjectVersion>()
                .HasIndex(pv => pv.ProjectId);

            // 7. Groups: Liên kết với Projects
            modelBuilder.Entity<Entities.Group>()
                .HasOne(g => g.Project)
                .WithMany() // Tập hợp Group thuộc Project
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Group>()
                .HasIndex(g => g.ProjectId);

            // 8. GroupMembers: Liên kết với Groups và Users
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany() // Tập hợp thành viên thuộc Group
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Student)
                .WithMany() // Tập hợp Group mà sinh viên tham gia
                .HasForeignKey(gm => gm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupMember>()
                .HasIndex(gm => gm.GroupId);

            // 9. GroupRequests: Liên kết với Groups và Users
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Group)
                .WithMany() // Tập hợp yêu cầu thuộc Group
                .HasForeignKey(gr => gr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Student)
                .WithMany() // Tập hợp yêu cầu của sinh viên
                .HasForeignKey(gr => gr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupRequest>()
                .HasIndex(gr => gr.GroupId);

            // 10. Tasks: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Project)
                .WithMany() // Tập hợp Task thuộc Project
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Group)
                .WithMany() // Tập hợp Task thuộc Group
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Student)
                .WithMany() // Tập hợp Task được giao cho sinh viên
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasIndex(t => t.ProjectId);

            // 11. Submissions: Liên kết với Projects và Groups
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Project)
                .WithMany() // Tập hợp Submission thuộc Project
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Group)
                .WithMany() // Tập hợp Submission thuộc Group
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Submission>()
                .HasIndex(s => s.ProjectId);

            // 12. SubmissionVersions: Liên kết với Submissions
            modelBuilder.Entity<SubmissionVersion>()
                .HasOne(sv => sv.Submission)
                .WithMany() // Tập hợp phiên bản thuộc Submission
                .HasForeignKey(sv => sv.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubmissionVersion>()
                .HasIndex(sv => sv.SubmissionId);

            // 13. GradeCriteria: Liên kết với Courses
            modelBuilder.Entity<GradeCriteria>()
                .HasOne(gc => gc.Course)
                .WithMany() // Tập hợp tiêu chí thuộc Course
                .HasForeignKey(gc => gc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeCriteria>()
                .HasIndex(gc => gc.CourseId);

            // 14. Grades: Liên kết với Projects, Groups, Users, GradeCriteria
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Project)
                .WithMany() // Tập hợp Grade thuộc Project
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Group)
                .WithMany() // Tập hợp Grade thuộc Group
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany() // Tập hợp Grade của sinh viên
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Criteria)
                .WithMany() // Tập hợp Grade thuộc tiêu chí
                .HasForeignKey(g => g.CriteriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.GradedByUser)
                .WithMany() // Tập hợp Grade do giảng viên chấm
                .HasForeignKey(g => g.GradedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.ProjectId);

            // 15. GradeVersions: Liên kết với Grades
            modelBuilder.Entity<GradeVersion>()
                .HasOne(gv => gv.Grade)
                .WithMany() // Tập hợp phiên bản thuộc Grade
                .HasForeignKey(gv => gv.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeVersion>()
                .HasIndex(gv => gv.GradeId);

            // 16. GradeAppeals: Liên kết với Grades và Users
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Grade)
                .WithMany() // Tập hợp phúc khảo thuộc Grade
                .HasForeignKey(ga => ga.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Student)
                .WithMany() // Tập hợp phúc khảo của sinh viên
                .HasForeignKey(ga => ga.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeAppeal>()
                .HasIndex(ga => ga.GradeId);

            // 17. Notifications: Liên kết với Users và Groups
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany() // Tập hợp thông báo của User
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Group)
                .WithMany() // Tập hợp thông báo của Group
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserId);

            // 18. Meetings: Liên kết với Groups và Users
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Group)
                .WithMany() // Tập hợp Meeting thuộc Group
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreatedByUser)
                .WithMany() // Tập hợp Meeting do User tạo
                .HasForeignKey(m => m.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meeting>()
                .HasIndex(m => m.GroupId);

            // 19. MeetingRecords: Liên kết với Meetings
            modelBuilder.Entity<MeetingRecord>()
                .HasOne(mr => mr.Meeting)
                .WithMany() // Tập hợp bản ghi thuộc Meeting
                .HasForeignKey(mr => mr.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MeetingRecord>()
                .HasIndex(mr => mr.MeetingId);

            // 20. Resources: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Project)
                .WithMany() // Tập hợp Resource thuộc Project
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Group)
                .WithMany() // Tập hợp Resource thuộc Group
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.CreatedByUser)
                .WithMany() // Tập hợp Resource do User tạo
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.ProjectId);

            // 21. CodeRuns: Liên kết với Submissions
            modelBuilder.Entity<CodeRun>()
                .HasOne(cr => cr.Submission)
                .WithMany() // Tập hợp CodeRun thuộc Submission
                .HasForeignKey(cr => cr.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CodeRun>()
                .HasIndex(cr => cr.SubmissionId);

            // 22. Discussions: Liên kết với Projects và Users
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.Project)
                .WithMany() // Tập hợp Discussion thuộc Project
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.User)
                .WithMany() // Tập hợp Discussion của User
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasIndex(d => d.ProjectId);

            // 23. Feedbacks: Liên kết với Submissions and Users
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Submission)
                .WithMany() // Tập hợp Feedback thuộc Submission
                .HasForeignKey(f => f.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Lecturer)
                .WithMany() // Tập hợp Feedback do Lecturer tạo
                .HasForeignKey(f => f.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Feedback>()
                .HasIndex(f => f.SubmissionId);

            // 24. FeedbackSurveys: Liên kết với Users
            modelBuilder.Entity<FeedbackSurvey>()
                .HasOne(fs => fs.User)
                .WithMany() // Tập hợp khảo sát của User
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FeedbackSurvey>()
                .HasIndex(fs => fs.UserId);

            // 25. DefenseSchedules: Liên kết with Projects
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Project)
                .WithMany() // Tập hợp lịch bảo vệ thuộc Project
                .HasForeignKey(ds => ds.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.ProjectId);

            // 26. DefenseCommittees: Không có khóa ngoại
            modelBuilder.Entity<DefenseCommittee>()
                .HasIndex(dc => dc.Name)
                .IsUnique();

            // 27. CommitteeMembers: Liên kết với DefenseCommittees và Users
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Committee)
                .WithMany() // Tập hợp thành viên thuộc Committee
                .HasForeignKey(cm => cm.CommitteeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Lecturer)
                .WithMany() // Tập hợp vai trò trong Committee của Lecturer
                .HasForeignKey(cm => cm.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CommitteeMember>()
                .HasIndex(cm => cm.CommitteeId);

            // 28. Questions: Liên kết với Projects và Users
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Project)
                .WithMany() // Tập hợp câu hỏi thuộc Project
                .HasForeignKey(q => q.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedByUser)
                .WithMany() // Tập hợp câu hỏi do User tạo
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                .HasIndex(q => q.ProjectId);

            // 29. FAQs: Không có khóa ngoại
            modelBuilder.Entity<FAQ>()
                .HasIndex(f => f.Category);

            // 30. SkillAssessments: Liên kết với Users
            modelBuilder.Entity<SkillAssessment>()
                .HasOne(sa => sa.Student)
                .WithMany() // Tập hợp đánh giá kỹ năng của sinh viên
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SkillAssessment>()
                .HasIndex(sa => sa.StudentId);

            // 31. AISuggestions: Liên kết với Users và Projects
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.User)
                .WithMany() // Tập hợp gợi ý của User
                .HasForeignKey(ais => ais.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.Project)
                .WithMany() // Tập hợp gợi ý thuộc Project
                .HasForeignKey(ais => ais.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasIndex(ais => ais.ProjectId);

            // 32. TimeTrackings: Liên kết với Users và Projects
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Student)
                .WithMany() // Tập hợp thời gian làm việc của sinh viên
                .HasForeignKey(tt => tt.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Project)
                .WithMany() // Tập hợp thời gian làm việc thuộc Project
                .HasForeignKey(tt => tt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TimeTracking>()
                .HasIndex(tt => tt.StudentId);

            // 33. Logs: Liên kết với Users
            modelBuilder.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany() // Tập hợp nhật ký của User
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Log>()
                .HasIndex(l => l.UserId);

            // 34. GradeLogs: Liên kết với Grades và Users
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Grade)
                .WithMany() // Tập hợp nhật ký chấm điểm thuộc Grade
                .HasForeignKey(gl => gl.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Lecturer)
                .WithMany() // Tập hợp nhật ký chấm điểm của Lecturer
                .HasForeignKey(gl => gl.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeLog>()
                .HasIndex(gl => gl.GradeId);

            // 35. GradeSchedules: Liên kết với Projects and Users
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Project)
                .WithMany() // Tập hợp lịch chấm điểm thuộc Project
                .HasForeignKey(gs => gs.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Lecturer)
                .WithMany() // Tập hợp lịch chấm điểm của Lecturer
                .HasForeignKey(gs => gs.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeSchedule>()
                .HasIndex(gs => gs.ProjectId);

            // 36. SystemConfigs: Không có khóa ngoại
            modelBuilder.Entity<SystemConfig>()
                .HasIndex(sc => sc.Key)
                .IsUnique();

            // 37. Backups: Không có khóa ngoại
            modelBuilder.Entity<Backup>()
                .HasIndex(b => b.CreatedAt);

            // 38. SystemMetrics: Không có khóa ngoại
            modelBuilder.Entity<SystemMetric>()
                .HasIndex(sm => sm.MetricType);

            // 39. Calendars: Liên kết với Users and Groups
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.User)
                .WithMany() // Tập hợp lịch của User
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.Group)
                .WithMany() // Tập hợp lịch của Group
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasIndex(c => c.UserId);

            // 40. PeerReviews: Liên kết với Groups and Users
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Group)
                .WithMany() // Tập hợp đánh giá thuộc Group
                .HasForeignKey(pr => pr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany() // Tập hợp đánh giá do Reviewer thực hiện
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewee)
                .WithMany() // Tập hợp đánh giá nhận được bởi Reviewee
                .HasForeignKey(pr => pr.RevieweeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasIndex(pr => pr.GroupId);
        }
    }
}