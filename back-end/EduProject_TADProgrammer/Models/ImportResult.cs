namespace EduProject_TADProgrammer.Models
{
    public class ImportResult
    {
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public List<string> Errors { get; set; }
    }
}