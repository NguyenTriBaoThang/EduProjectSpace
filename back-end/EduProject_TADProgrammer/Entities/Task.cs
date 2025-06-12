// File: Entities/Task.cs
// Mục đích: Định nghĩa entity Task để lưu trữ nhiệm vụ được giao cho nhóm hoặc sinh viên.
// Hỗ trợ chức năng:
//   27: Giảng viên - Giao nhiệm vụ
//   29: Giảng viên - Xem báo cáo tiến độ
//   40: Sinh viên - Kiểm tra tiến độ cá nhân
//   53: Lập kế hoạch và quản lý nhiệm vụ

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Task
    {
        // Khóa chính của bản ghi nhiệm vụ
        [Key]
        public long Id { get; set; }

        // ID của đề tài liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (đề tài chứa nhiệm vụ)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của nhóm được giao nhiệm vụ (tùy chọn)
        public long? GroupId { get; set; }

        // Liên kết với entity Group (nhóm được giao nhiệm vụ)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Tiêu đề nhiệm vụ (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Mô tả chi tiết nhiệm vụ (tùy chọn)
        public string Description { get; set; }

        // Thời hạn hoàn thành nhiệm vụ (tùy chọn)
        public DateTime? Deadline { get; set; }

        // Trạng thái của nhiệm vụ (bắt buộc, giá trị: "Todo", "InProgress", "Done")
        [Required]
        public string Status { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thêm danh sách các Submission liên quan đến Task
        public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}