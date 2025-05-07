// File: Core/Models/GroupMemberDto.cs
// Mục đích: Truyền dữ liệu danh sách thành viên trong nhóm giữa API và frontend.
// Chức năng hỗ trợ: 
//   39: Sinh viên - Tham gia nhóm
//   52: Đánh giá hiệu suất nhóm
namespace EduProject_TADProgrammer.Models
{
    public class GroupMemberDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long StudentId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}