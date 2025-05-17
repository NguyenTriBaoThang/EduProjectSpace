// File: Entities/DefenseSchedule.cs
// Mục đích: Định nghĩa entity DefenseSchedule để lưu trữ thông tin lịch bảo vệ đồ án.
// Hỗ trợ chức năng:
//   56: Quản lý lịch bảo vệ

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class DefenseSchedule
    {
        // Khóa chính của bản ghi lịch bảo vệ
        [Key]
        public long Id { get; set; }

        // ID của dự án liên quan đến lịch bảo vệ (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (dự án được bảo vệ)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Thời gian bắt đầu bảo vệ (bắt buộc)
        [Required]
        public DateTime StartTime { get; set; }

        // Thời gian kết thúc bảo vệ (bắt buộc)
        [Required]
        public DateTime EndTime { get; set; }

        // Phòng tổ chức bảo vệ (bắt buộc, tối đa 50 ký tự)
        [Required]
        [StringLength(50)]
        public string Room { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}