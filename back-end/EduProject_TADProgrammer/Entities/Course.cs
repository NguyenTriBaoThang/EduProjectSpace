// File: Core/Entities/Course.cs
// Mục đích: Định nghĩa entity Course để lưu thông tin môn học đồ án (tên, kỳ học, thời gian).
// Hỗ trợ chức năng: 
//   7: Quản lý quy trình đồ án
//   17: Quản lý danh sách môn học
//   18: Thiết lập thời gian kỳ học
//   77: So sánh điểm giữa các môn
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
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
