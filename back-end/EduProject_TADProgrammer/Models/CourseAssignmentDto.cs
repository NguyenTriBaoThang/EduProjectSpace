// File: Dtos/CourseAssignmentDto.cs
// Mục đích: Định nghĩa DTO để chuẩn hóa dữ liệu môn học cần phân công.

namespace EduProject_TADProgrammer.Models
{
    public class CourseAssignmentDto
    {
        public long CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string ClassCode { get; set; }
        public int StudentCount { get; set; }
        public int AssignedCount { get; set; }
        public int AssignedNullCount { get; set; }
    }
}
