// File: Core/Models/MeetingRecordDto.cs
// Mục đích: Truyền dữ liệu bản ghi âm hoặc tài liệu cuộc họp giữa API và frontend.
// Chức năng hỗ trợ: 
//   73: Hỗ trợ họp trực tuyến
namespace EduProject_TADProgrammer.Models
{
    public class MeetingRecordDto
    {
        public long Id { get; set; }
        public long MeetingId { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}