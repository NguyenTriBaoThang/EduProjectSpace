// File: Entities/Submission.cs
// Mục đích: Định nghĩa entity Submission để lưu trữ bài nộp của nhóm (báo cáo, mã nguồn).
// Hỗ trợ chức năng:
//   7: Quản lý quy trình đồ án
//   10: Nộp bài và gia hạn
//   11: Kiểm tra tài liệu nộp bài
//   32: Giảng viên - Kiểm tra tính hợp lệ bài nộp
//   59: Quản lý phiên bản tài liệu
//   65: Kiểm tra và chạy mã nguồn tự động
//   69: Hỗ trợ phân loại tài liệu
//   88: Theo dõi tiến độ nộp tài liệu

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduProject_TADProgrammer.Entities
{
    public class Submission
    {
        // Khóa chính của bản ghi bài nộp
        [Key]
        public long Id { get; set; }

        // ID của đề tài liên quan (bắt buộc)
        [Required]
        public long ProjectId { get; set; }

        // Liên kết với entity Project (đề tài liên quan đến bài nộp)
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        // ID của nhóm nộp bài (bắt buộc)
        [Required]
        public long GroupId { get; set; }

        // Liên kết với entity Group (nhóm nộp bài)
        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        // Đường dẫn đến file bài nộp (bắt buộc, tối đa 255 ký tự)
        [Required]
        [StringLength(255)]
        public string FilePath { get; set; }

        // Số phiên bản của bài nộp (bắt buộc, ví dụ: 1, 2, 3...)
        [Required]
        public int Version { get; set; }

        // Trạng thái của bài nộp (bắt buộc, giá trị: "Submitted", "Validated", "Rejected")
        [Required]
        public string Status { get; set; }

        // Thời gian nộp bài (mặc định là thời gian hiện tại theo UTC)
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        // Danh sách các phiên bản của bài nộp
        public virtual ICollection<SubmissionVersion> SubmissionVersions { get; set; } = new List<SubmissionVersion>();

        // Danh sách kết quả chạy mã nguồn tự động
        public virtual ICollection<CodeRun> CodeRuns { get; set; } = new List<CodeRun>();

        // Danh sách phản hồi từ giảng viên hoặc hệ thống
        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}