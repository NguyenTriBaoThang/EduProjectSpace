// File: Entities/Department.cs
// Mục đích: Định nghĩa entity Department để lưu thông tin khoa và bộ môn
// Ghi chú: Thay thế Faculty và Department trong Course cũ
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Department
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FacultyCode { get; set; } // Ghi chú: Mã khoa, ví dụ: "CNTT"

        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; } // Ghi chú: Tên khoa, ví dụ: "Công nghệ Thông tin"

        [Required]
        [StringLength(50)]
        public string DepartmentCode { get; set; } // Ghi chú: Mã bộ môn, ví dụ: "CNTT"

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } // Ghi chú: Tên bộ môn, ví dụ: "CNTT"

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}