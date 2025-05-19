// File: Models/StudentCourseDto.cs
// Mục đích: Định nghĩa DTO để trả dữ liệu phân công sinh viên về client
namespace EduProject_TADProgrammer.Models
{
    public class StudentCourseDto
    {
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public string CourseId { get; set; }
        public string Semester { get; set; }
        public string ClassCode { get; set; } // Đổi từ ClassId thành ClassCode
        public string LecturerName { get; set; }
    }
}