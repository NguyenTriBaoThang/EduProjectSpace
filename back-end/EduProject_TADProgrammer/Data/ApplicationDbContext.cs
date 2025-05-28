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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gọi seeding dữ liệu
            SeedData.Seed(modelBuilder);

            // 1. Users: Liên kết với Roles, Course (cho giảng viên), chỉ mục cho Username và Email
            // Hỗ trợ chức năng: 1, 3, 4, 6, 9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users) // Thuộc tính navigation: Users trong Role
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Role nếu User còn tồn tại
            modelBuilder.Entity<User>()
                .HasOne(u => u.Course) // Liên kết với Course cho giảng viên
                .WithMany(c => c.Lecturers) // Thuộc tính navigation: Lecturers trong Course
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
                .WithMany(s => s.Courses) // Thuộc tính navigation: Courses trong Semester
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
                .WithMany(u => u.StudentCourses) // Thuộc tính navigation: StudentCourses trong User
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses) // Thuộc tính navigation: StudentCourses trong Course
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentCourse>()
                .HasIndex(sc => new { sc.StudentId, sc.CourseId })
                .IsUnique(); // Đảm bảo một sinh viên chỉ đăng ký một Course một lần

            // 5. Projects: Liên kết với Courses và Users (Lecturer), ràng buộc CourseId và Lecturer.CourseId
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

            // 6. ProjectVersions: Liên kết với Projects
            modelBuilder.Entity<ProjectVersion>()
                .HasOne(pv => pv.Project)
                .WithMany(p => p.ProjectVersions) // Thuộc tính navigation: ProjectVersions trong Project
                .HasForeignKey(pv => pv.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProjectVersion>()
                .HasIndex(pv => pv.ProjectId);

            // 7. Groups: Liên kết với Projects
            modelBuilder.Entity<Entities.Group>()
                .HasIndex(g => g.ProjectId)
                .IsUnique(); // Đảm bảo mỗi Project chỉ có một Group


            // 8. GroupMembers: Liên kết với Groups và Users
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMembers) // Thuộc tính navigation: GroupMembers trong Group
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Student)
                .WithMany(u => u.GroupMembers) // Thuộc tính navigation: GroupMembers trong User
                .HasForeignKey(gm => gm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupMember>()
                .HasIndex(gm => gm.GroupId);

            // 9. GroupRequests: Liên kết với Groups và Users
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Group)
                .WithMany(g => g.GroupRequests) // Thuộc tính navigation: GroupRequests trong Group
                .HasForeignKey(gr => gr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GroupRequest>()
                .HasOne(gr => gr.Student)
                .WithMany(u => u.GroupRequests) // Thuộc tính navigation: GroupRequests trong User
                .HasForeignKey(gr => gr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupRequest>()
                .HasIndex(gr => gr.GroupId);

            // 10. Tasks: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks) // Thuộc tính navigation: Tasks trong Project
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Tasks) // Thuộc tính navigation: Tasks trong Group
                .HasForeignKey(t => t.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Student)
                .WithMany(u => u.Tasks) // Thuộc tính navigation: Tasks trong User
                .HasForeignKey(t => t.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            // Thêm cấu hình cho mối quan hệ với Submissions
            modelBuilder.Entity<Entities.Task>()
                .HasMany(t => t.Submissions)
                .WithOne(s => s.Task)
                .HasForeignKey(s => s.TaskId)
                .OnDelete(DeleteBehavior.Restrict); // Không xóa Task nếu Submission còn tồn tại
            modelBuilder.Entity<Entities.Task>()
                .HasIndex(t => t.ProjectId);

            // 11. Submissions: Liên kết với Projects và Groups
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Project)
                .WithMany(p => p.Submissions) // Thuộc tính navigation: Submissions trong Project
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Submission>()
                .HasOne(s => s.Group)
                .WithMany(g => g.Submissions) // Thuộc tính navigation: Submissions trong Group
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Submission>()
                .HasIndex(s => s.ProjectId);

            // 12. SubmissionVersions: Liên kết với Submissions
            modelBuilder.Entity<SubmissionVersion>()
                .HasOne(sv => sv.Submission)
                .WithMany(s => s.SubmissionVersions) // Thuộc tính navigation: SubmissionVersions trong Submission
                .HasForeignKey(sv => sv.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<SubmissionVersion>()
                .HasIndex(sv => sv.SubmissionId);

            // 13. GradeCriteria: Liên kết với Courses
            modelBuilder.Entity<GradeCriteria>()
                .HasOne(gc => gc.Course)
                .WithMany(c => c.GradeCriteria) // Thuộc tính navigation: GradeCriteria trong Course
                .HasForeignKey(gc => gc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeCriteria>()
                .HasIndex(gc => gc.CourseId);

            // 14. Grades: Liên kết với Projects, Groups, Users, GradeCriteria
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Project)
                .WithMany(p => p.Grades) // Thuộc tính navigation: Grades trong Project
                .HasForeignKey(g => g.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Group)
                .WithMany(g => g.Grades) // Thuộc tính navigation: Grades trong Group
                .HasForeignKey(g => g.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(u => u.Grades) // Thuộc tính navigation: Grades trong User
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Criteria)
                .WithMany(gc => gc.Grades) // Thuộc tính navigation: Grades trong GradeCriteria
                .HasForeignKey(g => g.CriteriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.GradedByUser)
                .WithMany(u => u.GradedGrades) // Thuộc tính navigation: GradedGrades trong User
                .HasForeignKey(g => g.GradedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grade>()
                .HasIndex(g => g.ProjectId);

            // 15. GradeVersions: Liên kết với Grades
            modelBuilder.Entity<GradeVersion>()
                .HasOne(gv => gv.Grade)
                .WithMany(g => g.GradeVersions) // Thuộc tính navigation: GradeVersions trong Grade
                .HasForeignKey(gv => gv.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeVersion>()
                .HasIndex(gv => gv.GradeId);

            // 16. GradeAppeals: Liên kết với Grades và Users
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Grade)
                .WithMany(g => g.GradeAppeals) // Thuộc tính navigation: GradeAppeals trong Grade
                .HasForeignKey(ga => ga.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeAppeal>()
                .HasOne(ga => ga.Student)
                .WithMany(u => u.GradeAppeals) // Thuộc tính navigation: GradeAppeals trong User
                .HasForeignKey(ga => ga.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeAppeal>()
                .HasIndex(ga => ga.GradeId);

            // 17. Notifications: Liên kết với Users và Groups
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications) // Thuộc tính navigation: Notifications trong User
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Group)
                .WithMany(g => g.Notifications) // Thuộc tính navigation: Notifications trong Group
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserId);

            // 18. Meetings: Liên kết với Groups và Users
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Meetings) // Thuộc tính navigation: Meetings trong Group
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreatedByUser)
                .WithMany(u => u.Meetings) // Thuộc tính navigation: Meetings trong User
                .HasForeignKey(m => m.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meeting>()
                .HasIndex(m => m.GroupId);

            // 19. MeetingRecords: Liên kết với Meetings
            modelBuilder.Entity<MeetingRecord>()
                .HasOne(mr => mr.Meeting)
                .WithMany(m => m.MeetingRecords) // Thuộc tính navigation: MeetingRecords trong Meeting
                .HasForeignKey(mr => mr.MeetingId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MeetingRecord>()
                .HasIndex(mr => mr.MeetingId);

            // 20. Resources: Liên kết với Projects, Groups, Users
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Project)
                .WithMany(p => p.Resources) // Thuộc tính navigation: Resources trong Project
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Group)
                .WithMany(g => g.Resources) // Thuộc tính navigation: Resources trong Group
                .HasForeignKey(r => r.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.CreatedByUser)
                .WithMany(g => g.Resources) // Thuộc tính navigation: Resources trong Group
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.ProjectId);

            // 21. CodeRuns: Liên kết với Submissions
            modelBuilder.Entity<CodeRun>()
                .HasOne(cr => cr.Submission)
                .WithMany(s => s.CodeRuns) // Thuộc tính navigation: CodeRuns trong Submission
                .HasForeignKey(cr => cr.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CodeRun>()
                .HasIndex(cr => cr.SubmissionId);

            // 22. Discussions: Liên kết với Projects và Users
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.Project)
                .WithMany(p => p.Discussions) // Thuộc tính navigation: Discussions trong Project
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasOne(d => d.User)
                .WithMany(u => u.Discussions) // Thuộc tính navigation: Discussions trong User
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Discussion>()
                .HasIndex(d => d.ProjectId);

            // 23. Feedbacks: Liên kết với Submissions and Users
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Submission)
                .WithMany(s => s.Feedbacks) // Thuộc tính navigation: Feedbacks trong Submission
                .HasForeignKey(f => f.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Lecturer)
                .WithMany(u => u.Feedbacks) // Thuộc tính navigation: Feedbacks trong User
                .HasForeignKey(f => f.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Feedback>()
                .HasIndex(f => f.SubmissionId);

            // 24. FeedbackSurveys: Liên kết với Users
            modelBuilder.Entity<FeedbackSurvey>()
                .HasOne(fs => fs.User)
                .WithMany(u => u.FeedbackSurveys) // Thuộc tính navigation: FeedbackSurveys trong User
                .HasForeignKey(fs => fs.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FeedbackSurvey>()
                .HasIndex(fs => fs.UserId);

            // 25. DefenseSchedules: Liên kết với Projects và Meetings
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Project)
                .WithMany(p => p.DefenseSchedules)
                .HasForeignKey(ds => ds.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<DefenseSchedule>()
                .HasOne(ds => ds.Meeting)
                .WithMany(m => m.DefenseSchedules)
                .HasForeignKey(ds => ds.MeetingId)
                .OnDelete(DeleteBehavior.Restrict); // Changed to Restrict to avoid cascade path issues
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.ProjectId);
            modelBuilder.Entity<DefenseSchedule>()
                .HasIndex(ds => ds.MeetingId);

            // 26. DefenseCommittees: Không có khóa ngoại
            modelBuilder.Entity<DefenseCommittee>()
                .HasIndex(dc => dc.Name)
                .IsUnique(); // Đảm bảo tên hội đồng duy nhất
            modelBuilder.Entity<DefenseCommittee>()
                .HasOne(dc => dc.Semester)
                .WithMany()
                .HasForeignKey(dc => dc.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            // 27. CommitteeMembers: Liên kết với DefenseCommittees và Users
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Committee)
                .WithMany(dc => dc.CommitteeMembers) // Thuộc tính navigation: CommitteeMembers trong DefenseCommittee
                .HasForeignKey(cm => cm.CommitteeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CommitteeMember>()
                .HasOne(cm => cm.Lecturer)
                .WithMany(u => u.CommitteeMembers) // Thuộc tính navigation: CommitteeMembers trong User
                .HasForeignKey(cm => cm.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CommitteeMember>()
                .HasIndex(cm => cm.CommitteeId);
            modelBuilder.Entity<CommitteeMember>()
                .Property(cm => cm.Role)
                .HasConversion<string>();

            // 28. Questions: Liên kết với Projects và Users
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Project)
                .WithMany(p => p.Questions) // Thuộc tính navigation: Questions trong Project
                .HasForeignKey(q => q.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedByUser)
                .WithMany(u => u.Questions) // Thuộc tính navigation: Questions trong User
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
                .WithMany(u => u.SkillAssessments) // Thuộc tính navigation: SkillAssessments trong User
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SkillAssessment>()
                .HasIndex(sa => sa.StudentId);

            // 31. AISuggestions: Liên kết với Users và Projects
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.User)
                .WithMany(u => u.AISuggestions) // Thuộc tính navigation: AISuggestions trong User
                .HasForeignKey(ais => ais.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasOne(ais => ais.Project)
                .WithMany(p => p.AISuggestions) // Thuộc tính navigation: AISuggestions trong Project
                .HasForeignKey(ais => ais.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AISuggestion>()
                .HasIndex(ais => ais.ProjectId);

            // 32. TimeTrackings: Liên kết với Users và Projects
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Student)
                .WithMany(u => u.TimeTrackings) // Thuộc tính navigation: TimeTrackings trong User
                .HasForeignKey(tt => tt.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeTracking>()
                .HasOne(tt => tt.Project)
                .WithMany(p => p.TimeTrackings) // Thuộc tính navigation: TimeTrackings trong Project
                .HasForeignKey(tt => tt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TimeTracking>()
                .HasIndex(tt => tt.StudentId);

            // 33. Logs: Liên kết với Users
            modelBuilder.Entity<Log>()
                .HasOne(l => l.User)
                .WithMany(u => u.Logs) // Thuộc tính navigation: Logs trong User
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Log>()
                .HasIndex(l => l.UserId);

            // 34. GradeLogs: Liên kết với Grades và Users
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Grade)
                .WithMany(g => g.GradeLogs) // Thuộc tính navigation: GradeLogs trong Grade
                .HasForeignKey(gl => gl.GradeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeLog>()
                .HasOne(gl => gl.Lecturer)
                .WithMany(u => u.GradeLogs) // Thuộc tính navigation: GradeLogs trong User
                .HasForeignKey(gl => gl.LecturerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GradeLog>()
                .HasIndex(gl => gl.GradeId);

            // 35. GradeSchedules: Liên kết với Projects and Users
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Project)
                .WithMany(p => p.GradeSchedules) // Thuộc tính navigation: GradeSchedules trong Project
                .HasForeignKey(gs => gs.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<GradeSchedule>()
                .HasOne(gs => gs.Lecturer)
                .WithMany(u => u.GradeSchedules) // Thuộc tính navigation: GradeSchedules trong User
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
                .WithMany(u => u.Calendars) // Thuộc tính navigation: Calendars trong User
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasOne(c => c.Group)
                .WithMany(g => g.Calendars) // Thuộc tính navigation: Calendars trong Group
                .HasForeignKey(c => c.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entities.Calendar>()
                .HasIndex(c => c.UserId);

            // 40. PeerReviews: Liên kết với Groups and Users
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Group)
                .WithMany(g => g.PeerReviews) // Thuộc tính navigation: PeerReviews trong Group
                .HasForeignKey(pr => pr.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany(u => u.PeerReviewsAsReviewer) // Thuộc tính navigation: PeerReviewsAsReviewer trong User
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasOne(pr => pr.Reviewee)
                .WithMany(u => u.PeerReviewsAsReviewee) // Thuộc tính navigation: PeerReviewsAsReviewee trong User
                .HasForeignKey(pr => pr.RevieweeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PeerReview>()
                .HasIndex(pr => pr.GroupId);

            // 41. RolePermission
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany() // Ghi chú: Role không cần navigation property ngược lại
                .HasForeignKey(rp => rp.RoleId);
        }
    }
}