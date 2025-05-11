// File: Core/Models/NotificationDto.cs
// Mục đích: Truyền dữ liệu thông báo gửi đến người dùng hoặc nhóm giữa API và frontend.
// Chức năng hỗ trợ: 
//   6: Hệ thống thông báo tự động
//   22: Admin - Tạo thông báo khẩn cấp
//   35: Giảng viên - Gửi thông báo cá nhân
//   46: AI theo dõi tiến độ và nhắc nhở
//   64: Thông báo nhóm qua tin nhắn
//   68: Quản lý danh sách sinh viên chờ duyệt
//   75: Lịch trình chấm điểm
//   76: Kiểm tra điểm bất thường
//   88: Theo dõi tiến độ nộp tài liệu
namespace EduProject_TADProgrammer.Models
{
    public class NotificationDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? GroupId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}