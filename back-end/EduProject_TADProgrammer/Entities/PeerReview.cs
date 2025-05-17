// File: Entities/PeerReview.cs
// Mục đích: Định nghĩa entity PeerReview để lưu đánh giá giữa các thành viên trong nhóm.
// Hỗ trợ chức năng: 
//   52: Đánh giá hiệu suất nhóm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class PeerReview
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public long ReviewerId { get; set; }

        [ForeignKey("ReviewerId")]
        public User Reviewer { get; set; }

        [Required]
        public long RevieweeId { get; set; }

        [ForeignKey("RevieweeId")]
        public User Reviewee { get; set; }

        [Required]
        [Range(1, 10)]
        public int Score { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
