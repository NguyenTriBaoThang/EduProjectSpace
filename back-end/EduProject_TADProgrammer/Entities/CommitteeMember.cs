// File: Entities/CommitteeMember.cs
// Mục đích: Định nghĩa entity CommitteeMember để lưu trữ thông tin giảng viên trong hội đồng bảo vệ.
// Hỗ trợ chức năng:
//   19: Admin - Thành lập hội đồng chấm điểm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class CommitteeMember
    {
        // Khóa chính của bản ghi thành viên hội đồng
        [Key]
        public long Id { get; set; }

        // ID của hội đồng bảo vệ (bắt buộc)
        [Required]
        public long CommitteeId { get; set; }

        // Liên kết với entity DefenseCommittee (hội đồng bảo vệ)
        [ForeignKey("CommitteeId")]
        public DefenseCommittee Committee { get; set; }

        // ID của giảng viên tham gia hội đồng (bắt buộc)
        [Required]
        public long LecturerId { get; set; }

        // Liên kết với entity User (giảng viên)
        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        // Vai trò của giảng viên trong hội đồng (bắt buộc, sử dụng enum CommitteeRole)
        [Required]
        public string Role { get; set; } //President, Secretary, Member

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}