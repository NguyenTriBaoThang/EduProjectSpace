// File: Entities/ProjectVersion.cs
// Mục đích: Định nghĩa entity ProjectVersion để lưu trữ lịch sử chỉnh sửa của các đề tài đồ án.
// Hỗ trợ chức năng:
//   67: Theo dõi lịch sử chỉnh sửa đề tài

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class ProjectVersion
    {
        // Khóa chính của bản ghi phiên bản đề tài
        [Key]
        public long Id { get; set; }

        // ID của đề tài liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (đề tài được chỉnh sửa)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Tiêu đề của phiên bản đề tài (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Mô tả chi tiết của phiên bản đề tài (tùy chọn)
        public string Description { get; set; }

        // Số phiên bản của đề tài (bắt buộc, ví dụ: 1, 2, 3...)
        [Required]
        public int VersionNumber { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}