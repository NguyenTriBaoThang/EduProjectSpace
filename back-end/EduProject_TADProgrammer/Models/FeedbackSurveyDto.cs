// File: Core/Models/FeedbackSurveyDto.cs
// Mục đích: Truyền dữ liệu khảo sát phản hồi của người dùng giữa API và frontend.
// Chức năng hỗ trợ: 
//   72: Phúc khảo và phản hồi điểm số (phần khảo sát)
namespace EduProject_TADProgrammer.Models
{
    public class FeedbackSurveyDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}