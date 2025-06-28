namespace EduProject_TADProgrammer.Models
{
    public class LecturerCourseGroupDto
    {
        public List<LecturerCourseSummaryDto> Courses { get; set; }
    }

    public class LecturerCourseSummaryDto
    {
        public long Id { get; set; }
        public string CourseId { get; set; } 
        public string Name { get; set; }
        public string? Semester { get; set; }
        public string FacultyCode { get; set; }
        public int StudentCount { get; set; }
        public int GroupCount { get; set; }
    }

    public class LecturerCourseGroupStudentDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
        public bool IsLeader { get; set; }
    }

    public class LecturerCourseGroupsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public List<LecturerCourseGroupStudentDto> Members { get; set; }
    }

    public class LecturerCourseGroupProjectDto
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
    }

    public class AutoLecturerCourseGroupRequestDto
    {
        public string CourseId { get; set; }
        public int GroupSize { get; set; }
    }
}
