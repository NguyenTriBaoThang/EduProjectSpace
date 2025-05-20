// File: Entities/Group.cs
// Mục đích: Định nghĩa entity Group để lưu trữ thông tin nhóm sinh viên thực hiện đề tài trong hệ thống.
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
    public class Group
    {
        // Khóa chính của bản ghi nhóm
        [Key]
        public long Id { get; set; }

        // Tên nhóm (bắt buộc, tối đa 50 ký tự)
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // ID của dự án liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (dự án của nhóm)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Số thành viên tối đa của nhóm (mặc định là 0 nếu không giới hạn)
        public int MaxMembers { get; set; }

        // Trạng thái của nhóm (tối đa 50 ký tự, ví dụ: "Approved", "Pending")
        [StringLength(50)]
        public string Status { get; set; }

        // ID của giảng viên hướng dẫn (tùy chọn)
        public long? LecturerId { get; set; }

        // Liên kết với entity User (giảng viên hướng dẫn)
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách thành viên của nhóm
        public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

        // Danh sách yêu cầu tham gia nhóm
        public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();

        // Danh sách nhiệm vụ của nhóm
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

        // Danh sách bài nộp của nhóm
        public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

        // Danh sách điểm số của nhóm
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

        // Danh sách thông báo liên quan đến nhóm
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        // Danh sách cuộc họp của nhóm
        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

        // Danh sách tài nguyên của nhóm
        public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

        // Danh sách lịch của nhóm
        public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

        // Danh sách đánh giá ngang hàng trong nhóm
        public virtual ICollection<PeerReview> PeerReviews { get; set; } = new List<PeerReview>();

        // Danh sách sinh viên trong nhóm
        public virtual ICollection<User> Students { get; set; } = new List<User>();
    }
}