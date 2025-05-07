// File: Core/Models/GradeDto.cs
// Mục đích: Truyền dữ liệu điểm số của nhóm hoặc sinh viên giữa API và frontend.
// Chức năng hỗ trợ: 
//   12: Hỗ trợ chấm điểm
//   13: Đánh giá minh bạch
//   14: Xem phản hồi và điểm
//   15: Báo cáo và thống kê
//   36, 61, 66, 71, 72, 74, 76-83
namespace EduProject_TADProgrammer.Models
{
    public class GradeDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long GroupId { get; set; }
        public long? StudentId { get; set; }
        public long CriteriaId { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
        public DateTime GradedAt { get; set; }
        public long GradedBy { get; set; }
    }
}