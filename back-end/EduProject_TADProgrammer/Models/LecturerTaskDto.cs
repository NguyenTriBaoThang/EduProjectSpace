namespace EduProject_TADProgrammer.Models
{
    public class LecturerTaskDto
    {
        public long Id { get; set; }
        public string CourseId { get; set; }
        public string ProjectId { get; set; }
        public string TaskDescription { get; set; }
        public string Semester { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
    }

    public class CreateLecturerTaskDto
    {
        public string CourseId { get; set; }
        public string ProjectId { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class UpdateLecturerTaskDto
    {
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
    }
}
