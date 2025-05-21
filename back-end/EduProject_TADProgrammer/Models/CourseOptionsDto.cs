// File: Models/CourseOptionsDto.cs
// Mục đích: Định nghĩa DTO để trả về danh sách môn học, học kỳ, và lớp học cho frontend.
// Hỗ trợ chức năng:
//   Cung cấp tùy chọn môn học, học kỳ, và lớp học để hiển thị trên giao diện người dùng (ví dụ: dropdown, form lọc).

using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO chính để truyền danh sách môn học, học kỳ, và lớp học
    public class CourseOptionsDto
    {
        // Danh sách các môn học
        public List<CourseOption> Courses { get; set; }

        // Danh sách các học kỳ
        public List<SemesterOption> Semesters { get; set; }

        // Danh sách các mã lớp học
        public List<string> Classes { get; set; }
    }

    // DTO để truyền thông tin một môn học
    public class CourseOption
    {
        // Mã môn học (ví dụ: "CS101")
        public string Code { get; set; }

        // Tên môn học (ví dụ: "Lập trình cơ bản")
        public string Name { get; set; }
    }

    // DTO để truyền thông tin một học kỳ
    public class SemesterOption
    {
        // Tên học kỳ (ví dụ: "HK1_2023-2024")
        public string Name { get; set; }
    }
}