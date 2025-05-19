// File: Models/LecturerDto.cs
// Mục đích: Định nghĩa DTO để trả danh sách giảng viên về client
namespace EduProject_TADProgrammer.Models
{
    public class LecturerDto
    {
        public long Id { get; set; } // ID giảng viên
        public string FullName { get; set; } // Tên đầy đủ
    }
}