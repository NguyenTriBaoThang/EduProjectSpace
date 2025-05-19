// File: Core/Models/CourseDto.cs
// Mục đích: Truyền dữ liệu thông tin môn học đồ án (tên, kỳ học, thời gian) giữa API và frontend.
// Chức năng hỗ trợ: 
//   7: Quản lý quy trình đồ án
//   17: Quản lý danh sách môn học
//   18: Thiết lập thời gian kỳ học
//   77: So sánh điểm giữa các môn
namespace EduProject_TADProgrammer.Models
{
    public class CourseDto
    {
        public long Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string ClassCode { get; set; } // Đổi từ ClassId thành ClassCode
        public int StudentCount { get; set; }
        public int AssignedCount { get; set; }
    }
}