// File: Core/Models/DefenseCommitteeDto.cs
// Mục đích: Truyền dữ liệu thông tin hội đồng chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   19: Admin - Thành lập hội đồng chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class DefenseCommitteeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public string SemesterName { get; set; }
        public List<CommitteeMemberDto> Members { get; set; } = new List<CommitteeMemberDto>();
    }
}