using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    public class HeadProgressCourseDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public string Head { get; set; }
        public int GroupCount { get; set; }
        public int CompletedCount { get; set; }
    }

    public class HeadProgressCourseGroupDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Members { get; set; }
        public string Lecturer { get; set; }
        public string Status { get; set; }
    }

    public class HeadProgressCourseDetailDto
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
        public List<FileSubmission> Files { get; set; }
        public string Date { get; set; }
        public string Deadline { get; set; }
    }

    public class FileSubmission
    {
        public string FilePath { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
    }
}