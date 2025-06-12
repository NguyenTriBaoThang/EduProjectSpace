// File: Data/ApplicationDbContext.cs
// Mục đích: Cấu hình DbContext để ánh xạ 40 bảng cơ sở dữ liệu với Entity Framework Core.
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
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LecturerCourses> LecturerCourses { get; set; } // Thêm DbSet mới

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi seeding dữ liệu
            SeedData.Seed(modelBuilder);

            // 1. Users: Liên kết với Roles, chỉ mục cho Username và Email
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // 2. Semesters: Chỉ mục cho Name
            modelBuilder.Entity<Semester>()
                .HasIndex(s => s.Name)
                .IsUnique();

            // 3. Courses: Liên kết với Semesters và Departments
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Semester)
                .WithMany(s => s.Courses)
                .HasForeignKey(c => c.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId);
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.SemesterId);

            // 4. StudentCourses: Liên kết giữa Users (sinh viên) và Courses
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(u => u.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasIndex(sc => new { sc.StudentId, sc.CourseId })
                .IsUnique();

            // 5. LecturerCourses: Liên kết giữa Users (giảng viên) và Courses
            modelBuilder.Entity<LecturerCourses>()
                .HasOne(lc => lc.Lecturer)
                .WithMany(u => u.LecturerCourses)
                .HasForeignKey(lc => lc.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LecturerCourses>()
                .HasOne(lc => lc.Course)
                .WithMany(c => c.LecturerCourses)
                .HasForeignKey(lc => lc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<LecturerCourses>()
                .HasIndex(lc => new { lc.LecturerId, lc.CourseId })
                .IsUnique(); // Đảm bảo một giảng viên chỉ được gán một lần cho một Course

            // 6. Projects: Liên kết với Courses và Groups
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Group)
                .WithOne(g => g.Project)
                .HasForeignKey<Group>(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.CourseId);
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.ProjectCode)
                .IsUnique();

            // 7. ProjectVersions: Liên kết với Projects
            modelBuilder.Entity<ProjectVersion>()
                .HasOne(pv => pv.Project)
                .WithMany(p => p.ProjectVersions)
                .HasForeignKey(pv => pv.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProjectVersion>()
                .HasIndex(pv => pv.ProjectId);

            // 8. Groups: Liên kết với Projects
            modelBuilder.Entity<Entities.Group>()
                .HasIndex(g => g.ProjectId)
                .IsUnique();

            // 9. GroupMembers: Liên kết với Groups và Users
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMembers)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Student)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(gm => gm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupMember>()
                .HasIndex(gm => gm.GroupId);

            // 10. GroupRequests: Liên kết với Groups và Users
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Group)
                .WithMany(g => g.GroupRequests)
                .HasForeignKey(gr => gr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Student)
                .WithMany(u => u.GroupRequests)
                .HasForeignKey(gr => gr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupRequest>()
                .HasIndex(gr => gr.GroupId);

            // 11. Tasks: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Tasks)
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasMany(t => t.Submissions)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasIndex(t => t.ProjectId);

            // 12. Submissions: Liên kết với Projects và Groups
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Project)
                .WithMany(p => p.Submissions)
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Submission>()
                .HasOne(t => t.Student)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Submissions)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Submission>()
                .HasIndex(s => s.ProjectId);

            // 13. SubmissionVersions: Liên kết với Submissions
            modelBuilder.Entity<SubmissionVersion>()
                .HasOne(sv => sv.Submission)
                .WithMany(s => s.SubmissionVersions)
                .HasForeignKey(sv => sv.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubmissionVersion>()
                .HasIndex(sv => sv.SubmissionId);

            // 14. GradeCriteria: Liên kết với Courses
            modelBuilder.Entity<GradeCriteria>()
                .HasOne(gc => gc.Course)
                .WithMany(c => c.GradeCriteria)
                .HasForeignKey(gc => gc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeCriteria>()
                .HasIndex(gc => gc.CourseId);

            // 15. Grades: Liên kết với Projects, Groups, Users, GradeCriteria
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Project)
                .WithMany(p => p.Grades)
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Group)
                .WithMany(g => g.Grades)
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(u => u.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Criteria)
                .WithMany(gc => gc.Grades)
                .HasForeignKey(g => g.CriteriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.GradedByUser)
                .WithMany(u => u.GradedGrades)
                .HasForeignKey(g => g.GradedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.ProjectId);

            // 16. GradeVersions: Liên kết với Grades
            modelBuilder.Entity<GradeVersion>()
                .HasOne(gv => gv.Grade)
                .WithMany(g => g.GradeVersions)
                .HasForeignKey(gv => gv.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeVersion>()
                .HasIndex(gv => gv.GradeId);

            // 17. GradeAppeals: Liên kết với Grades và Users
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Grade)
                .WithMany(g => g.GradeAppeals)
                .HasForeignKey(ga => ga.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Student)
                .WithMany(u => u.GradeAppeals)
                .HasForeignKey(ga => ga.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeAppeal>()
                .HasIndex(ga => ga.GradeId);

            // 18. Notifications: Liên kết với Users và Groups
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Group)
                .WithMany(g => g.Notifications)
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserId);

            // 19. Meetings: Liên kết với Groups và Users
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Meetings)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreatedByUser)
                .WithMany(u => u.Meetings)
                .HasForeignKey(m => m.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meeting>()
                .HasIndex(m => m.GroupId);

            // 20. MeetingRecords: Liên kết với Meetings
            modelBuilder.Entity<MeetingRecord>()
                .HasOne(mr => mr.Meeting)
                .WithMany(m => m.MeetingRecords)
                .HasForeignKey(mr => mr.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MeetingRecord>()
                .HasIndex(mr => mr.MeetingId);

            // 21. Resources: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Project)
                .WithMany(p => p.Resources)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Group)
                .WithMany(g => g.Resources)
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.CreatedByUser)
                .WithMany(u => u.Resources)
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.ProjectId);

            // 22. CodeRuns: Liên kết với Submissions
            modelBuilder.Entity<CodeRun>()
                .HasOne(cr => cr.Submission)
                .WithMany(s => s.CodeRuns)
                .HasForeignKey(cr => cr.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CodeRun>()
                .HasIndex(cr => cr.SubmissionId);

            // 23. Discussions: Liên kết với Projects và Users
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Discussions)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.User)
                .WithMany(u => u.Discussions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasIndex(d => d.ProjectId);

            // 24. Feedbacks: Liên kết với Submissions và Users
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Submission)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(f => f.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Lecturer)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Feedback>()
                .HasIndex(f => f.SubmissionId);

            // 25. FeedbackSurveys: Liên kết với Users
            modelBuilder.Entity<FeedbackSurvey>()
                .HasOne(fs => fs.User)
                .WithMany(u => u.FeedbackSurveys)
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FeedbackSurvey>()
                .HasIndex(fs => fs.UserId);

            // 26. DefenseSchedules: Liên kết với Projects và Meetings
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Project)
                .WithMany(p => p.DefenseSchedules)
                .HasForeignKey(ds => ds.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Meeting)
                .WithMany(m => m.DefenseSchedules)
                .HasForeignKey(ds => ds.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.ProjectId);
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.MeetingId);

            // 27. DefenseCommittees: Liên kết với Semesters
            modelBuilder.Entity<DefenseCommittee>()
                .HasIndex(dc => dc.Name)
                .IsUnique();
            modelBuilder.Entity<DefenseCommittee>()
                .HasOne(dc => dc.Semester)
                .WithMany()
                .HasForeignKey(dc => dc.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            // 28. CommitteeMembers: Liên kết với DefenseCommittees và Users
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Committee)
                .WithMany(dc => dc.CommitteeMembers)
                .HasForeignKey(cm => cm.CommitteeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Lecturer)
                .WithMany(u => u.CommitteeMembers)
                .HasForeignKey(cm => cm.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CommitteeMember>()
                .HasIndex(cm => cm.CommitteeId);
            modelBuilder.Entity<CommitteeMember>()
                .Property(cm => cm.Role)
                .HasConversion<string>();

            // 29. Questions: Liên kết với Projects và Users
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Project)
                .WithMany(p => p.Questions)
                .HasForeignKey(q => q.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedByUser)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                .HasIndex(q => q.ProjectId);

            // 30. FAQs: Chỉ mục cho Category
            modelBuilder.Entity<FAQ>()
                .HasIndex(f => f.Category);

            // 31. SkillAssessments: Liên kết với Users
            modelBuilder.Entity<SkillAssessment>()
                .HasOne(sa => sa.Student)
                .WithMany(u => u.SkillAssessments)
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SkillAssessment>()
                .HasIndex(sa => sa.StudentId);

            // 32. AISuggestions: Liên kết với Users và Projects
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.User)
                .WithMany(u => u.AISuggestions)
                .HasForeignKey(ais => ais.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.Project)
                .WithMany(p => p.AISuggestions)
                .HasForeignKey(ais => ais.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasIndex(ais => ais.ProjectId);

            // 33. TimeTrackings: Liên kết với Users và Projects
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Student)
                .WithMany(u => u.TimeTrackings)
                .HasForeignKey(tt => tt.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Project)
                .WithMany(p => p.TimeTrackings)
                .HasForeignKey(tt => tt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TimeTracking>()
                .HasIndex(tt => tt.StudentId);

            // 34. Logs: Liên kết với Users
            modelBuilder.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logs)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Log>()
                .HasIndex(l => l.UserId);

            // 35. GradeLogs: Liên kết với Grades và Users
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Grade)
                .WithMany(g => g.GradeLogs)
                .HasForeignKey(gl => gl.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Lecturer)
                .WithMany(u => u.GradeLogs)
                .HasForeignKey(gl => gl.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeLog>()
                .HasIndex(gl => gl.GradeId);

            // 36. GradeSchedules: Liên kết với Projects và Users
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Project)
                .WithMany(p => p.GradeSchedules)
                .HasForeignKey(gs => gs.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Lecturer)
                .WithMany(u => u.GradeSchedules)
                .HasForeignKey(gs => gs.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeSchedule>()
                .HasIndex(gs => gs.ProjectId);

            // 37. SystemConfigs: Chỉ mục cho Key
            modelBuilder.Entity<SystemConfig>()
                .HasIndex(sc => sc.Key)
                .IsUnique();

            // 38. Backups: Chỉ mục cho CreatedAt
            modelBuilder.Entity<Backup>()
                .HasIndex(b => b.CreatedAt);

            // 39. SystemMetrics: Chỉ mục cho MetricType
            modelBuilder.Entity<SystemMetric>()
                .HasIndex(sm => sm.MetricType);

            // 40. Calendars: Liên kết với Users và Groups
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.User)
                .WithMany(u => u.Calendars)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.Group)
                .WithMany(g => g.Calendars)
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasIndex(c => c.UserId);

            // 41. PeerReviews: Liên kết với Groups và Users
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Group)
                .WithMany(g => g.PeerReviews)
                .HasForeignKey(pr => pr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany(u => u.PeerReviewsAsReviewer)
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewee)
                .WithMany(u => u.PeerReviewsAsReviewee)
                .HasForeignKey(pr => pr.RevieweeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasIndex(pr => pr.GroupId);

            // 42. RolePermission
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany()
                .HasForeignKey(rp => rp.RoleId);
        }
    }
}