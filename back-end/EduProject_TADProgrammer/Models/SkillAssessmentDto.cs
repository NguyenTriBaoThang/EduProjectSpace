// File: Core/Models/SkillAssessmentDto.cs
// Mục đích: Truyền dữ liệu kết quả tự đánh giá kỹ năng của sinh viên giữa API và frontend.
// Chức năng hỗ trợ: 
//   60: Đánh giá năng lực cá nhân
namespace EduProject_TADProgrammer.Models
{
    public class SkillAssessmentDto
    {
        public long Id { get; set; }
        public long StudentId { get; set; }
        public string Skill { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}