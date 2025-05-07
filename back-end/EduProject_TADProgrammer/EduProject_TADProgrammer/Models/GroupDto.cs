// File: Core/Models/GroupDto.cs
// Mục đích: Truyền dữ liệu thông tin nhóm sinh viên thực hiện đề tài giữa API và frontend.
// Chức năng hỗ trợ: 
//   7: Quản lý quy trình đồ án
//   28: Giảng viên - Phân công nhóm
//   39: Sinh viên - Tham gia nhóm
//   49: Nhật ký hoạt động nhóm
//   52: Đánh giá hiệu suất nhóm
//   64: Thông báo nhóm
//   68: Quản lý danh sách sinh viên chờ duyệt
//   80: Tổng hợp điểm nhóm
//   87: Lập kế hoạch tài nguyên nhóm
//   88: Theo dõi tiến độ nộp tài liệu
//   89: Sinh viên - Xem tài nguyên nhóm
namespace EduProject_TADProgrammer.Models
{
    public class GroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
