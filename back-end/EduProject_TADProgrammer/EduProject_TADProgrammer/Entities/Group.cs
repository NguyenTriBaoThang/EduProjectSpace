// File: Core/Entities/Group.cs
// Mục đích: Định nghĩa entity Group để lưu thông tin nhóm sinh viên thực hiện đề tài.
// Hỗ trợ chức năng: 
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
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Group
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
