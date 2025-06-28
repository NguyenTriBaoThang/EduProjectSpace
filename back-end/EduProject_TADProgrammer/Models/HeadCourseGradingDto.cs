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
        public string Grade { get; set; }
        public string Status { get; set; }
        public string Approved { get; set; }
        public HeadCourseGradeDetails Grades { get; set; }
    }

    public class HeadCourseGradeDetails
    {
        public long StudentId { get; set; }
        public string FullName { get; set; }
        public double? TotalScore { get; set; }
        public string CouncilFeedback { get; set; }
        public string Approved { get; set; }
        public List<FileSubmissionHeadCourseGradingDto> ReportFiles { get; set; } // Changed to List<FileSubmission>
    }

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
        public double? TotalScore { get; set; }
        public string CouncilFeedback { get; set; }
    }

    // New DTO for file submissions with student info
    public class FileSubmissionHeadCourseGradingDto
    {
        public string FilePath { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
    }
}