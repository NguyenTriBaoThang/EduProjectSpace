// File: Entities/Project.cs
// Mục đích: Định nghĩa entity Project để lưu thông tin đề tài đồ án (tiêu đề, mô tả, trạng thái).
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa trạng thái của dự án
    public enum ProjectStatus
    {
        Pending,    // Đang chờ phê duyệt
        Approved,   // Đã được phê duyệt
        Rejected,   // Bị từ chối
        Submitted,  // Đã nộp
        Graded      // Đã chấm điểm
    }

    public class Project
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        public long LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        [Required]
        public long GroupId { get; set; }

        public Group Group { get; set; } 

        [Required]
        public string Status { get; set; }

        [Required]
        [StringLength(20)]
        public string ProjectCode { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ProjectVersion> ProjectVersions { get; set; } = new List<ProjectVersion>();
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
        public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();
        public virtual ICollection<DefenseSchedule> DefenseSchedules { get; set; } = new List<DefenseSchedule>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        public virtual ICollection<AISuggestion> AISuggestions { get; set; } = new List<AISuggestion>();
        public virtual ICollection<TimeTracking> TimeTrackings { get; set; } = new List<TimeTracking>();
        public virtual ICollection<GradeSchedule> GradeSchedules { get; set; } = new List<GradeSchedule>();
    }
}
