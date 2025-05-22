// File: Models/HeadCourseGradingDto.cs
// Mục đích: Định nghĩa DTO để trả về danh sách môn học, nhóm và chi tiết chấm điểm.
namespace EduProject_TADProgrammer.Models
{
    public class HeadCourseGradingDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public string Head { get; set; }
        public int GroupCount { get; set; }
        public int GradedCount { get; set; }
        public int ApprovedCount { get; set; }
    }

    public class GroupHeadCourseGradingDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Members { get; set; }
        public string Lecturer { get; set; }
        public string Grade { get; set; } // Điểm tổng dưới dạng chuỗi (đã tính theo Weight)
        public string Status { get; set; }
        public string Approved { get; set; }
        public HeadCourseGradeDetails Grades { get; set; }
    }

    public class HeadCourseGradeDetails
    {
        public long StudentId { get; set; }
        public string FullName { get; set; }
        public double? TotalScore { get; set; } // Điểm tổng (đã tính theo Weight)
        public string CouncilFeedback { get; set; }
        public string Approved { get; set; }
        public List<string> ReportFiles { get; set; } // Sửa từ string thành List<string> để đồng bộ
    }

    // DTO mới để hỗ trợ chi tiết nhóm
    public class GroupHeadCourseGradingDetailDto
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<GroupMemberDetail> Members { get; set; }
        public string Lecturer { get; set; }
        public string Status { get; set; }
        public HeadCourseGradeDetails Grades { get; set; }
    }

    public class GroupMemberDetail
    {
        public long StudentId { get; set; }
        public string FullName { get; set; }
        public double? TotalScore { get; set; } // Điểm tổng của từng sinh viên
        public string CouncilFeedback { get; set; }
    }
}