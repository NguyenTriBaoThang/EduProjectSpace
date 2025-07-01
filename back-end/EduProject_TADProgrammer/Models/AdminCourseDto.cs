namespace EduProject_TADProgrammer.Models
{
    public class AdminCourseDto
    {
        public long Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string SemesterName { get; set; }
        public string FacultyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DefenseDate { get; set; }
    }

    public class SemesterDto
    {
        public string Name { get; set; }
    }

    public class FacultyDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CreateAdminCourseRequest
    {
        public string Name { get; set; }
        public string SemesterName { get; set; }
        public string FacultyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DefenseDate { get; set; }
    }

    public class UpdateAdminCourseRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SemesterName { get; set; }
        public string FacultyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DefenseDate { get; set; }
    }
}