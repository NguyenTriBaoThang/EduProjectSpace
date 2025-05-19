// File: Models/ExportCourseRequest.cs
// Mục đích: Định nghĩa DTO để nhận dữ liệu tìm kiếm khi xuất Excel
namespace EduProject_TADProgrammer.Models
{
    public class ExportCourseRequest
    {
        public string SearchText { get; set; } // Chuỗi tìm kiếm
    }
}