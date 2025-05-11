// File: Core/Entities/CommitteeMember.cs
// Mục đích: Định nghĩa entity CommitteeMember để lưu danh sách giảng viên trong hội đồng.
// Hỗ trợ chức năng: 
//   19: Admin - Thành lập hội đồng chấm điểm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class CommitteeMember
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long CommitteeId { get; set; }

        [ForeignKey("CommitteeId")]
        public DefenseCommittee Committee { get; set; }

        [Required]
        public long LecturerId { get; set; }

        [ForeignKey("LecturerId")]
        public User Lecturer { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } // Chủ tịch, Thư ký, Thành viên

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
