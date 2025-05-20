// File: Entities/GradeAppeal.cs
// Mục đích: Định nghĩa entity GradeAppeal để lưu trữ yêu cầu phúc khảo điểm của sinh viên.
// Hỗ trợ chức năng:
//   72: Phúc khảo và phản hồi điểm số

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeAppeal
    {
        // Khóa chính của bản ghi yêu cầu phúc khảo
        [Key]
        public long Id { get; set; }

        // ID của điểm số liên quan (bắt buộc)
        [Required]
        public long GradeId { get; set; }

        // Liên kết với entity Grade (điểm số được phúc khảo)
        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        // ID của sinh viên gửi yêu cầu (bắt buộc)
        [Required]
        public long StudentId { get; set; }

        // Liên kết với entity User (sinh viên gửi yêu cầu)
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        // Lý do yêu cầu phúc khảo (bắt buộc)
        [Required]
        public string Reason { get; set; }

        // Trạng thái của yêu cầu (bắt buộc, giá trị: "Pending", "Approved", "Rejected")
        [Required]
        public string Status { get; set; }

        // Phản hồi từ giảng viên hoặc quản trị viên (tùy chọn)
        public string? Response { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}