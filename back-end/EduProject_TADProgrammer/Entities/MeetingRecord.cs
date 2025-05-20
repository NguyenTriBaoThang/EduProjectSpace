// File: Entities/MeetingRecord.cs
// Mục đích: Định nghĩa entity MeetingRecord để lưu trữ bản ghi âm hoặc tài liệu của cuộc họp.
// Hỗ trợ chức năng:
//   73: Hỗ trợ họp trực tuyến

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class MeetingRecord
    {
        // Khóa chính của bản ghi tài liệu cuộc họp
        [Key]
        public long Id { get; set; }

        // ID của cuộc họp liên quan (bắt buộc)
        [Required]
        public long MeetingId { get; set; }

        // Liên kết với entity Meeting (cuộc họp chứa bản ghi)
        [ForeignKey("MeetingId")]
        public Meeting Meeting { get; set; }

        // Đường dẫn đến file bản ghi hoặc tài liệu (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}