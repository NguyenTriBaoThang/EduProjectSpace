// File: Core/Models/MeetingDto.cs
// Mục đích: Truyền dữ liệu thông tin cuộc họp trực tuyến hoặc trực tiếp giữa API và frontend.
// Chức năng hỗ trợ: 
//   30: Giảng viên - Tạo lịch họp nhóm
//   73: Hỗ trợ họp trực tuyến
namespace EduProject_TADProgrammer.Models
{
    public class MeetingDto
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}