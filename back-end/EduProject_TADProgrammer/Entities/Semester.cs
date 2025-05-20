// File: Entities/Semester.cs
// Mục đích: Định nghĩa entity Semester để lưu trữ thông tin về kỳ học trong hệ thống.
// Hỗ trợ chức năng:
//   Quản lý các kỳ học và liên kết với các môn học trong hệ thống.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class Semester
    {
        // Khóa chính của bản ghi kỳ học
        [Key]
        public long Id { get; set; }

        // Tên kỳ học (bắt buộc, tối đa 20 ký tự, ví dụ: "HK1_2023-2024", "HK2_2023-2024")
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        // Ngày bắt đầu kỳ học (bắt buộc)
        [Required]
        public DateTime StartDate { get; set; }

        // Ngày kết thúc kỳ học (bắt buộc)
        [Required]
        public DateTime EndDate { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Mô tả thêm về kỳ học (tùy chọn)
        public string? Description { get; set; }

        // Danh sách các môn học thuộc kỳ học này
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}