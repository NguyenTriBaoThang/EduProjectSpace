// File: Entities/Log.cs
// Mục đích: Định nghĩa entity Log để lưu trữ nhật ký hệ thống (hành động, truy cập của người dùng).
// Hỗ trợ chức năng:
//   24: Theo dõi nhật ký hệ thống

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Log
    {
        // Khóa chính của bản ghi nhật ký
        [Key]
        public long Id { get; set; }

        // ID của người dùng thực hiện hành động (bắt buộc)
        [Required]
        public long UserId { get; set; }

        // Liên kết với entity User (người dùng thực hiện hành động)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Hành động được thực hiện (bắt buộc, ví dụ: "Login", "Create", "Update", "Delete", "Submission", "JoinGroup", "SendMessage", "Grade")
        [Required]
        public string Action { get; set; }

        // Chi tiết về hành động (tùy chọn, mô tả thêm thông tin)
        public string Details { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}