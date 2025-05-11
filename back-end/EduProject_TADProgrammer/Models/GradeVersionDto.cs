// File: Core/Models/GradeVersionDto.cs
// Mục đích: Truyền dữ liệu lịch sử chỉnh sửa điểm số giữa API và frontend.
// Chức năng hỗ trợ: 
//   81: Quản lý phiên bản điểm số
namespace EduProject_TADProgrammer.Models
{
    public class GradeVersionDto
    {
        public long Id { get; set; }
        public long GradeId { get; set; }
        public float Score { get; set; }
        public string Comment { get; set; }
        public int VersionNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}