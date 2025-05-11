// File: Core/Entities/Resource.cs
// Mục đích: Định nghĩa entity Resource để lưu tài liệu tham khảo, tài nguyên nhóm, hoặc mẫu.
// Hỗ trợ chức năng: 
//   31: Giảng viên - Quản lý tài liệu
//   38: Giảng viên - Tạo tài liệu mẫu
//   42: Sinh viên - Tải tài liệu mẫu
//   51: Quản lý tài liệu và tài nguyên
//   69: Hỗ trợ phân loại tài liệu
//   87: Công cụ lập kế hoạch tài nguyên nhóm
//   89: Sinh viên - Xem tài nguyên nhóm
//   90: Admin - Quản lý danh sách tài liệu nhóm
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Resource
    {
        [Key]
        public long Id { get; set; }

        public long? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        public long? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        [Required]
        public string Type { get; set; } // REFERENCE, GROUP, SAMPLE

        [Required]
        public long CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
