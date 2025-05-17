// File: Entities/Department.cs
// Mục đích: Định nghĩa entity Department để lưu trữ thông tin về khoa và bộ môn.

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Department
    {
        // Khóa chính của bản ghi khoa/bộ môn
        [Key]
        public long Id { get; set; }

        // Mã khoa (bắt buộc, tối đa 50 ký tự, ví dụ: "CNTT")
        [Required]
        [StringLength(50)]
        public string FacultyCode { get; set; }

        // Tên khoa (bắt buộc, tối đa 100 ký tự, ví dụ: "Công nghệ Thông tin")
        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; }

        // Mã bộ môn (bắt buộc, tối đa 50 ký tự, ví dụ: "CNTT")
        [Required]
        [StringLength(50)]
        public string DepartmentCode { get; set; }

        // Tên bộ môn (bắt buộc, tối đa 100 ký tự, ví dụ: "CNTT")
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        // Danh sách các môn học liên quan đến khoa/bộ môn
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}