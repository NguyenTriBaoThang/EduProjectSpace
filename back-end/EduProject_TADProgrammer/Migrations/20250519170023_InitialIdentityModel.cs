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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_DefenseSchedules_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_AISuggestions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Discussions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Grades_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_GradeSchedules_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_StudentCourses_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 4L, new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(578), null, "Differential backup for Feb 4", "backups/db_backup_2025_02_04.sql", 73400320L, "Success", "Differential", new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(579) },
                    { 7L, new DateTime(2025, 5, 13, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(591), null, "Incremental backup for Feb 7", "backups/db_backup_2025_02_07.sql", 41943040L, "Success", "Incremental", new DateTime(2025, 5, 13, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(592) },
                    { 10L, new DateTime(2025, 5, 10, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(601), null, "Incremental backup for Feb 10", "backups/db_backup_2025_02_10.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 10, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(602) }
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
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9502), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9505), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9506), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9508), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9510), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9511), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9513), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9515), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9517), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9518), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9520), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9521), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(671), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(675), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(677), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(83), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(85), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(86), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(88), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(89), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(91), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(93), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(94), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(96), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(97), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(99), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(101), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(158), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(160), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(162), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(164), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 19, 16, 0, 19, 48, DateTimeKind.Utc).AddTicks(165), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 19, 16, 0, 19, 48, DateTimeKind.Utc).AddTicks(167), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 19, 16, 0, 19, 48, DateTimeKind.Utc).AddTicks(169), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 19, 16, 0, 19, 48, DateTimeKind.Utc).AddTicks(171), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 19, 15, 0, 19, 48, DateTimeKind.Utc).AddTicks(172), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 19, 15, 0, 19, 48, DateTimeKind.Utc).AddTicks(174), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 19, 15, 0, 19, 48, DateTimeKind.Utc).AddTicks(176), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 19, 15, 0, 19, 48, DateTimeKind.Utc).AddTicks(177), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "DepartmentId", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6480), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6481) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6488), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6488) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6492), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6493) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6497), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6497) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6501), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6501) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6506) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6509), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6510) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6514), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6515) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6518), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6519) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6530), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6531) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6535), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6535) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6539), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6539) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name", "SemesterId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8698), "Hội đồng 1", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8699) },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8701), "Hội đồng 2", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8702) },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8704), "Hội đồng 3", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8704) },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8706), "Hội đồng 4", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8707) },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8709), "Hội đồng 5", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8709) },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8711), "Hội đồng 6", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8712) },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8714), "Hội đồng 7", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8714) },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8716), "Hội đồng 8", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8717) },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8719), "Hội đồng 9", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8719) },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8721), "Hội đồng 10", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8722) },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8724), "Hội đồng 11", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8724) },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8726), "Hội đồng 12", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8727) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "EditGrading", "EditProjects", "EditUsers", "RoleId", "UpdatedAt", "ViewGrading", "ViewProjects", "ViewUsers" },
                values: new object[,]
                {
                    { 1L, true, true, true, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(848), true, true, true },
                    { 2L, false, false, false, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(850), false, true, false },
                    { 3L, false, false, false, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(852), false, true, false },
                    { 4L, false, false, false, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(854), false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5784), "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5785), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5797), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5798), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5828), "head2@hutech.edu.vn", 0, "Trần Thị Lan", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5828), "head2" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6060), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6061), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6090), "student2@hutech.edu.vn", 0, "Trần Văn Bình", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6090), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6099), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6099), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6108), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6109), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6117), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6118), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6128), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6129), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6216), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6216), "student7" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(384), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(388), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(392), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(396), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(399), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(445), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(567), 1L, "Daily full database backup", "backups/db_backup_2025_02_01.sql", 104857600L, "Success", "Full", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(568) },
                    { 2L, new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(571), 1L, "Incremental backup for Feb 2", "backups/db_backup_2025_02_02.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(572) },
                    { 3L, new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(575), 2L, "Daily full database backup", "backups/db_backup_2025_02_03.sql", 110100480L, "Success", "Full", new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(575) },
                    { 5L, new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(581), 1L, "Incremental backup failed due to disk space", "backups/db_backup_2025_02_05.sql", null, "Failed", "Incremental", new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(585) },
                    { 6L, new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(588), 2L, "Weekly full database backup", "backups/db_backup_2025_02_06.sql", 115343360L, "Success", "Full", new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(588) },
                    { 8L, new DateTime(2025, 5, 12, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(594), 1L, "Differential backup in progress", "backups/db_backup_2025_02_08.sql", null, "Pending", "Differential", new DateTime(2025, 5, 12, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(595) },
                    { 9L, new DateTime(2025, 5, 11, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(598), 2L, "Daily full database backup", "backups/db_backup_2025_02_09.sql", 120586240L, "Success", "Full", new DateTime(2025, 5, 11, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(599) },
                    { 11L, new DateTime(2025, 5, 9, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(605), 1L, "Differential backup for Feb 11", "backups/db_backup_2025_02_11.sql", 83886080L, "Success", "Differential", new DateTime(2025, 5, 9, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(605) },
                    { 12L, new DateTime(2025, 5, 8, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(608), 2L, "Daily full database backup", "backups/db_backup_2025_02_12.sql", 125829120L, "Success", "Full", new DateTime(2025, 5, 8, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(609) }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(233), "Họp nhóm để thảo luận tiến độ dự án", new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, false, "Phòng họp A", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(234), 7L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(248), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(248), 9L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(256), "Nộp báo cáo nhiệm vụ cá nhân", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(256), 11L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(263), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(264), 13L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(271), "Nộp báo cáo thực tập", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(272), 8L },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(279), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(280), 10L },
                    { 14L, new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(288), "Nộp bài tập môn Cấu trúc dữ liệu", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp bài tập", null, false, "Phòng họp B", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(288), 12L },
                    { 16L, new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(296), "Thi cuối kỳ môn Lập trình nâng cao", new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 101", new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(296), 7L },
                    { 18L, new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(305), "Nộp báo cáo dự án nhóm", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp báo cáo", null, false, "Phòng họp B", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(305), 9L },
                    { 20L, new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(313), "Thi cuối kỳ môn Cơ sở dữ liệu", new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 102", new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(313), 11L },
                    { 22L, new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(320), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 4, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(321), 13L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8777), 2L, "Chủ tịch", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8778) },
                    { 3L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8783), 3L, "Chủ tịch", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8783) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9679), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9782), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9784), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9786), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9788), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9789), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9791), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9793), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9794), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9796), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9797), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9800), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9802), 4, 11L }
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
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 1L, "LOGIN", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(496), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(499), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(501), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(502), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(504), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(506), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(508), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(509), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9154), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9157), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "GroupId", "ProjectCode", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6702), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 1L, "AI_YTE_2025_01", "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6702) },
                    { 2L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6708), "Xây dựng hệ thống quản lý đồ án sinh viên.", 2L, "QLDA_2025_01", "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6708) },
                    { 3L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6713), "Phát triển website bán hàng trực tuyến.", 3L, "TMĐT_2025_01", "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6713) },
                    { 4L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6718), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 4L, "PTDL_2025_01", "SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6718) },
                    { 5L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6722), "Phát triển app quản lý học tập cho sinh viên.", 5L, "QLHT_2025_01", "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6723) },
                    { 6L, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6727), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 6L, "BM_IOT_2025_01", "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6727) },
                    { 7L, 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6731), "Phân tích hành vi người dùng trên mạng xã hội.", 7L, "PTMXH_2025_01", "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6732) },
                    { 8L, 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6736), "Phát triển app học ngoại ngữ với AI.", 9L, "HNN_2025_01", "GRADED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6736) },
                    { 9L, 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6744), "Xây dựng hệ thống quản lý kho hàng tự động.", 8L, "QLK_2025_01", "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6745) },
                    { 10L, 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6750), "Phát triển app đặt lịch khám bệnh trực tuyến.", 10L, "DLKB_2025_01", "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6751) },
                    { 11L, 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6756), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 12L, "QLNS_2025_01", "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6756) },
                    { 12L, 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6762), "Phát triển app hỗ trợ học tập nhóm.", 11L, "HTN_2025_01", "PENDING", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6762) },
                    { 13L, 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6768), "Xây dựng hệ thống phân tích tài chính cá nhân.", 13L, "PTTC_2025_01", "PENDING", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6769) }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9857), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9860), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9861), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9863), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9864), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9866), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9868), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9869), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9871), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9873), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9874), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9876), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(724), "ENROLLED", 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(724) },
                    { 2L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(727), "ENROLLED", 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(728) },
                    { 3L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(730), "ENROLLED", 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(730) },
                    { 4L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(732), "ENROLLED", 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(733) },
                    { 5L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(735), "ENROLLED", 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(735) },
                    { 6L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(737), "ENROLLED", 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(738) },
                    { 7L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(740), "ENROLLED", 13L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(740) },
                    { 8L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(742), "ENROLLED", 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(743) },
                    { 9L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(745), "ENROLLED", 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(746) },
                    { 10L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(748), "ENROLLED", 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(748) },
                    { 11L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(751), "ENROLLED", 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(751) },
                    { 12L, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(753), "ENROLLED", 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(754) },
                    { 13L, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(756), "ENROLLED", 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(756) },
                    { 14L, 6L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(758), "ENROLLED", 13L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(759) },
                    { 15L, 6L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(761), "ENROLLED", 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(761) },
                    { 16L, 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(763), "COMPLETED", 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(764) },
                    { 17L, 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(766), "COMPLETED", 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(766) },
                    { 18L, 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(768), "COMPLETED", 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(769) },
                    { 19L, 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(771), "COMPLETED", 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(771) },
                    { 20L, 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(773), "COMPLETED", 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(774) },
                    { 21L, 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(776), "COMPLETED", 13L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(776) },
                    { 22L, 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(778), "COMPLETED", 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(779) },
                    { 23L, 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(781), "COMPLETED", 8L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(781) },
                    { 24L, 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(783), "ENROLLED", 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(784) },
                    { 25L, 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(786), "ENROLLED", 10L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(786) },
                    { 26L, 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(788), "ENROLLED", 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(789) },
                    { 27L, 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(791), "ENROLLED", 12L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(791) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5839), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(5839), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6039), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6040), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6051), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6051), "lecturer3" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6225), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6225), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6236), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", null, false, "$2a$11$vlTNCCr0zib9.GP9Jsp/deU/sbiYq3G0W.a4Tw3vISvsFZAC.O1cK", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6237), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(387), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(390), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(394), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(397), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(401), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(447), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8780), 4L, "Thành viên", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8781) },
                    { 4L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8785), 5L, "Thư ký", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8786) },
                    { 5L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8788), 6L, "Thành viên", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8788) },
                    { 6L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8790), 14L, "Chủ tịch", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8791) },
                    { 7L, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8793), 15L, "Thư ký", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8793) },
                    { 8L, 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8795), 4L, "Thành viên", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8796) },
                    { 9L, 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8798), 5L, "Chủ tịch", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8798) },
                    { 10L, 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8800), 6L, "Thư ký", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8801) },
                    { 11L, 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8803), 14L, "Thành viên", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8803) },
                    { 12L, 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8805), 15L, "Chủ tịch", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8806) }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8850), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8852), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8854), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8857), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8859), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8861), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8863), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8865), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8867), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8870), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8872), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8874), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9676), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9682), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9684), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9685), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9687), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9690), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9692), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9694), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9696), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9698), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9700), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8462), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8465), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8467), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8469), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8471), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8473), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8475), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8477), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8479), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8481), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8483), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8485), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "LecturerId", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7202), null, 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7204) },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7211), null, 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7212) },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7217), null, 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7218) },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7222), null, 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7223) },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7229), null, 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7229) },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7234), null, 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7234) },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7238), null, 5, "Nhóm 7", 7L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7238) },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7242), null, 5, "Nhóm 8", 8L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7243) },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7246), null, 5, "Nhóm 9", 9L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7247) },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7251), null, 5, "Nhóm 10", 10L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7251) },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7255), null, 5, "Nhóm 11", 11L, "APPROVED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7255) },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7259), null, 5, "Nhóm 12", 12L, "PENDING", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7259) },
                    { 13L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7263), null, 5, "Nhóm 13", 13L, "PENDING", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7264) }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(511), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(513), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(514), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(516), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6917), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 18, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6920), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6931), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6934), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6938), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6941), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6944), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6947), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(6950), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7015), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7020), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7024), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9383), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9388), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9390), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9392), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9393), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9395), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9397), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9399), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9442), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9444), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9445), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9447), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9299), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9313), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9315), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9317), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9319), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9322), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9324), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9326), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9328), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9330), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9332), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7597), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7603), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7608), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7613), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7618), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7623), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9938), 120, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9934), 1L, new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(9930), 7L },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9941), 60, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9940), 1L, new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(9940), 8L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9945), 180, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9944), 2L, new DateTime(2025, 5, 19, 14, 0, 19, 47, DateTimeKind.Utc).AddTicks(9943), 9L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9948), 60, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9948), 3L, new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(9947), 10L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9954), 120, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9954), 4L, new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(9950), 11L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9960), 240, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9957), 5L, new DateTime(2025, 5, 19, 13, 0, 19, 47, DateTimeKind.Utc).AddTicks(9956), 12L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9964), 60, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9963), 6L, new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(9962), 13L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9972), 120, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9971), 7L, new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(9965), 7L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9975), 180, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9974), 8L, new DateTime(2025, 5, 19, 14, 0, 19, 47, DateTimeKind.Utc).AddTicks(9974), 8L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9979), 60, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9978), 9L, new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(9977), 9L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9982), 120, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9981), 10L, new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(9980), 10L },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9985), 180, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9984), 11L, new DateTime(2025, 5, 19, 14, 0, 19, 47, DateTimeKind.Utc).AddTicks(9984), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(238), "Nộp bài tập lớn môn Lập trình", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, false, "Phòng họp B", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(239), 2L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(242), "Họp nhóm để phân công nhiệm vụ", new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, false, "Phòng họp B", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(243), 8L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(252), "Họp nhóm để kiểm tra tiến độ", new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, false, "Phòng họp C", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(252), 10L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(260), "Họp nhóm để chuẩn bị thuyết trình", new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, false, "Phòng họp A", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(260), 12L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(267), "Họp nhóm để hoàn thiện dự án", new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, false, "Phòng họp B", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(268), 7L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(275), "Họp nhóm để đánh giá tiến độ", new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, false, "Phòng họp C", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 19, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(276), 9L },
                    { 13L, new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(283), "Họp nhóm để phân tích yêu cầu dự án", new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 7L, false, "Phòng họp A", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 18, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(284), 11L },
                    { 15L, new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(292), "Họp nhóm để chuẩn bị báo cáo", new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 8L, false, "Phòng họp B", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 17, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(292), 13L },
                    { 17L, new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(301), "Họp nhóm bị hủy do lịch trùng", new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 9L, false, "Phòng họp C", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Meeting", new DateTime(2025, 5, 16, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(301), 8L },
                    { 19L, new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(309), "Họp nhóm để hoàn thiện thuyết trình", new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 10L, false, "Phòng họp A", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 15, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(309), 10L },
                    { 21L, new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(317), "Họp nhóm để đánh giá dự án", new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 11L, false, "Phòng họp B", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 14, 17, 0, 19, 48, DateTimeKind.Utc).AddTicks(317), 12L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8205), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8209), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8244), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8247), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8250), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8252), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8255), 4L, 6L, 6L, 9f, null },
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8257), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8260), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8263), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8265), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8267), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7419), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7422), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7423), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7425), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7426), 11L },
                    { 6L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7428), 12L },
                    { 7L, 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7429), 13L },
                    { 8L, 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7431), 7L },
                    { 9L, 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7432), 8L },
                    { 10L, 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7434), 9L },
                    { 11L, 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7435), 10L },
                    { 12L, 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7437), 11L },
                    { 13L, 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7438), 12L },
                    { 14L, 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7440), 13L },
                    { 15L, 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7441), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7513), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7515), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7517), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7518), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7520), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7522), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7523), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7525), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7527), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7528), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7530), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7531), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8929), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8933), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8940), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8943), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8945), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8948), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8951), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8953), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8956), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8958), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8962), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8964), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9160), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9162), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9164), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9166), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9169), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9171), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9173), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9176), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9178), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9180), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9225), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9228), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9230), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9232), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9234), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9236), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9238), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9240), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9242), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9243), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9245), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9247), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9302), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7708), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7711), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7714), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7717), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7719), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7721), 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7724), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7726), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7729), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7731), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7734), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7777), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7594), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7600), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7605), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7610), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7615), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7620), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "ErrorMessage", "ExecutionTime", "Language", "PlagiarismScore", "Result", "Status", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7982), null, 50.5f, "Python", 0.1f, "Output: Hello World", "Success", 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7983) },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println(\"Hello\"); } }", new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(7987), null, 120f, "Java", 0.2f, "Output: Hello", "Success", 2L, new DateTime(2025, 5, 19, 16, 0, 19, 47, DateTimeKind.Utc).AddTicks(7989) },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(7992), null, 30.2f, "JavaScript", 0.15f, "Output: Hello World", "Success", 3L, new DateTime(2025, 5, 19, 15, 0, 19, 47, DateTimeKind.Utc).AddTicks(7993) },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 19, 14, 0, 19, 47, DateTimeKind.Utc).AddTicks(7996), "SyntaxError: unexpected EOF while parsing", null, "Python", 0.3f, "Error: Invalid syntax", "Failed", 4L, new DateTime(2025, 5, 19, 14, 0, 19, 47, DateTimeKind.Utc).AddTicks(7997) },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println(\"Test\"); } }", new DateTime(2025, 5, 19, 13, 0, 19, 47, DateTimeKind.Utc).AddTicks(8000), null, 110.5f, "Java", 0.1f, "Output: Test", "Success", 5L, new DateTime(2025, 5, 19, 13, 0, 19, 47, DateTimeKind.Utc).AddTicks(8001) },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 19, 12, 0, 19, 47, DateTimeKind.Utc).AddTicks(8004), null, 45f, "Python", 0.05f, "Output: IoT Security", "Success", 6L, new DateTime(2025, 5, 19, 12, 0, 19, 47, DateTimeKind.Utc).AddTicks(8005) },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 19, 11, 0, 19, 47, DateTimeKind.Utc).AddTicks(8009), null, 25.8f, "JavaScript", 0.2f, "Output: Social Media", "Success", 7L, new DateTime(2025, 5, 19, 11, 0, 19, 47, DateTimeKind.Utc).AddTicks(8009) },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 19, 10, 0, 19, 47, DateTimeKind.Utc).AddTicks(8013), "Process exceeded 5-second limit", null, "Python", 0.4f, "Execution timed out", "Timeout", 8L, new DateTime(2025, 5, 19, 10, 0, 19, 47, DateTimeKind.Utc).AddTicks(8013) },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println(\"Warehouse\"); } }", new DateTime(2025, 5, 19, 9, 0, 19, 47, DateTimeKind.Utc).AddTicks(8016), null, 130f, "Java", 0.1f, "Output: Warehouse", "Success", 9L, new DateTime(2025, 5, 19, 9, 0, 19, 47, DateTimeKind.Utc).AddTicks(8017) },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 19, 8, 0, 19, 47, DateTimeKind.Utc).AddTicks(8020), null, 48.3f, "Python", 0.05f, "Output: Booking System", "Success", 10L, new DateTime(2025, 5, 19, 8, 0, 19, 47, DateTimeKind.Utc).AddTicks(8021) },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 19, 7, 0, 19, 47, DateTimeKind.Utc).AddTicks(8024), null, 28.7f, "JavaScript", 0.15f, "Output: HR System", "Success", 11L, new DateTime(2025, 5, 19, 7, 0, 19, 47, DateTimeKind.Utc).AddTicks(8024) },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 19, 6, 0, 19, 47, DateTimeKind.Utc).AddTicks(8027), "NameError: name 'undefined_variable' is not defined", null, "Python", 0.3f, "Error: NameError", "Failed", 12L, new DateTime(2025, 5, 19, 6, 0, 19, 47, DateTimeKind.Utc).AddTicks(8028) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7907), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7909), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7911), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7913), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7914), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7916), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7918), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7919), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7921), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7922), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7924), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7926), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8529), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8532), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8535), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8628), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8630), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8632), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8634), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8636), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8638), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8640), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8642), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8396), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8398), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8400), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8401), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8403), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8405), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8407), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8408), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8410), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8412), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8414), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8415), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 18, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8328), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8332), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8334), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8335), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8337), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8339), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8341), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8343), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8345), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8346), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8348), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(8350), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9078), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9080), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9082), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9083), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9085), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9086), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9088), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9089), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9091), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9092), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9094), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(9096), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7834), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 18, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7836), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7839), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7841), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7843), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7845), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7846), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7848), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7850), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7852), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7853), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 19, 17, 0, 19, 47, DateTimeKind.Utc).AddTicks(7855), "submissions/dt011_v1.pdf", 11L, 1 }
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
                unique: true);

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
                name: "IX_Projects_CourseId",
                table: "Projects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectCode",
                table: "Projects",
                column: "ProjectCode",
                unique: true);

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
                name: "FK_Groups_Users_LecturerId",
                table: "Groups",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id");
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
                name: "StudentCourses");

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
