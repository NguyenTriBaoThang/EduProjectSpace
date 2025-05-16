// File: Entities/RolePermission.cs
// Mục đích: Định nghĩa entity lưu trữ quyền truy cập cho từng vai trò
// Ghi chú: Mỗi bản ghi đại diện cho các quyền của một vai trò (Admin, Giảng viên, Sinh viên)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class RolePermission
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long RoleId { get; set; } // Ghi chú: Liên kết với bảng Roles (1: Admin, 2: Giảng viên, 3: Sinh viên, 4: Trưởng bộ môn)

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public bool ViewUsers { get; set; } // Ghi chú: Quyền xem danh sách người dùng
        public bool EditUsers { get; set; } // Ghi chú: Quyền sửa danh sách người dùng
        public bool ViewProjects { get; set; } // Ghi chú: Quyền xem danh sách đề tài
        public bool EditProjects { get; set; } // Ghi chú: Quyền sửa danh sách đề tài
        public bool ViewGrading { get; set; } // Ghi chú: Quyền xem hội đồng chấm điểm
        public bool EditGrading { get; set; } // Ghi chú: Quyền sửa hội đồng chấm điểm

        public DateTime UpdatedAt { get; set; } // Ghi chú: Thời gian cập nhật quyền
    }
}