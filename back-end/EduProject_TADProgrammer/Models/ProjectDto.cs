// File: Core/Models/ProjectDto.cs
// Mục đích: Truyền dữ liệu thông tin đề tài đồ án (tiêu đề, mô tả, trạng thái) giữa API và frontend.
// Chức năng hỗ trợ: 
//   7: Quản lý quy trình đồ án
//   8: Đề xuất và kiểm tra đề tài
//   9: Phân công đề tài
//   27: Giao nhiệm vụ
//   50: Quản lý danh sách đề tài bắt buộc
//   56: Quản lý lịch bảo vệ
//   67: Lịch sử chỉnh sửa đề tài
//   75: Lịch trình chấm điểm
namespace EduProject_TADProgrammer.Models
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string Title { get; set; }
        public long StudentCourseId { get; set; }
        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public long LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public GroupProjectDto Group { get; set; }
    }

    public class GroupProjectDto
    {
        public long Id { get; set; }
        public List<StudentDto> Students { get; set; }
    }

    public class StudentDto
    {
        public long ?Id { get; set; }
        public string ?FullName { get; set; }
    }
}