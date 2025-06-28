// File: Entities/Notification.cs
// Mục đích: Định nghĩa entity Notification để lưu trữ thông báo gửi đến người dùng hoặc nhóm trong hệ thống.
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
        // Khóa chính của bản ghi thông báo
        [Key]
        public long Id { get; set; }

        // ID của người dùng liên quan (bắt buộc, thường là người tạo hoặc người nhận nếu RecipientType là Individual)
        [Required]
        public long? UserId { get; set; }

        // Liên kết với entity User (người dùng liên quan)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // ID của nhóm liên quan (tùy chọn, sử dụng nếu RecipientType là Group)
        public long? GroupId { get; set; }

        // Liên kết với entity Group (nhóm nhận thông báo)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Tiêu đề thông báo (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Nội dung thông báo (bắt buộc)
        [Required]
        public string Content { get; set; }

        // Loại người nhận (bắt buộc, tối đa 50 ký tự, giá trị: "Individual", "Group", "Course", "All")
        [Required]
        [StringLength(50)]
        public string RecipientType { get; set; }

        // Người dùng đã xem thông báo này lần đầu chưa (dùng cho loại cá nhân)
        public bool IsFirstViewed { get; set; } = false;

        // Thời gian xem lần đầu (tùy chọn, nếu bạn muốn lưu)
        public DateTime? FirstViewedAt { get; set; }

        // Loại thông báo (bắt buộc, giá trị: "Email", "Web", "Urgent")
        [Required]
        public string Type { get; set; }

        // Trạng thái thông báo (bắt buộc, giá trị: "Pending", "Sent", "Failed")
        [Required]
        public string Status { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}