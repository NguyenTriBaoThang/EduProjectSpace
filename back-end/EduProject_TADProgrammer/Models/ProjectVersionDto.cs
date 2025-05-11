// File: Core/Models/ProjectVersionDto.cs
// Mục đích: Truyền dữ liệu lịch sử chỉnh sửa đề tài đồ án giữa API và frontend.
// Chức năng hỗ trợ: 
//   67: Theo dõi lịch sử chỉnh sửa đề tài
namespace EduProject_TADProgrammer.Models
{
    public class ProjectVersionDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int VersionNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}