// File: Models/HeadCourseGradingDto.cs
// Mục đích: Định nghĩa DTO để trả về danh sách môn học cần duyệt chấm điểm.

namespace EduProject_TADProgrammer.Models
{
    public class HeadCourseGradingDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public string Head { get; set; }
        public int GroupCount { get; set; }
        public int GradedCount { get; set; }
        public int ApprovedCount { get; set; }
    }
}
