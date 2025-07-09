namespace EduProject_TADProgrammer.Models
{
    public class HeadCourseAssignmentDto
    {
        public long CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public int StudentCount { get; set; }
        public int AssignedCount { get; set; }
        public int AssignedNullCount { get; set; }
    }

    public class HeadCourseAssignmentLecturerDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
    }

    public class HeadCourseAssignmentStudentDto
    {
        public long Id { get; set; }
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public string CourseCode { get; set; }
        public string LecturerName { get; set; }
    }

    public class HeadCourseAssignmentRequest
    {
        public long StudentId { get; set; }
        public string LecturerName { get; set; }
    }
}