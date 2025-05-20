// File: Entities/TimeTracking.cs
// Mục đích: Định nghĩa entity TimeTracking để lưu trữ thời gian làm việc của sinh viên trên các đề tài.
// Hỗ trợ chức năng:
//   37: Giảng viên - Phân tích mức độ tham gia
//   55: Theo dõi thời gian làm việc

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class TimeTracking
    {
        // Khóa chính của bản ghi theo dõi thời gian
        [Key]
        public long Id { get; set; }

        // ID của sinh viên thực hiện công việc (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên thực hiện công việc)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // ID của đề tài liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (đề tài được thực hiện)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // Thời gian bắt đầu làm việc (bắt buộc)
        [Required]
        public DateTime StartTime { get; set; }

        // Thời gian kết thúc làm việc (tùy chọn)
        public DateTime? EndTime { get; set; }

        // Thời lượng làm việc (tùy chọn, tính bằng phút)
        public int? Duration { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}