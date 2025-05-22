// File: Core/Models/NotificationDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu thông báo gửi đến người dùng hoặc nhóm, và cấu hình thông báo giữa API và frontend.
// Hỗ trợ chức năng:
//   6: Thông báo tự động (gửi thông báo đến người dùng hoặc nhóm, quản lý cấu hình thông báo).

using System;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin chi tiết thông báo
    public class NotificationDto
    {
        // ID của thông báo
        public long Id { get; set; }

        // ID của người dùng nhận thông báo
        public long UserId { get; set; }

        // ID của nhóm nhận thông báo (tùy chọn, null nếu gửi cho cá nhân)
        public long? GroupId { get; set; }

        // Tiêu đề thông báo (ví dụ: "Cập nhật tiến độ đồ án")
        public string Title { get; set; }

        // Nội dung thông báo (ví dụ: "Vui lòng nộp báo cáo giai đoạn 1 trước ngày 2023-10-20")
        public string Content { get; set; }

        // Loại thông báo (ví dụ: "Hệ thống", "Nhắc nhở", "Cảnh báo")
        public string Type { get; set; }

        // Trạng thái thông báo (ví dụ: "Chưa đọc", "Đã đọc")
        public string Status { get; set; }

        // Loại người nhận (ví dụ: "Cá nhân", "Nhóm")
        public string RecipientType { get; set; }

        // Thời gian tạo thông báo
        public DateTime CreatedAt { get; set; }
    }

    // DTO để truyền thông tin cấu hình thông báo
    public class NotificationConfigDto
    {
        // Cho phép gửi thông báo qua web (true: bật, false: tắt)
        public bool EnableWeb { get; set; }

        // Cho phép gửi thông báo qua email (true: bật, false: tắt)
        public bool EnableEmail { get; set; }

        // Tần suất nhắc nhở (ví dụ: "none", "daily", "weekly")
        public string ReminderFrequency { get; set; }
    }
}