// File: Models/AdminSemesterDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu thông tin kỳ học giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý kỳ học (xem, tạo, cập nhật thông tin kỳ học).

using System;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin chi tiết kỳ học
    public class AdminSemesterDto
    {
        // ID của kỳ học
        public long Id { get; set; }

        // Tên kỳ học (ví dụ: "HK1_2023-2024")
        public string Name { get; set; }

        // Ngày bắt đầu kỳ học
        public DateTime StartDate { get; set; }

        // Ngày kết thúc kỳ học
        public DateTime EndDate { get; set; }

        // Trạng thái kỳ học (tính toán, ví dụ: "Hoạt động" hoặc "Kết thúc")
        public string Status { get; set; }

        // Thời gian tạo kỳ học
        public DateTime CreatedAt { get; set; }

        // Mô tả thêm về kỳ học (tùy chọn)
        public string? Description { get; set; }
    }

    // DTO để yêu cầu tạo mới kỳ học
    public class CreateAdminSemesterRequest
    {
        // Tên kỳ học (bắt buộc, ví dụ: "HK1_2023-2024")
        public string Name { get; set; }

        // Ngày bắt đầu kỳ học (bắt buộc)
        public DateTime StartDate { get; set; }

        // Ngày kết thúc kỳ học (bắt buộc)
        public DateTime EndDate { get; set; }

        // Mô tả thêm về kỳ học (tùy chọn)
        public string? Description { get; set; }
    }

    // DTO để yêu cầu cập nhật kỳ học
    public class UpdateAdminSemesterRequest
    {
        // ID của kỳ học (bắt buộc)
        public long Id { get; set; }

        // Tên kỳ học (bắt buộc, ví dụ: "HK1_2023-2024")
        public string Name { get; set; }

        // Ngày bắt đầu kỳ học (bắt buộc)
        public DateTime StartDate { get; set; }

        // Ngày kết thúc kỳ học (bắt buộc)
        public DateTime EndDate { get; set; }

        // Mô tả thêm về kỳ học (tùy chọn)
        public string? Description { get; set; }
    }
}