// File: Core/Models/GroupRequestDto.cs
// Mục đích: Truyền dữ liệu yêu cầu tham gia nhóm của sinh viên giữa API và frontend.
// Chức năng hỗ trợ: 
//   68: Quản lý danh sách sinh viên chờ duyệt
namespace EduProject_TADProgrammer.Models
{
    public class GroupRequestDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long StudentId { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}