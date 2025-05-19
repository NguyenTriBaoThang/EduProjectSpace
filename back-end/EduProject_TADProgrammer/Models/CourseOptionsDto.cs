// File: Models/CourseOptionsDto.cs
// Mục đích: Định nghĩa DTO để trả về danh sách môn học, học kỳ, và lớp cho frontend
namespace EduProject_TADProgrammer.Models
{
    public class CourseOptionsDto
    {
        public List<CourseOption> Courses { get; set; }
        public List<SemesterOption> Semesters { get; set; }
        public List<string> Classes { get; set; }
    }

    public class CourseOption
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class SemesterOption
    {
        public string Name { get; set; }
    }
}