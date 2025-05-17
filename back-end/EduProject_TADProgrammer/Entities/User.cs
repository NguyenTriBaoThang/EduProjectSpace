// File: Entities/User.cs
// Mục đích: Định nghĩa entity User để lưu thông tin người dùng (Admin, Giảng viên, Sinh viên).
// Hỗ trợ chức năng: 
//   1: Phân quyền và bảo mật
//   3: Quản lý tài khoản
//   4: Quản lý phân quyền
//   6: Thông báo tự động
//   9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using BCrypt.Net;

namespace EduProject_TADProgrammer.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [StringLength(255)]
        public string ?AvatarUrl { get; set; }

        [StringLength(50)]
        public string ?ClassCode { get; set; } // For students only

        [Required]
        public int FailedLoginAttempts { get; set; } = 0;

        [Required]
        public bool Locked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Thêm quan hệ với Course cho giảng viên
        public long? CourseId { get; set; } // Chỉ áp dụng cho ROLE_LECTURER
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public virtual ICollection<GradeAppeal> GradeAppeals { get; set; } = new List<GradeAppeal>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public virtual ICollection<SkillAssessment> SkillAssessments { get; set; } = new List<SkillAssessment>();
        public virtual ICollection<AISuggestion> AISuggestions { get; set; } = new List<AISuggestion>();
        public virtual ICollection<TimeTracking> TimeTrackings { get; set; } = new List<TimeTracking>();
        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
        public virtual ICollection<GradeLog> GradeLogs { get; set; } = new List<GradeLog>();
        public virtual ICollection<GradeSchedule> GradeSchedules { get; set; } = new List<GradeSchedule>();
        public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        public virtual ICollection<FeedbackSurvey> FeedbackSurveys { get; set; } = new List<FeedbackSurvey>();
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public virtual ICollection<PeerReview> PeerReviewsAsReviewer { get; set; } = new List<PeerReview>();
        public virtual ICollection<PeerReview> PeerReviewsAsReviewee { get; set; } = new List<PeerReview>();
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>(); 
        public virtual ICollection<Grade> GradedGrades { get; set; } = new List<Grade>();

        // Phương thức mã hóa mật khẩu
        public void HashPassword()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }

        // Phương thức kiểm tra mật khẩu
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
