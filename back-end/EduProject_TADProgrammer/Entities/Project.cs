// File: Entities/Project.cs
// Mục đích: Định nghĩa entity Project để lưu trữ thông tin đề tài đồ án (tiêu đề, mô tả, trạng thái).
// Hỗ trợ chức năng:
//   7: Quản lý quy trình đồ án
//   8: Đề xuất và kiểm tra đề tài
//   9: Phân công đề tài
//   27: Giao nhiệm vụ
//   50: Quản lý danh sách đề tài bắt buộc
//   56: Quản lý lịch bảo vệ
//   67: Lịch sử chỉnh sửa đề tài
//   75: Lịch trình chấm điểm

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Project
    {
        // Khóa chính của bản ghi đề tài
        [Key]
        public long Id { get; set; }

        // Tiêu đề đề tài (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Mô tả chi tiết đề tài (tùy chọn)
        public string Description { get; set; }

        // ID của môn học liên quan (bắt buộc)
        [Required]
        public long CourseId { get; set; }

        // Liên kết với entity Course (môn học chứa đề tài)
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // ID của nhóm thực hiện đề tài (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm thực hiện đề tài)
        public Group Group { get; set; }

        // Trạng thái của đề tài (bắt buộc, ví dụ: "Proposed", "Approved", "Completed")
        [Required]
        public string Status { get; set; }

        // Mã đề tài (bắt buộc, tối đa 20 ký tự)
        [Required]
        [StringLength(20)]
        public string ProjectCode { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách các phiên bản của đề tài (lịch sử chỉnh sửa)
        public virtual ICollection<ProjectVersion> ProjectVersions { get; set; } = new List<ProjectVersion>();

        // Danh sách nhiệm vụ liên quan đến đề tài
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

        // Danh sách bài nộp của đề tài
        public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

        // Danh sách điểm số của đề tài
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        // Danh sách tài nguyên liên quan đến đề tài
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

        // Danh sách bài đăng hoặc bình luận trên diễn đàn liên quan đến đề tài
        public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();

        // Danh sách lịch bảo vệ của đề tài
        public virtual ICollection<DefenseSchedule> DefenseSchedules { get; set; } = new List<DefenseSchedule>();

        // Danh sách câu hỏi liên quan đến đề tài
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        // Danh sách gợi ý AI cho đề tài
        public virtual ICollection<AISuggestion> AISuggestions { get; set; } = new List<AISuggestion>();

        // Danh sách theo dõi thời gian làm việc trên đề tài
        public virtual ICollection<TimeTracking> TimeTrackings { get; set; } = new List<TimeTracking>();

        // Danh sách lịch trình chấm điểm của đề tài
        public virtual ICollection<GradeSchedule> GradeSchedules { get; set; } = new List<GradeSchedule>();
    }
}