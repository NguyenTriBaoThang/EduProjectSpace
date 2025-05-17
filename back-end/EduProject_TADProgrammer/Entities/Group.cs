// File: Entities/Group.cs
// Mục đích: Định nghĩa entity Group để lưu thông tin nhóm sinh viên thực hiện đề tài.
// Hỗ trợ chức năng: 
//   7: Quản lý quy trình đồ án
//   28: Giảng viên - Phân công nhóm
//   39: Sinh viên - Tham gia nhóm
//   49: Nhật ký hoạt động nhóm
//   52: Đánh giá hiệu suất nhóm
//   64: Thông báo nhóm
//   68: Quản lý danh sách sinh viên chờ duyệt
//   80: Tổng hợp điểm nhóm
//   87: Lập kế hoạch tài nguyên nhóm
//   88: Theo dõi tiến độ nộp tài liệu
//   89: Sinh viên - Xem tài nguyên nhóm
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa trạng thái của nhóm
    public enum GroupStatus
    {
        Approved,
        Pending
    }

    public class Group
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public int MaxMembers { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();
        public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
        public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();
        public virtual ICollection<PeerReview> PeerReviews { get; set; } = new List<PeerReview>();
        public virtual ICollection<User> Students { get; set; } = new List<User>();
    }
}