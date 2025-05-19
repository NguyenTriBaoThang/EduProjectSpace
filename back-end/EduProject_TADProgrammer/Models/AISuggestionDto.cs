// File: Core/Models/AISuggestionDto.cs
// Mục đích: Truyền dữ liệu gợi ý từ AI (đề tài, tài liệu, điểm số) giữa API và frontend.
// Chức năng hỗ trợ: 
//   46: AI theo dõi tiến độ và nhắc nhở
//   47: AI gợi ý học tập và đề tài
//   54: Gợi ý công cụ lập trình
//   56: Quản lý lịch bảo vệ (gợi ý lịch)
//   71: AI hỗ trợ chấm điểm và đánh giá
//   86: Hỗ trợ phân tích phản hồi giảng viên
namespace EduProject_TADProgrammer.Models
{
    public class AISuggestionDto
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ProjectId { get; set; }
        public string Type { get; set; } //Project, Grade, Resource, Schedule, Feedback
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}