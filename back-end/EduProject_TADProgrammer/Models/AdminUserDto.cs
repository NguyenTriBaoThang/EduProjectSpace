using System;

namespace EduProject_TADProgrammer.Models
{
    public class AdminUserDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public string? FacultyCode { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public int FailedLoginAttempts { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateAdminUserRequest
    {
        public string Username { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateAdminUserRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }

    public class CreateAdminUserStudentRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long? DepartmentId { get; set; }
    }

    public class UpdateAdminUserStudentRequest
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public bool Locked { get; set; }
        public string? Password { get; set; }
    }

    public class CreateAdminUserLecturerRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public long RoleId { get; set; }
    }

    public class UpdateAdminUserLecturerRequest
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string? ClassCode { get; set; }
        public long? DepartmentId { get; set; }
        public long RoleId { get; set; }
        public string? Password { get; set; }
        public bool Locked { get; set; }
    }
}