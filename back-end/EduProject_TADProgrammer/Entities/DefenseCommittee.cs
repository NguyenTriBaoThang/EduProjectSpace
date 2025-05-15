// File: Core/Entities/DefenseCommittee.cs
// Mục đích: Định nghĩa entity DefenseCommittee để lưu thông tin hội đồng chấm điểm.
// Hỗ trợ chức năng: 
//   19: Admin - Thành lập hội đồng chấm điểm
using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Entities
{
    public class DefenseCommittee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
    }
}
