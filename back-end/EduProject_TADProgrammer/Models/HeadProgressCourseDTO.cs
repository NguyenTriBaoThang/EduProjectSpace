// File: Models/ProgressCourseDTO.cs
// Mục đích: Định nghĩa DTO để trả về thông tin môn học và tiến độ cho frontend.

namespace EduProject_TADProgrammer.Models
{
    public class HeadProgressCourseDTO
    {
        // Mã môn học
        public string CourseId { get; set; }

        // Tên môn học
        public string Name { get; set; }

        // Học kỳ
        public string Semester { get; set; }

        // Mã ngành
        public string FacultyCode { get; set; }

        // Tên trưởng bộ môn
        public string Head { get; set; }

        // Số lượng nhóm
        public int GroupCount { get; set; }

        // Số lượng nhóm hoàn thành
        public int CompletedCount { get; set; }
    }
}
