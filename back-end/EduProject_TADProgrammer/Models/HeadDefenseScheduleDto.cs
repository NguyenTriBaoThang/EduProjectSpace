using System;
using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Models
{
    public class HeadDefenseScheduleDto
    {
        public long? Id { get; set; }
        public string ProjectId { get; set; }
        public string GroupName { get; set; }
        public string Members { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Council { get; set; }
    }

   

    public class HeadCourseDefenseDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string ClassId { get; set; }
        public int GroupCount { get; set; }
        public int ScheduledCount { get; set; }
    }

    public class CreateDefenseScheduleDto
    {
        [Required(ErrorMessage = "ProjectId is required")]
        public long ProjectId { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Room is required")]
        [StringLength(50, ErrorMessage = "Room cannot exceed 50 characters")]
        public string Room { get; set; }

        [StringLength(50, ErrorMessage = "MeetingId cannot exceed 50 characters")]
        public long MeetingId { get; set; }
    }

    /// <summary>
    /// DTO để lấy danh sách dự án
    /// </summary>
    public class ProjectDto
    {
        public long Id { get; set; }
        public string ProjectCode { get; set; }
        public string Name { get; set; }
        public string Members { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// DTO để lấy danh sách meeting
    /// </summary>
    public class MeetingDto
    {
        public long MeetingId { get; set; }
        public string Link { get; set; }
    }
}