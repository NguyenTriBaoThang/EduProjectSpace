// File: Entities/AISuggestion.cs
// Mục đích: Định nghĩa entity AISuggestion để lưu trữ các gợi ý từ AI, hỗ trợ các chức năng liên quan đến học tập và quản lý đồ án.
// Hỗ trợ chức năng:
//   46: AI theo dõi tiến độ và nhắc nhở
//   47: AI gợi ý học tập và đề tài
//   54: Gợi ý công cụ lập trình
//   56: Quản lý lịch bảo vệ (gợi ý lịch)
//   71: AI hỗ trợ chấm điểm và đánh giá
//   86: Hỗ trợ phân tích phản hồi giảng viên

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class AISuggestion
    {
        // Khóa chính của bản ghi gợi ý
        [Key]
        public long Id { get; set; }

        // ID của người dùng nhận gợi ý (có thể null nếu gợi ý không dành cho cá nhân cụ thể)
        public long? UserId { get; set; }

        // Liên kết với entity User (người nhận gợi ý)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // ID của dự án liên quan đến gợi ý (có thể null nếu gợi ý không liên quan đến dự án cụ thể)
        public long? ProjectId { get; set; }

        // Liên kết với entity Project (dự án liên quan)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Loại gợi ý (bắt buộc, sử dụng enum SuggestionType)
        [Required]
        public string Type { get; set; } //Project, Grade, Resource, Schedule, Feedback

        // Nội dung gợi ý (bắt buộc, chứa chi tiết gợi ý từ AI)
        [Required]
        public string Content { get; set; }

        // Thời gian tạo gợi ý (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}