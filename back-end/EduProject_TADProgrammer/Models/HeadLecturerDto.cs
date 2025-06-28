using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    public class HeadLecturerDto
    {
        public string Lecturer { get; set; }
        public string CourseCode { get; set; }
        public string SemesterName { get; set; }
        public string FacultyCode { get; set; }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }
    }

    public class HeadLecturerGroupDetailDto
    {
        public long GroupId { get; set; }
        public string StudentIds { get; set; }
        public string StudentNames { get; set; }
        public string GroupName { get; set; }
        public string ProjectName { get; set; }
    }

    public class HeadLecturerGroupDetailsDto
    {
        public string LecturerName { get; set; }
        public string CourseInfo { get; set; }
        public string GroupName { get; set; }
        public List<HeadLecturerMemberGroupDetailDto> Members { get; set; }
        public string ProjectName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string GradingDate { get; set; }
        public string Description { get; set; }
        public List<FileSubmissionHeadLecturerDto> Files { get; set; } // Changed from FileUrls
    }

    public class HeadLecturerMemberGroupDetailDto
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
    }

    // New DTO for file submissions with student info
    public class FileSubmissionHeadLecturerDto
    {
        public string FilePath { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
    }
}