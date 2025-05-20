// File: Core/Models/ProjectDto.cs
// Mục đích: Truyền dữ liệu thông tin đề tài đồ án (tiêu đề, mô tả, trạng thái) giữa API và frontend.

using System;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    public class AdminProjectDto
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string Title { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public long ?LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AdminProjectGroupDto Group { get; set; }
    }

    public class CourseAdminProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class AdminProjectGroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<AdminProjectStudentDto> Students { get; set; }
    }

    public class AdminProjectStudentDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }

    public class CreateAdminProjectRequest
    {
        public string ProjectCode { get; set; }
        public string Title { get; set; }
        public long CourseId { get; set; }
        public string? Status { get; set; }
    }

    public class UpdateAdminProjectRequest
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string Title { get; set; }
        public long CourseId { get; set; }
        public string Status { get; set; }
    }
}