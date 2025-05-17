// File: Entities/Log.cs
// Mục đích: Định nghĩa entity Log để lưu nhật ký hệ thống (hành động, truy cập).
// Hỗ trợ chức năng: 
//   24: Theo dõi nhật ký hệ thống
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public enum LogAction
    {
        Login,         // Đăng nhập
        Update,        // Cập nhật thông tin
        Delete,        // Xóa
        Submission,    // Nộp bài
        JoinGroup,     // Tham gia nhóm
        SendMessage,   // Gửi tin nhắn
        Create,        // Tạo mới
        Grade          // Chấm điểm
    }

    public class Log
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Action { get; set; }

        public string Details { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
