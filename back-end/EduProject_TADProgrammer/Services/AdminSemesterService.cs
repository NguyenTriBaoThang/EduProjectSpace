using Microsoft.EntityFrameworkCore;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using EduProject_TADProgrammer.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;

namespace EduProject_TADProgrammer.Services
{
    public class AdminSemesterService
    {
        private readonly ApplicationDbContext _context;

        public AdminSemesterService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả kỳ học, ánh xạ sang SemesterDto.
        public async Task<List<AdminSemesterDto>> GetAllSemesters()
        {
            return await _context.Semesters
                .Select(s => new AdminSemesterDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Status = DateTime.UtcNow > s.EndDate ? "Kết thúc" : "Hoạt động",
                    CreatedAt = s.CreatedAt,
                    //UpdatedAt = s.UpdatedAt,
                    Description = s.Description
                })
                .ToListAsync();
        }

        // Lấy kỳ học theo ID, ánh xạ sang SemesterDto.
        public async Task<AdminSemesterDto> GetSemesterById(long id)
        {
            var semester = await _context.Semesters
                .FirstOrDefaultAsync(s => s.Id == id);
            if (semester == null)
                return null;

            return new AdminSemesterDto
            {
                Id = semester.Id,
                Name = semester.Name,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate,
                Status = DateTime.UtcNow > semester.EndDate ? "Kết thúc" : "Hoạt động",
                CreatedAt = semester.CreatedAt,
                //UpdatedAt = semester.UpdatedAt,
                Description = semester.Description
            };
        }

        // Lấy kỳ học theo ID (entity).
        public async Task<Semester> GetById(long id)
        {
            return await _context.Semesters
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Tạo kỳ học mới, kiểm tra trùng Name.
        public async Task<AdminSemesterDto> CreateSemester(Semester semester)
        {
            if (await _context.Semesters.AnyAsync(s => s.Name == semester.Name))
                throw new System.Exception("Tên kỳ học đã tồn tại.");

            //semester.UpdatedAt = DateTime.UtcNow;
            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();

            var createdSemester = await _context.Semesters
                .FirstOrDefaultAsync(s => s.Id == semester.Id);
            return new AdminSemesterDto
            {
                Id = createdSemester.Id,
                Name = createdSemester.Name,
                StartDate = createdSemester.StartDate,
                EndDate = createdSemester.EndDate,
                Status = DateTime.UtcNow > createdSemester.EndDate ? "Kết thúc" : "Hoạt động",
                CreatedAt = createdSemester.CreatedAt,
                //UpdatedAt = createdSemester.UpdatedAt,
                Description = createdSemester.Description
            };
        }

        // Cập nhật thông tin kỳ học, kiểm tra trùng Name.
        public async System.Threading.Tasks.Task UpdateSemester(Semester semester)
        {
            if (await _context.Semesters.AnyAsync(s => s.Name == semester.Name && s.Id != semester.Id))
                throw new System.Exception("Tên kỳ học đã tồn tại.");

            //semester.UpdatedAt = DateTime.UtcNow;
            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        // Xóa kỳ học.
        public async System.Threading.Tasks.Task DeleteSemester(long id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester != null)
            {
                _context.Semesters.Remove(semester);
                await _context.SaveChangesAsync();
            }
        }

        // Xuất danh sách kỳ học sang Excel.
        public async Task<MemoryStream> ExportSemestersToExcelAsync()
        {
            var semesters = await GetAllSemesters();
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("DanhSachKyHoc");
                worksheet.Cells[1, 1].Value = "Danh sách kỳ học - Hệ thống Sinh viên HUTECH";
                worksheet.Cells[3, 1].Value = "#";
                worksheet.Cells[3, 2].Value = "Mã kỳ học";
                worksheet.Cells[3, 3].Value = "Tên kỳ học";
                worksheet.Cells[3, 4].Value = "Ngày bắt đầu";
                worksheet.Cells[3, 5].Value = "Ngày kết thúc";
                worksheet.Cells[3, 6].Value = "Trạng thái";

                for (int i = 0; i < semesters.Count; i++)
                {
                    var row = i + 4;
                    worksheet.Cells[row, 1].Value = i + 1;
                    worksheet.Cells[row, 2].Value = semesters[i].Name;
                    worksheet.Cells[row, 3].Value = semesters[i].Name;
                    worksheet.Cells[row, 4].Value = semesters[i].StartDate.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 5].Value = semesters[i].EndDate.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 6].Value = semesters[i].Status;
                }

                worksheet.Cells.AutoFitColumns();
                await package.SaveAsync();
            }

            stream.Position = 0;
            return stream;
        }
    }
}