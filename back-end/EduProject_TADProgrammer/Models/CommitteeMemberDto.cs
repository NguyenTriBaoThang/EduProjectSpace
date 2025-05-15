// File: Core/Models/CommitteeMemberDto.cs
// Mục đích: Truyền dữ liệu danh sách giảng viên trong hội đồng chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   19: Admin - Thành lập hội đồng chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class CommitteeMemberDto
    {
        public long LecturerId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public class CreateDefenseCommitteeRequest
    {
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public List<CommitteeMemberRequest> Members { get; set; } = new List<CommitteeMemberRequest>();
    }

    public class UpdateDefenseCommitteeRequest
    {
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public List<CommitteeMemberRequest> Members { get; set; } = new List<CommitteeMemberRequest>();
    }

    public class CommitteeMemberRequest
    {
        public long LecturerId { get; set; }
        public string Role { get; set; }
    }
}