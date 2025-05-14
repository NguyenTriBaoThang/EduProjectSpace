using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class StudentCourse
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [Required]
        public long CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}