// File: Core/Entities/Meeting.cs
// Mục đích: Định nghĩa entity Meeting để lưu thông tin cuộc họp trực tuyến hoặc trực tiếp.
// Hỗ trợ chức năng: 
//   30: Giảng viên - Tạo lịch họp nhóm
//   73: Hỗ trợ họp trực tuyến
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Meeting
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        public long CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<MeetingRecord> MeetingRecords { get; set; } = new List<MeetingRecord>();
    }
}
