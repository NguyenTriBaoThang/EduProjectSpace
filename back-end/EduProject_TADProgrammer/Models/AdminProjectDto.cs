// File: Models/AdminProjectDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu thông tin đề tài đồ án (tiêu đề, mô tả, trạng thái) giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý đề tài đồ án (tạo, cập nhật, xem thông tin đề tài, nhóm và sinh viên liên quan).

using System;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin chi tiết đề tài đồ án
    public class AdminProjectDto
    {
        // ID của đề tài
        public long Id { get; set; }

        // Mã đề tài (ví dụ: "DA001")
        public string ProjectCode { get; set; }

        // Tiêu đề đề tài
        public string Title { get; set; }

        // ID của môn học liên quan
        public long CourseId { get; set; }

        // Tên môn học (ví dụ: "Đồ án lập trình")
        public string CourseName { get; set; }

        // ID của giảng viên hướng dẫn (tùy chọn)
        public long? LecturerId { get; set; }

        // Tên giảng viên hướng dẫn
        public string LecturerName { get; set; }

        // Trạng thái đề tài (ví dụ: "Đang thực hiện", "Hoàn thành")
        public string Status { get; set; }

        // Thời gian tạo đề tài
        public DateTime CreatedAt { get; set; }

        // Thời gian cập nhật đề tài
        public DateTime UpdatedAt { get; set; }

        // Thông tin nhóm thực hiện đề tài
        public AdminProjectGroupDto Group { get; set; }
    }

    // DTO để truyền thông tin môn học liên quan đến đề tài
    public class CourseAdminProjectDto
    {
        // ID của môn học
        public long Id { get; set; }

        // Tên môn học (ví dụ: "Đồ án lập trình")
        public string Name { get; set; }
    }

    // DTO để truyền thông tin nhóm thực hiện đề tài
    public class AdminProjectGroupDto
    {
        // ID của nhóm
        public long Id { get; set; }

        // Tên nhóm (ví dụ: "Nhóm 1")
        public string Name { get; set; }

        // ID của đề tài liên quan
        public long ProjectId { get; set; }

        // Thời gian tạo nhóm
        public DateTime CreatedAt { get; set; }

        // Danh sách sinh viên trong nhóm
        public List<AdminProjectStudentDto> Students { get; set; }
    }

    // DTO để truyền thông tin sinh viên trong nhóm
    public class AdminProjectStudentDto
    {
        // ID của sinh viên
        public long Id { get; set; }

        // Họ và tên đầy đủ của sinh viên
        public string FullName { get; set; }
    }

    // DTO để yêu cầu tạo mới đề tài đồ án
    public class CreateAdminProjectRequest
    {
        // Mã đề tài (bắt buộc, ví dụ: "DA001")
        public string ProjectCode { get; set; }

        // Tiêu đề đề tài (bắt buộc)
        public string Title { get; set; }

        // ID của môn học liên quan (bắt buộc)
        public long CourseId { get; set; }

        // Trạng thái đề tài (tùy chọn, ví dụ: "Đang thực hiện")
        public string? Status { get; set; }
    }

    // DTO để yêu cầu cập nhật đề tài đồ án
    public class UpdateAdminProjectRequest
    {
        // ID của đề tài (bắt buộc)
        public long Id { get; set; }

        // Mã đề tài (bắt buộc, ví dụ: "DA001")
        public string ProjectCode { get; set; }

        // Tiêu đề đề tài (bắt buộc)
        public string Title { get; set; }

        // ID của môn học liên quan (bắt buộc)
        public long CourseId { get; set; }

        // Trạng thái đề tài (bắt buộc, ví dụ: "Đang thực hiện")
        public string Status { get; set; }
    }
}