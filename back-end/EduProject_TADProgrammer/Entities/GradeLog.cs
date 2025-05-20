// File: Entities/GradeLog.cs
// Mục đích: Định nghĩa entity GradeLog để lưu trữ nhật ký các hoạt động chấm điểm trong hệ thống.
// Hỗ trợ chức năng:
//   74: Nhật ký chấm điểm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeLog
    {
        // Khóa chính của bản ghi nhật ký chấm điểm
        [Key]
        public long Id { get; set; }

        // ID của điểm số liên quan (bắt buộc)
        [Required]
        public long GradeId { get; set; }

        // Liên kết với entity Grade (điểm số được ghi nhật ký)
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        // ID của giảng viên thực hiện hành động (bắt buộc)
        [Required]
        public long LecturerId { get; set; }

        // Liên kết với entity User (giảng viên thực hiện hành động)
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        // Hành động được thực hiện (bắt buộc, tối đa 50 ký tự, giá trị: "Create", "Update", "Delete")
        [Required]
        [StringLength(50)]
        public string Action { get; set; }

        // Chi tiết về hành động (tùy chọn, mô tả thêm thông tin)
        public string Details { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}