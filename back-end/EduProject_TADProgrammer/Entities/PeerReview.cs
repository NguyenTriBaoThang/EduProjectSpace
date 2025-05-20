// File: Entities/PeerReview.cs
// Mục đích: Định nghĩa entity PeerReview để lưu trữ đánh giá giữa các thành viên trong nhóm sinh viên.
// Hỗ trợ chức năng:
//   52: Đánh giá hiệu suất nhóm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class PeerReview
    {
        // Khóa chính của bản ghi đánh giá ngang hàng
        [Key]
        public long Id { get; set; }

        // ID của nhóm liên quan (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm chứa các thành viên được đánh giá)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // ID của người đánh giá (bắt buộc)
        [Required]
        public long ReviewerId { get; set; }

        // Liên kết với entity User (người thực hiện đánh giá)
        [ForeignKey("ReviewerId")]
        public User Reviewer { get; set; }

        // ID của người được đánh giá (bắt buộc)
        [Required]
        public long RevieweeId { get; set; }

        // Liên kết với entity User (người được đánh giá)
        [ForeignKey("RevieweeId")]
        public User Reviewee { get; set; }

        // Điểm đánh giá (bắt buộc, từ 1 đến 10)
        [Required]
        [Range(1, 10, ErrorMessage = "Score must be between 1 and 10")]
        public int Score { get; set; }

        // Nhận xét về đánh giá (tùy chọn)
        public string Comment { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}