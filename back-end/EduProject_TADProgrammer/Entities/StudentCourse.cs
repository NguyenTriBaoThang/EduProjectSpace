using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class StudentCourse
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // Thuộc tính mới: Trạng thái tham gia (đã đăng ký, đã hoàn thành, v.v.)
        [StringLength(50)]
        public string Status { get; set; } // Thêm mới: Hỗ trợ chức năng 7 (Quản lý quy trình đồ án)

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        // Thuộc tính mới: Thời gian cập nhật
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Thêm mới: Theo dõi thay đổi
    }
}