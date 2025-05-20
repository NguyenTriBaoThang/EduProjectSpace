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
        // Khóa chính của bản ghi bài đăng hoặc bình luận
        [Key]
        public long Id { get; set; }

        // ID của dự án liên quan (tùy chọn, null nếu bài đăng không thuộc dự án cụ thể)
        public long? ProjectId { get; set; }

        // Liên kết với entity Project (dự án liên quan đến bài đăng)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của người dùng tạo bài đăng (bắt buộc)
        [Required]
        public long UserId { get; set; }

        // Liên kết với entity User (người tạo bài đăng)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // Tiêu đề bài đăng (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Nội dung bài đăng (bắt buộc)
        [Required]
        public string Content { get; set; }

        // Số lượt bình chọn cho bài đăng (mặc định là 0)
        public int Votes { get; set; } = 0;

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
