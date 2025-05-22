// File: Models/ImportResult.cs
// Mục đích: Định nghĩa DTO để trả về kết quả của quá trình nhập dữ liệu (import) từ API đến frontend.
// Hỗ trợ chức năng:
//   Báo cáo kết quả nhập dữ liệu (thành công, thất bại, và lỗi chi tiết).

using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin kết quả nhập dữ liệu
    public class ImportResult
    {
        // Số lượng bản ghi nhập thành công
        public int SuccessCount { get; set; }

        // Số lượng bản ghi nhập thất bại
        public int FailedCount { get; set; }

        // Danh sách thông báo lỗi (mỗi chuỗi mô tả một lỗi cụ thể, ví dụ: "Dòng 5: Email không hợp lệ")
        public List<string> Errors { get; set; }
    }
}