// File: Models/AdminDefenseCommitteesDto.cs
// Mục đích: Định nghĩa các DTO để truyền dữ liệu danh sách giảng viên trong hội đồng chấm điểm giữa API và frontend.
// Hỗ trợ chức năng:
//   Quản lý hội đồng chấm điểm (tạo, cập nhật, xem danh sách hội đồng và thành viên).

using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    // DTO để truyền thông tin hội đồng chấm điểm
    public class AdminDefenseCommitteesDto
    {
        // ID của hội đồng chấm điểm
        public long Id { get; set; }

        // Tên hội đồng (ví dụ: "Hội đồng bảo vệ đồ án kỳ 1 2023-2024")
        public string Name { get; set; }

        // ID của kỳ học liên quan
        public long SemesterId { get; set; }

        // Tên kỳ học (ví dụ: "HK1_2023-2024")
        public string SemesterName { get; set; }

        // Danh sách thành viên của hội đồng
        public List<AdminDefenseCommitteesMemberDto> Members { get; set; } = new List<AdminDefenseCommitteesMemberDto>();
    }

    // DTO để truyền thông tin thành viên trong hội đồng chấm điểm
    public class AdminDefenseCommitteesMemberDto
    {
        // ID của giảng viên
        public long LecturerId { get; set; }

        // Họ và tên đầy đủ của giảng viên
        public string FullName { get; set; }

        // Vai trò trong hội đồng (ví dụ: "Chủ tịch", "Thư ký", "Thành viên")
        public string Role { get; set; }
    }

    // DTO để yêu cầu tạo mới hội đồng chấm điểm
    public class CreateAdminDefenseCommitteeRequest
    {
        // Tên hội đồng (bắt buộc)
        public string Name { get; set; }

        // ID của kỳ học liên quan (bắt buộc)
        public long SemesterId { get; set; }

        // Danh sách thành viên của hội đồng
        public List<AdminDefenseCommitteesMembersRequest> Members { get; set; } = new List<AdminDefenseCommitteesMembersRequest>();
    }

    // DTO để yêu cầu cập nhật hội đồng chấm điểm
    public class UpdateAdminDefenseCommitteeRequest
    {
        // Tên hội đồng (bắt buộc)
        public string Name { get; set; }

        // ID của kỳ học liên quan (bắt buộc)
        public long SemesterId { get; set; }

        // Danh sách thành viên của hội đồng
        public List<AdminDefenseCommitteesMembersRequest> Members { get; set; } = new List<AdminDefenseCommitteesMembersRequest>();
    }

    // DTO để truyền thông tin thành viên trong yêu cầu tạo/cập nhật hội đồng
    public class AdminDefenseCommitteesMembersRequest
    {
        // ID của giảng viên (bắt buộc)
        public long LecturerId { get; set; }

        // Vai trò trong hội đồng (bắt buộc, ví dụ: "Chủ tịch", "Thư ký", "Thành viên")
        public string Role { get; set; }
    }
}