// File: Core/Models/PeerReviewDto.cs
// Mục đích: Truyền dữ liệu đánh giá giữa các thành viên trong nhóm giữa API và frontend.
// Chức năng hỗ trợ: 
//   52: Đánh giá hiệu suất nhóm
namespace EduProject_TADProgrammer.Models
{
    public class PeerReviewDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long ReviewerId { get; set; }
        public long RevieweeId { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}