using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Entities;
using EduProject_TADProgrammer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Calendar.v3.Data;
using Newtonsoft.Json;

namespace EduProject_TADProgrammer.Services
{
    public class HeadDefenseScheduleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public HeadDefenseScheduleService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<HeadDefenseScheduleDto> GetDefenseSchedules()
        {
            return _context.DefenseSchedules
                .Include(ds => ds.Project)
                .Include(ds => ds.Project.Group)
                .Include(ds => ds.Meeting)
                .Select(ds => new HeadDefenseScheduleDto
                {
                    Id = ds.Id,
                    ProjectId = ds.ProjectId,
                    ProjectTitle = ds.Project != null ? ds.Project.Title : "Không xác định",
                    GroupName = ds.Project != null && ds.Project.Group != null ? ds.Project.Group.Name : "Không xác định",
                    StartTime = ds.StartTime,
                    EndTime = ds.EndTime,
                    Room = ds.Room,
                    MeetingId = ds.MeetingId,
                    MeetingLocation = ds.MeetingId.HasValue && ds.Meeting != null ? ds.Meeting.Location : "",
                    CreatedAt = ds.CreatedAt
                })
                .OrderBy(dto => dto.StartTime)
                .ToList();
        }

        public int GetTotalDefenseSchedules()
        {
            return _context.DefenseSchedules.Count();
        }

        public HeadDefenseScheduleDto CreateDefenseSchedule(CreateHeadDefenseScheduleDto dto)
        {
            // Kiểm tra dữ liệu đầu vào
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Dữ liệu đầu vào không được null.");
            if (dto.StartTime >= dto.EndTime)
                throw new ArgumentException("Thời gian bắt đầu phải sớm hơn thời gian kết thúc.");
            if (string.IsNullOrWhiteSpace(dto.Room))
                throw new ArgumentException("Phòng không được để trống.");

            Console.WriteLine($"Dữ liệu đầu vào: {JsonConvert.SerializeObject(dto, Formatting.Indented)}");

            var project = _context.Projects
                .Include(p => p.Group)
                .FirstOrDefault(p => p.Id == dto.ProjectId);
            if (project == null)
                throw new KeyNotFoundException($"Không tìm thấy dự án với ID {dto.ProjectId}.");

            var meeting = CreateGoogleMeetMeeting(project, dto.StartTime, dto.EndTime);

            var defenseSchedule = new DefenseSchedule
            {
                ProjectId = dto.ProjectId,
                Project = project,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Room = dto.Room,
                MeetingId = meeting.Id,
                Meeting = meeting,
                CreatedAt = DateTime.UtcNow
            };
            _context.DefenseSchedules.Add(defenseSchedule);
            _context.SaveChanges();

            return new HeadDefenseScheduleDto
            {
                Id = defenseSchedule.Id,
                ProjectId = defenseSchedule.ProjectId,
                ProjectTitle = project.Title,
                GroupName = project.Group != null ? project.Group.Name : "Không xác định",
                StartTime = defenseSchedule.StartTime,
                EndTime = defenseSchedule.EndTime,
                Room = defenseSchedule.Room,
                MeetingId = defenseSchedule.MeetingId,
                MeetingLocation = meeting.Location,
                CreatedAt = defenseSchedule.CreatedAt
            };
        }

        private Meeting CreateGoogleMeetMeeting(Project project, DateTime startTime, DateTime endTime)
        {
            // Kiểm tra thời gian đầu vào
            if (startTime >= endTime)
                throw new ArgumentException("Thời gian bắt đầu phải sớm hơn thời gian kết thúc.");

            // Ghi log thời gian đầu vào
            Console.WriteLine($"Thời gian đầu vào: Start={startTime:yyyy-MM-ddTHH:mm:sszzz}, End={endTime:yyyy-MM-ddTHH:mm:sszzz}");

            // Lấy đường dẫn từ appsettings.json
            var credentialPath = _configuration["GoogleCredentialPath"]
                ?? throw new InvalidOperationException("Không tìm thấy đường dẫn tệp thông tin xác thực Google trong cấu hình.");

            // Chuyển đổi đường dẫn tương đối thành đường dẫn tuyệt đối
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var fullCredentialPath = Path.Combine(basePath, credentialPath);

            if (!File.Exists(fullCredentialPath))
                throw new FileNotFoundException($"Tệp thông tin xác thực không tồn tại tại: {fullCredentialPath}");

            // Ghi log đường dẫn tệp
            Console.WriteLine($"Đường dẫn tệp thông tin xác thực: {fullCredentialPath}");

            var credential = GoogleCredential.FromFile(fullCredentialPath)
                .CreateScoped(CalendarService.Scope.Calendar);

            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "EduProject_TADProgrammer"
            });

            // Tạo sự kiện Google Calendar
            var calendarEvent = new Event
            {
                Summary = $"Buổi bảo vệ đồ án - {project.ProjectCode}",
                Description = $"Buổi bảo vệ đồ án cho nhóm {project.Group?.Name ?? "Không xác định"}",
                Start = new EventDateTime
                {
                    DateTime = startTime,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                End = new EventDateTime
                {
                    DateTime = endTime,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                ConferenceData = new ConferenceData
                {
                    CreateRequest = new CreateConferenceRequest
                    {
                        RequestId = Guid.NewGuid().ToString(),
                        ConferenceSolutionKey = new ConferenceSolutionKey
                        {
                            Type = "hangoutsMeet" // Sử dụng "hangoutsMeet" để tạo Google Meet
                        }
                    }
                }
            };

            try
            {
                // Ghi log dữ liệu sự kiện
                Console.WriteLine($"Tạo sự kiện: {JsonConvert.SerializeObject(calendarEvent, Formatting.Indented)}");

                // Sử dụng lịch "primary"
                string calendarId = "primary"; // Thay bằng ID lịch cụ thể nếu cần, ví dụ: "your_calendar_id@group.calendar.google.com"
                Console.WriteLine($"Lịch được sử dụng: {calendarId}");
                var request = service.Events.Insert(calendarEvent, calendarId);
                request.ConferenceDataVersion = 1;
                var createdEvent = request.Execute();

                // Ghi log toàn bộ sự kiện được tạo
                Console.WriteLine($"Sự kiện được tạo: {JsonConvert.SerializeObject(createdEvent, Formatting.Indented)}");

                if (string.IsNullOrEmpty(createdEvent.HangoutLink))
                {
                    Console.WriteLine("Không tạo được liên kết Google Meet. Kiểm tra ConferenceData và quyền tài khoản.");
                    throw new Exception("Không tạo được liên kết Google Meet.");
                }

                // Ghi log liên kết Google Meet
                Console.WriteLine($"Liên kết Google Meet: {createdEvent.HangoutLink}");

                var meeting = new Meeting
                {
                    GroupId = project.GroupId,
                    Title = $"Buổi bảo vệ đồ án {project.ProjectCode}",
                    StartTime = startTime,
                    EndTime = endTime,
                    Location = createdEvent.HangoutLink,
                    CreatedBy = 1,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Meetings.Add(meeting);
                _context.SaveChanges();

                return meeting;
            }
            catch (Google.GoogleApiException ex)
            {
                // Ghi log chi tiết lỗi
                Console.WriteLine($"Lỗi Google API: {ex.Message}");
                Console.WriteLine($"Chi tiết: {ex.Error?.Message}");
                Console.WriteLine($"Mã lỗi: {ex.Error?.Code}");
                Console.WriteLine($"Lý do: {ex.Error?.Errors?.FirstOrDefault()?.Reason}");
                throw new Exception($"Lỗi Google API: {ex.Message}, Chi tiết: {ex.Error?.Message}, Mã lỗi: {ex.Error?.Code}, Lý do: {ex.Error?.Errors?.FirstOrDefault()?.Reason}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không xác định: {ex.Message}, StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        public HeadDefenseScheduleDto UpdateDefenseSchedule(long id, UpdateHeadDefenseScheduleDto dto)
        {
            var defenseSchedule = _context.DefenseSchedules
                .Include(ds => ds.Project)
                .Include(ds => ds.Project.Group)
                .Include(ds => ds.Meeting)
                .FirstOrDefault(ds => ds.Id == id);
            if (defenseSchedule == null)
                throw new KeyNotFoundException("Không tìm thấy lịch bảo vệ.");

            if (dto.StartTime >= dto.EndTime)
                throw new ArgumentException("Thời gian bắt đầu phải sớm hơn thời gian kết thúc.");

            defenseSchedule.StartTime = dto.StartTime;
            defenseSchedule.EndTime = dto.EndTime;
            defenseSchedule.Room = dto.Room;

            if (defenseSchedule.MeetingId.HasValue && defenseSchedule.Meeting != null)
            {
                defenseSchedule.Meeting.StartTime = dto.StartTime;
                defenseSchedule.Meeting.EndTime = dto.EndTime;
                _context.SaveChanges();
            }

            return new HeadDefenseScheduleDto
            {
                Id = defenseSchedule.Id,
                ProjectId = defenseSchedule.ProjectId,
                ProjectTitle = defenseSchedule.Project != null ? defenseSchedule.Project.Title : "Không xác định",
                GroupName = defenseSchedule.Project != null && defenseSchedule.Project.Group != null ? defenseSchedule.Project.Group.Name : "Không xác định",
                StartTime = defenseSchedule.StartTime,
                EndTime = defenseSchedule.EndTime,
                Room = defenseSchedule.Room,
                MeetingId = defenseSchedule.MeetingId,
                MeetingLocation = defenseSchedule.MeetingId.HasValue && defenseSchedule.Meeting != null ? defenseSchedule.Meeting.Location : "",
                CreatedAt = defenseSchedule.CreatedAt
            };
        }

        public void DeleteDefenseSchedule(long id)
        {
            var defenseSchedule = _context.DefenseSchedules
                .Include(ds => ds.Meeting)
                .FirstOrDefault(ds => ds.Id == id);
            if (defenseSchedule == null)
                throw new KeyNotFoundException("Không tìm thấy lịch bảo vệ.");

            if (defenseSchedule.MeetingId.HasValue && defenseSchedule.Meeting != null)
            {
                _context.Meetings.Remove(defenseSchedule.Meeting);
            }

            _context.DefenseSchedules.Remove(defenseSchedule);
            _context.SaveChanges();
        }
    }
}