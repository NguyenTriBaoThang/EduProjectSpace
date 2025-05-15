// File: Core/Entities/DefenseCommittee.cs
// Mục đích: Định nghĩa entity DefenseCommittee để lưu thông tin hội đồng chấm điểm.
// Hỗ trợ chức năng: 
//   19: Admin - Thành lập hội đồng chấm điểm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class DefenseCommittee
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Tên hội đồng (VD: Hội đồng chấm điểm CNTT HK1)

        [Required]
        public long SemesterId { get; set; } // Liên kết với kỳ học

        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
    }
}
