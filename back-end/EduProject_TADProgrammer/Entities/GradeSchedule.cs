// File: Entities/GradeSchedule.cs
// Mục đích: Định nghĩa entity GradeSchedule để lưu trữ lịch trình chấm điểm cho dự án.
// Hỗ trợ chức năng:
//   75: Lịch trình chấm điểm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeSchedule
    {
        // Khóa chính của bản ghi lịch trình chấm điểm
        [Key]
        public long Id { get; set; }

        // ID của dự án liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (dự án được chấm điểm)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của giảng viên được phân công chấm điểm (bắt buộc)
        [Required]
        public long LecturerId { get; set; }

        // Liên kết với entity User (giảng viên chấm điểm)
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        // Thời hạn chấm điểm (bắt buộc)
        [Required]
        public DateTime Deadline { get; set; }

        // Trạng thái của lịch trình (bắt buộc, giá trị: "Pending", "Completed", "Cancelled")
        [Required]
        public string Status { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}