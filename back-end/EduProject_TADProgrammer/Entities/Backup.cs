// File: Entities/Backup.cs
// Mục đích: Định nghĩa entity Backup để lưu thông tin sao lưu dữ liệu.
// Hỗ trợ chức năng: 
//   25: Quản lý vận hành hệ thống
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa loại sao lưu
    public enum BackupType
    {
        Full,      // Sao lưu toàn bộ dữ liệu
        Incremental, // Sao lưu gia tăng (chỉ dữ liệu thay đổi)
        Differential // Sao lưu khác biệt (so với lần sao lưu đầy đủ cuối)
    }

    // Enum để định nghĩa trạng thái sao lưu
    public enum BackupStatus
    {
        Pending,   // Đang chờ thực hiện
        Success,   // Sao lưu thành công
        Failed     // Sao lưu thất bại
    }

    public class Backup
    {
        // Khóa chính của bản ghi sao lưu
        [Key]
        public long Id { get; set; }

        // Đường dẫn đến tệp sao lưu (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        // Loại sao lưu (bắt buộc, sử dụng enum BackupType)
        [Required]
        public string Type { get; set; } //Full, Incremental, Differential

        // Trạng thái sao lưu (bắt buộc, sử dụng enum BackupStatus)
        [Required]
        public string Status { get; set; } //Pending, Success, Failed

        // Kích thước tệp sao lưu (tính bằng bytes, có thể null nếu chưa xác định)
        public long? FileSize { get; set; }

        // ID của người hoặc hệ thống thực hiện sao lưu (có thể null nếu tự động)
        public long? CreatedBy { get; set; }

        // Liên kết với entity User (người thực hiện sao lưu)
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        // Mô tả ngắn về bản sao lưu (ví dụ: mục đích hoặc nội dung)
        [StringLength(500)]
        public string Description { get; set; }

        // Thời gian tạo bản sao lưu (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản sao lưu (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
