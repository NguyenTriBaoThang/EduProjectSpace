using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduProject_TADProgrammer.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetricType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ViewUsers = table.Column<bool>(type: "bit", nullable: false),
                    EditUsers = table.Column<bool>(type: "bit", nullable: false),
                    ViewProjects = table.Column<bool>(type: "bit", nullable: false),
                    EditProjects = table.Column<bool>(type: "bit", nullable: false),
                    ViewGrading = table.Column<bool>(type: "bit", nullable: false),
                    EditGrading = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemesterId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DefenseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefenseCommittees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemesterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefenseCommittees_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeCriteria",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeCriteria_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AISuggestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AISuggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    EventTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsAllDay = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeRuns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlagiarismScore = table.Column<float>(type: "real", nullable: true),
                    ExecutionTime = table.Column<float>(type: "real", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeRuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeMembers_DefenseCommittees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "DefenseCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefenseSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackSurveys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeAppeals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeAppeals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    CriteriaId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GradedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_GradeCriteria_CriteriaId",
                        column: x => x.CriteriaId,
                        principalTable: "GradeCriteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeVersions_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GradeSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClassCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeerReviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    ReviewerId = table.Column<long>(type: "bigint", nullable: false),
                    RevieweeId = table.Column<long>(type: "bigint", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Users_RevieweeId",
                        column: x => x.RevieweeId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeerReviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillAssessments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillAssessments_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingRecords_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCourseId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_StudentCourses_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "StudentCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectVersions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resources_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Submissions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeTrackings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTrackings_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTrackings_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubmissionVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmissionVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmissionVersions_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 4L, new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(473), null, "Differential backup for Feb 4", "backups/db_backup_2025_02_04.sql", 73400320L, "Success", "Differential", new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(475) },
                    { 7L, new DateTime(2025, 5, 13, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(495), null, "Incremental backup for Feb 7", "backups/db_backup_2025_02_07.sql", 41943040L, "Success", "Incremental", new DateTime(2025, 5, 13, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(496) },
                    { 10L, new DateTime(2025, 5, 10, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(509), null, "Incremental backup for Feb 10", "backups/db_backup_2025_02_10.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 10, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(511) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentCode", "DepartmentName", "FacultyCode", "FacultyName" },
                values: new object[,]
                {
                    { 1L, "CNTT", "CNTT", "CNTT", "Công nghệ Thông tin" },
                    { 2L, "Toan", "Toán", "KinhTe", "Kinh tế" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9036), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9039), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9041), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9043), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9045), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9047), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9049), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9051), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9054), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9057), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9058), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9061), "Làm sao để đổi mật khẩu?" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "LecturerId", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 7L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 7", null, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 8L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 8", null, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 9L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 9", null, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 10L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 10", null, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 11L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 11", null, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 12L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 12", null, "PENDING", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 13L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5, "Nhóm 13", null, "PENDING", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "Quản trị viên", "ROLE_ADMIN" },
                    { 2L, "Giảng viên hướng dẫn", "ROLE_LECTURER_GUIDE" },
                    { 3L, "Sinh viên", "ROLE_STUDENT" },
                    { 4L, "Trưởng bộ môn", "ROLE_HEAD" },
                    { 5L, "Giảng viên phản biện", "ROLE_LECTURER_REVIEW" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "CreatedAt", "Description", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(623), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(628), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(630), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9765), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9768), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9770), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9772), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9774), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9775), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9777), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9779), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9780), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9782), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9784), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9786), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9876), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9879), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9881), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9883), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9885), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9887), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9890), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9892), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9895), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9897), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9899), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9901), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "DepartmentId", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5430), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5431) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5438), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5438) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5444), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5445) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5450), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5450) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5456), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5456) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5461), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5462) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5468), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5469) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5474), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5475) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5480), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5480) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5491), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5492) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5497) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5502), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5503) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name", "SemesterId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7900), "Hội đồng 1", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7901) },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7904), "Hội đồng 2", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7905) },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7909), "Hội đồng 3", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7909) },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7912), "Hội đồng 4", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7912) },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7915), "Hội đồng 5", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7915) },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7918), "Hội đồng 6", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7918) },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7921), "Hội đồng 7", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7921) },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7923), "Hội đồng 8", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7924) },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7926), "Hội đồng 9", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7927) },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7930), "Hội đồng 10", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7931) },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7933), "Hội đồng 11", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7934) },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7936), "Hội đồng 12", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7937) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "EditGrading", "EditProjects", "EditUsers", "RoleId", "UpdatedAt", "ViewGrading", "ViewProjects", "ViewUsers" },
                values: new object[,]
                {
                    { 1L, true, true, true, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(877), true, true, true },
                    { 2L, false, false, false, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(880), false, true, false },
                    { 3L, false, false, false, 3L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(882), false, true, false },
                    { 4L, false, false, false, 4L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(884), false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4820), "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4821), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4834), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4835), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4845), "head2@hutech.edu.vn", 0, "Trần Thị Lan", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4846), "head2" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4966), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4967), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4989), "student2@hutech.edu.vn", 0, "Trần Văn Bình", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4990), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5000), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5001), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5010), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5011), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5088), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5089), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5098), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5099), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5107), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5108), "student7" },
                    { 16L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5138), "student8@hutech.edu.vn", 0, "Lê Văn Hùng", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5139), "student8" },
                    { 17L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5148), "student9@hutech.edu.vn", 0, "Trần Thị Mai", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5149), "student9" },
                    { 18L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5206), "student10@hutech.edu.vn", 0, "Nguyễn Văn Tâm", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5207), "student10" },
                    { 19L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5216), "student11@hutech.edu.vn", 0, "Phạm Thị Lan", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5217), "student11" },
                    { 20L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5227), "student12@hutech.edu.vn", 0, "Nguyễn Văn Tú", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5228), "student12" },
                    { 21L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5237), "student13@hutech.edu.vn", 0, "Phạm Thị Hoa", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5237), "student13" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(200), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(257), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(262), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(267), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(271), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(277), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(457), 1L, "Daily full database backup", "backups/db_backup_2025_02_01.sql", 104857600L, "Success", "Full", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(458) },
                    { 2L, new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(462), 1L, "Incremental backup for Feb 2", "backups/db_backup_2025_02_02.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(465) },
                    { 3L, new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(469), 2L, "Daily full database backup", "backups/db_backup_2025_02_03.sql", 110100480L, "Success", "Full", new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(470) },
                    { 5L, new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(478), 1L, "Incremental backup failed due to disk space", "backups/db_backup_2025_02_05.sql", null, "Failed", "Incremental", new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(486) },
                    { 6L, new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(490), 2L, "Weekly full database backup", "backups/db_backup_2025_02_06.sql", 115343360L, "Success", "Full", new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(491) },
                    { 8L, new DateTime(2025, 5, 12, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(499), 1L, "Differential backup in progress", "backups/db_backup_2025_02_08.sql", null, "Pending", "Differential", new DateTime(2025, 5, 12, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(500) },
                    { 9L, new DateTime(2025, 5, 11, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(504), 2L, "Daily full database backup", "backups/db_backup_2025_02_09.sql", 120586240L, "Success", "Full", new DateTime(2025, 5, 11, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(505) },
                    { 11L, new DateTime(2025, 5, 9, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(514), 1L, "Differential backup for Feb 11", "backups/db_backup_2025_02_11.sql", 83886080L, "Success", "Differential", new DateTime(2025, 5, 9, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(515) },
                    { 12L, new DateTime(2025, 5, 8, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(519), 2L, "Daily full database backup", "backups/db_backup_2025_02_12.sql", 125829120L, "Success", "Full", new DateTime(2025, 5, 8, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(520) }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9985), "Họp nhóm để thảo luận tiến độ dự án", new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, false, "Phòng họp A", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9987), 7L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(4), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(5), 9L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(15), "Nộp báo cáo nhiệm vụ cá nhân", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(16), 11L },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(26), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(26), 13L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(36), "Nộp báo cáo thực tập", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(36), 8L },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(47), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(47), 10L },
                    { 13L, new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(51), "Họp nhóm để phân tích yêu cầu dự án", new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 7L, false, "Phòng họp A", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(53), 11L },
                    { 14L, new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(57), "Nộp bài tập môn Cấu trúc dữ liệu", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp bài tập", null, false, "Phòng họp B", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 18, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(57), 12L },
                    { 15L, new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(62), "Họp nhóm để chuẩn bị báo cáo", new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 8L, false, "Phòng họp B", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(63), 13L },
                    { 16L, new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(67), "Thi cuối kỳ môn Lập trình nâng cao", new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 101", new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 17, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(68), 7L },
                    { 17L, new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(73), "Họp nhóm bị hủy do lịch trùng", new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 9L, false, "Phòng họp C", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Meeting", new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(74), 8L },
                    { 18L, new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(78), "Nộp báo cáo dự án nhóm", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp báo cáo", null, false, "Phòng họp B", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 16, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(79), 9L },
                    { 19L, new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(83), "Họp nhóm để hoàn thiện thuyết trình", new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 10L, false, "Phòng họp A", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(84), 10L },
                    { 20L, new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(89), "Thi cuối kỳ môn Cơ sở dữ liệu", new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 102", new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 15, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(89), 11L },
                    { 21L, new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(94), "Họp nhóm để đánh giá dự án", new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 11L, false, "Phòng họp B", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(96), 12L },
                    { 22L, new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(100), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 4, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 14, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(101), 13L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8024), 2L, "Chủ tịch", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8025) },
                    { 3L, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8031), 3L, "Chủ tịch", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8032) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9210), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9343), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9346), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9347), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9349), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9351), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9353), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9355), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9357), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9359), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9360), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9362), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9364), 4, 11L }
                });

            migrationBuilder.InsertData(
                table: "GradeCriteria",
                columns: new[] { "Id", "CourseId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { 1L, 1L, "Chất lượng nội dung đồ án.", "Nội dung", 0.4f },
                    { 2L, 1L, "Cách trình bày báo cáo.", "Trình bày", 0.3f },
                    { 3L, 1L, "Kỹ năng bảo vệ.", "Bảo vệ", 0.3f },
                    { 4L, 2L, "Chất lượng nội dung đồ án cơ sở.", "Nội dung", 0.5f },
                    { 5L, 2L, "Kỹ năng thực hành.", "Thực hành", 0.5f },
                    { 6L, 3L, "Chất lượng nội dung đồ án KTPM.", "Nội dung", 0.4f },
                    { 7L, 4L, "Kỹ năng thực hành KTPM.", "Thực hành", 0.6f },
                    { 8L, 5L, "Mức độ bảo mật.", "Bảo mật", 0.5f },
                    { 9L, 6L, "Kỹ năng phân tích dữ liệu.", "Phân tích", 0.5f },
                    { 10L, 7L, "Ứng dụng thực tế.", "Ứng dụng", 0.4f },
                    { 11L, 8L, "Khả năng quản lý kho.", "Quản lý", 0.5f },
                    { 12L, 9L, "Tính tiện ích của app.", "Tiện ích", 0.5f },
                    { 13L, 10L, "Hiệu quả quản lý nhân sự.", "Hiệu quả", 0.5f }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6344), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6346), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6347), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6349), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6351), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6353), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 1L, "LOGIN", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(357), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(360), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(362), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(365), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(367), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(369), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(371), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(373), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8540), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8544), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8560), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8564), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8567), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8569), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8572), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8670), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8672), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8674), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8677), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9444), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9447), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9449), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9452), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9454), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9456), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9458), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9459), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9461), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9463), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9465), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9467), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4934), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4935), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4945), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4946), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4956), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(4957), "lecturer3" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5117), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5118), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5128), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", null, false, "$2a$11$Yr67xJs4vr7WHVytOGGfhuC/.Wl6vzQ1hoAoqe2cIhv2oa7wnznpy", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5129), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8028), 4L, "Thành viên", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8029) },
                    { 4L, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8034), 5L, "Thư ký", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8035) },
                    { 5L, 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8038), 6L, "Thành viên", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8039) },
                    { 6L, 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8041), 14L, "Chủ tịch", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8042) },
                    { 7L, 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8044), 15L, "Thư ký", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8045) },
                    { 8L, 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8048), 4L, "Thành viên", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8049) },
                    { 9L, 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8052), 5L, "Chủ tịch", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8052) },
                    { 10L, 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8055), 6L, "Thư ký", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8056) },
                    { 11L, 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8058), 14L, "Thành viên", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8059) },
                    { 12L, 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8061), 15L, "Chủ tịch", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8062) }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(375), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(377), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(379), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(381), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8282), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8356), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8360), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8363), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8366), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8369), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "GroupId", "LecturerId", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 4L, "ENROLLED", 7L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 2L, 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 4L, "ENROLLED", 8L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 3L, 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 4L, "ENROLLED", 9L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 4L, 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5L, "ENROLLED", 10L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 5L, 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 5L, "ENROLLED", 11L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 6L, 2L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 6L, "ENROLLED", 12L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 7L, 2L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 6L, "ENROLLED", 13L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 8L, 3L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 14L, "ENROLLED", 16L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 9L, 3L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 14L, "ENROLLED", 17L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 10L, 4L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 15L, "ENROLLED", 18L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 11L, 4L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 15L, "ENROLLED", 19L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 12L, 5L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 4L, "ENROLLED", 20L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 13L, 5L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null, 4L, "ENROLLED", 21L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8449), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8451), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8452), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8454), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8455), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8457), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectCode", "Status", "StudentCourseId", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", "AI_YTE_2025_01", "NOT_SUBMITTED", 1L, "Ứng dụng AI trong y tế", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 2L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng hệ thống quản lý đồ án sinh viên.", "QLDA_2025_01", "NOT_SUBMITTED", 2L, "Hệ thống quản lý đồ án", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 3L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển website bán hàng trực tuyến.", "TMĐT_2025_01", "NOT_SUBMITTED", 3L, "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 4L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", "PTDL_2025_01", "SUBMITTED", 4L, "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 5L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển app quản lý học tập cho sinh viên.", "QLHT_2025_01", "SUBMITTED", 5L, "Ứng dụng quản lý học tập", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 6L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", "BM_IOT_2025_01", "SUBMITTED", 6L, "Hệ thống bảo mật IoT", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 7L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phân tích hành vi người dùng trên mạng xã hội.", "PTMXH_2025_01", "SUBMITTED", 7L, "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 8L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển app học ngoại ngữ với AI.", "HNN_2025_01", "GRADED", 8L, "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 9L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng hệ thống quản lý kho hàng tự động.", "QLK_2025_01", "GRADED", 9L, "Hệ thống quản lý kho", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 10L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển app đặt lịch khám bệnh trực tuyến.", "DLKB_2025_01", "GRADED", 10L, "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 11L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", "QLNS_2025_01", "GRADED", 11L, "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 12L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Phát triển app hỗ trợ học tập nhóm.", "HTN_2025_01", "PENDING", 12L, "Ứng dụng học tập nhóm", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null },
                    { 13L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), "Xây dựng hệ thống phân tích tài chính cá nhân.", "PTTC_2025_01", "PENDING", 13L, "Hệ thống phân tích tài chính", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(203), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(260), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(264), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(269), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(275), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(280), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8125), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8129), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8132), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8135), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8138), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8141), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8143), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8146), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8149), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8152), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8155), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8157), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9206), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9213), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9216), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9219), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9221), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9224), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9226), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9229), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9232), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9234), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9237), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7609), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7612), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7614), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7617), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7620), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7623), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7625), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7627), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7630), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7632), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7635), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7637), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7330), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7333), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7337), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7340), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7343), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "LecturerId", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 4L, 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 2L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 5L, 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 3L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 6L, 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 4L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 14L, 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 5L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 15L, 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) },
                    { 6L, new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc), 4L, 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 5, 19, 3, 9, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5901), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 18, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5904), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5913), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5915), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5917), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5919), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5921), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5923), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5926), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5928), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5930), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(5932), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8925), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8928), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8930), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8932), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8933), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8935), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8937), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8939), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8941), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8943), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8946), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8948), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8755), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8761), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8764), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8767), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8769), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8772), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8774), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8777), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8780), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8782), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8785), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6619), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6624), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6679), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6683), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6686), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6689), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6452), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6459), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6467), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6470), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6473), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6477), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6480), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6483), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6486), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9565), 120, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9562), 1L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9560), 7L },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9573), 60, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9572), 1L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9571), 8L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9577), 180, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9576), 2L, new DateTime(2025, 5, 18, 22, 36, 21, 594, DateTimeKind.Utc).AddTicks(9575), 9L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9581), 60, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9580), 3L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9579), 10L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9590), 120, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9588), 4L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9583), 11L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9597), 240, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9593), 5L, new DateTime(2025, 5, 18, 21, 36, 21, 594, DateTimeKind.Utc).AddTicks(9592), 12L },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9653), 60, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9651), 6L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9649), 13L },
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9663), 120, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9662), 7L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9655), 7L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9667), 180, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9666), 8L, new DateTime(2025, 5, 18, 22, 36, 21, 594, DateTimeKind.Utc).AddTicks(9665), 8L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9671), 60, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9670), 9L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(9669), 9L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9675), 120, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9674), 10L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(9673), 10L },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9679), 180, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9678), 11L, new DateTime(2025, 5, 18, 22, 36, 21, 594, DateTimeKind.Utc).AddTicks(9677), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9994), "Nộp bài tập lớn môn Lập trình", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, false, "Phòng họp B", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9995), 2L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(9999), "Họp nhóm để phân công nhiệm vụ", new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, false, "Phòng họp B", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc), 8L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(10), "Họp nhóm để kiểm tra tiến độ", new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, false, "Phòng họp C", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(11), 10L },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(21), "Họp nhóm để chuẩn bị thuyết trình", new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, false, "Phòng họp A", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(21), 12L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(31), "Họp nhóm để hoàn thiện dự án", new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, false, "Phòng họp B", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(32), 7L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(42), "Họp nhóm để đánh giá tiến độ", new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, false, "Phòng họp C", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 1, 36, 21, 595, DateTimeKind.Utc).AddTicks(43), 9L }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "ErrorMessage", "ExecutionTime", "Language", "PlagiarismScore", "Result", "Status", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 18, 19, 36, 21, 594, DateTimeKind.Utc).AddTicks(7029), null, 25.8f, "JavaScript", 0.2f, "Output: Social Media", "Success", 7L, new DateTime(2025, 5, 18, 19, 36, 21, 594, DateTimeKind.Utc).AddTicks(7030) },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 18, 18, 36, 21, 594, DateTimeKind.Utc).AddTicks(7034), "Process exceeded 5-second limit", null, "Python", 0.4f, "Execution timed out", "Timeout", 8L, new DateTime(2025, 5, 18, 18, 36, 21, 594, DateTimeKind.Utc).AddTicks(7034) },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println(\"Warehouse\"); } }", new DateTime(2025, 5, 18, 17, 36, 21, 594, DateTimeKind.Utc).AddTicks(7039), null, 130f, "Java", 0.1f, "Output: Warehouse", "Success", 9L, new DateTime(2025, 5, 18, 17, 36, 21, 594, DateTimeKind.Utc).AddTicks(7040) },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 18, 16, 36, 21, 594, DateTimeKind.Utc).AddTicks(7044), null, 48.3f, "Python", 0.05f, "Output: Booking System", "Success", 10L, new DateTime(2025, 5, 18, 16, 36, 21, 594, DateTimeKind.Utc).AddTicks(7044) },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 18, 15, 36, 21, 594, DateTimeKind.Utc).AddTicks(7048), null, 28.7f, "JavaScript", 0.15f, "Output: HR System", "Success", 11L, new DateTime(2025, 5, 18, 15, 36, 21, 594, DateTimeKind.Utc).AddTicks(7049) },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 18, 14, 36, 21, 594, DateTimeKind.Utc).AddTicks(7053), "NameError: name 'undefined_variable' is not defined", null, "Python", 0.3f, "Error: NameError", "Failed", 12L, new DateTime(2025, 5, 18, 14, 36, 21, 594, DateTimeKind.Utc).AddTicks(7054) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6893), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6895), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6897), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6899), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6901), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6903), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7816), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7818), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7820), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7822), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 9L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7532), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7534), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7536), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7538), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7441), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7444), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7446), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7448), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7301), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7310), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7313), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7317), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7320), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7323), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7327), 4L, 6L, 6L, 9f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6227), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6229), 8L },
                    { 3L, 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6231), 9L },
                    { 4L, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6233), 10L },
                    { 5L, 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6235), 11L },
                    { 6L, 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6237), 12L },
                    { 7L, 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6239), 13L },
                    { 8L, 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6241), 16L },
                    { 9L, 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6243), 17L },
                    { 10L, 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6245), 18L },
                    { 11L, 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6247), 19L },
                    { 12L, 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6249), 20L },
                    { 13L, 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6251), 21L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6330), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6333), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6335), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6337), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6339), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6341), 6L, "PENDING", 8L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8254), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8259), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8268), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8271), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8274), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8278), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8547), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8550), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8553), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8555), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8558), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8651), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8654), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8657), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8659), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8661), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8663), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8666), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8668), 6L, 9L, 8L, 6 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8758), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 8L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6794), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6796), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6798), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6800), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6802), "submissions/dt011_v1.pdf", 11L, 1 }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6596), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6601), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6605), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6609), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6612), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6616), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6448), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6456), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6463), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "ErrorMessage", "ExecutionTime", "Language", "PlagiarismScore", "Result", "Status", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6997), null, 50.5f, "Python", 0.1f, "Output: Hello World", "Success", 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6998) },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println(\"Hello\"); } }", new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(7002), null, 120f, "Java", 0.2f, "Output: Hello", "Success", 2L, new DateTime(2025, 5, 19, 0, 36, 21, 594, DateTimeKind.Utc).AddTicks(7004) },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(7009), null, 30.2f, "JavaScript", 0.15f, "Output: Hello World", "Success", 3L, new DateTime(2025, 5, 18, 23, 36, 21, 594, DateTimeKind.Utc).AddTicks(7010) },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 18, 22, 36, 21, 594, DateTimeKind.Utc).AddTicks(7014), "SyntaxError: unexpected EOF while parsing", null, "Python", 0.3f, "Error: Invalid syntax", "Failed", 4L, new DateTime(2025, 5, 18, 22, 36, 21, 594, DateTimeKind.Utc).AddTicks(7015) },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println(\"Test\"); } }", new DateTime(2025, 5, 18, 21, 36, 21, 594, DateTimeKind.Utc).AddTicks(7019), null, 110.5f, "Java", 0.1f, "Output: Test", "Success", 5L, new DateTime(2025, 5, 18, 21, 36, 21, 594, DateTimeKind.Utc).AddTicks(7020) },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 18, 20, 36, 21, 594, DateTimeKind.Utc).AddTicks(7024), null, 45f, "Python", 0.05f, "Output: IoT Security", "Success", 6L, new DateTime(2025, 5, 18, 20, 36, 21, 594, DateTimeKind.Utc).AddTicks(7025) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6880), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6883), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6885), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6887), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6889), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6891), 4L, 6L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7798), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7801), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7804), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7806), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7808), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7811), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7813), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7512), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7515), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7518), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7520), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7523), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7525), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7527), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7530), "Tạo điểm cho nhóm 6.", 7L, 4L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 18, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7421), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7426), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7428), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7430), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7432), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7435), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7437), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(7439), 7L, 9f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8438), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8441), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8442), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8444), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8446), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(8448), "records/meeting6.mp4", 6L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6775), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 18, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6778), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6783), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6784), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6787), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6789), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 19, 1, 36, 21, 594, DateTimeKind.Utc).AddTicks(6792), "submissions/dt006_v1.pdf", 6L, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AISuggestions_ProjectId",
                table: "AISuggestions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AISuggestions_UserId",
                table: "AISuggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Backups_CreatedAt",
                table: "Backups",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Backups_CreatedBy",
                table: "Backups",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_GroupId",
                table: "Calendars",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeRuns_SubmissionId",
                table: "CodeRuns",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMembers_CommitteeId",
                table: "CommitteeMembers",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeMembers_LecturerId",
                table: "CommitteeMembers",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SemesterId",
                table: "Courses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseCommittees_Name",
                table: "DefenseCommittees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DefenseCommittees_SemesterId",
                table: "DefenseCommittees",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseSchedules_ProjectId",
                table: "DefenseSchedules",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_ProjectId",
                table: "Discussions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussions_UserId",
                table: "Discussions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_Category",
                table: "FAQs",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_LecturerId",
                table: "Feedbacks",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_SubmissionId",
                table: "Feedbacks",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackSurveys_UserId",
                table: "FeedbackSurveys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeAppeals_GradeId",
                table: "GradeAppeals",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeAppeals_StudentId",
                table: "GradeAppeals",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeCriteria_CourseId",
                table: "GradeCriteria",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeLogs_GradeId",
                table: "GradeLogs",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeLogs_LecturerId",
                table: "GradeLogs",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CriteriaId",
                table: "Grades",
                column: "CriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradedBy",
                table: "Grades",
                column: "GradedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GroupId",
                table: "Grades",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ProjectId",
                table: "Grades",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSchedules_LecturerId",
                table: "GradeSchedules",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSchedules_ProjectId",
                table: "GradeSchedules",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeVersions_GradeId",
                table: "GradeVersions",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_GroupId",
                table: "GroupMembers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_StudentId",
                table: "GroupMembers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRequests_GroupId",
                table: "GroupRequests",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRequests_StudentId",
                table: "GroupRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_LecturerId",
                table: "Groups",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProjectId",
                table: "Groups",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRecords_MeetingId",
                table: "MeetingRecords",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_CreatedBy",
                table: "Meetings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_GroupId",
                table: "Meetings",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_GroupId",
                table: "Notifications",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_GroupId",
                table: "PeerReviews",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_RevieweeId",
                table: "PeerReviews",
                column: "RevieweeId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerReviews_ReviewerId",
                table: "PeerReviews",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCode",
                table: "Projects",
                column: "ProjectCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentCourseId",
                table: "Projects",
                column: "StudentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVersions_ProjectId",
                table: "ProjectVersions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedBy",
                table: "Questions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProjectId",
                table: "Questions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CreatedBy",
                table: "Resources",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_GroupId",
                table: "Resources",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_Name",
                table: "Semesters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillAssessments_StudentId",
                table: "SkillAssessments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_GroupId",
                table: "StudentCourses",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_LecturerId",
                table: "StudentCourses",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId_CourseId",
                table: "StudentCourses",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_GroupId",
                table: "Submissions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ProjectId",
                table: "Submissions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionVersions_SubmissionId",
                table: "SubmissionVersions",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemConfigs_Key",
                table: "SystemConfigs",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemMetrics_MetricType",
                table: "SystemMetrics",
                column: "MetricType");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_GroupId",
                table: "Tasks",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StudentId",
                table: "Tasks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_ProjectId",
                table: "TimeTrackings",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTrackings_StudentId",
                table: "TimeTrackings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CourseId",
                table: "Users",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AISuggestions_Projects_ProjectId",
                table: "AISuggestions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AISuggestions_Users_UserId",
                table: "AISuggestions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Backups_Users_CreatedBy",
                table: "Backups",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Groups_GroupId",
                table: "Calendars",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calendars_Users_UserId",
                table: "Calendars",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CodeRuns_Submissions_SubmissionId",
                table: "CodeRuns",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeMembers_Users_LecturerId",
                table: "CommitteeMembers",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenseSchedules_Projects_ProjectId",
                table: "DefenseSchedules",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Projects_ProjectId",
                table: "Discussions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Discussions_Users_UserId",
                table: "Discussions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Submissions_SubmissionId",
                table: "Feedbacks",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_LecturerId",
                table: "Feedbacks",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackSurveys_Users_UserId",
                table: "FeedbackSurveys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeAppeals_Grades_GradeId",
                table: "GradeAppeals",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeAppeals_Users_StudentId",
                table: "GradeAppeals",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeLogs_Grades_GradeId",
                table: "GradeLogs",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeLogs_Users_LecturerId",
                table: "GradeLogs",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Groups_GroupId",
                table: "Grades",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Projects_ProjectId",
                table: "Grades",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_GradedBy",
                table: "Grades",
                column: "GradedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Users_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeSchedules_Projects_ProjectId",
                table: "GradeSchedules",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GradeSchedules_Users_LecturerId",
                table: "GradeSchedules",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Groups_GroupId",
                table: "GroupMembers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_Users_StudentId",
                table: "GroupMembers",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRequests_Groups_GroupId",
                table: "GroupRequests",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRequests_Users_StudentId",
                table: "GroupRequests",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_LecturerId",
                table: "Groups",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_LecturerId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "AISuggestions");

            migrationBuilder.DropTable(
                name: "Backups");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "CodeRuns");

            migrationBuilder.DropTable(
                name: "CommitteeMembers");

            migrationBuilder.DropTable(
                name: "DefenseSchedules");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackSurveys");

            migrationBuilder.DropTable(
                name: "GradeAppeals");

            migrationBuilder.DropTable(
                name: "GradeLogs");

            migrationBuilder.DropTable(
                name: "GradeSchedules");

            migrationBuilder.DropTable(
                name: "GradeVersions");

            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "GroupRequests");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "MeetingRecords");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PeerReviews");

            migrationBuilder.DropTable(
                name: "ProjectVersions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SkillAssessments");

            migrationBuilder.DropTable(
                name: "SubmissionVersions");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "SystemMetrics");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TimeTrackings");

            migrationBuilder.DropTable(
                name: "DefenseCommittees");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "GradeCriteria");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Semesters");
        }
    }
}
