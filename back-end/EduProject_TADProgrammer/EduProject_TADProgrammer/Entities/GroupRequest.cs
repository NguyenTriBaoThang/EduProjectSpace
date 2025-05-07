// File: Core/Entities/GroupRequest.cs
// Mục đích: Định nghĩa entity GroupRequest để lưu yêu cầu tham gia nhóm của sinh viên.
// Hỗ trợ chức năng: 
//   68: Quản lý danh sách sinh viên chờ duyệt
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EduProject_TADProgrammer.Entities
{
    public class GroupRequest
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

        [Required]
        public string Status { get; set; } // PENDING, APPROVED, REJECTED

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
