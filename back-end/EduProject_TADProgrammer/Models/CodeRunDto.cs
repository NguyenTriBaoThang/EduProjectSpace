// File: Core/Models/CodeRunDto.cs
// Mục đích: Truyền dữ liệu kết quả kiểm tra hoặc chạy mã nguồn giữa API và frontend.
// Chức năng hỗ trợ: 
//   44: Sinh viên - Kiểm tra mã nguồn
//   57: Hỗ trợ lập trình
//   65: Kiểm tra và chạy mã nguồn tự động
namespace EduProject_TADProgrammer.Models
{
    public class CodeRunDto
    {
        public long Id { get; set; }
        public long SubmissionId { get; set; }
        public string Code { get; set; }
        public string Language { get; set; } //Java, Python, CSharp, CPlusPlus, JavaScript, Ruby, Go, TypeScript, PHP
        public string Status { get; set; } //Pending, Success, Failed, Timeout
        public string Result { get; set; }
        public string ErrorMessage { get; set; }
        public float? PlagiarismScore { get; set; }
        public float? ExecutionTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}