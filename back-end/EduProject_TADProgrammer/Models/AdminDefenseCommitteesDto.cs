// File: Core/Models/CommitteeMemberDto.cs
// Mục đích: Truyền dữ liệu danh sách giảng viên trong hội đồng chấm điểm giữa API và frontend.

namespace EduProject_TADProgrammer.Models
{
    public class AdminDefenseCommitteesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public string SemesterName { get; set; }
        public List<AdminDefenseCommitteesMemberDto> Members { get; set; } = new List<AdminDefenseCommitteesMemberDto>();
    }

    public class AdminDefenseCommitteesMemberDto
    {
        public long LecturerId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }

    public class CreateAdminDefenseCommitteeRequest
    {
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public List<AdminDefenseCommitteesMembersRequest> Members { get; set; } = new List<AdminDefenseCommitteesMembersRequest>();
    }

    public class UpdateAdminDefenseCommitteeRequest
    {
        public string Name { get; set; }
        public long SemesterId { get; set; }
        public List<AdminDefenseCommitteesMembersRequest> Members { get; set; } = new List<AdminDefenseCommitteesMembersRequest>();
    }

    public class AdminDefenseCommitteesMembersRequest
    {
        public long LecturerId { get; set; }
        public string Role { get; set; }
    }
}