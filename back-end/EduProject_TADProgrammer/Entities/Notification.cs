// File: Core/Entities/Notification.cs
// Mục đích: Định nghĩa entity Notification để lưu thông báo gửi đến người dùng hoặc nhóm.
// Hỗ trợ chức năng: 
//   6: Hệ thống thông báo tự động
//   22: Admin - Tạo thông báo khẩn cấp
//   35: Giảng viên - Gửi thông báo cá nhân
//   46: AI theo dõi tiến độ và nhắc nhở
//   64: Thông báo nhóm qua tin nhắn
//   68: Quản lý danh sách sinh viên chờ duyệt
//   75: Lịch trình chấm điểm
//   76: Kiểm tra điểm bất thường
//   88: Theo dõi tiến độ nộp tài liệu
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Notification
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientType { get; set; }

        [Required]
        public string Type { get; set; } // EMAIL, WEB, URGENT

        [Required]
        public string Status { get; set; } // SENT, PENDING

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
