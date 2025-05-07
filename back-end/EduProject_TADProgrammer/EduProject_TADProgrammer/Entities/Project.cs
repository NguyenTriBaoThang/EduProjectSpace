// File: Core/Entities/Project.cs
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

namespace EduProject_TADProgrammer.Entities
{
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
        public string Status { get; set; } // PENDING, APPROVED, REJECTED

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
