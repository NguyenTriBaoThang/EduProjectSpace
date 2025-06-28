using System.ComponentModel.DataAnnotations;

namespace EduProject_TADProgrammer.Models
{
    public class LecturerReviewDto
    {
    }

    public class CourseLecturerReviewDto
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string FacultyCode { get; set; }
        public int ProjectCount { get; set; }
        public int ReviewedCount { get; set; }
    }

    public class ProjectLecturerReviewListDto
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
        public int MemberCount { get; set; }
        public string Status { get; set; }
        public bool IsFullyReviewed { get; set; }
    }

    public class ProjectLecturerReviewDto
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string CourseId { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
        public string GroupMembers { get; set; }
        public string Status { get; set; }
        public bool IsFullyReviewed { get; set; }
        public List<StudentGradeLecturerReviewDto> StudentGrades { get; set; } = new List<StudentGradeLecturerReviewDto>();
        public List<TaskLecturerReviewDto> Tasks { get; set; } = new List<TaskLecturerReviewDto>(); // Added
    }

    public class TaskLecturerReviewDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public List<SubmissionLecturerReviewDto> Submissions { get; set; } = new List<SubmissionLecturerReviewDto>();
    }

    public class SubmissionLecturerReviewDto
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string SubmittedById { get; set; }
        public string FullName { get; set; }
        public string Feedback { get; set; }
        public float? Score { get; set; }
    }

    public class StudentGradeLecturerReviewDto
    {
        public long StudentId { get; set; }
        public string FullName { get; set; }
        public List<CriteriaGradeLecturerReviewDto> CriteriaGrades { get; set; } = new List<CriteriaGradeLecturerReviewDto>();
        public bool HasPendingAppeal { get; set; }
        public decimal? TotalScore { get; set; }
    }

    public class CriteriaGradeLecturerReviewDto
    {
        public long CriteriaId { get; set; }
        public string CriteriaName { get; set; }
        public decimal? Score { get; set; }
        public float Weight { get; set; }
    }

    public class SaveGradesLecturerReviewDto
    {
        public List<StudentGradeInputLecturerReviewDto> StudentGrades { get; set; } = new List<StudentGradeInputLecturerReviewDto>();
    }

    public class StudentGradeInputLecturerReviewDto
    {
        [Required]
        public long StudentId { get; set; }
        public List<CriteriaGradeInputLecturerReviewDto> CriteriaGrades { get; set; } = new List<CriteriaGradeInputLecturerReviewDto>();
        public string Comment { get; set; }
    }

    public class CriteriaGradeInputLecturerReviewDto
    {
        [Required]
        public long CriteriaId { get; set; }
        [Range(0, 10)]
        public decimal Score { get; set; }
    }
}