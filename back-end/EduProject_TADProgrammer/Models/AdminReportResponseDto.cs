namespace EduProject_TADProgrammer.Models
{
    public class SemesterAdminReportDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentAdminReportDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class StudentAdminReportDto
    {
        public long Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string ClassCode { get; set; }
        public string FacultyCode { get; set; }
        public string SemesterCode { get; set; }
    }

    public class ProjectAdminReportDto
    {
        public long Id { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string StudentName { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; }
        public string SemesterCode { get; set; }
        public string FacultyCode { get; set; }
        public string FacultyName { get; set; }
    }

    public class LecturerAdminReportDto
    {
        public long Id { get; set; }
        public string LecturerId { get; set; }
        public string Name { get; set; }
        public string FacultyCode { get; set; }
    }

    public class AdminReportSummaryDto
    {
        public int StudentCount { get; set; }
        public int ApprovedProjects { get; set; }
        public int PendingProjects { get; set; }
        public int LecturerCount { get; set; }
    }

    public class AdminReportResponseDto
    {
        public AdminReportSummaryDto Summary { get; set; }
        public List<StudentAdminReportDto> Students { get; set; }
        public List<ProjectAdminReportDto> Projects { get; set; }
        public List<LecturerAdminReportDto> Lecturers { get; set; }
    }
}