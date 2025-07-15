using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EduProject_TADProgrammer.Data;
using EduProject_TADProgrammer.Middleware;
using EduProject_TADProgrammer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Thêm ApplicationDbContext với SQL Server
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                   .EnableSensitiveDataLogging()
                   .EnableDetailedErrors());

        // Thêm dịch vụ MVC và Razor Pages
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllersWithViews();

        // Thêm Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Thêm các dịch vụ
        builder.Services.AddScoped<JwtService>();
        builder.Services.AddScoped<LogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<CourseOptionsService>();
        builder.Services.AddHostedService<DeadlineReminderService>();

        builder.Services.AddScoped<AdminUserService>();
        builder.Services.AddScoped<AdminRoleService>();
        builder.Services.AddScoped<AdminCourseService>();
        builder.Services.AddScoped<AdminReportService>();
        builder.Services.AddScoped<AdminProjectService>();
        builder.Services.AddScoped<AdminSemesterService>();
        builder.Services.AddScoped<AdminDashboardService>();
        builder.Services.AddScoped<AdminRolePermissionService>();
        builder.Services.AddScoped<AdminDefenseCommitteeService>();
        
        builder.Services.AddScoped<HeadLecturerService>();
        builder.Services.AddScoped<HeadDashboardService>();
        builder.Services.AddScoped<HeadCourseGradingService>();
        builder.Services.AddScoped<HeadGradeCriteriaService>();
        builder.Services.AddScoped<HeadDefenseScheduleService>();
        builder.Services.AddScoped<HeadProgressCoursesService>();
        builder.Services.AddScoped<HeadCourseAssignmentService>();

        builder.Services.AddScoped<LecturerTaskService>();
        builder.Services.AddScoped<LecturerReviewService>();
        builder.Services.AddScoped<LecturerCourseService>();
        builder.Services.AddScoped<LecturerFeedbackService>();
        builder.Services.AddScoped<LecturerResourcesService>();
        builder.Services.AddScoped<LecturerDashboardService>();
        builder.Services.AddScoped<LecturerCourseGroupService>();
        builder.Services.AddScoped<LecturerProjectApprovalService>();

        builder.Services.AddScoped<StudentCourseService>();
        builder.Services.AddScoped<StudentDashboardService>();

        builder.Services.AddHttpClient<LecturerResourcesService>();
        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

        // Thêm CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyAllowOrigins", policy =>
            {
                policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500", "http://localhost:3000", "http://localhost:8080", "http://localhost:5000")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials(); //hỗ trợ HttpOnly cookie
            });
        });

        builder.Services.AddLogging(logging =>
        {
            logging.AddConsole();
            logging.AddDebug();
        });

        // Cấu hình JWT Authentication AddJwtBearer
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["token"];
                    return Task.CompletedTask;
                }
            };
        });

        var app = builder.Build();

        // Cấu hình pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        //app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors("MyAllowOrigins");
        //app.UseMiddleware<JwtMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Kiểm tra kết nối DB
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            try
            {
                dbContext.Database.CanConnect();
                Console.WriteLine("Kết nối cơ sở dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}");
            }
        }

        app.Run();
    }
}