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
    public class HeadGradeCriteriaService
    {
        private readonly ApplicationDbContext _context;

        public HeadGradeCriteriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HeadGradeCriteriaDto>> GetAllGradeCriteriaAsync(long headLecturerId, long? courseId = null)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            var query = _context.GradeCriteria
                .Include(gc => gc.Course)
                    .ThenInclude(c => c.Department)
                .Where(gc => gc.Course.DepartmentId == headLecturer.DepartmentId);

            if (courseId.HasValue)
                query = query.Where(gc => gc.CourseId == courseId.Value);

            return await query
                .Select(gc => new HeadGradeCriteriaDto
                {
                    Id = gc.Id,
                    CourseId = gc.CourseId,
                    CourseName = gc.Course.Name,
                    DepartmentId = gc.Course.DepartmentId,
                    FacultyCode = gc.Course.Department.FacultyCode,
                    Name = gc.Name,
                    Weight = gc.Weight,
                    Description = gc.Description
                })
                .OrderBy(gc => gc.CourseId)
                .ThenBy(gc => gc.Name)
                .ToListAsync();
        }

        public async Task<List<CourseDto>> GetCoursesAsync(long headLecturerId)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            return await _context.Courses
                .Include(c => c.Department)
                .Where(c => c.DepartmentId == headLecturer.DepartmentId)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CourseCode = c.CourseCode,
                    DepartmentId = c.DepartmentId,
                    FacultyCode = c.Department.FacultyCode
                })
                .ToListAsync();
        }

        public async Task<HeadGradeCriteriaDto> CreateGradeCriteriaAsync(long headLecturerId, GradeCriteria gradeCriteria)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            var course = await _context.Courses
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.Id == gradeCriteria.CourseId);
            if (course == null) throw new Exception("Môn học không tồn tại.");
            if (course.DepartmentId != headLecturer.DepartmentId)
                throw new Exception("Không có quyền tạo tiêu chí cho môn học thuộc khoa khác.");

            if (await _context.GradeCriteria.AnyAsync(gc => gc.Name == gradeCriteria.Name && gc.CourseId == gradeCriteria.CourseId))
                throw new Exception($"Tiêu chí '{gradeCriteria.Name}' đã tồn tại.");

            var totalWeight = await _context.GradeCriteria
                .Where(gc => gc.CourseId == gradeCriteria.CourseId)
                .SumAsync(gc => gc.Weight);
            if (totalWeight + gradeCriteria.Weight > 1.0f)
                throw new Exception("Tổng trọng số vượt quá 100%.");

            _context.GradeCriteria.Add(gradeCriteria);
            await _context.SaveChangesAsync();

            return await _context.GradeCriteria
                .Include(gc => gc.Course)
                    .ThenInclude(c => c.Department)
                .Where(gc => gc.Id == gradeCriteria.Id)
                .Select(gc => new HeadGradeCriteriaDto
                {
                    Id = gc.Id,
                    CourseId = gc.CourseId,
                    CourseName = gc.Course.Name,
                    DepartmentId = gc.Course.DepartmentId,
                    FacultyCode = gc.Course.Department.FacultyCode,
                    Name = gc.Name,
                    Weight = gc.Weight,
                    Description = gc.Description
                })
                .FirstOrDefaultAsync();
        }

        public async System.Threading.Tasks.Task UpdateGradeCriteriaAsync(long headLecturerId, GradeCriteria gradeCriteria)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            var existingCriteria = await _context.GradeCriteria
                .Include(gc => gc.Course)
                    .ThenInclude(c => c.Department)
                .FirstOrDefaultAsync(gc => gc.Id == gradeCriteria.Id);
            if (existingCriteria == null) throw new Exception("Tiêu chí không tồn tại.");
            if (existingCriteria.Course.DepartmentId != headLecturer.DepartmentId)
                throw new Exception("Không có quyền sửa tiêu chí của khoa khác.");

            if (gradeCriteria.CourseId != existingCriteria.CourseId &&
                await _context.GradeCriteria.AnyAsync(gc => gc.Name == gradeCriteria.Name && gc.CourseId == gradeCriteria.CourseId))
                throw new Exception($"Tiêu chí '{gradeCriteria.Name}' đã tồn tại.");

            var totalWeight = await _context.GradeCriteria
                .Where(gc => gc.CourseId == gradeCriteria.CourseId && gc.Id != gradeCriteria.Id)
                .SumAsync(gc => gc.Weight);
            if (totalWeight + gradeCriteria.Weight > 1.0f)
                throw new Exception("Tổng trọng số vượt quá 100%.");

            existingCriteria.Name = gradeCriteria.Name;
            existingCriteria.Weight = gradeCriteria.Weight;
            existingCriteria.Description = gradeCriteria.Description;
            existingCriteria.CourseId = gradeCriteria.CourseId;
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteGradeCriteriaAsync(long headLecturerId, long id)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            var gradeCriteria = await _context.GradeCriteria
                .Include(gc => gc.Course)
                    .ThenInclude(c => c.Department)
                .FirstOrDefaultAsync(gc => gc.Id == id);
            if (gradeCriteria == null) throw new Exception("Tiêu chí không tồn tại.");
            if (gradeCriteria.Course.DepartmentId != headLecturer.DepartmentId)
                throw new Exception("Không có quyền xóa tiêu chí của khoa khác.");

            if (await _context.Grades.AnyAsync(g => g.CriteriaId == id))
                throw new Exception("Tiêu chí đã được sử dụng, không thể xóa.");

            _context.GradeCriteria.Remove(gradeCriteria);
            await _context.SaveChangesAsync();
        }

        public async Task<ImportResult> ImportGradeCriteriaAsync(long headLecturerId, List<GradeCriteria> gradeCriteriaList)
        {
            var headLecturer = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == headLecturerId);
            if (headLecturer == null || headLecturer.Role.Name != "ROLE_HEAD")
                throw new Exception("Trưởng bộ môn không tồn tại hoặc không có quyền.");

            var results = new List<HeadGradeCriteriaDto>();
            var errors = new List<string>();
            int successCount = 0;

            foreach (var gradeCriteria in gradeCriteriaList)
            {
                try
                {
                    var course = await _context.Courses
                        .Include(c => c.Department)
                        .FirstOrDefaultAsync(c => c.Id == gradeCriteria.CourseId);
                    if (course == null)
                        throw new Exception($"Môn học ID {gradeCriteria.CourseId} không tồn tại.");
                    if (course.DepartmentId != headLecturer.DepartmentId)
                        throw new Exception($"Không có quyền nhập tiêu chí cho môn học {course.Name}.");

                    if (await _context.GradeCriteria.AnyAsync(gc => gc.Name == gradeCriteria.Name && gc.CourseId == gradeCriteria.CourseId))
                        throw new Exception($"Tiêu chí '{gradeCriteria.Name}' đã tồn tại.");

                    var totalWeight = await _context.GradeCriteria
                        .Where(gc => gc.CourseId == gradeCriteria.CourseId)
                        .SumAsync(gc => gc.Weight);
                    if (totalWeight + gradeCriteria.Weight > 1.0f)
                        throw new Exception($"Tổng trọng số cho môn học {course.Name} vượt quá 100%.");

                    _context.GradeCriteria.Add(gradeCriteria);
                    await _context.SaveChangesAsync();
                    successCount++;

                    var createdCriteria = await _context.GradeCriteria
                        .Include(gc => gc.Course)
                            .ThenInclude(c => c.Department)
                        .Where(gc => gc.Id == gradeCriteria.Id)
                        .Select(gc => new HeadGradeCriteriaDto
                        {
                            Id = gc.Id,
                            CourseId = gc.CourseId,
                            CourseName = gc.Course.Name,
                            DepartmentId = gc.Course.DepartmentId,
                            FacultyCode = gc.Course.Department.FacultyCode,
                            Name = gc.Name,
                            Weight = gc.Weight,
                            Description = gc.Description
                        })
                        .FirstOrDefaultAsync();

                    results.Add(createdCriteria);
                }
                catch (Exception ex)
                {
                    errors.Add($"Lỗi khi nhập tiêu chí '{gradeCriteria.Name}' (CourseId: {gradeCriteria.CourseId}): {ex.Message}");
                }
            }

            return new ImportResult
            {
                SuccessCount = successCount,
                FailedCount = gradeCriteriaList.Count - successCount,
                Errors = errors
            };
        }
    }

    public class CourseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public long DepartmentId { get; set; }
        public string FacultyCode { get; set; }
    }
}