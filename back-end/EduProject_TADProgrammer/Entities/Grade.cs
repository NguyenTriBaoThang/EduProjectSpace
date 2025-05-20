// File: Entities/Grade.cs
// Mục đích: Định nghĩa entity Grade để lưu trữ điểm số của nhóm hoặc sinh viên trong hệ thống.
// Hỗ trợ chức năng:
//   12: Hỗ trợ chấm điểm
//   13: Đánh giá minh bạch
//   14: Xem phản hồi và điểm
//   15: Báo cáo và thống kê
//   36, 61, 66, 71, 72, 74, 76-83

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class Grade
    {
        // Khóa chính của bản ghi điểm số
        [Key]
        public long Id { get; set; }

        // ID của dự án liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (dự án được chấm điểm)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của nhóm liên quan (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm được chấm điểm)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // ID của sinh viên liên quan (tùy chọn, null nếu điểm dành cho nhóm)
        public long? StudentId { get; set; }

        // Liên kết với entity User (sinh viên được chấm điểm)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // ID của tiêu chí chấm điểm (bắt buộc)
        [Required]
        public long CriteriaId { get; set; }

        // Liên kết với entity GradeCriteria (tiêu chí chấm điểm)
        [ForeignKey("CriteriaId")]
        public GradeCriteria Criteria { get; set; }

        // Điểm số (bắt buộc)
        [Required]
        public float Score { get; set; }

        // Nhận xét về điểm số (tùy chọn)
        public string Comment { get; set; }

        // Thời gian chấm điểm (mặc định là thời gian hiện tại theo UTC)
        public DateTime GradedAt { get; set; } = DateTime.UtcNow;

        // ID của người chấm điểm (bắt buộc, thường là giảng viên)
        [Required]
        public long GradedBy { get; set; }

        // Liên kết với entity User (người chấm điểm)
        [ForeignKey("GradedBy")]
        public User GradedByUser { get; set; }

        // Danh sách các phiên bản điểm số (lịch sử chỉnh sửa)
        public virtual ICollection<GradeVersion> GradeVersions { get; set; } = new List<GradeVersion>();

        // Danh sách các yêu cầu phúc khảo liên quan
        public virtual ICollection<GradeAppeal> GradeAppeals { get; set; } = new List<GradeAppeal>();

        // Danh sách nhật ký chấm điểm
        public virtual ICollection<GradeLog> GradeLogs { get; set; } = new List<GradeLog>();
    }
}