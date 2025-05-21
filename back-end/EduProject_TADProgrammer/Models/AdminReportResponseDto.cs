// File: Models/AdminReportResponseDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu báo cáo qua API.
// Ghi chú: Các DTO này được dùng để trả về dữ liệu cho bộ lọc và báo cáo trong admin_reports.html.

namespace EduProject_TADProgrammer.Models
{
    // DTO cho kỳ học (dùng cho dropdown bộ lọc)
    public class SemesterAdminReportDto
    {
        // Ghi chú: ID của kỳ học trong DB
        public long Id { get; set; }

        // Ghi chú: Tên kỳ học, ví dụ: "HK20251"
        public string Name { get; set; } 
    }

    // DTO cho khoa/bộ môn (dùng cho dropdown bộ lọc)
    public class DepartmentAdminReportDto
    {
        // Ghi chú: ID của khoa/bộ môn
        public long Id { get; set; }

        // Ghi chú: Tên khoa/bộ môn, ví dụ: "Công nghệ Thông tin"
        public string Name { get; set; }

        // Ghi chú: Mã khoa/bộ môn, ví dụ: "CNTT"
        public string Code { get; set; } 
    }

    // DTO cho sinh viên (dùng trong báo cáo chi tiết)
    public class StudentAdminReportDto
    {
        // Ghi chú: ID sinh viên
        public long Id { get; set; }

        // Ghi chú: Mã sinh viên, ví dụ: "21520001"
        public string StudentId { get; set; }

        // Ghi chú: Họ và tên sinh viên
        public string Name { get; set; }

        // Ghi chú: Mã lớp, ví dụ: "CNTT21A"
        public string ClassCode { get; set; }

        // Ghi chú: Mã khoa, ví dụ: "CNTT"
        public string FacultyCode { get; set; }

        // Ghi chú: Mã bộ môn, ví dụ: "CNTT"
        public string DepartmentCode { get; set; }

        // Ghi chú: Mã kỳ học, ví dụ: "HK20251"
        public string SemesterCode { get; set; } 
    }

    // DTO cho đề tài (dùng trong báo cáo chi tiết)
    public class ProjectAdminReportDto
    {
        // Ghi chú: ID đề tài
        public long Id { get; set; }

        // Ghi chú: Mã đề tài, ví dụ: "DT001"
        public string ProjectId { get; set; }

        // Ghi chú: Tên đề tài
        public string Name { get; set; } 

        // Ghi chú: Tên sinh viên thực hiện
        public string StudentName { get; set; } 

        // Ghi chú: Tên giảng viên hướng dẫn
        public string LecturerName { get; set; } 

        // Ghi chú: Trạng thái, ví dụ: "Đã duyệt"
        public string Status { get; set; } 

        // Ghi chú: Mã kỳ học
        public string SemesterCode { get; set; } 

        // Ghi chú: Mã khoa
        public string FacultyCode { get; set; } 

        // Ghi chú: Mã bộ môn
        public string FacultyName { get; set; } 
    }

    // DTO cho giảng viên (dùng trong báo cáo chi tiết)
    public class LecturerAdminReportDto
    {
        // Ghi chú: ID giảng viên
        public long Id { get; set; }

        // Ghi chú: Mã giảng viên, ví dụ: "GV001"
        public string LecturerId { get; set; } 

        // Ghi chú: Họ và tên giảng viên
        public string Name { get; set; } 

        // Ghi chú: Mã bộ môn
        public string DepartmentCode { get; set; } 

        // Ghi chú: Mã khoa
        public string FacultyCode { get; set; } 
    }

    // DTO cho thống kê tổng quan
    public class AdminReportSummaryDto
    {
        // Ghi chú: Số lượng sinh viên
        public int StudentCount { get; set; } 

        // Ghi chú: Số đề tài đã duyệt/hoàn thành
        public int ApprovedProjects { get; set; } 

        // Ghi chú: Số đề tài chưa duyệt
        public int PendingProjects { get; set; } 

        // Ghi chú: Số lượng giảng viên
        public int LecturerCount { get; set; } 
    }

    // DTO tổng hợp dữ liệu báo cáo
    public class AdminReportResponseDto
    {
        // Ghi chú: Thống kê tổng quan
        public AdminReportSummaryDto Summary { get; set; }

        // Ghi chú: Danh sách sinh viên
        public List<StudentAdminReportDto> Students { get; set; }

        // Ghi chú: Danh sách đề tài
        public List<ProjectAdminReportDto> Projects { get; set; }

        // Ghi chú: Danh sách giảng viên
        public List<LecturerAdminReportDto> Lecturers { get; set; } 
    }
}