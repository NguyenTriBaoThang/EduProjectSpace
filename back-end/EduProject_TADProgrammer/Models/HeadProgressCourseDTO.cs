// File: Models/ProgressCourseDto.cs
// Mục đích: Định nghĩa DTO để trả về thông tin môn học và tiến độ cho frontend.

namespace EduProject_TADProgrammer.Models
{
    public class HeadProgressCourseDto
    {
        // Mã môn học
        public string CourseId { get; set; }

        // Tên môn học
        public string Name { get; set; }

        // Học kỳ
        public string Semester { get; set; }

        // Mã ngành
        public string FacultyCode { get; set; }

        // Tên trưởng bộ môn
        public string Head { get; set; }

        // Số lượng nhóm
        public int GroupCount { get; set; }

        // Số lượng nhóm hoàn thành
        public int CompletedCount { get; set; }
    }

    public class HeadProgressCourseGroupDto
    {
        // ID của nhóm
        public long Id { get; set; }

        // Tên nhóm
        public string Name { get; set; }

        // Mã đồ án
        public string ProjectId { get; set; }

        // Tên đồ án
        public string ProjectName { get; set; }

        // Danh sách thành viên (chuỗi cách nhau bởi dấu phẩy)
        public string Members { get; set; }

        // Tên giảng viên hướng dẫn
        public string Lecturer { get; set; }

        // Trạng thái của nhóm
        public string Status { get; set; }
    }

    public class HeadProgressCourseDetailDTO
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Members { get; set; }
        public string Lecturer { get; set; }
        public string Status { get; set; }
        public List<HeadProgressCoursePhase> Phases { get; set; }
    }

    public class HeadProgressCoursePhase
    {
        public string Phase { get; set; }
        public string Description { get; set; }
        public List<string> Files { get; set; }
        public string Date { get; set; }
        public string Deadline { get; set; }
        public string Score { get; set; }
    }
}
