// File: Entities/CodeRun.cs
// Mục đích: Định nghĩa entity CodeRun để lưu trữ kết quả kiểm tra hoặc chạy mã nguồn, hỗ trợ kiểm tra tự động và lập trình.
// Hỗ trợ chức năng:
//   44: Sinh viên - Kiểm tra mã nguồn
//   57: Hỗ trợ lập trình
//   65: Kiểm tra và chạy mã nguồn tự động

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class CodeRun
    {
        // Khóa chính của bản ghi chạy mã nguồn
        [Key]
        public long Id { get; set; }

        // ID của bài nộp liên quan (bắt buộc)
        [Required]
        public long SubmissionId { get; set; }

        // Liên kết với entity Submission (bài nộp chứa mã nguồn)
        [ForeignKey("SubmissionId")]
        public Submission Submission { get; set; }

        // Mã nguồn được chạy (bắt buộc)
        [Required]
        public string Code { get; set; }

        // Ngôn ngữ lập trình (bắt buộc, sử dụng enum ProgrammingLanguage)
        [Required]
        public string Language { get; set; } //Java, Python, JavaScript, Ruby, TypeScript

        // Trạng thái thực thi (bắt buộc, sử dụng enum RunStatus)
        [Required]
        public string Status { get; set; } //Pending, Success, Failed, Timeout

        // Kết quả thực thi (tùy chọn, chứa đầu ra hoặc thông tin chi tiết)
        public string Result { get; set; }

        // Thông báo lỗi nếu thực thi thất bại (tùy chọn)
        public string? ErrorMessage { get; set; }

        // Điểm đạo văn (tùy chọn, từ 0 đến 100)
        [Range(0, 100, ErrorMessage = "PlagiarismScore must be between 0 and 100")]
        public float? PlagiarismScore { get; set; }

        // Thời gian thực thi (tùy chọn, tính bằng mili giây)
        public float? ExecutionTime { get; set; }

        // Thời gian tạo bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Thời gian cập nhật bản ghi (mặc định là thời gian hiện tại theo UTC)
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}