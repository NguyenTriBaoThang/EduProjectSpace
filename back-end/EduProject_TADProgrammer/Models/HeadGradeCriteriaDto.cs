using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Models
{
    public class HeadGradeCriteriaDto
    {
        public long Id { get; set; }
        [Required] public long CourseId { get; set; }
        public string CourseName { get; set; }
        public long DepartmentId { get; set; }
        public string FacultyCode { get; set; }
        [Required, StringLength(100)] public string Name { get; set; }
        [Required, Range(0, 1)] public float Weight { get; set; }
        [StringLength(500)] public string Description { get; set; }
    }
}