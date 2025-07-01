namespace EduProject_TADProgrammer.Models
{
    // DTO cho thông tin tổng quan dashboard
    public class StudentDashboardDto
    {
        public int TotalSubmissions { get; set; }
        public Dictionary<string, int> SubmissionByProject { get; set; }
        public Dictionary<string, int> ProgressByProject { get; set; }
        public int PendingTasks { get; set; }
        public int UnreadNotifications { get; set; }
        public bool HasTodoProposal { get; set; } // Thêm thuộc tính mới
    }

    // DTO cho thông báo
    public class NotificationStudentDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FullText { get; set; }
        public DateTime Date { get; set; }
    }

    // DTO cho công việc
    public class TaskStudentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
    }

    // DTO cho sự kiện lịch
    public class CalendarStudentDto
    {
        public long Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartTime { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}