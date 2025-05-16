// File: Core/Entities/Course.cs
// Mục đích: Định nghĩa entity Course để lưu thông tin môn học đồ án (tên, kỳ học, thời gian).
// Hỗ trợ chức năng: 
//   7: Quản lý quy trình đồ án
//   17: Quản lý danh sách môn học
//   18: Thiết lập thời gian kỳ học
//   77: So sánh điểm giữa các môn
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Course
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public long SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        [Required]
        public long DepartmentId { get; set; } // Liên kết với khoa

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // Thuộc tính mới: Mã môn học để dễ tra cứu
        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; } // Thêm mới: Hỗ trợ chức năng 17 (Quản lý danh sách môn học)

        // Thuộc tính mới: Lịch bảo vệ đồ án
        public DateTime? DefenseDate { get; set; } // Thêm mới: Hỗ trợ chức năng 56 (Quản lý lịch bảo vệ)

        // Thuộc tính mới: Trạng thái môn học (đang mở, đã đóng, v.v.)
        [StringLength(50)]
        public string Status { get; set; } // Thêm mới: Hỗ trợ chức năng 18 (Thiết lập thời gian kỳ học)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thuộc tính mới: Thời gian cập nhật
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Thêm mới: Theo dõi thay đổi

        public virtual ICollection<User> Lecturers { get; set; } = new List<User>();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<GradeCriteria> GradeCriteria { get; set; } = new List<GradeCriteria>();
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}