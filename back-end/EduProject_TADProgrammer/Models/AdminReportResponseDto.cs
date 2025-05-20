// File: Models/ReportDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu báo cáo qua API.
// Ghi chú: Các DTO này được dùng để trả về dữ liệu cho bộ lọc và báo cáo trong admin_reports.html.

namespace EduProject_TADProgrammer.Models
{
    // DTO cho kỳ học (dùng cho dropdown bộ lọc)
    public class SemesterAdminReportDto
    {
        public long Id { get; set; } // Ghi chú: ID của kỳ học trong DB
        public string Name { get; set; } // Ghi chú: Tên kỳ học, ví dụ: "HK20251"
    }

    // DTO cho khoa/bộ môn (dùng cho dropdown bộ lọc)
    public class DepartmentAdminReportDto
    {
        public long Id { get; set; } // Ghi chú: ID của khoa/bộ môn
        public string Name { get; set; } // Ghi chú: Tên khoa/bộ môn, ví dụ: "Công nghệ Thông tin"
        public string Code { get; set; } // Ghi chú: Mã khoa/bộ môn, ví dụ: "CNTT"
    }

    // DTO cho sinh viên (dùng trong báo cáo chi tiết)
    public class StudentAdminReportDto
    {
        public long Id { get; set; } // Ghi chú: ID sinh viên
        public string StudentId { get; set; } // Ghi chú: Mã sinh viên, ví dụ: "21520001"
        public string Name { get; set; } // Ghi chú: Họ và tên sinh viên
        public string ClassCode { get; set; } // Ghi chú: Mã lớp, ví dụ: "CNTT21A"
        public string FacultyCode { get; set; } // Ghi chú: Mã khoa, ví dụ: "CNTT"
        public string DepartmentCode { get; set; } // Ghi chú: Mã bộ môn, ví dụ: "CNTT"
        public string SemesterCode { get; set; } // Ghi chú: Mã kỳ học, ví dụ: "HK20251"
    }

    // DTO cho đề tài (dùng trong báo cáo chi tiết)
    public class ProjectAdminReportDto
    {
        public long Id { get; set; } // Ghi chú: ID đề tài
        public string ProjectId { get; set; } // Ghi chú: Mã đề tài, ví dụ: "DT001"
        public string Name { get; set; } // Ghi chú: Tên đề tài
        public string StudentName { get; set; } // Ghi chú: Tên sinh viên thực hiện
        public string LecturerName { get; set; } // Ghi chú: Tên giảng viên hướng dẫn
        public string Status { get; set; } // Ghi chú: Trạng thái, ví dụ: "Đã duyệt"
        public string SemesterCode { get; set; } // Ghi chú: Mã kỳ học
        public string FacultyCode { get; set; } // Ghi chú: Mã khoa
        public string FacultyName { get; set; } // Ghi chú: Mã bộ môn
    }

    // DTO cho giảng viên (dùng trong báo cáo chi tiết)
    public class LecturerAdminReportDto
    {
        public long Id { get; set; } // Ghi chú: ID giảng viên
        public string LecturerId { get; set; } // Ghi chú: Mã giảng viên, ví dụ: "GV001"
        public string Name { get; set; } // Ghi chú: Họ và tên giảng viên
        public string DepartmentCode { get; set; } // Ghi chú: Mã bộ môn
        public string FacultyCode { get; set; } // Ghi chú: Mã khoa
    }

    // DTO cho thống kê tổng quan
    public class AdminReportSummaryDto
    {
        public int StudentCount { get; set; } // Ghi chú: Số lượng sinh viên
        public int ApprovedProjects { get; set; } // Ghi chú: Số đề tài đã duyệt/hoàn thành
        public int PendingProjects { get; set; } // Ghi chú: Số đề tài chưa duyệt
        public int LecturerCount { get; set; } // Ghi chú: Số lượng giảng viên
    }

    // DTO tổng hợp dữ liệu báo cáo
    public class AdminReportResponseDto
    {
        public AdminReportSummaryDto Summary { get; set; } // Ghi chú: Thống kê tổng quan
        public List<StudentAdminReportDto> Students { get; set; } // Ghi chú: Danh sách sinh viên
        public List<ProjectAdminReportDto> Projects { get; set; } // Ghi chú: Danh sách đề tài
        public List<LecturerAdminReportDto> Lecturers { get; set; } // Ghi chú: Danh sách giảng viên
    }
}