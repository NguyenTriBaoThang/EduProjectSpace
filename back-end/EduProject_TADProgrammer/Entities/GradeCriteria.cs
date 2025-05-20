// File: Entities/GradeCriteria.cs
// Mục đích: Định nghĩa entity GradeCriteria để lưu trữ tiêu chí chấm điểm cho môn học.
// Hỗ trợ chức năng:
//   12: Hỗ trợ chấm điểm giảng viên
//   13: Đánh giá minh bạch và công bằng
//   20: Admin - Quy định thành phần điểm
//   70: Quản lý tiêu chí chấm điểm
//   79: Kiểm tra hoàn thành chấm

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeCriteria
    {
        // Khóa chính của bản ghi tiêu chí chấm điểm
        [Key]
        public long Id { get; set; }

        // ID của môn học liên quan (bắt buộc)
        [Required]
        public long CourseId { get; set; }

        // Liên kết với entity Course (môn học áp dụng tiêu chí)
        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        // Tên tiêu chí chấm điểm (bắt buộc, tối đa 100 ký tự)
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Trọng số của tiêu chí (bắt buộc, ví dụ: 0.3 cho 30%)
        [Required]
        public float Weight { get; set; }

        // Mô tả chi tiết về tiêu chí (tùy chọn)
        public string Description { get; set; }

        // Danh sách điểm số được chấm theo tiêu chí này
        public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}