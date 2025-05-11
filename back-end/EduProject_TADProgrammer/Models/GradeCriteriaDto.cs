// File: Core/Models/GradeCriteriaDto.cs
// Mục đích: Truyền dữ liệu tiêu chí chấm điểm giữa API và frontend.
// Chức năng hỗ trợ: 
//   12: Hỗ trợ chấm điểm giảng viên
//   13: Đánh giá minh bạch và công bằng
//   20: Admin - Quy định thành phần điểm
//   70: Quản lý tiêu chí chấm điểm
//   79: Kiểm tra hoàn thành chấm
namespace EduProject_TADProgrammer.Models
{
    public class GradeCriteriaDto
    {
        public long Id { get; set; }
        public long CourseId { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
    }
}