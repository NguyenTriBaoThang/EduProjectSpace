using EduProject_TADProgrammer.Controllers;

namespace EduProject_TADProgrammer.Models
{
    public class LecturerProjectApprovalDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public int ProposalCount { get; set; }
    }

    public class LecturerProjectApprovalRequestDto
    {
        public string ApprovalStatus { get; set; }
        public string? ApprovalReason { get; set; }
    }

    public class ProjectLecturerProjectApprovalDto
    {
        public long Id { get; set; }
        public string CourseId { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string LecturerName { get; set; }
        public string Description { get; set; }
        public List<string> DescriptionFilePath { get; set; } // Changed from string to List<string>
        public string ApprovalStatus { get; set; }
        public string ApprovalReason { get; set; }
        public List<StudentLecturerProjectApprovalDto> Students { get; set; }
    }

    public class StudentLecturerProjectApprovalDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsLeader { get; set; }
    }
}
