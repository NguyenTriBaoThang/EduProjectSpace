// File: Models/HeadLecturerDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu thông tin giảng viên hướng dẫn, nhóm, và chi tiết đồ án giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý thông tin giảng viên hướng dẫn (xem danh sách giảng viên, nhóm, sinh viên, và chi tiết đồ án).

using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin tổng quan về giảng viên hướng dẫn
    public class HeadLecturerDto
    {
        // Tên giảng viên hướng dẫn
        public string Lecturer { get; set; }

        // Mã môn học (ví dụ: "CS101")
        public string CourseCode { get; set; }

        // Tên học kỳ (ví dụ: "HK1_2023-2024")
        public string SemesterName { get; set; }

        // Mã lớp học (ví dụ: "K64A")
        public string ClassCode { get; set; }

        // Tổng số sinh viên được hướng dẫn
        public int StudentCount { get; set; }

        // Tổng số nhóm được hướng dẫn
        public int GroupCount { get; set; }
    }

    // DTO để truyền thông tin chi tiết nhóm
    public class HeadLecturerGroupDetailDto
    {
        // Số thứ tự nhóm (ví dụ: 1, 2, 3...)
        public int Index { get; set; }

        // Danh sách mã sinh viên (phân cách bằng dấu phẩy, ví dụ: "SV001,SV002")
        public string StudentIds { get; set; }

        // Danh sách tên sinh viên (phân cách bằng dấu phẩy, ví dụ: "Nguyễn Văn A, Trần Thị B")
        public string StudentNames { get; set; }

        // Tên nhóm (ví dụ: "Nhóm 1")
        public string GroupName { get; set; }

        // Tên đồ án (ví dụ: "Hệ thống quản lý đồ án")
        public string ProjectName { get; set; }
    }

    // DTO để truyền thông tin chi tiết nhóm và đồ án
    public class HeadLecturerGroupDetailsDto
    {
        // Tên giảng viên hướng dẫn
        public string LecturerName { get; set; }

        // Thông tin môn học (kết hợp mã môn, tên môn, lớp, kỳ học, ví dụ: "CS101 - Đồ án lập trình - K64A - HK1_2023-2024")
        public string CourseInfo { get; set; }

        // Tên nhóm (ví dụ: "Nhóm 1")
        public string GroupName { get; set; }

        // Danh sách thành viên nhóm
        public List<HeadLecturerMemberGroupDetailDto> Members { get; set; }

        // Tên đồ án (ví dụ: "Hệ thống quản lý đồ án")
        public string ProjectName { get; set; }

        // Thời gian bắt đầu đồ án (chuỗi định dạng, ví dụ: "2023-09-01")
        public string StartDate { get; set; }

        // Thời gian kết thúc đồ án (chuỗi định dạng, ví dụ: "2023-12-31")
        public string EndDate { get; set; }

        // Thời gian chấm điểm (chuỗi định dạng, ví dụ: "2024-01-15")
        public string GradingDate { get; set; }

        // Mô tả đề tài đồ án
        public string Description { get; set; }

        // Danh sách URL của các file mô tả đề tài
        public List<string> FileUrls { get; set; }
    }

    // DTO để truyền thông tin thành viên trong nhóm
    public class HeadLecturerMemberGroupDetailDto
    {
        // Mã sinh viên (ví dụ: "SV001")
        public string StudentId { get; set; }

        // Tên sinh viên (ví dụ: "Nguyễn Văn A")
        public string StudentName { get; set; }
    }
}