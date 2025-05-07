// File: Core/Models/FeedbackDto.cs
// Mục đích: Truyền dữ liệu phản hồi của giảng viên về bài nộp giữa API và frontend.
// Chức năng hỗ trợ: 
//   14: Xem phản hồi và điểm số
//   62: Quản lý phản hồi giảng viên
//   86: Hỗ trợ phân tích phản hồi giảng viên
namespace EduProject_TADProgrammer.Models
{
    public class FeedbackDto
    {
        public long Id { get; set; }
        public long SubmissionId { get; set; }
        public long LecturerId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}