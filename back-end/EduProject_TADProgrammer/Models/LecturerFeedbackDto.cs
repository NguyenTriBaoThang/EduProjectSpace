namespace EduProject_TADProgrammer.Models
{
    public class LecturerFeedbackDto
    {
        public long SubmissionId { get; set; }
        public string Content { get; set; }
    }

    public class CourseLecturerFeedbackDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public int ProjectCount { get; set; }
    }

    public class ProjectLecturerFeedbackDto
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Members { get; set; }
        public string Status { get; set; }
    }

    public class ProjectDetailLecturerFeedbackDto
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
        public string GroupMembers { get; set; }
        public string Status { get; set; }
        public List<TaskSubmissionGroupLecturerFeedbackDto> TaskSubmissionGroups { get; set; } = new List<TaskSubmissionGroupLecturerFeedbackDto>();
    }

    public class TaskSubmissionGroupLecturerFeedbackDto
    {
        public long TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public List<SubmissionLecturerFeedbackDto> Submissions { get; set; } = new List<SubmissionLecturerFeedbackDto>();
    }

    public class SubmissionLecturerFeedbackDto
    {
        public string Title { get; set; }
        public long SubmissionId { get; set; }
        public string FileName { get; set; }
        public string SubmittedBy { get; set; }
        public string SubmittedAt { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }
    }
}