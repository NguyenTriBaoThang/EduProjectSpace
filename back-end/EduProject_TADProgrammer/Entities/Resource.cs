// File: Entities/Resource.cs
// Mục đích: Định nghĩa entity Resource để lưu trữ tài liệu tham khảo, tài nguyên nhóm, hoặc mẫu.
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
        // Khóa chính của bản ghi tài nguyên
        [Key]
        public long Id { get; set; }

        // ID của đề tài liên quan (tùy chọn)
        public long? ProjectId { get; set; }

        // Liên kết với entity Project (đề tài liên quan đến tài nguyên)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của nhóm liên quan (tùy chọn)
        public long? GroupId { get; set; }

        // Liên kết với entity Group (nhóm liên quan đến tài nguyên)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Tiêu đề tài nguyên (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Đường dẫn đến file tài nguyên (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        // Loại tài nguyên (bắt buộc, giá trị: "Reference", "Group", "Sample")
        [Required]
        public string Type { get; set; }

        // ID của người tạo tài nguyên (bắt buộc, thường là giảng viên hoặc sinh viên)
        [Required]
        public long CreatedBy { get; set; }

        // Liên kết với entity User (người tạo tài nguyên)
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}