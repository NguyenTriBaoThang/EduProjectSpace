// File: Entities/FeedbackSurvey.cs
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
        // Khóa chính của bản ghi khảo sát phản hồi
        [Key]
        public long Id { get; set; }

        // ID của người dùng gửi khảo sát (bắt buộc)
        [Required]
        public long UserId { get; set; }

        // Liên kết với entity User (người gửi khảo sát)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Nội dung phản hồi của khảo sát (bắt buộc)
        [Required]
        public string Content { get; set; }

        // Điểm đánh giá (bắt buộc, từ 1 đến 5)
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}