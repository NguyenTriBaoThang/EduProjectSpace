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
        builder.Services.AddControllersWithViews();

        // Thêm Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Thêm các dịch vụ
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<RoleService>();
        builder.Services.AddScoped<DashboardService>();
        builder.Services.AddScoped<JwtService>();

        // Thêm CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyAllowOrigins", policy =>
            {
                policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials(); // Thêm để hỗ trợ HttpOnly cookie
            });
        });

        // Cấu hình JWT Authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
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

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors("MyAllowOrigins");
        app.UseMiddleware<JwtMiddleware>();
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