using System;

namespace EduProject_TADProgrammer.Models
{
    public class HeadDefenseScheduleDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string GroupName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
        public long? MeetingId { get; set; }
        public string MeetingLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateHeadDefenseScheduleDto
    {
        public long ProjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
    }

    public class UpdateHeadDefenseScheduleDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Room { get; set; }
    }
}