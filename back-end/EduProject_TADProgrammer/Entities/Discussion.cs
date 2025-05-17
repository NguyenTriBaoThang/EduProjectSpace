// File: Entities/Discussion.cs
// Mục đích: Định nghĩa entity Discussion để lưu bài đăng và bình luận trên diễn đàn.
// Hỗ trợ chức năng: 
//   41: Sinh viên - Gửi câu hỏi thảo luận
//   48: Diễn đàn trao đổi và thảo luận
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Discussion
    {
        [Key]
        public long Id { get; set; }

        public long? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int Votes { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
