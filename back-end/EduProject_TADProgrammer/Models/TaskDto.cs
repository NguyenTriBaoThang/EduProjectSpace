// File: Core/Models/TaskDto.cs
// Mục đích: Truyền dữ liệu nhiệm vụ được giao cho nhóm hoặc sinh viên giữa API và frontend.
// Chức năng hỗ trợ: 
//   27: Giảng viên - Giao nhiệm vụ
//   29: Giảng viên - Xem báo cáo tiến độ
//   40: Sinh viên - Kiểm tra tiến độ cá nhân
//   53: Lập kế hoạch và quản lý nhiệm vụ
namespace EduProject_TADProgrammer.Models
{
    public class TaskDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long? GroupId { get; set; }
        public long? StudentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}