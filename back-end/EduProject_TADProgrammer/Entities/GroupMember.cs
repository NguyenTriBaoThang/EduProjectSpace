// File: Entities/GroupMember.cs
// Mục đích: Định nghĩa entity GroupMember để lưu trữ danh sách thành viên trong mỗi nhóm sinh viên.
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
        // Khóa chính của bản ghi thành viên nhóm
        [Key]
        public long Id { get; set; }

        // ID của nhóm liên quan (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm chứa thành viên)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // ID của sinh viên (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên là thành viên)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // Thời gian tham gia nhóm (mặc định là thời gian hiện tại theo UTC)
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
    }
}