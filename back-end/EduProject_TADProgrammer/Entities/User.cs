// File: Entities/User.cs
// Mục đích: Định nghĩa entity User để lưu trữ thông tin người dùng (Admin, Giảng viên, Sinh viên).
// Hỗ trợ chức năng:
//   1: Phân quyền và bảo mật
//   3: Quản lý tài khoản
//   4: Quản lý phân quyền
//   6: Thông báo tự động
//   9, 23, 27, 29, 30, 32-35, 39, 40, 43, 55, 60, 72, 78, 84

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class User
    {
        // Khóa chính của bản ghi người dùng
        [Key]
        public long Id { get; set; }

        // Tên đăng nhập (bắt buộc, từ 3 đến 50 ký tự)
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        // Mật khẩu (bắt buộc, từ 8 đến 255 ký tự, được mã hóa)
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        // Email (bắt buộc, tối đa 100 ký tự, định dạng email hợp lệ)
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        // Họ và tên đầy đủ (bắt buộc, tối đa 100 ký tự)
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        // ID của vai trò (bắt buộc)
        [Required]
        public long RoleId { get; set; }

        // Liên kết với entity Role (vai trò của người dùng)
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        // URL của ảnh đại diện (tùy chọn, tối đa 255 ký tự)
        [StringLength(255)]
        public string? AvatarUrl { get; set; }

        // Mã lớp học (tùy chọn, tối đa 50 ký tự, chỉ áp dụng cho sinh viên)
        [StringLength(50)]
        public string? ClassCode { get; set; }

        // ID của khoa (tùy chọn, áp dụng cho giảng viên hướng dẫn, sinh viên, trưởng khoa)
        public long? DepartmentId { get; set; }

        // Liên kết với entity Department (khoa của người dùng)
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        // ID của môn học (tùy chọn, chỉ áp dụng cho giảng viên)
        public long? CourseId { get; set; }

        // Liên kết với entity Course (môn học giảng viên phụ trách)
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // Số lần đăng nhập thất bại (bắt buộc, mặc định là 0)
        [Required]
        public int FailedLoginAttempts { get; set; } = 0;

        // Trạng thái khóa tài khoản (bắt buộc, mặc định là false)
        [Required]
        public bool Locked { get; set; } = false;

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách quan hệ với các entity khác
        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>(); // Thành viên nhóm
        public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>(); // Yêu cầu tham gia nhóm
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>(); // Nhiệm vụ được giao
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>(); // Điểm số của người dùng
        public virtual ICollection<GradeAppeal> GradeAppeals { get; set; } = new List<GradeAppeal>(); // Yêu cầu phúc khảo điểm
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>(); // Thông báo nhận được
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>(); // Cuộc họp tổ chức hoặc tham gia
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>(); // Tài nguyên được tạo
        public virtual ICollection<SkillAssessment> SkillAssessments { get; set; } = new List<SkillAssessment>(); // Đánh giá kỹ năng
        public virtual ICollection<AISuggestion> AISuggestions { get; set; } = new List<AISuggestion>(); // Gợi ý AI
        public virtual ICollection<TimeTracking> TimeTrackings { get; set; } = new List<TimeTracking>(); // Theo dõi thời gian làm việc
        public virtual ICollection<Log> Logs { get; set; } = new List<Log>(); // Nhật ký hoạt động
        public virtual ICollection<GradeLog> GradeLogs { get; set; } = new List<GradeLog>(); // Nhật ký điểm
        public virtual ICollection<GradeSchedule> GradeSchedules { get; set; } = new List<GradeSchedule>(); // Lịch chấm điểm
        public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>(); // Thảo luận trên diễn đàn
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>(); // Phản hồi
        public virtual ICollection<FeedbackSurvey> FeedbackSurveys { get; set; } = new List<FeedbackSurvey>(); // Khảo sát phản hồi
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>(); // Thành viên hội đồng
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>(); // Câu hỏi kiểm tra
        public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>(); // Lịch cá nhân
        public virtual ICollection<PeerReview> PeerReviewsAsReviewer { get; set; } = new List<PeerReview>(); // Đánh giá ngang hàng (người đánh giá)
        public virtual ICollection<PeerReview> PeerReviewsAsReviewee { get; set; } = new List<PeerReview>(); // Đánh giá ngang hàng (người được đánh giá)
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>(); // Môn học sinh viên đăng ký
        public virtual ICollection<Grade> GradedGrades { get; set; } = new List<Grade>(); // Điểm do người dùng chấm

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