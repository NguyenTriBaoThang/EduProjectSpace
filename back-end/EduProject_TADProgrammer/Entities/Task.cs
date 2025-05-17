// File: Entities/Task.cs
// Mục đích: Định nghĩa entity Task để lưu nhiệm vụ được giao cho nhóm hoặc sinh viên.
// Hỗ trợ chức năng: 
//   27: Giảng viên - Giao nhiệm vụ
//   29: Giảng viên - Xem báo cáo tiến độ
//   40: Sinh viên - Kiểm tra tiến độ cá nhân
//   53: Lập kế hoạch và quản lý nhiệm vụ
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa trạng thái của nhiệm vụ
    public enum TaskStatus
    {
        Todo,       // Chưa bắt đầu
        InProgress, // Đang thực hiện
        Done        // Hoàn thành
    }

    public class Task
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public long? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public long? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
