// File: Core/Entities/GradeCriteria.cs
// Mục đích: Định nghĩa entity GradeCriteria để lưu tiêu chí chấm điểm.
// Hỗ trợ chức năng: 
//   12: Hỗ trợ chấm điểm giảng viên
//   13: Đánh giá minh bạch và công bằng
//   20: Admin - Quy định thành phần điểm
//   70: Quản lý tiêu chí chấm điểm
//   79: Kiểm tra hoàn thành chấm
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeCriteria
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public float Weight { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
