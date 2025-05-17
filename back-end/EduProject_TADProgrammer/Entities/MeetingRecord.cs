// File: Entities/MeetingRecord.cs
// Mục đích: Định nghĩa entity MeetingRecord để lưu bản ghi âm hoặc tài liệu cuộc họp.
// Hỗ trợ chức năng: 
//   73: Hỗ trợ họp trực tuyến
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class MeetingRecord
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long MeetingId { get; set; }

        [ForeignKey("MeetingId")]
        public Meeting Meeting { get; set; }

        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
