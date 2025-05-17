// File: Entities/GroupRequest.cs
// Mục đích: Định nghĩa entity GroupRequest để lưu yêu cầu tham gia nhóm của sinh viên.
// Hỗ trợ chức năng: 
//   68: Quản lý danh sách sinh viên chờ duyệt
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa trạng thái của yêu cầu tham gia nhóm
    public enum GroupRequestStatus
    {
        Pending,    // Đang chờ duyệt
        Approved,   // Đã được chấp nhận
        Rejected    // Bị từ chối
    }


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
        public string Status { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
