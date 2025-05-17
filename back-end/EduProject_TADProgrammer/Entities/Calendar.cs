// File: Entities/Calendar.cs
// Mục đích: Định nghĩa entity Calendar để lưu trữ lịch cá nhân và nhóm, hỗ trợ quản lý sự kiện.
// Hỗ trợ chức năng:
//   84: Quản lý lịch cá nhân và nhóm

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    // Enum để định nghĩa loại sự kiện
    public enum EventType
    {
        Meeting,     // Cuộc họp (cá nhân hoặc nhóm)
        Deadline,    // Hạn chót (nộp bài, bảo vệ)
        Reminder,    // Nhắc nhở
        Other        // Sự kiện khác
    }

    // Enum để định nghĩa trạng thái sự kiện
    public enum EventStatus
    {
        Scheduled,   // Đã lên lịch
        Completed,   // Đã hoàn thành
        Cancelled    // Đã hủy
    }

    public class Calendar
    {
        // Khóa chính của bản ghi sự kiện
        [Key]
        public long Id { get; set; }

        // ID của người dùng liên quan đến sự kiện (có thể null nếu là sự kiện nhóm)
        public long? UserId { get; set; }

        // Liên kết với entity User (người sở hữu sự kiện)
        [ForeignKey("UserId")]
        public User User { get; set; }

        // ID của nhóm liên quan đến sự kiện (có thể null nếu là sự kiện cá nhân)
        public long? GroupId { get; set; }

        // Liên kết với entity Group (nhóm liên quan)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Tiêu đề sự kiện (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255, ErrorMessage = "EventTitle must not exceed 255 characters")]
        public string EventTitle { get; set; }

        // Mô tả chi tiết về sự kiện (tùy chọn, tối đa 1000 ký tự)
        [StringLength(1000)]
        public string Description { get; set; }

        // Thời gian bắt đầu sự kiện (bắt buộc)
        [Required]
        public DateTime StartTime { get; set; }

        // Thời gian kết thúc sự kiện (bắt buộc)
        [Required]
        public DateTime EndTime { get; set; }

        // Địa điểm tổ chức sự kiện (tùy chọn, tối đa 255 ký tự)
        [StringLength(255)]
        public string Location { get; set; }

        // Xác định sự kiện kéo dài cả ngày (mặc định là false)
        public bool IsAllDay { get; set; } = false;

        // Loại sự kiện (bắt buộc, sử dụng enum EventType)
        [Required]
        public string Type { get; set; } //Meeting, Deadline, Reminder, Other

        // Trạng thái sự kiện (bắt buộcMostrar más, sử dụng enum EventStatus)
        [Required]
        public string Status { get; set; } //Scheduled, Completed, Cancelled

        // Thời gian tạo sự kiện (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật sự kiện (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Validation để đảm bảo StartTime < EndTime
        [CustomValidation(typeof(Calendar), nameof(ValidateTimeRange))]
        public static ValidationResult ValidateTimeRange(object value, ValidationContext context)
        {
            var calendar = (Calendar)context.ObjectInstance;
            if (calendar.StartTime >= calendar.EndTime)
            {
                return new ValidationResult("StartTime must be earlier than EndTime.");
            }
            return ValidationResult.Success;
        }
    }
}