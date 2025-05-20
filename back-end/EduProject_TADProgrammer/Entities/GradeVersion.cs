// File: Entities/GradeVersion.cs
// Mục đích: Định nghĩa entity GradeVersion để lưu trữ lịch sử chỉnh sửa điểm số trong hệ thống.
// Hỗ trợ chức năng:
//   81: Quản lý phiên bản điểm số

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeVersion
    {
        // Khóa chính của bản ghi phiên bản điểm số
        [Key]
        public long Id { get; set; }

        // ID của điểm số liên quan (bắt buộc)
        [Required]
        public long GradeId { get; set; }

        // Liên kết với entity Grade (điểm số được chỉnh sửa)
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        // Điểm số của phiên bản này (bắt buộc)
        [Required]
        public float Score { get; set; }

        // Nhận xét về điểm số (tùy chọn)
        public string Comment { get; set; }

        // Số phiên bản của điểm số (bắt buộc, ví dụ: 1, 2, 3...)
        [Required]
        public int VersionNumber { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}