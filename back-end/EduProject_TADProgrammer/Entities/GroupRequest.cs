// File: Entities/GroupRequest.cs
// Mục đích: Định nghĩa entity GroupRequest để lưu trữ yêu cầu tham gia nhóm của sinh viên.
// Hỗ trợ chức năng:
//   68: Quản lý danh sách sinh viên chờ duyệt

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GroupRequest
    {
        // Khóa chính của bản ghi yêu cầu tham gia nhóm
        [Key]
        public long Id { get; set; }

        // ID của nhóm mà sinh viên yêu cầu tham gia (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm được yêu cầu tham gia)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // ID của sinh viên gửi yêu cầu (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên gửi yêu cầu)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // Trạng thái của yêu cầu (bắt buộc, giá trị: "Pending", "Approved", "Rejected")
        [Required]
        public string Status { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}