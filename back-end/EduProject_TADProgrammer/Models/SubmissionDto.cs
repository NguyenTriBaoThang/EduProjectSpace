// File: Core/Models/SubmissionDto.cs
// Mục đích: Truyền dữ liệu bài nộp của nhóm (báo cáo, mã nguồn) giữa API và frontend.
// Chức năng hỗ trợ: 
//   7: Quản lý quy trình đồ án
//   10: Nộp bài và gia hạn
//   11: Kiểm tra tài liệu nộp bài
//   32: Giảng viên - Kiểm tra tính hợp lệ bài nộp
//   59: Quản lý phiên bản tài liệu
//   65: Kiểm tra và chạy mã nguồn tự động
//   69: Hỗ trợ phân loại tài liệu
//   88: Theo dõi tiến độ nộp tài liệu
namespace EduProject_TADProgrammer.Models
{
    public class SubmissionDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long GroupId { get; set; }
        public string FilePath { get; set; }
        public int Version { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}