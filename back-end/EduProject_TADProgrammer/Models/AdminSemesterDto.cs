// File: Core/Models/SemesterDto.cs
namespace EduProject_TADProgrammer.Models
{
    public class AdminSemesterDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Calculated: "Hoạt động" or "Kết thúc"
        public DateTime CreatedAt { get; set; }
        public string ?Description { get; set; }
    }

    public class CreateAdminSemesterRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateAdminSemesterRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
    }
}