// File: Core/Models/SubmissionVersionDto.cs
// Mục đích: Truyền dữ liệu lịch sử phiên bản bài nộp giữa API và frontend.
// Chức năng hỗ trợ: 
//   59: Quản lý phiên bản tài liệu
namespace EduProject_TADProgrammer.Models
{
    public class SubmissionVersionDto
    {
        public long Id { get; set; }
        public long SubmissionId { get; set; }
        public string FilePath { get; set; }
        public int VersionNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}