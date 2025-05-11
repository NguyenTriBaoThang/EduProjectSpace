// File: Core/Models/ResourceDto.cs
// Mục đích: Truyền dữ liệu tài liệu tham khảo, tài nguyên nhóm, hoặc mẫu giữa API và frontend.
// Chức năng hỗ trợ: 
//   31: Giảng viên - Quản lý tài liệu
//   38: Giảng viên - Tạo tài liệu mẫu
//   42: Sinh viên - Tải tài liệu mẫu
//   51: Quản lý tài liệu và tài nguyên
//   69: Hỗ trợ phân loại tài liệu
//   87: Công cụ lập kế hoạch tài nguyên nhóm
//   89: Sinh viên - Xem tài nguyên nhóm
//   90: Admin - Quản lý danh sách tài liệu nhóm
namespace EduProject_TADProgrammer.Models
{
    public class ResourceDto
    {
        public long Id { get; set; }
        public long? ProjectId { get; set; }
        public long? GroupId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string Type { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}