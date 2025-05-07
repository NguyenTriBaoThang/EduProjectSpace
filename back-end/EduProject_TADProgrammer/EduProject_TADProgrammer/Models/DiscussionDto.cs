// File: Core/Models/DiscussionDto.cs
// Mục đích: Truyền dữ liệu bài đăng và bình luận trên diễn đàn giữa API và frontend.
// Chức năng hỗ trợ: 
//   41: Sinh viên - Gửi câu hỏi thảo luận
//   48: Diễn đàn trao đổi và thảo luận
namespace EduProject_TADProgrammer.Models
{
    public class DiscussionDto
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
