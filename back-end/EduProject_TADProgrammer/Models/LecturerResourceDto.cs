namespace EduProject_TADProgrammer.Models
{
    public class LecturerResourceDto
    {
    }

    public class CourseResourceDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; } // Đổi từ ClassId thành FacultyCode
        public int ProjectCount { get; set; }
        public int ResourceCount { get; set; }
    }

    public class ResourceDto
    {
        public long Id { get; set; }
        public string ProjectId { get; set; }
        public string GroupName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }

    public class AddResourceDto
    {
        public string ProjectId { get; set; }
        public long GroupId { get; set; }
        public string FacultyCode { get; set; } // Đổi từ ClassId thành FacultyCode
        public string Title { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }

    public class UpdateResourceDto
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }

    public class GenerateSuggestionDto
    {
        public string ProjectId { get; set; }
        public string Keywords { get; set; }
    }

    public class AISuggestionDto
    {
        public long Id { get; set; }
        public string ProjectId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}