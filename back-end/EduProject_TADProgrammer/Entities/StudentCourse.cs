// File: Entities/StudentCourse.cs
// Mục đích: Định nghĩa entity StudentCourse để lưu trữ thông tin đăng ký môn học của sinh viên.
// Hỗ trợ chức năng:
//   Quản lý đăng ký môn học và trạng thái tham gia của sinh viên.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class StudentCourse
    {
        // Khóa chính của bản ghi đăng ký môn học
        [Key]
        public long Id { get; set; }

        // ID của sinh viên đăng ký (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên đăng ký môn học)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // ID của môn học được đăng ký (bắt buộc)
        [Required]
        public long CourseId { get; set; }

        // Liên kết với entity Course (môn học được đăng ký)
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // Trạng thái tham gia môn học (tùy chọn, tối đa 50 ký tự, ví dụ: "COMPLETED", "ENROLLED")
        [StringLength(50)]
        public string Status { get; set; }

        // Thời gian đăng ký môn học (mặc định là thời gian hiện tại theo UTC)
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}