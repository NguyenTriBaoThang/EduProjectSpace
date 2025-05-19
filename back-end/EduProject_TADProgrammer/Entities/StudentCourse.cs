using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa trạng thái tham gia môn học
    public enum CourseEnrollmentStatus
    {
        Enrolled,   // Đã đăng ký
        Completed,  // Đã hoàn thành
        Withdrawn   // Đã rút khỏi môn học
    }

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

        // Trạng thái tham gia (COMPLETED, ENROLLED)
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public long ?LecturerId { get; set; }
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }
        public long? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}