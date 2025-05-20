// File: Dtos/CourseAssignmentDto.cs
// Mục đích: Định nghĩa DTO để chuẩn hóa dữ liệu môn học cần phân công.

namespace EduProject_TADProgrammer.Models
{
    public class HeadCourseAssignmentDto
    {
        public long CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string ClassCode { get; set; }
        public int StudentCount { get; set; }
        public int AssignedCount { get; set; }
        public int AssignedNullCount { get; set; }
    }

    public class HeadCourseAssignmentLecturerDto
    {
        public long Id { get; set; } // ID giảng viên
        public string FullName { get; set; } // Tên đầy đủ
    }

    public class HeadCourseAssignmentStudentDto
    {
        public long Id { get; set; } // ID sinh viên
        public string StudentCode { get; set; } // Mã sinh viên
        public string FullName { get; set; } // Tên sinh viên
        public string CourseCode { get; set; } // Mã môn học
        public string LecturerName { get; set; } // Tên giảng viên hướng dẫn
    }

    public class HeadCourseAssignmentRequest
    {
        public long StudentId { get; set; }
        public string LecturerName { get; set; }
    }
}
