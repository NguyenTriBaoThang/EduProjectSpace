using System;
using System.Collections.Generic;

namespace EduProject_TADProgrammer.Models
{
    public class LecturerDashboardDto
    {
        public int ProjectCount { get; set; } // Tổng số đề tài giảng viên hướng dẫn
        public int ApprovedProjects { get; set; } // Số đề tài đã duyệt
        public int PendingProjects { get; set; } // Số đề tài chờ duyệt
        public int NotificationCount { get; set; } // Số thông báo mới
        public List<NotificationDto> Notifications { get; set; } // Danh sách thông báo
    }
}