namespace EduProject_TADProgrammer.Models
{
    public class StudentCourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public string Status { get; set; }
        public int Progress { get; set; }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
