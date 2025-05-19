// File: Models/StudentAssignmentDto.cs
// Mục đích: Định nghĩa DTO để trả dữ liệu danh sách sinh viên cần phân công GVHD về client
// File: Models/ImportAssignmentRequest.cs
// Mục đích: Định nghĩa DTO để nhận dữ liệu từ file Excel khi phân công

namespace EduProject_TADProgrammer.Models
{
    public class StudentAssignmentDto
    {
        public long Id { get; set; } // ID sinh viên
        public string StudentCode { get; set; } // Mã sinh viên
        public string FullName { get; set; } // Tên sinh viên
        public string CourseCode { get; set; } // Mã môn học
        public string LecturerName { get; set; } // Tên giảng viên hướng dẫn
    }

    public class ImportAssignmentRequest
    {
        public string StudentCode { get; set; } // Mã sinh viên
        public string LecturerName { get; set; } // Tên giảng viên
    }
}