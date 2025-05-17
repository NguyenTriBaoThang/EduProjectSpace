// File: Entities/ProjectVersion.cs
// Mục đích: Định nghĩa entity ProjectVersion để lưu lịch sử chỉnh sửa của các đề tài đồ án.
// Hỗ trợ chức năng: 
//   67: Theo dõi lịch sử chỉnh sửa đề tài
// Bảng này lưu các phiên bản của đề tài (tiêu đề, mô tả) để khôi phục hoặc xem lại thay đổi.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class ProjectVersion
    {
        [Key]
        public long Id { get; set; } // Khóa chính, ID duy nhất cho mỗi phiên bản

        [Required]
        public long ProjectId { get; set; } // Khóa ngoại liên kết với đề tài

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } // Quan hệ với bảng Projects

        [Required]
        [StringLength(255)]
        public string Title { get; set; } // Tiêu đề của phiên bản, tối đa 255 ký tự

        public string Description { get; set; } // Mô tả của phiên bản

        [Required]
        public int VersionNumber { get; set; } // Số phiên bản (1, 2, 3, ...)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Thời gian tạo phiên bản
    }
}
