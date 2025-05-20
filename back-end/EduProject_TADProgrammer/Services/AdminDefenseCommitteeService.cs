// File: Services/DefenseCommitteeService.cs
// Mục đích: Xử lý logic nghiệp vụ cho hội đồng chấm điểm.
// Hỗ trợ chức năng: 
//   19: Admin - Thành lập hội đồng chấm điểm
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduProject_TADProgrammer.Services
{
    public class AdminDefenseCommitteeService
    {
        private readonly ApplicationDbContext _context;

        public AdminDefenseCommitteeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách hội đồng
        public async Task<List<AdminDefenseCommitteesDto>> GetAllCommittees()
        {
            return await _context.DefenseCommittees
                .Include(dc => dc.Semester)
                .Include(dc => dc.CommitteeMembers)
                    .ThenInclude(cm => cm.Lecturer)
                .Select(dc => new AdminDefenseCommitteesDto
                {
                    Id = dc.Id,
                    Name = dc.Name,
                    SemesterId = dc.SemesterId,
                    SemesterName = dc.Semester.Name,
                    Members = dc.CommitteeMembers.Select(cm => new AdminDefenseCommitteesMemberDto
                    {
                        LecturerId = cm.LecturerId,
                        FullName = cm.Lecturer.FullName,
                        Role = cm.Role
                    }).ToList()
                })
                .ToListAsync();
        }

        // Lấy hội đồng theo ID
        public async Task<AdminDefenseCommitteesDto> GetCommitteeById(long id)
        {
            var committee = await _context.DefenseCommittees
                .Include(dc => dc.Semester)
                .Include(dc => dc.CommitteeMembers)
                    .ThenInclude(cm => cm.Lecturer)
                .FirstOrDefaultAsync(dc => dc.Id == id);

            if (committee == null) return null;

            return new AdminDefenseCommitteesDto
            {
                Id = committee.Id,
                Name = committee.Name,
                SemesterId = committee.SemesterId,
                SemesterName = committee.Semester.Name,
                Members = committee.CommitteeMembers.Select(cm => new AdminDefenseCommitteesMemberDto
                {
                    LecturerId = cm.LecturerId,
                    FullName = cm.Lecturer.FullName,
                    Role = cm.Role
                }).ToList()
            };
        }

        // Thêm hội đồng mới
        public async Task<AdminDefenseCommitteesDto> CreateCommittee(CreateAdminDefenseCommitteeRequest request)
        {
            // Kiểm tra tên hội đồng đã tồn tại
            if (await _context.DefenseCommittees.AnyAsync(dc => dc.Name == request.Name))
                throw new Exception("Tên hội đồng đã tồn tại.");

            // Kiểm tra kỳ học hợp lệ
            if (!await _context.Semesters.AnyAsync(s => s.Id == request.SemesterId))
                throw new Exception("Kỳ học không hợp lệ.");

            // Kiểm tra giảng viên hợp lệ
            var lecturers = await _context.Users
                .Where(u => request.Members.Select(m => m.LecturerId).Contains(u.Id) && (u.RoleId == 2 || u.RoleId == 4))
                .ToListAsync();
            if (lecturers.Count != request.Members.Count)
                throw new Exception("Một hoặc nhiều giảng viên không hợp lệ.");

            // Kiểm tra vai trò hợp lệ
            var validRoles = new[] { "Chủ tịch", "Thư ký", "Thành viên" };
            if (request.Members.Any(m => !validRoles.Contains(m.Role)))
                throw new Exception("Vai trò không hợp lệ. Chỉ chấp nhận: Chủ tịch, Thư ký, Thành viên.");

            var committee = new DefenseCommittee
            {
                Name = request.Name,
                SemesterId = request.SemesterId,
                CommitteeMembers = request.Members.Select(m => new CommitteeMember
                {
                    LecturerId = m.LecturerId,
                    Role = m.Role
                }).ToList()
            };

            _context.DefenseCommittees.Add(committee);
            await _context.SaveChangesAsync();

            return await GetCommitteeById(committee.Id);
        }

        // Cập nhật hội đồng
        public async System.Threading.Tasks.Task UpdateCommittee(long id, UpdateAdminDefenseCommitteeRequest request)
        {
            var committee = await _context.DefenseCommittees
                .Include(dc => dc.CommitteeMembers)
                .FirstOrDefaultAsync(dc => dc.Id == id);
            if (committee == null)
                throw new Exception("Hội đồng không tồn tại.");

            // Kiểm tra tên hội đồng trùng lặp
            if (await _context.DefenseCommittees.AnyAsync(dc => dc.Name == request.Name && dc.Id != id))
                throw new Exception("Tên hội đồng đã tồn tại.");

            // Kiểm tra kỳ học hợp lệ
            if (!await _context.Semesters.AnyAsync(s => s.Id == request.SemesterId))
                throw new Exception("Kỳ học không hợp lệ.");

            // Kiểm tra giảng viên hợp lệ
            var lecturers = await _context.Users
                .Where(u => request.Members.Select(m => m.LecturerId).Contains(u.Id) && (u.RoleId == 2 || u.RoleId == 4))
                .ToListAsync();
            if (lecturers.Count != request.Members.Count)
                throw new Exception("Một hoặc nhiều giảng viên không hợp lệ.");

            // Kiểm tra vai trò hợp lệ
            var validRoles = new[] { "Chủ tịch", "Thư ký", "Thành viên" };
            if (request.Members.Any(m => !validRoles.Contains(m.Role)))
                throw new Exception("Vai trò không hợp lệ. Chỉ chấp nhận: Chủ tịch, Thư ký, Thành viên.");

            committee.Name = request.Name;
            committee.SemesterId = request.SemesterId;
            committee.UpdatedAt = DateTime.UtcNow;

            _context.CommitteeMembers.RemoveRange(committee.CommitteeMembers);
            committee.CommitteeMembers = request.Members.Select(m => new CommitteeMember
            {
                CommitteeId = committee.Id,
                LecturerId = m.LecturerId,
                Role = m.Role
            }).ToList();

            await _context.SaveChangesAsync();
        }

        // Xóa hội đồng
        public async System.Threading.Tasks.Task DeleteCommittee(long id)
        {
            var committee = await _context.DefenseCommittees.FindAsync(id);
            if (committee == null)
                throw new Exception("Hội đồng không tồn tại.");

            _context.DefenseCommittees.Remove(committee);
            await _context.SaveChangesAsync();
        }
    }
}