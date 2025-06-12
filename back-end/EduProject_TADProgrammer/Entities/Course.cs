// File: Entities/Course.cs
// Mục đích: Định nghĩa entity Course để lưu trữ thông tin môn học đồ án (tên, kỳ học, thời gian).
// Hỗ trợ chức năng:
//   7: Quản lý quy trình đồ án
//   17: Quản lý danh sách môn học
//   18: Thiết lập thời gian kỳ học
//   77: So sánh điểm giữa các môn

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Course
    {
        // Khóa chính của bản ghi môn học
        [Key]
        public long Id { get; set; }

        // Tên môn học (bắt buộc, tối đa 100 ký tự)
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // ID của kỳ học liên quan (bắt buộc)
        [Required]
        public long SemesterId { get; set; }

        // Liên kết với entity Semester (kỳ học)
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        // ID của khoa liên quan (bắt buộc)
        [Required]
        public long DepartmentId { get; set; }

        // Liên kết với entity Department (khoa)
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        // Ngày bắt đầu môn học (bắt buộc)
        [Required]
        public DateTime StartDate { get; set; }

        // Ngày kết thúc môn học (bắt buộc)
        [Required]
        public DateTime EndDate { get; set; }

        // Mã môn học để dễ tra cứu (bắt buộc, tối đa 20 ký tự)
        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; }

        // Ngày bảo vệ đồ án (tùy chọn)
        public DateTime? DefenseDate { get; set; }

        // Trạng thái môn học (bắt buộc, sử dụng enum CourseStatus)
        [Required]
        public string Status { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách giảng viên giảng dạy môn học
        public virtual ICollection<User> Lecturers { get; set; } = new List<User>();

        // Danh sách dự án liên quan đến môn học
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

        // Danh sách tiêu chí chấm điểm của môn học
        public virtual ICollection<GradeCriteria> GradeCriteria { get; set; } = new List<GradeCriteria>();

        // Danh sách sinh viên đăng ký môn học
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        // Danh sách giảng viên hướng dẫn
        public virtual ICollection<LecturerCourses> LecturerCourses { get; set; } = new List<LecturerCourses>();
    }
}