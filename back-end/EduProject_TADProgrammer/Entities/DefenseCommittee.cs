// File: Entities/DefenseCommittee.cs
// Mục đích: Định nghĩa entity DefenseCommittee để lưu trữ thông tin hội đồng chấm điểm.
// Hỗ trợ chức năng:
//   19: Admin - Thành lập hội đồng chấm điểm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Entities
{
    public class DefenseCommittee
    {
        // Khóa chính của bản ghi hội đồng chấm điểm
        [Key]
        public long Id { get; set; }

        // Tên hội đồng (bắt buộc, tối đa 100 ký tự, ví dụ: Hội đồng chấm điểm CNTT HK1)
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // ID của kỳ học liên quan (bắt buộc)
        [Required]
        public long SemesterId { get; set; }

        // Liên kết với entity Semester (kỳ học)
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách thành viên trong hội đồng chấm điểm
        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
    }
}