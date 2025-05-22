// File: Models/HeadProgressCourseDto.cs
// Mục đích: Định nghĩa các DTO để trả về thông tin môn học và tiến độ (bao gồm nhóm, đồ án, và giai đoạn) cho frontend.
// Hỗ trợ chức năng:
//   Quản lý tiến độ môn học (xem thông tin môn học, nhóm, và tiến độ chi tiết của các giai đoạn đồ án).

using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin tổng quan về môn học và tiến độ
    public class HeadProgressCourseDto
    {
        // Mã môn học (ví dụ: "CS101")
        public string CourseId { get; set; }

        // Tên môn học (ví dụ: "Đồ án lập trình")
        public string Name { get; set; }

        // Học kỳ (ví dụ: "HK1_2023-2024")
        public string Semester { get; set; }

        // Mã ngành (ví dụ: "CNTT")
        public string FacultyCode { get; set; }

        // Tên trưởng bộ môn
        public string Head { get; set; }

        // Số lượng nhóm trong môn học
        public int GroupCount { get; set; }

        // Số lượng nhóm đã hoàn thành đồ án
        public int CompletedCount { get; set; }
    }

    // DTO để truyền thông tin nhóm trong môn học
    public class HeadProgressCourseGroupDto
    {
        // ID của nhóm
        public long Id { get; set; }

        // Tên nhóm (ví dụ: "Nhóm 1")
        public string Name { get; set; }

        // Mã đồ án (ví dụ: "DA001")
        public string ProjectId { get; set; }

        // Tên đồ án (ví dụ: "Hệ thống quản lý đồ án")
        public string ProjectName { get; set; }

        // Danh sách tên thành viên nhóm (chuỗi cách nhau bởi dấu phẩy, ví dụ: "Nguyễn Văn A, Trần Thị B")
        public string Members { get; set; }

        // Tên giảng viên hướng dẫn
        public string Lecturer { get; set; }

        // Trạng thái của nhóm (ví dụ: "Đang thực hiện", "Hoàn thành")
        public string Status { get; set; }
    }

    // DTO để truyền thông tin chi tiết nhóm và các giai đoạn đồ án
    public class HeadProgressCourseDetailDto
    {
        // ID của nhóm
        public long GroupId { get; set; }

        // Tên nhóm (ví dụ: "Nhóm 1")
        public string GroupName { get; set; }

        // Mã đồ án (ví dụ: "DA001")
        public string ProjectId { get; set; }

        // Tên đồ án (ví dụ: "Hệ thống quản lý đồ án")
        public string ProjectName { get; set; }

        // Danh sách tên thành viên nhóm (chuỗi cách nhau bởi dấu phẩy, ví dụ: "Nguyễn Văn A, Trần Thị B")
        public string Members { get; set; }

        // Tên giảng viên hướng dẫn
        public string Lecturer { get; set; }

        // Trạng thái của nhóm (ví dụ: "Đang thực hiện", "Hoàn thành")
        public string Status { get; set; }

        // Danh sách các giai đoạn của đồ án
        public List<HeadProgressCoursePhase> Phases { get; set; }
    }

    // DTO để truyền thông tin một giai đoạn của đồ án
    public class HeadProgressCoursePhase
    {
        // Tên giai đoạn (ví dụ: "Phân tích yêu cầu")
        public string Phase { get; set; }

        // Mô tả giai đoạn
        public string Description { get; set; }

        // Danh sách URL file liên quan đến giai đoạn
        public List<string> Files { get; set; }

        // Ngày nộp giai đoạn (chuỗi định dạng, ví dụ: "2023-10-15")
        public string Date { get; set; }

        // Thời hạn nộp giai đoạn (chuỗi định dạng, ví dụ: "2023-10-20")
        public string Deadline { get; set; }

        // Điểm của giai đoạn (chuỗi, ví dụ: "8.5" hoặc "Chưa chấm")
        public string Score { get; set; }
    }
}