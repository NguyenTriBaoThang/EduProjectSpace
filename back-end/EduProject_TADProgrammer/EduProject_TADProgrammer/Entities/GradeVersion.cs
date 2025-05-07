// File: Core/Entities/GradeVersion.cs
// Mục đích: Định nghĩa entity GradeVersion để lưu lịch sử chỉnh sửa điểm số.
// Hỗ trợ chức năng: 
//   81: Quản lý phiên bản điểm số
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class GradeVersion
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GradeId { get; set; }

        [ForeignKey("GradeId")]
        public Grade Grade { get; set; }

        [Required]
        public float Score { get; set; }

        public string Comment { get; set; }

        [Required]
        public int VersionNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
