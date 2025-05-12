using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduProject_TADProgrammer.Services;
using System;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace EduProject_TADProgrammer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        // API GET để lấy toàn bộ danh sách log
        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                var logs = await _logService.GetAllLogs();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi tải danh sách log: " + ex.Message });
            }
        }

        // API GET để lấy 5 log gần nhất
        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentLogs()
        {
            try
            {
                var logs = await _logService.GetRecentLogs();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi tải log gần nhất: " + ex.Message });
            }
        }

        // API GET để xuất danh sách log sang Excel
        [HttpGet("export")]
        public async Task<IActionResult> ExportLogs(
            [FromQuery] string search = "",
            [FromQuery] string roleFilter = "",
            [FromQuery] string actionFilter = "")
        {
            try
            {
                var filteredLogs = await _logService.GetLogsForExport(search, roleFilter, actionFilter);

                if (filteredLogs == null || !filteredLogs.Any())
                {
                    return Ok("Không có dữ liệu để xuất.");
                }

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("LichSuHoatDong");

                worksheet.Cell(1, 1).Value = "Lịch sử hoạt động - Hệ thống Sinh viên HUTECH";
                worksheet.Range("A1:F1").Merge().Style.Font.Bold = true;

                var headers = new[] { "#", "Thời gian", "Người dùng", "Vai trò", "Hành động", "Chi tiết" };
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cell(3, i + 1).Value = headers[i];
                    worksheet.Cell(3, i + 1).Style.Font.Bold = true;
                }

                for (int i = 0; i < filteredLogs.Count; i++)
                {
                    var log = filteredLogs[i];
                    worksheet.Cell(i + 4, 1).Value = i + 1;

                    // Ép kiểu Timestamp thành DateTime và định dạng
                    var timestampValue = log.GetType().GetProperty("CreatedAt")?.GetValue(log);
                    string timestampStr = timestampValue != null && timestampValue is DateTime
                        ? ((DateTime)timestampValue).ToString("dd/MM/yyyy HH:mm")
                        : "N/A";

                    worksheet.Cell(i + 4, 2).Value = timestampStr;
                    worksheet.Cell(i + 4, 3).Value = log.GetType().GetProperty("FullName")?.GetValue(log)?.ToString() ?? "N/A";
                    worksheet.Cell(i + 4, 4).Value = log.GetType().GetProperty("RoleName")?.GetValue(log)?.ToString().Replace("ROLE_", "") ?? "N/A";
                    worksheet.Cell(i + 4, 5).Value = log.GetType().GetProperty("Action")?.GetValue(log)?.ToString() ?? "N/A";
                    worksheet.Cell(i + 4, 6).Value = log.GetType().GetProperty("Details")?.GetValue(log)?.ToString() ?? "N/A";
                }

                worksheet.Columns().AdjustToContents();

                using var stream = new System.IO.MemoryStream();
                workbook.SaveAs(stream);
                var fileContent = stream.ToArray();

                var fileName = "lich_su_hoat_dong.xlsx";
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xuất file Excel: " + ex.Message });
            }
        }
    }
}