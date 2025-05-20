// File: Entities/Meeting.cs
// Mục đích: Định nghĩa entity Meeting để lưu trữ thông tin cuộc họp trực tuyến hoặc trực tiếp của nhóm.
// Hỗ trợ chức năng:
//   30: Giảng viên - Tạo lịch họp nhóm
//   73: Hỗ trợ họp trực tuyến

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Meeting
    {
        // Khóa chính của bản ghi cuộc họp
        [Key]
        public long Id { get; set; }

        // ID của nhóm liên quan (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm tổ chức cuộc họp)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Tiêu đề cuộc họp (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        // Thời gian bắt đầu cuộc họp (bắt buộc)
        [Required]
        public DateTime StartTime { get; set; }

        // Thời gian kết thúc cuộc họp (bắt buộc)
        [Required]
        public DateTime EndTime { get; set; }

        // Địa điểm tổ chức cuộc họp (tùy chọn, tối đa 255 ký tự, ví dụ: phòng họp hoặc link họp trực tuyến)
        [StringLength(255)]
        public string Location { get; set; }

        // ID của người tạo cuộc họp (bắt buộc, thường là giảng viên hoặc trưởng nhóm)
        [Required]
        public long CreatedBy { get; set; }

        // Liên kết với entity User (người tạo cuộc họp)
        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Danh sách bản ghi hoặc tài liệu liên quan đến cuộc họp
        public virtual ICollection<MeetingRecord> MeetingRecords { get; set; } = new List<MeetingRecord>();
    }
}