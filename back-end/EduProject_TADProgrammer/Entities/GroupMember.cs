// File: Entities/GroupMember.cs
// Mục đích: Định nghĩa entity GroupMember để lưu danh sách thành viên trong mỗi nhóm.
// Hỗ trợ chức năng: 
//   39: Sinh viên - Tham gia nhóm
//   52: Đánh giá hiệu suất nhóm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GroupMember
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}
