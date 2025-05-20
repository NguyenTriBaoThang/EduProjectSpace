// LecturerDTO.cs
// Purpose: Defines the data transfer object to return lecturer details to the frontend.
namespace EduProject_TADProgrammer.Models
{
    public class HeadLecturerDto
    {
        public string Lecturer { get; set; } // Full name of the lecturer
        public string CourseCode { get; set; } // Course code associated with the lecturer
        public string SemesterName { get; set; } // Semester name
        public string ClassCode { get; set; } // Class code of students
        public int StudentCount { get; set; } // Number of students under the lecturer
        public int GroupCount { get; set; } // Number of groups under the lecturer
    }

    public class HeadLecturerGroupDetailDto
    {
        public int Index { get; set; } // Row number in the table
        public string StudentIds { get; set; } // Comma-separated student IDs
        public string StudentNames { get; set; } // Comma-separated student names
        public string GroupName { get; set; } // Name of the group
        public string ProjectName { get; set; } // Name of the project
    }

    public class HeadLecturerGroupDetailsDto
    {
        // Tên giảng viên hướng dẫn
        public string LecturerName { get; set; }

        // Thông tin môn học (mã môn, tên môn, lớp, kỳ học)
        public string CourseInfo { get; set; }

        // Tên nhóm
        public string GroupName { get; set; }

        // Danh sách thành viên nhóm (mã SV và tên SV)
        public List<HeadLecturerMemberGroupDetailDto> Members { get; set; }

        // Tên đồ án
        public string ProjectName { get; set; }

        // Thời gian bắt đầu đồ án
        public string StartDate { get; set; }

        // Thời gian kết thúc đồ án
        public string EndDate { get; set; }

        // Thời gian chấm điểm
        public string GradingDate { get; set; }

        // Mô tả đề tài
        public string Description { get; set; }

        // Danh sách file mô tả đề tài
        public List<string> FileUrls { get; set; }
    }

    // DTO cho thông tin thành viên nhóm
    public class HeadLecturerMemberGroupDetailDto
    {
        public string StudentId { get; set; } // Mã sinh viên
        public string StudentName { get; set; } // Tên sinh viên
    }
}
