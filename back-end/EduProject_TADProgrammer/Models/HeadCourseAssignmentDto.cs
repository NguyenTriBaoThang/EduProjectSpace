// File: Dtos/HeadCourseAssignmentDto.cs
// Mục đích: Định nghĩa các DTO để chuẩn hóa dữ liệu môn học cần phân công và thông tin liên quan giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý phân công môn học (phân công giảng viên hướng dẫn cho sinh viên, xem thông tin môn học, giảng viên, và sinh viên).

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin môn học cần phân công
    public class HeadCourseAssignmentDto
    {
        // ID của môn học
        public long CourseId { get; set; }

        // Tên môn học (ví dụ: "Đồ án lập trình")
        public string Name { get; set; }

        // Học kỳ của môn học (ví dụ: "HK1_2023-2024")
        public string Semester { get; set; }

        // Mã ngành (ví dụ: "K64A")
        public string FacultyCode { get; set; }

        // Tổng số sinh viên trong môn học
        public int StudentCount { get; set; }

        // Số sinh viên đã được phân công giảng viên hướng dẫn
        public int AssignedCount { get; set; }

        // Số sinh viên chưa được phân công giảng viên hướng dẫn
        public int AssignedNullCount { get; set; }
    }

    // DTO để truyền thông tin giảng viên
    public class HeadCourseAssignmentLecturerDto
    {
        // ID của giảng viên
        public long Id { get; set; }

        // Họ và tên đầy đủ của giảng viên
        public string FullName { get; set; }
    }

    // DTO để truyền thông tin sinh viên và phân công môn học
    public class HeadCourseAssignmentStudentDto
    {
        // ID của sinh viên
        public long Id { get; set; }

        // Mã sinh viên (ví dụ: "SV001")
        public string StudentCode { get; set; }

        // Họ và tên đầy đủ của sinh viên
        public string FullName { get; set; }

        // Mã môn học (ví dụ: "CS101")
        public string CourseCode { get; set; }

        // Tên giảng viên hướng dẫn
        public string LecturerName { get; set; }
    }

    // DTO để yêu cầu phân công giảng viên cho sinh viên
    public class HeadCourseAssignmentRequest
    {
        // ID của sinh viên (bắt buộc)
        public long StudentId { get; set; }

        // Tên giảng viên hướng dẫn (bắt buộc)
        public string LecturerName { get; set; }
    }
}