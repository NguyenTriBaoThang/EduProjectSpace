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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi seeding dữ liệu
            SeedData.Seed(modelBuilder);

            // Cấu hình mối quan hệ và ràng buộc cho từng bảng

            // 1. Users: Liên kết với Roles, chỉ mục cho Username và Email
            // Hỗ trợ chức năng: 1, 3, 4, 6, 9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Role nếu User còn tồn tại
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // 2. Projects: Liên kết với Courses và Users (Lecturer)
            // Hỗ trợ chức năng: 7, 8, 9, 27, 50, 56, 67, 75
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Course)
                .WithMany()
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Lecturer)
                .WithMany()
                .HasForeignKey(p => p.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.CourseId);

            // 3. ProjectVersions: Liên kết với Projects
            // Hỗ trợ chức năng: 67
            modelBuilder.Entity<ProjectVersion>()
                .HasOne(pv => pv.Project)
                .WithMany()
                .HasForeignKey(pv => pv.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa phiên bản nếu Project bị xóa
            modelBuilder.Entity<ProjectVersion>()
                .HasIndex(pv => pv.ProjectId);

            // 4. Groups: Liên kết với Projects
            // Hỗ trợ chức năng: 7, 28, 39, 49, 52, 64, 68, 80, 87, 88, 89
            modelBuilder.Entity<Entities.Group>()
                .HasOne(g => g.Project)
                .WithMany()
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Group>()
                .HasIndex(g => g.ProjectId);

            // 5. GroupMembers: Liên kết với Groups và Users
            // Hỗ trợ chức năng: 39, 52
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany()
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Student)
                .WithMany()
                .HasForeignKey(gm => gm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupMember>()
                .HasIndex(gm => gm.GroupId);

            // 6. GroupRequests: Liên kết với Groups và Users
            // Hỗ trợ chức năng: 68
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Group)
                .WithMany()
                .HasForeignKey(gr => gr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Student)
                .WithMany()
                .HasForeignKey(gr => gr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupRequest>()
                .HasIndex(gr => gr.GroupId);

            // 7. Tasks: Liên kết với Projects, Groups, Users
            // Hỗ trợ chức năng: 27, 29, 40, 53
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Group)
                .WithMany()
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Student)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasIndex(t => t.ProjectId);

            // 8. Submissions: Liên kết với Projects và Groups
            // Hỗ trợ chức năng: 7, 10, 11, 32, 59, 65, 69, 88
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Project)
                .WithMany()
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Group)
                .WithMany()
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Submission>()
                .HasIndex(s => s.ProjectId);

            // 9. SubmissionVersions: Liên kết với Submissions
            // Hỗ trợ chức năng: 59
            modelBuilder.Entity<SubmissionVersion>()
                .HasOne(sv => sv.Submission)
                .WithMany()
                .HasForeignKey(sv => sv.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubmissionVersion>()
                .HasIndex(sv => sv.SubmissionId);

            // 10. GradeCriteria: Liên kết với Courses
            // Hỗ trợ chức năng: 12, 13, 20, 70, 79
            modelBuilder.Entity<GradeCriteria>()
                .HasOne(gc => gc.Course)
                .WithMany()
                .HasForeignKey(gc => gc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeCriteria>()
                .HasIndex(gc => gc.CourseId);

            // 11. Grades: Liên kết với Projects, Groups, Users, GradeCriteria
            // Hỗ trợ chức năng: 12, 13, 14, 15, 36, 61, 66, 71, 72, 74, 76-83
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Project)
                .WithMany()
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Group)
                .WithMany()
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Criteria)
                .WithMany()
                .HasForeignKey(g => g.CriteriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.GradedByUser)
                .WithMany()
                .HasForeignKey(g => g.GradedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.ProjectId);

            // 12. GradeVersions: Liên kết với Grades
            // Hỗ trợ chức năng: 81
            modelBuilder.Entity<GradeVersion>()
                .HasOne(gv => gv.Grade)
                .WithMany()
                .HasForeignKey(gv => gv.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeVersion>()
                .HasIndex(gv => gv.GradeId);

            // 13. GradeAppeals: Liên kết với Grades và Users
            // Hỗ trợ chức năng: 72
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Grade)
                .WithMany()
                .HasForeignKey(ga => ga.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Student)
                .WithMany()
                .HasForeignKey(ga => ga.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeAppeal>()
                .HasIndex(ga => ga.GradeId);

            // 14. Notifications: Liên kết với Users và Groups
            // Hỗ trợ chức năng: 6, 22, 35, 46, 64, 68, 75, 76, 88
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Group)
                .WithMany()
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserId);

            // 15. Meetings: Liên kết với Groups và Users
            // Hỗ trợ chức năng: 30, 73
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Group)
                .WithMany()
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreatedByUser)
                .WithMany()
                .HasForeignKey(m => m.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meeting>()
                .HasIndex(m => m.GroupId);

            // 16. MeetingRecords: Liên kết với Meetings
            // Hỗ trợ chức năng: 73
            modelBuilder.Entity<MeetingRecord>()
                .HasOne(mr => mr.Meeting)
                .WithMany()
                .HasForeignKey(mr => mr.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MeetingRecord>()
                .HasIndex(mr => mr.MeetingId);

            // 17. Resources: Liên kết với Projects, Groups, Users
            // Hỗ trợ chức năng: 31, 38, 42, 51, 69, 87, 89, 90
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Project)
                .WithMany()
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Group)
                .WithMany()
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.CreatedByUser)
                .WithMany()
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.ProjectId);

            // 18. CodeRuns: Liên kết với Submissions
            // Hỗ trợ chức năng: 44, 57, 65
            modelBuilder.Entity<CodeRun>()
                .HasOne(cr => cr.Submission)
                .WithMany()
                .HasForeignKey(cr => cr.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CodeRun>()
                .HasIndex(cr => cr.SubmissionId);

            // 19. Discussions: Liên kết với Projects và Users
            // Hỗ trợ chức năng: 41, 48
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasIndex(d => d.ProjectId);

            // 20. Feedbacks: Liên kết với Submissions và Users
            // Hỗ trợ chức năng: 14, 62, 86
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Submission)
                .WithMany()
                .HasForeignKey(f => f.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Lecturer)
                .WithMany()
                .HasForeignKey(f => f.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Feedback>()
                .HasIndex(f => f.SubmissionId);

            // 21. FeedbackSurveys: Liên kết với Users
            // Hỗ trợ chức năng: 72
            modelBuilder.Entity<FeedbackSurvey>()
                .HasOne(fs => fs.User)
                .WithMany()
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FeedbackSurvey>()
                .HasIndex(fs => fs.UserId);

            // 22. DefenseSchedules: Liên kết với Projects
            // Hỗ trợ chức năng: 56
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Project)
                .WithMany()
                .HasForeignKey(ds => ds.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.ProjectId);

            // 23. CommitteeMembers: Liên kết với DefenseCommittees và Users
            // Hỗ trợ chức năng: 19
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Committee)
                .WithMany()
                .HasForeignKey(cm => cm.CommitteeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Lecturer)
                .WithMany()
                .HasForeignKey(cm => cm.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CommitteeMember>()
                .HasIndex(cm => cm.CommitteeId);

            // 24. Questions: Liên kết với Projects và Users
            // Hỗ trợ chức năng: 33, 85
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Project)
                .WithMany()
                .HasForeignKey(q => q.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedByUser)
                .WithMany()
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                .HasIndex(q => q.ProjectId);

            // 25. FAQs: Không có khóa ngoại
            // Hỗ trợ chức năng: 58
            modelBuilder.Entity<FAQ>()
                .HasIndex(f => f.Category);

            // 26. SkillAssessments: Liên kết với Users
            // Hỗ trợ chức năng: 60
            modelBuilder.Entity<SkillAssessment>()
                .HasOne(sa => sa.Student)
                .WithMany()
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SkillAssessment>()
                .HasIndex(sa => sa.StudentId);

            // 27. AISuggestions: Liên kết với Users và Projects
            // Hỗ trợ chức năng: 46, 47, 54, 56, 71, 86
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.User)
                .WithMany()
                .HasForeignKey(ais => ais.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.Project)
                .WithMany()
                .HasForeignKey(ais => ais.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasIndex(ais => ais.ProjectId);

            // 28. TimeTrackings: Liên kết với Users và Projects
            // Hỗ trợ chức năng: 37, 55
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Student)
                .WithMany()
                .HasForeignKey(tt => tt.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Project)
                .WithMany()
                .HasForeignKey(tt => tt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TimeTracking>()
                .HasIndex(tt => tt.StudentId);

            // 29. Logs: Liên kết với Users
            // Hỗ trợ chức năng: 24
            modelBuilder.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Log>()
                .HasIndex(l => l.UserId);

            // 30. GradeLogs: Liên kết với Grades và Users
            // Hỗ trợ chức năng: 74
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Grade)
                .WithMany()
                .HasForeignKey(gl => gl.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Lecturer)
                .WithMany()
                .HasForeignKey(gl => gl.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeLog>()
                .HasIndex(gl => gl.GradeId);

            // 31. GradeSchedules: Liên kết với Projects và Users
            // Hỗ trợ chức năng: 75
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Project)
                .WithMany()
                .HasForeignKey(gs => gs.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Lecturer)
                .WithMany()
                .HasForeignKey(gs => gs.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeSchedule>()
                .HasIndex(gs => gs.ProjectId);

            // 32. SystemConfigs: Không có khóa ngoại
            // Hỗ trợ chức năng: 16
            modelBuilder.Entity<SystemConfig>()
                .HasIndex(sc => sc.Key)
                .IsUnique();

            // 33. Backups: Không có khóa ngoại
            // Hỗ trợ chức năng: 25
            modelBuilder.Entity<Backup>()
                .HasIndex(b => b.CreatedAt);

            // 34. SystemMetrics: Không có khóa ngoại
            // Hỗ trợ chức năng: 26
            modelBuilder.Entity<SystemMetric>()
                .HasIndex(sm => sm.MetricType);

            // 35. Calendars: Liên kết với Users và Groups
            // Hỗ trợ chức năng: 84
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.Group)
                .WithMany()
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasIndex(c => c.UserId);

            // 36. PeerReviews: Liên kết với Groups và Users
            // Hỗ trợ chức năng: 52
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Group)
                .WithMany()
                .HasForeignKey(pr => pr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany()
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewee)
                .WithMany()
                .HasForeignKey(pr => pr.RevieweeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasIndex(pr => pr.GroupId);
        }
    }
}