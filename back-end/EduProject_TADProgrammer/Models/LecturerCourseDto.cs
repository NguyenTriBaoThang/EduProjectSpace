using EduProject_TADProgrammer.Controllers;

namespace EduProject_TADProgrammer.Models
{
    public class LecturerCourseDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public int ProjectCount { get; set; }
    }

    public class ProjectLecturerCourseDto
    {
        public long Id { get; set; }
        public string CourseId { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; }
        public List<StudentLecturerCourseDto> Students { get; set; }
    }

    public class LecturerCoursesTaskDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public string Status { get; set; }
        public string Feedback { get; set; }
        public List<SubmissionLecturerCourseDto> Submissions { get; set; }
    }

    public class FeedbackLecturerCourseRequest
    {
        public string Feedback { get; set; }
    }

    public class StudentLecturerCourseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public bool IsLeader { get; set; }
    }

    public class SubmissionLecturerCourseDto
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string SubmittedBy { get; set; }
    }
}
