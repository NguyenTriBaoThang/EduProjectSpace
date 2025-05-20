// File: Entities/SkillAssessment.cs
// Mục đích: Định nghĩa entity SkillAssessment để lưu trữ kết quả tự đánh giá kỹ năng của sinh viên.
// Hỗ trợ chức năng:
//   60: Đánh giá năng lực cá nhân

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class SkillAssessment
    {
        // Khóa chính của bản ghi đánh giá kỹ năng
        [Key]
        public long Id { get; set; }

        // ID của sinh viên thực hiện tự đánh giá (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên thực hiện đánh giá)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // Tên kỹ năng được đánh giá (bắt buộc, tối đa 100 ký tự, ví dụ: "Lập trình", "Giao tiếp")
        [Required]
        [StringLength(100)]
        public string Skill { get; set; }

        // Điểm tự đánh giá (bắt buộc, từ 1 đến 10)
        [Required]
        [Range(1, 10, ErrorMessage = "Score must be between 1 and 10")]
        public int Score { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}