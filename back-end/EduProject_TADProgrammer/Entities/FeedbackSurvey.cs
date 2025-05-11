// File: Core/Entities/FeedbackSurvey.cs
// Mục đích: Định nghĩa entity FeedbackSurvey để lưu khảo sát phản hồi của người dùng.
// Hỗ trợ chức năng: 
//   72: Phúc khảo và phản hồi điểm số (phần khảo sát)
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class FeedbackSurvey
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
