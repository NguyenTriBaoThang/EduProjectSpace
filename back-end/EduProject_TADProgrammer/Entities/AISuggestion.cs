// File: Core/Entities/AISuggestion.cs
// Mục đích: Định nghĩa entity AISuggestion để lưu gợi ý từ AI (đề tài, tài liệu, điểm số).
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
        [Key]
        public long Id { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // PROJECT, GRADE, RESOURCE

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
