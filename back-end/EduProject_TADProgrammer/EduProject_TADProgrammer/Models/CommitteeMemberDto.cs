// File: Core/Models/CommitteeMemberDto.cs
// Mục đích: Truyền dữ liệu danh sách giảng viên trong hội đồng chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   19: Admin - Thành lập hội đồng chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class CommitteeMemberDto
    {
        public long Id { get; set; }
        public long CommitteeId { get; set; }
        public long LecturerId { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}