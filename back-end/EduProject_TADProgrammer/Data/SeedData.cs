using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Entities;
using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EduProject_TADProgrammer.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Mật khẩu mẫu đã mã hóa (password123)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123");

            // 1. Role
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "ROLE_ADMIN", Description = "Quản trị viên" },
                new Role { Id = 2, Name = "ROLE_LECTURER_GUIDE", Description = "Giảng viên hướng dẫn" },
                new Role { Id = 3, Name = "ROLE_STUDENT", Description = "Sinh viên" },
                new Role { Id = 4, Name = "ROLE_HEAD", Description = "Trưởng bộ môn" },
                new Role { Id = 5, Name = "ROLE_LECTURER_REVIEW", Description = "Giảng viên phản biện" }
            );

            // 2. User
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = hashedPassword, Email = "admin@hutech.edu.vn", FullName = "Quản trị viên", RoleId = 1, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 2, Username = "AND123456789", Password = hashedPassword, Email = "AND123456789@hutech.edu.vn", FullName = "Nguyễn Đình Ánh", DepartmentId = 1, RoleId = 4, ClassCode = null, AvatarUrl = "/font-end/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 3, Username = "HVT123456789", Password = hashedPassword, Email = "HVT123456789@hutech.edu.vn", FullName = "Văn Thiên Hoàng", DepartmentId = 2, RoleId = 4, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 4, Username = "CNH123456789", Password = hashedPassword, Email = "CNH123456789@hutech.edu.vn", FullName = "Nguyễn Huy Cường", RoleId = 2, CourseId = 1, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 5, Username = "TNT123456789", Password = hashedPassword, Email = "TNT123456789@hutech.edu.vn", FullName = "Nguyễn Thanh Tùng", RoleId = 2, CourseId = 2, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 6, Username = "KBP123456789", Password = hashedPassword, Email = "KBP123456789@hutech.edu.vn", FullName = "Bùi Phú Khuyên", RoleId = 2, CourseId = 3, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 7, Username = "2180601452", Password = hashedPassword, Email = "2180601452@hutech.edu.vn", FullName = "Nguyễn Tri Bão Thắng", DepartmentId = 1, RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 8, Username = "2180600307", Password = hashedPassword, Email = "2180600307@hutech.edu.vn", FullName = "Huỳnh Thành Đô", DepartmentId = 1, RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 9, Username = "1911256118", Password = hashedPassword, Email = "1911256118@hutech.edu.vn", FullName = "Nguyễn Thuận An", DepartmentId = 1, RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 10, Username = "2180603746", Password = hashedPassword, Email = "2180603746@hutech.edu.vn", FullName = "Võ Thành Trung", DepartmentId = 2, RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 11, Username = "2180603747", Password = hashedPassword, Email = "2180603747@hutech.edu.vn", FullName = "Lê Quang Vinh", DepartmentId = 3, RoleId = 3, ClassCode = "21DTHA1", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 12, Username = "2180603748", Password = hashedPassword, Email = "2180603748@hutech.edu.vn", FullName = "Trần Quang Tài", DepartmentId = 3, RoleId = 3, ClassCode = "21DTHA2", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 13, Username = "2180603749", Password = hashedPassword, Email = "2180603749@hutech.edu.vn", FullName = "Trần Văn Tuệ", DepartmentId = 3, RoleId = 3, ClassCode = "21DTHA2", AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 14, Username = "TDTT123456789", Password = hashedPassword, Email = "TDTT123456789@hutech.edu.vn", FullName = "Đặng Thị Thạch Thảo", DepartmentId = 2, RoleId = 2, CourseId = 4, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 15, Username = "CHM123456789", Password = hashedPassword, Email = "CHM123456789@hutech.edu.vn", FullName = "Hàn Minh Châu", DepartmentId = 3, RoleId = 2, CourseId = 5, ClassCode = null, AvatarUrl = "/static/medit/imgUser/avatar.jpg", FailedLoginAttempts = 0, Locked = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 3. Course
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Đồ án Tốt nghiệp CNPM", SemesterId = 1, DepartmentId = 1,StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CourseCode = "CNTT_TN_2025", DefenseDate = new DateTime(2025, 6, 15), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 2, Name = "Đồ án Cơ sở CNPM", SemesterId = 1, DepartmentId = 1, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CourseCode = "CNTT_CS_2025", DefenseDate = new DateTime(2025, 6, 10), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 3, Name = "Đồ án Tốt nghiệp KTPM", SemesterId = 1, DepartmentId = 1, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CourseCode = "KTPM_TN_2025", DefenseDate = new DateTime(2025, 6, 15), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 4, Name = "Đồ án Cơ sở KTPM", SemesterId = 1, DepartmentId = 1, StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CourseCode = "KTPM_CS_2025", DefenseDate = new DateTime(2025, 6, 10), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 5, Name = "Đồ án Tốt nghiệp ATTT", SemesterId = 2, DepartmentId = 2, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 4, 30), CourseCode = "ATTT_TN_2025", DefenseDate = new DateTime(2025, 4, 20), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 6, Name = "Đồ án Cơ sở ATTT", SemesterId = 2, DepartmentId = 2, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 4, 30), CourseCode = "ATTT_CS_2025", DefenseDate = new DateTime(2025, 4, 15), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 7, Name = "Đồ án Tốt nghiệp KHMT", SemesterId = 2, DepartmentId = 1, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 4, 30), CourseCode = "KHMT_TN_2025", DefenseDate = new DateTime(2025, 4, 20), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 8, Name = "Đồ án Cơ sở KHMT", SemesterId = 2, DepartmentId = 1, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 4, 30), CourseCode = "KHMT_CS_2025", DefenseDate = new DateTime(2025, 4, 15), Status = "OPEN", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 9, Name = "Đồ án Tốt nghiệp HTTT", SemesterId = 3, DepartmentId = 1, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 10, 31), CourseCode = "HTTT_TN_2025", DefenseDate = new DateTime(2025, 10, 20), Status = "PLANNED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 10, Name = "Đồ án Cơ sở HTTT", SemesterId = 3, DepartmentId = 1, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 10, 31), CourseCode = "HTTT_CS_2025", DefenseDate = new DateTime(2025, 10, 15), Status = "PLANNED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 11, Name = "Đồ án Tốt nghiệp TTNT", SemesterId = 3, DepartmentId = 1, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 10, 31), CourseCode = "CNPM_TN_2025", DefenseDate = new DateTime(2025, 10, 20), Status = "PLANNED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Course { Id = 12, Name = "Đồ án Cơ sở TTNT", SemesterId = 3, DepartmentId = 1, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 10, 31), CourseCode = "CNPM_CS_2025", DefenseDate = new DateTime(2025, 10, 15), Status = "PLANNED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 4. Project
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Title = "Ứng dụng AI trong y tế", Description = "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", CourseId = 1, GroupId = 1, Status = "NOT_SUBMITTED", ProjectCode = "AI_YTE_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 2, Title = "Hệ thống quản lý đồ án", Description = "Xây dựng hệ thống quản lý đồ án sinh viên.", CourseId = 1, GroupId = 2, Status = "NOT_SUBMITTED", ProjectCode = "QLDA_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 3, Title = "Ứng dụng thương mại điện tử", Description = "Phát triển website bán hàng trực tuyến.", CourseId = 2,  GroupId = 3, Status = "NOT_SUBMITTED", ProjectCode = "TMĐT_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 4, Title = "Phân tích dữ liệu thời gian thực", Description = "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", CourseId = 3, GroupId = 4, Status = "SUBMITTED", ProjectCode = "PTDL_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 5, Title = "Ứng dụng quản lý học tập", Description = "Phát triển app quản lý học tập cho sinh viên.", CourseId = 4, GroupId = 5, Status = "SUBMITTED", ProjectCode = "QLHT_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 6, Title = "Hệ thống bảo mật IoT", Description = "Xây dựng giải pháp bảo mật cho thiết bị IoT.", CourseId = 5, GroupId = 6, Status = "SUBMITTED", ProjectCode = "BM_IOT_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 7, Title = "Phân tích dữ liệu mạng xã hội", Description = "Phân tích hành vi người dùng trên mạng xã hội.", CourseId = 6, GroupId = 7, Status = "SUBMITTED", ProjectCode = "PTMXH_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 8, Title = "Ứng dụng học ngoại ngữ", Description = "Phát triển app học ngoại ngữ với AI.", CourseId = 7, GroupId = 9, Status = "GRADED", ProjectCode = "HNN_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 9, Title = "Hệ thống quản lý kho", Description = "Xây dựng hệ thống quản lý kho hàng tự động.", CourseId = 8, GroupId = 8, Status = "GRADED", ProjectCode = "QLK_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 10, Title = "Ứng dụng đặt lịch khám bệnh", Description = "Phát triển app đặt lịch khám bệnh trực tuyến.", CourseId = 9, GroupId = 10, Status = "GRADED", ProjectCode = "DLKB_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 11, Title = "Hệ thống quản lý nhân sự", Description = "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", CourseId = 10, GroupId = 12, Status = "GRADED", ProjectCode = "QLNS_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 12, Title = "Ứng dụng học tập nhóm", Description = "Phát triển app hỗ trợ học tập nhóm.", CourseId = 11, GroupId = 11, Status = "PENDING", ProjectCode = "HTN_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Project { Id = 13, Title = "Hệ thống phân tích tài chính", Description = "Xây dựng hệ thống phân tích tài chính cá nhân.", CourseId = 12, GroupId = 13, Status = "PENDING", ProjectCode = "PTTC_2025_01", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 5. ProjectVersion
            modelBuilder.Entity<ProjectVersion>().HasData(
                new ProjectVersion { Id = 1, ProjectId = 1, Title = "Ứng dụng AI trong y tế", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 2, ProjectId = 1, Title = "Ứng dụng AI trong y tế (Cập nhật)", Description = "Cập nhật mô tả.", VersionNumber = 2, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new ProjectVersion { Id = 3, ProjectId = 2, Title = "Hệ thống quản lý đồ án", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 4, ProjectId = 3, Title = "Ứng dụng thương mại điện tử", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 5, ProjectId = 4, Title = "Phân tích dữ liệu thời gian thực", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 6, ProjectId = 5, Title = "Ứng dụng quản lý học tập", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 7, ProjectId = 6, Title = "Hệ thống bảo mật IoT", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 8, ProjectId = 7, Title = "Phân tích dữ liệu mạng xã hội", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 9, ProjectId = 8, Title = "Ứng dụng học ngoại ngữ", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 10, ProjectId = 9, Title = "Hệ thống quản lý kho", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 11, ProjectId = 10, Title = "Ứng dụng đặt lịch khám bệnh", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new ProjectVersion { Id = 12, ProjectId = 11, Title = "Hệ thống quản lý nhân sự", Description = "Phiên bản ban đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow }
            );

            // 6. Group
            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = "Nhóm 1", ProjectId = 1, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 2, Name = "Nhóm 2", ProjectId = 2, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 3, Name = "Nhóm 3", ProjectId = 3, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 4, Name = "Nhóm 4", ProjectId = 4, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 5, Name = "Nhóm 5", ProjectId = 5, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 6, Name = "Nhóm 6", ProjectId = 6, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 7, Name = "Nhóm 7", ProjectId = 7, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 8, Name = "Nhóm 8", ProjectId = 8, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 9, Name = "Nhóm 9", ProjectId = 9, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 10, Name = "Nhóm 10", ProjectId = 10, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 11, Name = "Nhóm 11", ProjectId = 11, MaxMembers = 5, Status = "APPROVED", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 12, Name = "Nhóm 12", ProjectId = 12, MaxMembers = 5, Status = "PENDING", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Group { Id = 13, Name = "Nhóm 13", ProjectId = 13, MaxMembers = 5, Status = "PENDING", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 7. GroupMember
            modelBuilder.Entity<GroupMember>().HasData(
                new GroupMember { Id = 1, GroupId = 1, StudentId = 7, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 2, GroupId = 1, StudentId = 8, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 3, GroupId = 2, StudentId = 9, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 4, GroupId = 3, StudentId = 10, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 5, GroupId = 3, StudentId = 11, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 6, GroupId = 4, StudentId = 12, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 7, GroupId = 4, StudentId = 13, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 8, GroupId = 5, StudentId = 7, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 9, GroupId = 6, StudentId = 8, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 10, GroupId = 7, StudentId = 9, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 11, GroupId = 8, StudentId = 10, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 12, GroupId = 9, StudentId = 11, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 13, GroupId = 10, StudentId = 12, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 14, GroupId = 11, StudentId = 13, JoinedAt = DateTime.UtcNow },
                new GroupMember { Id = 15, GroupId = 12, StudentId = 7, JoinedAt = DateTime.UtcNow }
            );

            // 8. GroupRequest
            modelBuilder.Entity<GroupRequest>().HasData(
                new GroupRequest { Id = 1, GroupId = 1, StudentId = 9, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 2, GroupId = 2, StudentId = 10, Status = "APPROVED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 3, GroupId = 3, StudentId = 12, Status = "REJECTED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 4, GroupId = 4, StudentId = 13, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 5, GroupId = 5, StudentId = 7, Status = "APPROVED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 6, GroupId = 6, StudentId = 8, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 7, GroupId = 7, StudentId = 9, Status = "APPROVED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 8, GroupId = 8, StudentId = 10, Status = "REJECTED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 9, GroupId = 9, StudentId = 11, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 10, GroupId = 10, StudentId = 12, Status = "APPROVED", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 11, GroupId = 11, StudentId = 13, Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GroupRequest { Id = 12, GroupId = 12, StudentId = 7, Status = "REJECTED", CreatedAt = DateTime.UtcNow }
            );

            // 9. Task
            modelBuilder.Entity<Entities.Task>().HasData(
                new Entities.Task { Id = 1, ProjectId = 1, GroupId = 1, Title = "Phân tích yêu cầu", Description = "Phân tích yêu cầu hệ thống AI.", Deadline = new DateTime(2025, 2, 15), Status = "TODO", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 2, ProjectId = 2, StudentId = 9, Title = "Thiết kế giao diện", Description = "Thiết kế giao diện quản lý đồ án.", Deadline = new DateTime(2025, 2, 20), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 3, ProjectId = 3, GroupId = 3, Title = "Xây dựng cơ sở dữ liệu", Description = "Thiết kế và triển khai CSDL.", Deadline = new DateTime(2025, 2, 25), Status = "DONE", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 4, ProjectId = 4, StudentId = 12, Title = "Tích hợp API", Description = "Tích hợp API phân tích dữ liệu.", Deadline = new DateTime(2025, 2, 28), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 5, ProjectId = 5, GroupId = 5, Title = "Phát triển tính năng", Description = "Phát triển tính năng quản lý lịch học.", Deadline = new DateTime(2025, 3, 1), Status = "TODO", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 6, ProjectId = 6, StudentId = 8, Title = "Kiểm tra bảo mật", Description = "Kiểm tra lỗ hổng bảo mật IoT.", Deadline = new DateTime(2025, 3, 5), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 7, ProjectId = 7, GroupId = 7, Title = "Thu thập dữ liệu", Description = "Thu thập dữ liệu từ mạng xã hội.", Deadline = new DateTime(2025, 3, 10), Status = "DONE", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 8, ProjectId = 8, StudentId = 10, Title = "Tích hợp AI", Description = "Tích hợp AI vào app học ngoại ngữ.", Deadline = new DateTime(2025, 3, 15), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 9, ProjectId = 9, GroupId = 9, Title = "Thiết kế hệ thống", Description = "Thiết kế hệ thống quản lý kho.", Deadline = new DateTime(2025, 3, 20), Status = "TODO", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 10, ProjectId = 10, StudentId = 12, Title = "Phát triển giao diện", Description = "Phát triển giao diện đặt lịch khám.", Deadline = new DateTime(2025, 3, 25), Status = "IN_PROGRESS", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 11, ProjectId = 11, GroupId = 11, Title = "Kiểm tra chức năng", Description = "Kiểm tra chức năng quản lý nhân sự.", Deadline = new DateTime(2025, 3, 30), Status = "DONE", CreatedAt = DateTime.UtcNow },
                new Entities.Task { Id = 12, ProjectId = 12, StudentId = 13, Title = "Tích hợp chat", Description = "Tích hợp tính năng chat nhóm.", Deadline = new DateTime(2025, 4, 1), Status = "TODO", CreatedAt = DateTime.UtcNow }
            );

            // 10. Submission
            modelBuilder.Entity<Submission>().HasData(
                new Submission { Id = 1, ProjectId = 1, GroupId = 1, FilePath = "submissions/dt001.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 2, ProjectId = 2, GroupId = 2, FilePath = "submissions/dt002.pdf", Version = 1, Status = "VALIDATED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 3, ProjectId = 3, GroupId = 3, FilePath = "submissions/dt003.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 4, ProjectId = 4, GroupId = 4, FilePath = "submissions/dt004.pdf", Version = 1, Status = "REJECTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 5, ProjectId = 5, GroupId = 5, FilePath = "submissions/dt005.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 6, ProjectId = 6, GroupId = 6, FilePath = "submissions/dt006.pdf", Version = 1, Status = "VALIDATED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 7, ProjectId = 7, GroupId = 7, FilePath = "submissions/dt007.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 8, ProjectId = 8, GroupId = 8, FilePath = "submissions/dt008.pdf", Version = 1, Status = "REJECTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 9, ProjectId = 9, GroupId = 9, FilePath = "submissions/dt009.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 10, ProjectId = 10, GroupId = 10, FilePath = "submissions/dt010.pdf", Version = 1, Status = "VALIDATED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 11, ProjectId = 11, GroupId = 11, FilePath = "submissions/dt011.pdf", Version = 1, Status = "SUBMITTED", SubmittedAt = DateTime.UtcNow },
                new Submission { Id = 12, ProjectId = 12, GroupId = 12, FilePath = "submissions/dt012.pdf", Version = 1, Status = "REJECTED", SubmittedAt = DateTime.UtcNow }
            );

            // 11. SubmissionVersion
            modelBuilder.Entity<SubmissionVersion>().HasData(
                new SubmissionVersion { Id = 1, SubmissionId = 1, FilePath = "submissions/dt001_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 2, SubmissionId = 1, FilePath = "submissions/dt001_v2.pdf", VersionNumber = 2, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new SubmissionVersion { Id = 3, SubmissionId = 2, FilePath = "submissions/dt002_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 4, SubmissionId = 3, FilePath = "submissions/dt003_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 5, SubmissionId = 4, FilePath = "submissions/dt004_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 6, SubmissionId = 5, FilePath = "submissions/dt005_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 7, SubmissionId = 6, FilePath = "submissions/dt006_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 8, SubmissionId = 7, FilePath = "submissions/dt007_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 9, SubmissionId = 8, FilePath = "submissions/dt008_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 10, SubmissionId = 9, FilePath = "submissions/dt009_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 11, SubmissionId = 10, FilePath = "submissions/dt010_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new SubmissionVersion { Id = 12, SubmissionId = 11, FilePath = "submissions/dt011_v1.pdf", VersionNumber = 1, CreatedAt = DateTime.UtcNow }
            );

            // 12. Feedback
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, SubmissionId = 1, LecturerId = 4, Content = "Cần cải thiện phần phân tích dữ liệu.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 2, SubmissionId = 2, LecturerId = 5, Content = "Tốt, nhưng cần bổ sung tài liệu tham khảo.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 3, SubmissionId = 3, LecturerId = 6, Content = "Cần chỉnh sửa bố cục báo cáo.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 4, SubmissionId = 4, LecturerId = 14, Content = "Bài nộp chưa đạt yêu cầu.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 5, SubmissionId = 5, LecturerId = 15, Content = "Cần bổ sung hình ảnh minh họa.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 6, SubmissionId = 6, LecturerId = 4, Content = "Tốt, nội dung đầy đủ.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 7, SubmissionId = 7, LecturerId = 5, Content = "Cần cải thiện phần kết luận.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 8, SubmissionId = 8, LecturerId = 6, Content = "Bài nộp không đúng định dạng.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 9, SubmissionId = 9, LecturerId = 14, Content = "Cần bổ sung tài liệu tham khảo.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 10, SubmissionId = 10, LecturerId = 15, Content = "Tốt, đạt yêu cầu.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 11, SubmissionId = 11, LecturerId = 4, Content = "Cần chỉnh sửa phần giới thiệu.", CreatedAt = DateTime.UtcNow },
                new Feedback { Id = 12, SubmissionId = 12, LecturerId = 5, Content = "Bài nộp không đạt, cần làm lại.", CreatedAt = DateTime.UtcNow }
            );

            // 13. CodeRun
            modelBuilder.Entity<CodeRun>().HasData(
                new CodeRun { Id = 1, SubmissionId = 1, Code = "print('Hello World')", Language = "Python", Status = "Success", Result = "Output: Hello World", PlagiarismScore = 0.1f, ExecutionTime = 50.5f, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CodeRun { Id = 2, SubmissionId = 2, Code = "public class Main { public static void main(String[] args) { System.out.println(\"Hello\"); } }", Language = "Java", Status = "Success", Result = "Output: Hello", PlagiarismScore = 0.2f, ExecutionTime = 120.0f, CreatedAt = DateTime.UtcNow.AddHours(-1), UpdatedAt = DateTime.UtcNow.AddHours(-1) },
                new CodeRun { Id = 3, SubmissionId = 3, Code = "console.log('Hello World');", Language = "JavaScript", Status = "Success", Result = "Output: Hello World", PlagiarismScore = 0.15f, ExecutionTime = 30.2f, CreatedAt = DateTime.UtcNow.AddHours(-2), UpdatedAt = DateTime.UtcNow.AddHours(-2) },
                new CodeRun { Id = 4, SubmissionId = 4, Code = "print('Error Test')", Language = "Python", Status = "Failed", Result = "Error: Invalid syntax", ErrorMessage = "SyntaxError: unexpected EOF while parsing", PlagiarismScore = 0.3f, ExecutionTime = null, CreatedAt = DateTime.UtcNow.AddHours(-3), UpdatedAt = DateTime.UtcNow.AddHours(-3) },
                new CodeRun { Id = 5, SubmissionId = 5, Code = "public class Test { public static void main(String[] args) { System.out.println(\"Test\"); } }", Language = "Java", Status = "Success", Result = "Output: Test", PlagiarismScore = 0.1f, ExecutionTime = 110.5f, CreatedAt = DateTime.UtcNow.AddHours(-4), UpdatedAt = DateTime.UtcNow.AddHours(-4) },
                new CodeRun { Id = 6, SubmissionId = 6, Code = "print('IoT Security')", Language = "Python", Status = "Success", Result = "Output: IoT Security", PlagiarismScore = 0.05f, ExecutionTime = 45.0f, CreatedAt = DateTime.UtcNow.AddHours(-5), UpdatedAt = DateTime.UtcNow.AddHours(-5) },
                new CodeRun { Id = 7, SubmissionId = 7, Code = "console.log('Social Media');", Language = "JavaScript", Status = "Success", Result = "Output: Social Media", PlagiarismScore = 0.2f, ExecutionTime = 25.8f, CreatedAt = DateTime.UtcNow.AddHours(-6), UpdatedAt = DateTime.UtcNow.AddHours(-6) },
                new CodeRun { Id = 8, SubmissionId = 8, Code = "print('Language Learning')", Language = "Python", Status = "Timeout", Result = "Execution timed out", ErrorMessage = "Process exceeded 5-second limit", PlagiarismScore = 0.4f, ExecutionTime = null, CreatedAt = DateTime.UtcNow.AddHours(-7), UpdatedAt = DateTime.UtcNow.AddHours(-7) },
                new CodeRun { Id = 9, SubmissionId = 9, Code = "public class Warehouse { public static void main(String[] args) { System.out.println(\"Warehouse\"); } }", Language = "Java", Status = "Success", Result = "Output: Warehouse", PlagiarismScore = 0.1f, ExecutionTime = 130.0f, CreatedAt = DateTime.UtcNow.AddHours(-8), UpdatedAt = DateTime.UtcNow.AddHours(-8) },
                new CodeRun { Id = 10, SubmissionId = 10, Code = "print('Booking System')", Language = "Python", Status = "Success", Result = "Output: Booking System", PlagiarismScore = 0.05f, ExecutionTime = 48.3f, CreatedAt = DateTime.UtcNow.AddHours(-9), UpdatedAt = DateTime.UtcNow.AddHours(-9) },
                new CodeRun { Id = 11, SubmissionId = 11, Code = "console.log('HR System');", Language = "JavaScript", Status = "Success", Result = "Output: HR System", PlagiarismScore = 0.15f, ExecutionTime = 28.7f, CreatedAt = DateTime.UtcNow.AddHours(-10), UpdatedAt = DateTime.UtcNow.AddHours(-10) },
                new CodeRun { Id = 12, SubmissionId = 12, Code = "print('Group Study')", Language = "Python", Status = "Failed", Result = "Error: NameError", ErrorMessage = "NameError: name 'undefined_variable' is not defined", PlagiarismScore = 0.3f, ExecutionTime = null, CreatedAt = DateTime.UtcNow.AddHours(-11), UpdatedAt = DateTime.UtcNow.AddHours(-11) }
            );

            // 14. GradeCriteria
            modelBuilder.Entity<GradeCriteria>().HasData(
                new GradeCriteria { Id = 1, CourseId = 1, Name = "Nội dung", Weight = 0.4f, Description = "Chất lượng nội dung đồ án." },
                new GradeCriteria { Id = 2, CourseId = 1, Name = "Trình bày", Weight = 0.3f, Description = "Cách trình bày báo cáo." },
                new GradeCriteria { Id = 3, CourseId = 1, Name = "Bảo vệ", Weight = 0.3f, Description = "Kỹ năng bảo vệ." },
                new GradeCriteria { Id = 4, CourseId = 2, Name = "Nội dung", Weight = 0.5f, Description = "Chất lượng nội dung đồ án cơ sở." },
                new GradeCriteria { Id = 5, CourseId = 2, Name = "Thực hành", Weight = 0.5f, Description = "Kỹ năng thực hành." },
                new GradeCriteria { Id = 6, CourseId = 3, Name = "Nội dung", Weight = 0.4f, Description = "Chất lượng nội dung đồ án KTPM." },
                new GradeCriteria { Id = 7, CourseId = 4, Name = "Thực hành", Weight = 0.6f, Description = "Kỹ năng thực hành KTPM." },
                new GradeCriteria { Id = 8, CourseId = 5, Name = "Bảo mật", Weight = 0.5f, Description = "Mức độ bảo mật." },
                new GradeCriteria { Id = 9, CourseId = 6, Name = "Phân tích", Weight = 0.5f, Description = "Kỹ năng phân tích dữ liệu." },
                new GradeCriteria { Id = 10, CourseId = 7, Name = "Ứng dụng", Weight = 0.4f, Description = "Ứng dụng thực tế." },
                new GradeCriteria { Id = 11, CourseId = 8, Name = "Quản lý", Weight = 0.5f, Description = "Khả năng quản lý kho." },
                new GradeCriteria { Id = 12, CourseId = 9, Name = "Tiện ích", Weight = 0.5f, Description = "Tính tiện ích của app." },
                new GradeCriteria { Id = 13, CourseId = 10, Name = "Hiệu quả", Weight = 0.5f, Description = "Hiệu quả quản lý nhân sự." }
            );

            // 15. Grade
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, ProjectId = 1, GroupId = 1, CriteriaId = 1, Score = 8.5f, Comment = "Nội dung tốt.", GradedAt = DateTime.UtcNow, GradedBy = 4 },
                new Grade { Id = 2, ProjectId = 1, GroupId = 1, CriteriaId = 2, Score = 8.0f, Comment = "Trình bày rõ ràng.", GradedAt = DateTime.UtcNow, GradedBy = 4 },
                new Grade { Id = 3, ProjectId = 2, GroupId = 2, CriteriaId = 1, Score = 7.5f, Comment = "Nội dung ổn.", GradedAt = DateTime.UtcNow, GradedBy = 5 },
                new Grade { Id = 4, ProjectId = 3, GroupId = 3, CriteriaId = 4, Score = 8.0f, Comment = "Nội dung tốt.", GradedAt = DateTime.UtcNow, GradedBy = 6 },
                new Grade { Id = 5, ProjectId = 4, GroupId = 4, CriteriaId = 6, Score = 7.0f, Comment = "Cần cải thiện.", GradedAt = DateTime.UtcNow, GradedBy = 14 },
                new Grade { Id = 6, ProjectId = 5, GroupId = 5, CriteriaId = 7, Score = 8.5f, Comment = "Thực hành tốt.", GradedAt = DateTime.UtcNow, GradedBy = 15 },
                new Grade { Id = 7, ProjectId = 6, GroupId = 6, CriteriaId = 8, Score = 9.0f, Comment = "Bảo mật tốt.", GradedAt = DateTime.UtcNow, GradedBy = 4 },
                new Grade { Id = 8, ProjectId = 7, GroupId = 7, CriteriaId = 9, Score = 6.5f, Comment = "Phân tích chưa sâu.", GradedAt = DateTime.UtcNow, GradedBy = 5 },
                new Grade { Id = 9, ProjectId = 8, GroupId = 8, CriteriaId = 10, Score = 8.0f, Comment = "Ứng dụng ổn.", GradedAt = DateTime.UtcNow, GradedBy = 6 },
                new Grade { Id = 10, ProjectId = 9, GroupId = 9, CriteriaId = 11, Score = 7.5f, Comment = "Quản lý tốt.", GradedAt = DateTime.UtcNow, GradedBy = 14 },
                new Grade { Id = 11, ProjectId = 10, GroupId = 10, CriteriaId = 12, Score = 8.0f, Comment = "Tiện ích cao.", GradedAt = DateTime.UtcNow, GradedBy = 15 },
                new Grade { Id = 12, ProjectId = 11, GroupId = 11, CriteriaId = 13, Score = 7.0f, Comment = "Hiệu quả ổn.", GradedAt = DateTime.UtcNow, GradedBy = 4 }
            );

            // 16. GradeVersion
            modelBuilder.Entity<GradeVersion>().HasData(
                new GradeVersion { Id = 1, GradeId = 1, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new GradeVersion { Id = 2, GradeId = 1, Score = 8.5f, Comment = "Cập nhật điểm.", VersionNumber = 2, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 3, GradeId = 2, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 4, GradeId = 3, Score = 7.5f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 5, GradeId = 4, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 6, GradeId = 5, Score = 7.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 7, GradeId = 6, Score = 8.5f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 8, GradeId = 7, Score = 9.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 9, GradeId = 8, Score = 6.5f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 10, GradeId = 9, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 11, GradeId = 10, Score = 7.5f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow },
                new GradeVersion { Id = 12, GradeId = 11, Score = 8.0f, Comment = "Phiên bản đầu.", VersionNumber = 1, CreatedAt = DateTime.UtcNow }
            );

            // 17. GradeLog
            modelBuilder.Entity<GradeLog>().HasData(
                new GradeLog { Id = 1, GradeId = 1, LecturerId = 4, Action = "CREATE", Details = "Tạo điểm cho nhóm 1.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 2, GradeId = 1, LecturerId = 4, Action = "UPDATE", Details = "Cập nhật điểm nhóm 1.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 3, GradeId = 2, LecturerId = 4, Action = "CREATE", Details = "Tạo điểm cho nhóm 1.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 4, GradeId = 3, LecturerId = 5, Action = "CREATE", Details = "Tạo điểm cho nhóm 2.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 5, GradeId = 4, LecturerId = 6, Action = "CREATE", Details = "Tạo điểm cho nhóm 3.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 6, GradeId = 5, LecturerId = 14, Action = "CREATE", Details = "Tạo điểm cho nhóm 4.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 7, GradeId = 6, LecturerId = 15, Action = "CREATE", Details = "Tạo điểm cho nhóm 5.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 8, GradeId = 7, LecturerId = 4, Action = "CREATE", Details = "Tạo điểm cho nhóm 6.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 9, GradeId = 8, LecturerId = 5, Action = "CREATE", Details = "Tạo điểm cho nhóm 7.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 10, GradeId = 9, LecturerId = 6, Action = "CREATE", Details = "Tạo điểm cho nhóm 8.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 11, GradeId = 10, LecturerId = 14, Action = "CREATE", Details = "Tạo điểm cho nhóm 9.", CreatedAt = DateTime.UtcNow },
                new GradeLog { Id = 12, GradeId = 11, LecturerId = 15, Action = "CREATE", Details = "Tạo điểm cho nhóm 10.", CreatedAt = DateTime.UtcNow }
            );

            // 18. GradeSchedule
            modelBuilder.Entity<GradeSchedule>().HasData(
                new GradeSchedule { Id = 1, ProjectId = 1, LecturerId = 4, Deadline = new DateTime(2025, 3, 1), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 2, ProjectId = 2, LecturerId = 5, Deadline = new DateTime(2025, 3, 2), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 3, ProjectId = 3, LecturerId = 6, Deadline = new DateTime(2025, 3, 3), Status = "COMPLETED", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 4, ProjectId = 4, LecturerId = 14, Deadline = new DateTime(2025, 3, 4), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 5, ProjectId = 5, LecturerId = 15, Deadline = new DateTime(2025, 3, 5), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 6, ProjectId = 6, LecturerId = 4, Deadline = new DateTime(2025, 3, 6), Status = "COMPLETED", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 7, ProjectId = 7, LecturerId = 5, Deadline = new DateTime(2025, 3, 7), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 8, ProjectId = 8, LecturerId = 6, Deadline = new DateTime(2025, 3, 8), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 9, ProjectId = 9, LecturerId = 14, Deadline = new DateTime(2025, 3, 9), Status = "COMPLETED", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 10, ProjectId = 10, LecturerId = 15, Deadline = new DateTime(2025, 3, 10), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 11, ProjectId = 11, LecturerId = 4, Deadline = new DateTime(2025, 3, 11), Status = "PENDING", CreatedAt = DateTime.UtcNow },
                new GradeSchedule { Id = 12, ProjectId = 12, LecturerId = 5, Deadline = new DateTime(2025, 3, 12), Status = "COMPLETED", CreatedAt = DateTime.UtcNow }
            );

            // 19. GradeAppeal
            modelBuilder.Entity<GradeAppeal>().HasData(
                new GradeAppeal { Id = 1, GradeId = 1, StudentId = 7, Reason = "Điểm nội dung chưa hợp lý.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 2, GradeId = 2, StudentId = 8, Reason = "Điểm trình bày thấp.", Status = "APPROVED", Response = "Đã điều chỉnh điểm.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 3, GradeId = 3, StudentId = 9, Reason = "Điểm nội dung không hợp lý.", Status = "REJECTED", Response = "Điểm đã hợp lý.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 4, GradeId = 4, StudentId = 10, Reason = "Điểm nội dung thấp.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 5, GradeId = 5, StudentId = 12, Reason = "Cần xem lại điểm.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 6, GradeId = 6, StudentId = 7, Reason = "Điểm thực hành chưa đúng.", Status = "APPROVED", Response = "Đã điều chỉnh.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 7, GradeId = 7, StudentId = 8, Reason = "Điểm bảo mật không hợp lý.", Status = "REJECTED", Response = "Điểm hợp lý.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 8, GradeId = 8, StudentId = 9, Reason = "Điểm phân tích thấp.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 9, GradeId = 9, StudentId = 10, Reason = "Điểm ứng dụng chưa đúng.", Status = "APPROVED", Response = "Đã điều chỉnh.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 10, GradeId = 10, StudentId = 11, Reason = "Điểm quản lý chưa hợp lý.", Status = "REJECTED", Response = "Điểm hợp lý.", CreatedAt = DateTime.UtcNow },
                new GradeAppeal { Id = 11, GradeId = 11, StudentId = 12, Reason = "Điểm tiện ích thấp.", Status = "PENDING", Response = null, CreatedAt = DateTime.UtcNow }
            );

            // 20. DefenseCommittee
            modelBuilder.Entity<DefenseCommittee>().HasData(
                new DefenseCommittee { Id = 1, Name = "Hội đồng 1", SemesterId = 1,CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 2, Name = "Hội đồng 2", SemesterId = 1,CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 3, Name = "Hội đồng 3", SemesterId = 1,CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 4, Name = "Hội đồng 4", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 5, Name = "Hội đồng 5", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 6, Name = "Hội đồng 6", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 7, Name = "Hội đồng 7", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 8, Name = "Hội đồng 8", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 9, Name = "Hội đồng 9", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 10, Name = "Hội đồng 10", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 11, Name = "Hội đồng 11", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new DefenseCommittee { Id = 12, Name = "Hội đồng 12", SemesterId = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 21. CommitteeMember
            modelBuilder.Entity<CommitteeMember>().HasData(
                new CommitteeMember { Id = 1, CommitteeId = 1, LecturerId = 2, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 2, CommitteeId = 1, LecturerId = 4, Role = "Thành viên", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 3, CommitteeId = 2, LecturerId = 3, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 4, CommitteeId = 2, LecturerId = 5, Role = "Thư ký", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 5, CommitteeId = 3, LecturerId = 6, Role = "Thành viên", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 6, CommitteeId = 4, LecturerId = 14, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 7, CommitteeId = 5, LecturerId = 15, Role = "Thư ký", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 8, CommitteeId = 6, LecturerId = 4, Role = "Thành viên", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 9, CommitteeId = 7, LecturerId = 5, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 10, CommitteeId = 8, LecturerId = 6, Role = "Thư ký", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 11, CommitteeId = 9, LecturerId = 14, Role = "Thành viên", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new CommitteeMember { Id = 12, CommitteeId = 10, LecturerId = 15, Role = "Chủ tịch", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 22. DefenseSchedule
            modelBuilder.Entity<DefenseSchedule>().HasData(
                new DefenseSchedule { Id = 1, ProjectId = 1, StartTime = new DateTime(2025, 3, 1, 8, 0, 0), EndTime = new DateTime(2025, 3, 1, 9, 0, 0), Room = "A101", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 2, ProjectId = 2, StartTime = new DateTime(2025, 3, 2, 8, 0, 0), EndTime = new DateTime(2025, 3, 2, 9, 0, 0), Room = "A102", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 3, ProjectId = 3, StartTime = new DateTime(2025, 3, 3, 8, 0, 0), EndTime = new DateTime(2025, 3, 3, 9, 0, 0), Room = "A103", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 4, ProjectId = 4, StartTime = new DateTime(2025, 3, 4, 8, 0, 0), EndTime = new DateTime(2025, 3, 4, 9, 0, 0), Room = "A104", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 5, ProjectId = 5, StartTime = new DateTime(2025, 3, 5, 8, 0, 0), EndTime = new DateTime(2025, 3, 5, 9, 0, 0), Room = "A105", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 6, ProjectId = 6, StartTime = new DateTime(2025, 3, 6, 8, 0, 0), EndTime = new DateTime(2025, 3, 6, 9, 0, 0), Room = "A106", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 7, ProjectId = 7, StartTime = new DateTime(2025, 3, 7, 8, 0, 0), EndTime = new DateTime(2025, 3, 7, 9, 0, 0), Room = "A107", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 8, ProjectId = 8, StartTime = new DateTime(2025, 3, 8, 8, 0, 0), EndTime = new DateTime(2025, 3, 8, 9, 0, 0), Room = "A108", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 9, ProjectId = 9, StartTime = new DateTime(2025, 3, 9, 8, 0, 0), EndTime = new DateTime(2025, 3, 9, 9, 0, 0), Room = "A109", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 10, ProjectId = 10, StartTime = new DateTime(2025, 3, 10, 8, 0, 0), EndTime = new DateTime(2025, 3, 10, 9, 0, 0), Room = "A110", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 11, ProjectId = 11, StartTime = new DateTime(2025, 3, 11, 8, 0, 0), EndTime = new DateTime(2025, 3, 11, 9, 0, 0), Room = "A111", CreatedAt = DateTime.UtcNow },
                new DefenseSchedule { Id = 12, ProjectId = 12, StartTime = new DateTime(2025, 3, 12, 8, 0, 0), EndTime = new DateTime(2025, 3, 12, 9, 0, 0), Room = "A112", CreatedAt = DateTime.UtcNow }
            );

            // 23. Meeting
            modelBuilder.Entity<Meeting>().HasData(
                new Meeting { Id = 1, GroupId = 1, Title = "Họp nhóm tuần 1", StartTime = new DateTime(2025, 2, 10, 14, 0, 0), EndTime = new DateTime(2025, 2, 10, 15, 0, 0), Location = "Phòng B101", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 2, GroupId = 2, Title = "Họp nhóm tuần 2", StartTime = new DateTime(2025, 2, 17, 14, 0, 0), EndTime = new DateTime(2025, 2, 17, 15, 0, 0), Location = "Online", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 3, GroupId = 3, Title = "Họp nhóm tuần 3", StartTime = new DateTime(2025, 2, 24, 14, 0, 0), EndTime = new DateTime(2025, 2, 24, 15, 0, 0), Location = "Phòng B102", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 4, GroupId = 4, Title = "Họp nhóm tuần 4", StartTime = new DateTime(2025, 3, 3, 14, 0, 0), EndTime = new DateTime(2025, 3, 3, 15, 0, 0), Location = "Online", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 5, GroupId = 5, Title = "Họp nhóm tuần 5", StartTime = new DateTime(2025, 3, 10, 14, 0, 0), EndTime = new DateTime(2025, 3, 10, 15, 0, 0), Location = "Phòng B103", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 6, GroupId = 6, Title = "Họp nhóm tuần 6", StartTime = new DateTime(2025, 3, 17, 14, 0, 0), EndTime = new DateTime(2025, 3, 17, 15, 0, 0), Location = "Online", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 7, GroupId = 7, Title = "Họp nhóm tuần 7", StartTime = new DateTime(2025, 3, 24, 14, 0, 0), EndTime = new DateTime(2025, 3, 24, 15, 0, 0), Location = "Phòng B104", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 8, GroupId = 8, Title = "Họp nhóm tuần 8", StartTime = new DateTime(2025, 3, 31, 14, 0, 0), EndTime = new DateTime(2025, 3, 31, 15, 0, 0), Location = "Online", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 9, GroupId = 9, Title = "Họp nhóm tuần 9", StartTime = new DateTime(2025, 4, 7, 14, 0, 0), EndTime = new DateTime(2025, 4, 7, 15, 0, 0), Location = "Phòng B105", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 10, GroupId = 10, Title = "Họp nhóm tuần 10", StartTime = new DateTime(2025, 4, 14, 14, 0, 0), EndTime = new DateTime(2025, 4, 14, 15, 0, 0), Location = "Online", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 11, GroupId = 11, Title = "Họp nhóm tuần 11", StartTime = new DateTime(2025, 4, 21, 14, 0, 0), EndTime = new DateTime(2025, 4, 21, 15, 0, 0), Location = "Phòng B106", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Meeting { Id = 12, GroupId = 12, Title = "Họp nhóm tuần 12", StartTime = new DateTime(2025, 4, 28, 14, 0, 0), EndTime = new DateTime(2025, 4, 28, 15, 0, 0), Location = "Online", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 24. MeetingRecord
            modelBuilder.Entity<MeetingRecord>().HasData(
                new MeetingRecord { Id = 1, MeetingId = 1, FilePath = "records/meeting1.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 2, MeetingId = 2, FilePath = "records/meeting2.mp4", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 3, MeetingId = 3, FilePath = "records/meeting3.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 4, MeetingId = 4, FilePath = "records/meeting4.mp4", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 5, MeetingId = 5, FilePath = "records/meeting5.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 6, MeetingId = 6, FilePath = "records/meeting6.mp4", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 7, MeetingId = 7, FilePath = "records/meeting7.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 8, MeetingId = 8, FilePath = "records/meeting8.mp4", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 9, MeetingId = 9, FilePath = "records/meeting9.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 10, MeetingId = 10, FilePath = "records/meeting10.mp4", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 11, MeetingId = 11, FilePath = "records/meeting11.mp3", CreatedAt = DateTime.UtcNow },
                new MeetingRecord { Id = 12, MeetingId = 12, FilePath = "records/meeting12.mp4", CreatedAt = DateTime.UtcNow }
            );

            // 25. Notification
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, UserId = 7, GroupId = null, Title = "Hạn nộp đồ án", Content = "Hạn nộp là 28/02/2025.", RecipientType = "user", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 2, UserId = 9, Title = "Phản hồi bài nộp", Content = "Bài nộp đã được phản hồi.", RecipientType = "group", Type = "EMAIL", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 3, UserId = 8, GroupId = 1, Title = "Nhóm mới", Content = "Bạn được thêm vào Nhóm 1.", RecipientType = "user", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 4, UserId = 10, GroupId = 3, Title = "Họp nhóm", Content = "Họp nhóm vào 14:00, 03/03/2025.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 5, UserId = 11, GroupId = 4, Title = "Phản hồi đồ án", Content = "Đồ án Nhóm 4 cần chỉnh sửa.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 6, UserId = 12, GroupId = 5, Title = "Nhiệm vụ mới", Content = "Bạn được giao nhiệm vụ mới.", RecipientType = "user", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 7, UserId = 13, GroupId = 6, Title = "Cập nhật điểm", Content = "Điểm của Nhóm 6 đã được cập nhật.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 8, UserId = 7, GroupId = 7, Title = "Hạn chót nhiệm vụ", Content = "Hạn chót nhiệm vụ là 10/03/2025.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 9, UserId = 8, GroupId = 8, Title = "Lịch bảo vệ", Content = "Lịch bảo vệ: 08/03/2025, A108.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 10, UserId = 9, GroupId = 9, Title = "Phản hồi mới", Content = "Nhóm 9 nhận phản hồi mới.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 11, UserId = 10, GroupId = 10, Title = "Cập nhật đồ án", Content = "Đồ án Nhóm 10 đã được phê duyệt.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow },
                new Notification { Id = 12, UserId = 11, GroupId = 11, Title = "Nhiệm vụ hoàn thành", Content = "Nhiệm vụ của Nhóm 11 đã hoàn thành.", RecipientType = "group", Type = "WEB", Status = "SENT", CreatedAt = DateTime.UtcNow }
            );

            // 26. PeerReview
            modelBuilder.Entity<PeerReview>().HasData(
                new PeerReview { Id = 1, GroupId = 1, ReviewerId = 7, RevieweeId = 8, Score = 8, Comment = "Làm việc tốt.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 2, GroupId = 1, ReviewerId = 8, RevieweeId = 7, Score = 7, Comment = "Cần cải thiện giao tiếp.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 3, GroupId = 3, ReviewerId = 10, RevieweeId = 11, Score = 9, Comment = "Hỗ trợ nhóm tốt.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 4, GroupId = 3, ReviewerId = 11, RevieweeId = 10, Score = 6, Comment = "Cần chủ động hơn.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 5, GroupId = 4, ReviewerId = 12, RevieweeId = 13, Score = 8, Comment = "Đóng góp tích cực.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 6, GroupId = 4, ReviewerId = 13, RevieweeId = 12, Score = 7, Comment = "Cần cải thiện kỹ năng.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 7, GroupId = 5, ReviewerId = 7, RevieweeId = 8, Score = 9, Comment = "Làm việc hiệu quả.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 8, GroupId = 6, ReviewerId = 8, RevieweeId = 9, Score = 6, Comment = "Cần tập trung hơn.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 9, GroupId = 7, ReviewerId = 9, RevieweeId = 10, Score = 8, Comment = "Hợp tác tốt.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 10, GroupId = 8, ReviewerId = 10, RevieweeId = 11, Score = 7, Comment = "Cần cải thiện thái độ.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 11, GroupId = 9, ReviewerId = 11, RevieweeId = 12, Score = 9, Comment = "Đóng góp lớn.", CreatedAt = DateTime.UtcNow },
                new PeerReview { Id = 12, GroupId = 10, ReviewerId = 12, RevieweeId = 13, Score = 8, Comment = "Làm việc ổn.", CreatedAt = DateTime.UtcNow }
            );

            // 27. Resource
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id = 1, ProjectId = 1, Title = "Tài liệu AI", FilePath = "resources/ai_doc.pdf", Type = "REFERENCE", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 2, GroupId = 2, Title = "Mẫu báo cáo", FilePath = "resources/report_template.docx", Type = "SAMPLE", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 3, ProjectId = 3, Title = "Tài liệu thương mại điện tử", FilePath = "resources/ecommerce.pdf", Type = "REFERENCE", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 4, ProjectId = 4, Title = "Hướng dẫn phân tích dữ liệu", FilePath = "resources/data_analysis.pdf", Type = "REFERENCE", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 5, ProjectId = 5, Title = "Tài liệu quản lý học tập", FilePath = "resources/study_management.pdf", Type = "REFERENCE", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 6, ProjectId = 6, Title = "Tài liệu bảo mật IoT", FilePath = "resources/iot_security.pdf", Type = "REFERENCE", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 7, ProjectId = 7, Title = "Phân tích mạng xã hội", FilePath = "resources/social_media_analysis.pdf", Type = "REFERENCE", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 8, ProjectId = 8, Title = "Tài liệu học ngoại ngữ", FilePath = "resources/language_learning.pdf", Type = "REFERENCE", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 9, ProjectId = 9, Title = "Hướng dẫn quản lý kho", FilePath = "resources/warehouse_management.pdf", Type = "REFERENCE", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 10, ProjectId = 10, Title = "Tài liệu đặt lịch khám bệnh", FilePath = "resources/booking_system.pdf", Type = "REFERENCE", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 11, ProjectId = 11, Title = "Tài liệu quản lý nhân sự", FilePath = "resources/hr_management.pdf", Type = "REFERENCE", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Resource { Id = 12, ProjectId = 12, Title = "Hướng dẫn học tập nhóm", FilePath = "resources/group_study.pdf", Type = "REFERENCE", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 28. Question
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, ProjectId = 1, Content = "Ứng dụng AI của bạn giải quyết vấn đề gì?", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Question { Id = 2, ProjectId = 2, Content = "Hệ thống quản lý đồ án có những tính năng gì?", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Question { Id = 3, ProjectId = 3, Content = "Website thương mại điện tử có tích hợp thanh toán không?", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Question { Id = 4, ProjectId = 4, Content = "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Question { Id = 5, ProjectId = 5, Content = "App quản lý học tập có hỗ trợ offline không?", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Question { Id = 6, ProjectId = 6, Content = "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Question { Id = 7, ProjectId = 7, Content = "Phân tích dữ liệu mạng xã hội có chính xác không?", CreatedBy = 5, CreatedAt = DateTime.UtcNow },
                new Question { Id = 8, ProjectId = 8, Content = "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", CreatedBy = 6, CreatedAt = DateTime.UtcNow },
                new Question { Id = 9, ProjectId = 9, Content = "Hệ thống quản lý kho có tự động hóa không?", CreatedBy = 14, CreatedAt = DateTime.UtcNow },
                new Question { Id = 10, ProjectId = 10, Content = "App đặt lịch khám bệnh có thông báo nhắc nhở không?", CreatedBy = 15, CreatedAt = DateTime.UtcNow },
                new Question { Id = 11, ProjectId = 11, Content = "Hệ thống quản lý nhân sự có báo cáo không?", CreatedBy = 4, CreatedAt = DateTime.UtcNow },
                new Question { Id = 12, ProjectId = 12, Content = "App học tập nhóm có tính năng chat không?", CreatedBy = 5, CreatedAt = DateTime.UtcNow }
            );

            // 29. FAQ
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { Id = 1, Question = "Làm thế nào để nộp đồ án?", Answer = "Đăng nhập, vào mục Nộp bài, tải file lên.", Category = "Nộp bài", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 2, Question = "Thời gian bảo vệ là khi nào?", Answer = "Xem lịch bảo vệ trong mục Lịch.", Category = "Bảo vệ", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 3, Question = "Làm sao để tham gia nhóm?", Answer = "Vào mục Nhóm, gửi yêu cầu tham gia.", Category = "Nhóm", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 4, Question = "Cách xem điểm đồ án?", Answer = "Vào mục Điểm số, chọn đồ án của bạn.", Category = "Điểm số", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 5, Question = "Làm sao để gửi phản hồi?", Answer = "Vào mục Phản hồi, điền nội dung.", Category = "Phản hồi", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 6, Question = "Hệ thống có hỗ trợ AI không?", Answer = "Có, AI hỗ trợ gợi ý và đánh giá.", Category = "Hỗ trợ", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 7, Question = "Làm sao để tạo nhiệm vụ?", Answer = "Vào mục Nhiệm vụ, nhấn Tạo mới.", Category = "Nhiệm vụ", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 8, Question = "Cách tải tài liệu tham khảo?", Answer = "Vào mục Tài liệu, chọn tài liệu và tải.", Category = "Tài liệu", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 9, Question = "Làm sao để xem lịch họp?", Answer = "Vào mục Lịch, chọn lịch họp nhóm.", Category = "Họp nhóm", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 10, Question = "Cách gửi kháng nghị điểm?", Answer = "Vào mục Điểm số, chọn Kháng nghị.", Category = "Kháng nghị", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 11, Question = "Hệ thống có hỗ trợ chat không?", Answer = "Có, vào mục Chat để trò chuyện nhóm.", Category = "Chat", CreatedAt = DateTime.UtcNow },
                new FAQ { Id = 12, Question = "Làm sao để đổi mật khẩu?", Answer = "Vào Cài đặt, chọn Đổi mật khẩu.", Category = "Tài khoản", CreatedAt = DateTime.UtcNow }
            );

            // 30. Discussion
            modelBuilder.Entity<Discussion>().HasData(
                new Discussion { Id = 1, ProjectId = 1, UserId = 7, Title = "Hỏi về AI trong y tế", Content = "Có ai biết cách tích hợp AI vào ứng dụng y tế?", Votes = 5, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 2, UserId = 9, Title = "Thắc mắc về thiết kế giao diện", Content = "Nên dùng framework nào cho giao diện?", Votes = 3, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 3, ProjectId = 3, UserId = 10, Title = "Thanh toán thương mại điện tử", Content = "Nên dùng cổng thanh toán nào?", Votes = 4, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 4, ProjectId = 4, UserId = 12, Title = "Phân tích dữ liệu", Content = "Có công cụ nào tốt để phân tích dữ liệu?", Votes = 2, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 5, ProjectId = 5, UserId = 7, Title = "Quản lý học tập", Content = "App quản lý học tập nên có tính năng gì?", Votes = 6, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 6, ProjectId = 6, UserId = 8, Title = "Bảo mật IoT", Content = "Làm sao để tăng cường bảo mật IoT?", Votes = 3, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 7, ProjectId = 7, UserId = 9, Title = "Phân tích mạng xã hội", Content = "Có công cụ nào miễn phí để phân tích?", Votes = 5, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 8, ProjectId = 8, UserId = 10, Title = "Học ngoại ngữ", Content = "App học ngoại ngữ nên có gì đặc biệt?", Votes = 4, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 9, ProjectId = 9, UserId = 11, Title = "Quản lý kho", Content = "Hệ thống quản lý kho nên tự động hóa thế nào?", Votes = 3, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 10, ProjectId = 10, UserId = 12, Title = "Đặt lịch khám bệnh", Content = "App đặt lịch nên có thông báo không?", Votes = 5, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 11, ProjectId = 11, UserId = 13, Title = "Quản lý nhân sự", Content = "Hệ thống nhân sự cần báo cáo gì?", Votes = 2, CreatedAt = DateTime.UtcNow },
                new Discussion { Id = 12, ProjectId = 12, UserId = 7, Title = "Học tập nhóm", Content = "App học nhóm nên có tính năng gì?", Votes = 4, CreatedAt = DateTime.UtcNow }
            );

            // 31. FeedbackSurvey
            modelBuilder.Entity<FeedbackSurvey>().HasData(
                new FeedbackSurvey { Id = 1, UserId = 7, Content = "Hệ thống dễ sử dụng.", Rating = 4, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 2, UserId = 8, Content = "Cần cải thiện tốc độ tải.", Rating = 3, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 3, UserId = 9, Content = "Giao diện thân thiện.", Rating = 5, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 4, UserId = 10, Content = "Chat nhóm bị lỗi.", Rating = 2, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 5, UserId = 11, Content = "Hỗ trợ tốt.", Rating = 4, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 6, UserId = 12, Content = "Cần thêm hướng dẫn sử dụng.", Rating = 3, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 7, UserId = 13, Content = "Tính năng quản lý nhóm tốt.", Rating = 5, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 8, UserId = 7, Content = "Thông báo không hoạt động.", Rating = 2, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 9, UserId = 8, Content = "Rất hài lòng với hệ thống.", Rating = 5, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 10, UserId = 9, Content = "Cần cải thiện tốc độ.", Rating = 3, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 11, UserId = 10, Content = "Giao diện đẹp.", Rating = 4, CreatedAt = DateTime.UtcNow },
                new FeedbackSurvey { Id = 12, UserId = 11, Content = "Hệ thống ổn định.", Rating = 4, CreatedAt = DateTime.UtcNow }
            );

            // 32. SkillAssessment
            modelBuilder.Entity<SkillAssessment>().HasData(
                new SkillAssessment { Id = 1, StudentId = 7, Skill = "Lập trình Python", Score = 8, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 2, StudentId = 8, Skill = "Thiết kế giao diện", Score = 7, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 3, StudentId = 9, Skill = "Phân tích dữ liệu", Score = 9, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 4, StudentId = 10, Skill = "Lập trình Java", Score = 6, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 5, StudentId = 11, Skill = "Quản lý dự án", Score = 8, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 6, StudentId = 12, Skill = "Kiểm thử phần mềm", Score = 7, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 7, StudentId = 13, Skill = "Lập trình JavaScript", Score = 9, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 8, StudentId = 7, Skill = "Giao tiếp nhóm", Score = 6, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 9, StudentId = 8, Skill = "Thiết kế cơ sở dữ liệu", Score = 8, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 10, StudentId = 9, Skill = "Tích hợp API", Score = 7, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 11, StudentId = 10, Skill = "Lập trình C#", Score = 8, CreatedAt = DateTime.UtcNow },
                new SkillAssessment { Id = 12, StudentId = 11, Skill = "Phân tích yêu cầu", Score = 9, CreatedAt = DateTime.UtcNow }
            );

            // 33. TimeTracking
            modelBuilder.Entity<TimeTracking>().HasData(
                new TimeTracking { Id = 1, StudentId = 7, ProjectId = 1, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow, Duration = 120, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 2, StudentId = 8, ProjectId = 1, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow, Duration = 60, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 3, StudentId = 9, ProjectId = 2, StartTime = DateTime.UtcNow.AddHours(-3), EndTime = DateTime.UtcNow, Duration = 180, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 4, StudentId = 10, ProjectId = 3, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow, Duration = 60, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 5, StudentId = 11, ProjectId = 4, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow, Duration = 120, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 6, StudentId = 12, ProjectId = 5, StartTime = DateTime.UtcNow.AddHours(-4), EndTime = DateTime.UtcNow, Duration = 240, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 7, StudentId = 13, ProjectId = 6, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow, Duration = 60, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 8, StudentId = 7, ProjectId = 7, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow, Duration = 120, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 9, StudentId = 8, ProjectId = 8, StartTime = DateTime.UtcNow.AddHours(-3), EndTime = DateTime.UtcNow, Duration = 180, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 10, StudentId = 9, ProjectId = 9, StartTime = DateTime.UtcNow.AddHours(-1), EndTime = DateTime.UtcNow, Duration = 60, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 11, StudentId = 10, ProjectId = 10, StartTime = DateTime.UtcNow.AddHours(-2), EndTime = DateTime.UtcNow, Duration = 120, CreatedAt = DateTime.UtcNow },
                new TimeTracking { Id = 12, StudentId = 11, ProjectId = 11, StartTime = DateTime.UtcNow.AddHours(-3), EndTime = DateTime.UtcNow, Duration = 180, CreatedAt = DateTime.UtcNow }
            );

            // 34. SystemConfig
            modelBuilder.Entity<SystemConfig>().HasData(
                new SystemConfig { Id = 1, Key = "LOGO_URL", Value = "images/hutech_logo.png", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 2, Key = "THEME_COLOR", Value = "#1976d2", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 3, Key = "EMAIL_SERVER", Value = "smtp.hutech.edu.vn", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 4, Key = "MAX_FILE_SIZE", Value = "10485760", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 5, Key = "DEFAULT_LANGUAGE", Value = "vi", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 6, Key = "NOTIFICATION_DURATION", Value = "7", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 7, Key = "SESSION_TIMEOUT", Value = "30", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 8, Key = "BACKUP_FREQUENCY", Value = "daily", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 9, Key = "ALLOWED_FILE_TYPES", Value = "pdf,docx,zip", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 10, Key = "TIMEZONE", Value = "Asia/Ho_Chi_Minh", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 11, Key = "MAX_LOGIN_ATTEMPTS", Value = "5", CreatedAt = DateTime.UtcNow },
                new SystemConfig { Id = 12, Key = "CHAT_ENABLED", Value = "true", CreatedAt = DateTime.UtcNow }
            );

            // 35. SystemMetric
            modelBuilder.Entity<SystemMetric>().HasData(
                new SystemMetric { Id = 1, MetricType = "CPU", Value = 45.5f, CreatedAt = DateTime.UtcNow },
                new SystemMetric { Id = 2, MetricType = "RAM", Value = 60.0f, CreatedAt = DateTime.UtcNow },
                new SystemMetric { Id = 3, MetricType = "DISK", Value = 75.0f, CreatedAt = DateTime.UtcNow },
                new SystemMetric { Id = 4, MetricType = "NETWORK", Value = 120.5f, CreatedAt = DateTime.UtcNow },
                new SystemMetric { Id = 5, MetricType = "CPU", Value = 50.0f, CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new SystemMetric { Id = 6, MetricType = "RAM", Value = 65.0f, CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new SystemMetric { Id = 7, MetricType = "DISK", Value = 80.0f, CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new SystemMetric { Id = 8, MetricType = "NETWORK", Value = 130.0f, CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new SystemMetric { Id = 9, MetricType = "CPU", Value = 55.0f, CreatedAt = DateTime.UtcNow.AddHours(-2) },
                new SystemMetric { Id = 10, MetricType = "RAM", Value = 70.0f, CreatedAt = DateTime.UtcNow.AddHours(-2) },
                new SystemMetric { Id = 11, MetricType = "DISK", Value = 85.0f, CreatedAt = DateTime.UtcNow.AddHours(-2) },
                new SystemMetric { Id = 12, MetricType = "NETWORK", Value = 140.0f, CreatedAt = DateTime.UtcNow.AddHours(-2) }
            );

            // 36. Calendar
            modelBuilder.Entity<Calendar>().HasData(
                new Calendar { Id = 1, UserId = 7, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 2, 10, 14, 0, 0), EndTime = new DateTime(2025, 2, 10, 15, 0, 0), Description = "Họp nhóm để thảo luận tiến độ dự án", Location = "Phòng họp A", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 2, UserId = 2, GroupId = 1, EventTitle = "Nộp bài", Type = "Deadline", Status = "Scheduled", StartTime = new DateTime(2025, 2, 28, 23, 59, 0), EndTime = new DateTime(2025, 2, 28, 23, 59, 0), Description = "Nộp bài tập lớn môn Lập trình", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 3, UserId = 8, GroupId = 2, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 2, 17, 14, 0, 0), EndTime = new DateTime(2025, 2, 17, 15, 0, 0), Description = "Họp nhóm để phân công nhiệm vụ", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 4, UserId = 9, EventTitle = "Bảo vệ đồ án", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 3, 1, 8, 0, 0), EndTime = new DateTime(2025, 3, 1, 9, 0, 0), Description = "Bảo vệ đồ án tốt nghiệp", Location = "Hội trường", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 5, UserId = 10, GroupId = 3, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 2, 24, 14, 0, 0), EndTime = new DateTime(2025, 2, 24, 15, 0, 0), Description = "Họp nhóm để kiểm tra tiến độ", Location = "Phòng họp C", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 6, UserId = 11, EventTitle = "Hạn nộp nhiệm vụ", Type = "Deadline", Status = "Scheduled", StartTime = new DateTime(2025, 2, 25, 23, 59, 0), EndTime = new DateTime(2025, 2, 25, 23, 59, 0), Description = "Nộp báo cáo nhiệm vụ cá nhân", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 7, UserId = 12, GroupId = 4, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 3, 3, 14, 0, 0), EndTime = new DateTime(2025, 3, 3, 15, 0, 0), Description = "Họp nhóm để chuẩn bị thuyết trình", Location = "Phòng họp A", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 8, UserId = 13, EventTitle = "Bảo vệ đồ án", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 3, 5, 8, 0, 0), EndTime = new DateTime(2025, 3, 5, 9, 0, 0), Description = "Bảo vệ đồ án chuyên ngành", Location = "Hội trường", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 9, UserId = 7, GroupId = 5, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 3, 10, 14, 0, 0), EndTime = new DateTime(2025, 3, 10, 15, 0, 0), Description = "Họp nhóm để hoàn thiện dự án", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 10, UserId = 8, EventTitle = "Hạn nộp nhiệm vụ", Type = "Deadline", Status = "Scheduled", StartTime = new DateTime(2025, 3, 15, 23, 59, 0), EndTime = new DateTime(2025, 3, 15, 23, 59, 0), Description = "Nộp báo cáo thực tập", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 11, UserId = 9, GroupId = 6, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 3, 17, 14, 0, 0), EndTime = new DateTime(2025, 3, 17, 15, 0, 0), Description = "Họp nhóm để đánh giá tiến độ", Location = "Phòng họp C", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 12, UserId = 10, EventTitle = "Bảo vệ đồ án", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 3, 20, 8, 0, 0), EndTime = new DateTime(2025, 3, 20, 9, 0, 0), Description = "Bảo vệ đồ án tốt nghiệp", Location = "Hội trường", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Calendar { Id = 13, UserId = 11, GroupId = 7, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 3, 24, 14, 0, 0), EndTime = new DateTime(2025, 3, 24, 15, 0, 0), Description = "Họp nhóm để phân tích yêu cầu dự án", Location = "Phòng họp A", CreatedAt = DateTime.UtcNow.AddDays(-1), UpdatedAt = DateTime.UtcNow.AddDays(-1) },
                new Calendar { Id = 14, UserId = 12, EventTitle = "Hạn nộp bài tập", Type = "Deadline", Status = "Scheduled", StartTime = new DateTime(2025, 3, 25, 23, 59, 0), EndTime = new DateTime(2025, 3, 25, 23, 59, 0), Description = "Nộp bài tập môn Cấu trúc dữ liệu", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow.AddDays(-1), UpdatedAt = DateTime.UtcNow.AddDays(-1) },
                new Calendar { Id = 15, UserId = 13, GroupId = 8, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 3, 31, 14, 0, 0), EndTime = new DateTime(2025, 3, 31, 15, 0, 0), Description = "Họp nhóm để chuẩn bị báo cáo", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow.AddDays(-2), UpdatedAt = DateTime.UtcNow.AddDays(-2) },
                new Calendar { Id = 16, UserId = 7, EventTitle = "Thi cuối kỳ", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 4, 1, 8, 0, 0), EndTime = new DateTime(2025, 4, 1, 10, 0, 0), Description = "Thi cuối kỳ môn Lập trình nâng cao", Location = "Phòng thi 101", CreatedAt = DateTime.UtcNow.AddDays(-2), UpdatedAt = DateTime.UtcNow.AddDays(-2) },
                new Calendar { Id = 17, UserId = 8, GroupId = 9, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Cancelled", StartTime = new DateTime(2025, 4, 7, 14, 0, 0), EndTime = new DateTime(2025, 4, 7, 15, 0, 0), Description = "Họp nhóm bị hủy do lịch trùng", Location = "Phòng họp C", CreatedAt = DateTime.UtcNow.AddDays(-3), UpdatedAt = DateTime.UtcNow.AddDays(-3) },
                new Calendar { Id = 18, UserId = 9, EventTitle = "Hạn nộp báo cáo", Type = "Deadline", Status = "Scheduled", StartTime = new DateTime(2025, 4, 10, 23, 59, 0), EndTime = new DateTime(2025, 4, 10, 23, 59, 0), Description = "Nộp báo cáo dự án nhóm", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow.AddDays(-3), UpdatedAt = DateTime.UtcNow.AddDays(-3) },
                new Calendar { Id = 19, UserId = 10, GroupId = 10, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 4, 14, 14, 0, 0), EndTime = new DateTime(2025, 4, 14, 15, 0, 0), Description = "Họp nhóm để hoàn thiện thuyết trình", Location = "Phòng họp A", CreatedAt = DateTime.UtcNow.AddDays(-4), UpdatedAt = DateTime.UtcNow.AddDays(-4) },
                new Calendar { Id = 20, UserId = 11, EventTitle = "Thi cuối kỳ", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 4, 15, 8, 0, 0), EndTime = new DateTime(2025, 4, 15, 10, 0, 0), Description = "Thi cuối kỳ môn Cơ sở dữ liệu", Location = "Phòng thi 102", CreatedAt = DateTime.UtcNow.AddDays(-4), UpdatedAt = DateTime.UtcNow.AddDays(-4) },
                new Calendar { Id = 21, UserId = 12, GroupId = 11, EventTitle = "Họp nhóm", Type = "Meeting", Status = "Scheduled", StartTime = new DateTime(2025, 4, 21, 14, 0, 0), EndTime = new DateTime(2025, 4, 21, 15, 0, 0), Description = "Họp nhóm để đánh giá dự án", Location = "Phòng họp B", CreatedAt = DateTime.UtcNow.AddDays(-5), UpdatedAt = DateTime.UtcNow.AddDays(-5) },
                new Calendar { Id = 22, UserId = 13, EventTitle = "Bảo vệ đồ án", Type = "Other", Status = "Scheduled", StartTime = new DateTime(2025, 4, 25, 8, 0, 0), EndTime = new DateTime(2025, 4, 25, 9, 0, 0), Description = "Bảo vệ đồ án chuyên ngành", Location = "Hội trường", CreatedAt = DateTime.UtcNow.AddDays(-5), UpdatedAt = DateTime.UtcNow.AddDays(-5) }
            );

            // 37. AISuggestion
            modelBuilder.Entity<AISuggestion>().HasData(
                new AISuggestion { Id = 1, UserId = 7, Type = "PROJECT", Content = "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 2, ProjectId = 1, Type = "GRADE", Content = "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 3, UserId = 8, Type = "PROJECT", Content = "Nên tích hợp tính năng chat vào hệ thống quản lý.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 4, ProjectId = 2, Type = "GRADE", Content = "Điểm trình bày có thể tăng nếu cải thiện bố cục.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 5, UserId = 9, Type = "PROJECT", Content = "Đề xuất thêm cổng thanh toán cho website thương mại.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 6, ProjectId = 3, Type = "GRADE", Content = "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 7, UserId = 10, Type = "PROJECT", Content = "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 8, ProjectId = 4, Type = "GRADE", Content = "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 9, UserId = 11, Type = "PROJECT", Content = "Đề xuất thêm chế độ offline cho app quản lý học tập.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 10, ProjectId = 5, Type = "GRADE", Content = "Điểm thực hành có thể tăng nếu bổ sung tính năng.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 11, UserId = 12, Type = "PROJECT", Content = "Nên tăng cường bảo mật cho hệ thống IoT.", CreatedAt = DateTime.UtcNow },
                new AISuggestion { Id = 12, ProjectId = 6, Type = "GRADE", Content = "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", CreatedAt = DateTime.UtcNow }
            );

            // 38. Log
            modelBuilder.Entity<Log>().HasData(
                new Log { Id = 1, UserId = 1, Action = "LOGIN", Details = "Admin đăng nhập hệ thống.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 2, UserId = 7, Action = "SUBMISSION", Details = "Sinh viên nộp bài cho đồ án 1.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 3, UserId = 8, Action = "JOIN_GROUP", Details = "Sinh viên tham gia Nhóm 1.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 4, UserId = 9, Action = "SEND_MESSAGE", Details = "Gửi tin nhắn trong Nhóm 2.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 5, UserId = 10, Action = "SUBMISSION", Details = "Sinh viên nộp bài cho đồ án 3.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 6, UserId = 11, Action = "CREATE_TASK", Details = "Tạo nhiệm vụ mới trong đồ án 4.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 7, UserId = 12, Action = "JOIN_GROUP", Details = "Sinh viên tham gia Nhóm 5.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 8, UserId = 13, Action = "SEND_MESSAGE", Details = "Gửi tin nhắn trong Nhóm 6.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 9, UserId = 4, Action = "GRADE", Details = "Chấm điểm cho Nhóm 1.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 10, UserId = 5, Action = "GRADE", Details = "Chấm điểm cho Nhóm 2.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 11, UserId = 6, Action = "CREATE_PROJECT", Details = "Tạo đồ án mới.", CreatedAt = DateTime.UtcNow },
                new Log { Id = 12, UserId = 14, Action = "UPDATE_PROJECT", Details = "Cập nhật đồ án 4.", CreatedAt = DateTime.UtcNow }
            );

            // 39. Backup
            modelBuilder.Entity<Backup>().HasData(
                new Backup { Id = 1, FilePath = "backups/db_backup_2025_02_01.sql", Type = "Full", Status = "Success", FileSize = 104857600, Description = "Daily full database backup", CreatedBy = 1, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Backup { Id = 2, FilePath = "backups/db_backup_2025_02_02.sql", Type = "Incremental", Status = "Success", FileSize = 52428800, Description = "Incremental backup for Feb 2", CreatedBy = 1, CreatedAt = DateTime.UtcNow.AddDays(-1), UpdatedAt = DateTime.UtcNow.AddDays(-1) },
                new Backup { Id = 3, FilePath = "backups/db_backup_2025_02_03.sql", Type = "Full", Status = "Success", FileSize = 110100480, Description = "Daily full database backup", CreatedBy = 2, CreatedAt = DateTime.UtcNow.AddDays(-2), UpdatedAt = DateTime.UtcNow.AddDays(-2) },
                new Backup { Id = 4, FilePath = "backups/db_backup_2025_02_04.sql", Type = "Differential", Status = "Success", FileSize = 73400320, Description = "Differential backup for Feb 4", CreatedBy = null, CreatedAt = DateTime.UtcNow.AddDays(-3), UpdatedAt = DateTime.UtcNow.AddDays(-3) },
                new Backup { Id = 5, FilePath = "backups/db_backup_2025_02_05.sql", Type = "Incremental", Status = "Failed", FileSize = null, Description = "Incremental backup failed due to disk space", CreatedBy = 1, CreatedAt = DateTime.UtcNow.AddDays(-4), UpdatedAt = DateTime.UtcNow.AddDays(-4) },
                new Backup { Id = 6, FilePath = "backups/db_backup_2025_02_06.sql", Type = "Full", Status = "Success", FileSize = 115343360, Description = "Weekly full database backup", CreatedBy = 2, CreatedAt = DateTime.UtcNow.AddDays(-5), UpdatedAt = DateTime.UtcNow.AddDays(-5) },
                new Backup { Id = 7, FilePath = "backups/db_backup_2025_02_07.sql", Type = "Incremental", Status = "Success", FileSize = 41943040, Description = "Incremental backup for Feb 7", CreatedBy = null, CreatedAt = DateTime.UtcNow.AddDays(-6), UpdatedAt = DateTime.UtcNow.AddDays(-6) },
                new Backup { Id = 8, FilePath = "backups/db_backup_2025_02_08.sql", Type = "Differential", Status = "Pending", FileSize = null, Description = "Differential backup in progress", CreatedBy = 1, CreatedAt = DateTime.UtcNow.AddDays(-7), UpdatedAt = DateTime.UtcNow.AddDays(-7) },
                new Backup { Id = 9, FilePath = "backups/db_backup_2025_02_09.sql", Type = "Full", Status = "Success", FileSize = 120586240, Description = "Daily full database backup", CreatedBy = 2, CreatedAt = DateTime.UtcNow.AddDays(-8), UpdatedAt = DateTime.UtcNow.AddDays(-8) },
                new Backup { Id = 10, FilePath = "backups/db_backup_2025_02_10.sql", Type = "Incremental", Status = "Success", FileSize = 52428800, Description = "Incremental backup for Feb 10", CreatedBy = null, CreatedAt = DateTime.UtcNow.AddDays(-9), UpdatedAt = DateTime.UtcNow.AddDays(-9) },
                new Backup { Id = 11, FilePath = "backups/db_backup_2025_02_11.sql", Type = "Differential", Status = "Success", FileSize = 83886080, Description = "Differential backup for Feb 11", CreatedBy = 1, CreatedAt = DateTime.UtcNow.AddDays(-10), UpdatedAt = DateTime.UtcNow.AddDays(-10) },
                new Backup { Id = 12, FilePath = "backups/db_backup_2025_02_12.sql", Type = "Full", Status = "Success", FileSize = 125829120, Description = "Daily full database backup", CreatedBy = 2, CreatedAt = DateTime.UtcNow.AddDays(-11), UpdatedAt = DateTime.UtcNow.AddDays(-11) }
            );

            // 40. Semester
            modelBuilder.Entity<Semester>().HasData(
                new Semester { Id = 1, Name = "HK2-2025", StartDate = new DateTime(2025, 2, 1), EndDate = new DateTime(2025, 6, 30), CreatedAt = DateTime.UtcNow },
                new Semester { Id = 2, Name = "HK1-2025", StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 4, 30), CreatedAt = DateTime.UtcNow },
                new Semester { Id = 3, Name = "HK3-2025", StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 10, 31), CreatedAt = DateTime.UtcNow }
            );

            // 41 StudentCourse 
            modelBuilder.Entity<StudentCourse>().HasData(
                // Nhóm 1 (Project 1, Course 1)
                new StudentCourse { Id = 1, StudentId = 7, CourseId = 1, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 2, StudentId = 8, CourseId = 1, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 3, StudentId = 9, CourseId = 1, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 2 (Project 2, Course 1)
                new StudentCourse { Id = 4, StudentId = 10, CourseId = 1, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 5, StudentId = 11, CourseId = 1, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 3 (Project 3, Course 2)
                new StudentCourse { Id = 6, StudentId = 12, CourseId = 2, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 7, StudentId = 13, CourseId = 2, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 4 (Project 4, Course 3)
                new StudentCourse { Id = 8, StudentId = 7, CourseId = 3, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 9, StudentId = 8, CourseId = 3, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 5 (Project 5, Course 4)
                new StudentCourse { Id = 10, StudentId = 9, CourseId = 4, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 11, StudentId = 10, CourseId = 4, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 6 (Project 6, Course 5)
                new StudentCourse { Id = 12, StudentId = 11, CourseId = 5, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 13, StudentId = 12, CourseId = 5, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 7 (Project 7, Course 6)
                new StudentCourse { Id = 14, StudentId = 13, CourseId = 6, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 15, StudentId = 7, CourseId = 6, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 8 (Project 8, Course 7)
                new StudentCourse { Id = 16, StudentId = 8, CourseId = 7, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 17, StudentId = 9, CourseId = 7, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 9 (Project 9, Course 8)
                new StudentCourse { Id = 18, StudentId = 10, CourseId = 8, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 19, StudentId = 11, CourseId = 8, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 10 (Project 10, Course 9)
                new StudentCourse { Id = 20, StudentId = 12, CourseId = 9, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 21, StudentId = 13, CourseId = 9, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 11 (Project 11, Course 10)
                new StudentCourse { Id = 22, StudentId = 7, CourseId = 10, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 23, StudentId = 8, CourseId = 10, Status = "COMPLETED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 12 (Project 12, Course 11)
                new StudentCourse { Id = 24, StudentId = 9, CourseId = 11, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 25, StudentId = 10, CourseId = 11, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                // Nhóm 13 (Project 13, Course 12)
                new StudentCourse { Id = 26, StudentId = 11, CourseId = 12, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new StudentCourse { Id = 27, StudentId = 12, CourseId = 12, Status = "ENROLLED", EnrolledAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // 42 RolePermissions
            modelBuilder.Entity<RolePermission>().HasData(
                new RolePermission { Id = 1, RoleId = 1, ViewUsers = true, EditUsers = true, ViewProjects = true, EditProjects = true, ViewGrading = true, EditGrading = true, UpdatedAt = DateTime.UtcNow },
                new RolePermission { Id = 2, RoleId = 2, ViewUsers = false, EditUsers = false, ViewProjects = true, EditProjects = false, ViewGrading = false, EditGrading = false, UpdatedAt = DateTime.UtcNow },
                new RolePermission { Id = 3, RoleId = 3, ViewUsers = false, EditUsers = false, ViewProjects = true, EditProjects = false, ViewGrading = false, EditGrading = false, UpdatedAt = DateTime.UtcNow },
                new RolePermission { Id = 4, RoleId = 4, ViewUsers = false, EditUsers = false, ViewProjects = true, EditProjects = false, ViewGrading = false, EditGrading = false, UpdatedAt = DateTime.UtcNow }
            );

            // 43. Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, FacultyCode = "CNPM", FacultyName = "Công nghệ phần mềm" },
                new Department { Id = 2, FacultyCode = "ATTT", FacultyName = "An toàn thông tin" },
                new Department { Id = 3, FacultyCode = "MMT", FacultyName = "Mạng máy tính" }
            );
        }
    }
}