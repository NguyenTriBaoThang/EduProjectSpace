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
                    FacultyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "DefenseSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeetingId = table.Column<long>(type: "bigint", nullable: true),
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
                    IsLeader = table.Column<bool>(type: "bit", nullable: false),
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
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: true),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    TaskId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Submissions_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
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
                    { 4L, new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3652), null, "Differential backup for Feb 4", "backups/db_backup_2025_02_04.sql", 73400320L, "Success", "Differential", new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3653) },
                    { 7L, new DateTime(2025, 5, 21, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3672), null, "Incremental backup for Feb 7", "backups/db_backup_2025_02_07.sql", 41943040L, "Success", "Incremental", new DateTime(2025, 5, 21, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3673) },
                    { 10L, new DateTime(2025, 5, 18, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3683), null, "Incremental backup for Feb 10", "backups/db_backup_2025_02_10.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 18, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3684) }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyCode", "FacultyName" },
                values: new object[,]
                {
                    { 1L, "CNPM", "Công nghệ phần mềm" },
                    { 2L, "ATTT", "An toàn thông tin" },
                    { 3L, "MMT", "Mạng máy tính" },
                    { 4L, "HTTT", "Hệ thống thông tin" },
                    { 5L, "TTNT", "Trí tuệ nhân tạo" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2202), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2205), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2208), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2210), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2212), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2215), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2217), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2219), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2221), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2223), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2225), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2227), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3794), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3798), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3801), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3018), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3020), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3022), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3024), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3026), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3028), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3030), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3032), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3033), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3035), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3037), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3039), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3119), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3121), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3123), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3126), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(3128), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(3131), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(3133), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(3136), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(3139), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(3141), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(3143), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(3146), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "DepartmentId", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8910), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8911) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8917), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8918) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8923), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8923) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8927), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8928) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8932), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8933) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8940), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8941) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8945), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8946) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8951), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8951) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8956), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8957) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8972), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8972) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8978), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp TTNT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8979) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8997), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở TTNT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8998) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name", "SemesterId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1168), "Hội đồng 1", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1169) },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1173), "Hội đồng 2", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1174) },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1177), "Hội đồng 3", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1177) },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1180), "Hội đồng 4", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1181) },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1183), "Hội đồng 5", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1184) },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1187), "Hội đồng 6", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1187) },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1190), "Hội đồng 7", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1191) },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1194), "Hội đồng 8", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1194) },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1197), "Hội đồng 9", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1201) },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1203), "Hội đồng 10", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1204) },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1206), "Hội đồng 11", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1207) },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1209), "Hội đồng 12", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1210) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "EditGrading", "EditProjects", "EditUsers", "RoleId", "UpdatedAt", "ViewGrading", "ViewProjects", "ViewUsers" },
                values: new object[,]
                {
                    { 1L, true, true, true, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(4025), true, true, true },
                    { 2L, false, false, false, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(4028), false, true, false },
                    { 3L, false, false, false, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(4031), false, true, false },
                    { 4L, false, false, false, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(4033), false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "DepartmentId", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8452), null, "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8453), "admin" },
                    { 2L, "/font-end/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8468), 1L, "AND123456789@hutech.edu.vn", 0, "Nguyễn Đình Ánh", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8469), "AND123456789" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8477), 2L, "HVT123456789@hutech.edu.vn", 0, "Văn Thiên Hoàng", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8478), "HVT123456789" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8605), 1L, "2180601452@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8605), "2180601452" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8637), 1L, "2180600307@hutech.edu.vn", 0, "Huỳnh Thành Đô", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8638), "2180600307" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8648), 1L, "1911256118@hutech.edu.vn", 0, "Nguyễn Thuận An", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8649), "1911256118" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8658), 2L, "2180603746@hutech.edu.vn", 0, "Võ Thành Trung", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8659), "2180603746" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8668), 3L, "2180603747@hutech.edu.vn", 0, "Lê Quang Vinh", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8669), "2180603747" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8689), 3L, "2180603748@hutech.edu.vn", 0, "Trần Quang Tài", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8690), "2180603748" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8700), 3L, "2180603749@hutech.edu.vn", 0, "Trần Văn Tuệ", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8700), "2180603749" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3447), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3453), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3459), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3465), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3471), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3477), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3637), 1L, "Daily full database backup", "backups/db_backup_2025_02_01.sql", 104857600L, "Success", "Full", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3637) },
                    { 2L, new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3642), 1L, "Incremental backup for Feb 2", "backups/db_backup_2025_02_02.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3643) },
                    { 3L, new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3647), 2L, "Daily full database backup", "backups/db_backup_2025_02_03.sql", 110100480L, "Success", "Full", new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3648) },
                    { 5L, new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3656), 1L, "Incremental backup failed due to disk space", "backups/db_backup_2025_02_05.sql", null, "Failed", "Incremental", new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3664) },
                    { 6L, new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3667), 2L, "Weekly full database backup", "backups/db_backup_2025_02_06.sql", 115343360L, "Success", "Full", new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3668) },
                    { 8L, new DateTime(2025, 5, 20, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3675), 1L, "Differential backup in progress", "backups/db_backup_2025_02_08.sql", null, "Pending", "Differential", new DateTime(2025, 5, 20, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3676) },
                    { 9L, new DateTime(2025, 5, 19, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3679), 2L, "Daily full database backup", "backups/db_backup_2025_02_09.sql", 120586240L, "Success", "Full", new DateTime(2025, 5, 19, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3680) },
                    { 11L, new DateTime(2025, 5, 17, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3687), 1L, "Differential backup for Feb 11", "backups/db_backup_2025_02_11.sql", 83886080L, "Success", "Differential", new DateTime(2025, 5, 17, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3688) },
                    { 12L, new DateTime(2025, 5, 16, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3692), 2L, "Daily full database backup", "backups/db_backup_2025_02_12.sql", 125829120L, "Success", "Full", new DateTime(2025, 5, 16, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3693) }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3221), "Họp nhóm để thảo luận tiến độ dự án", new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, false, "Phòng họp A", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3222), 7L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3239), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3240), 9L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3251), "Nộp báo cáo nhiệm vụ cá nhân", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3251), 11L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3274), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3274), 13L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3283), "Nộp báo cáo thực tập", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3284), 8L },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3293), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3294), 10L },
                    { 14L, new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3307), "Nộp bài tập môn Cấu trúc dữ liệu", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp bài tập", null, false, "Phòng họp B", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3308), 12L },
                    { 16L, new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3319), "Thi cuối kỳ môn Lập trình nâng cao", new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 101", new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3320), 7L },
                    { 18L, new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3330), "Nộp báo cáo dự án nhóm", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp báo cáo", null, false, "Phòng họp B", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3331), 9L },
                    { 20L, new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3340), "Thi cuối kỳ môn Cơ sở dữ liệu", new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 102", new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3341), 11L },
                    { 22L, new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3350), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 4, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3351), 13L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1284), 2L, "Chủ tịch", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1285) },
                    { 3L, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1292), 3L, "Chủ tịch", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1293) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2470), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2656), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2659), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2661), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2663), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2666), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2668), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2669), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2672), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2674), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2676), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2678), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2682), 4, 11L }
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
                    { 1L, "LOGIN", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3551), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3554), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3557), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3559), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3561), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3563), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3566), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3568), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1785), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1789), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "GroupId", "ProjectCode", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9122), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 1L, "AI_YTE_2025_01", "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9123) },
                    { 2L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9132), "Xây dựng hệ thống quản lý đồ án sinh viên.", 2L, "QLDA_2025_01", "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9133) },
                    { 3L, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9139), "Phát triển website bán hàng trực tuyến.", 3L, "TMĐT_2025_01", "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9139) },
                    { 4L, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9144), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 4L, "PTDL_2025_01", "SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9145) },
                    { 5L, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9150), "Phát triển app quản lý học tập cho sinh viên.", 5L, "QLHT_2025_01", "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9150) },
                    { 6L, 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9155), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 6L, "BM_IOT_2025_01", "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9156) },
                    { 7L, 6L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9161), "Phân tích hành vi người dùng trên mạng xã hội.", 7L, "PTMXH_2025_01", "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9161) },
                    { 8L, 7L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9166), "Phát triển app học ngoại ngữ với AI.", 9L, "HNN_2025_01", "GRADED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9167) },
                    { 9L, 8L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9171), "Xây dựng hệ thống quản lý kho hàng tự động.", 8L, "QLK_2025_01", "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9171) },
                    { 10L, 9L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9177), "Phát triển app đặt lịch khám bệnh trực tuyến.", 10L, "DLKB_2025_01", "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9177) },
                    { 11L, 10L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9183), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 12L, "QLNS_2025_01", "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9183) },
                    { 12L, 11L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9188), "Phát triển app hỗ trợ học tập nhóm.", 11L, "HTN_2025_01", "PENDING", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9189) },
                    { 13L, 12L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9193), "Xây dựng hệ thống phân tích tài chính cá nhân.", 13L, "PTTC_2025_01", "PENDING", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9194) }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2766), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2770), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2772), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2774), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2776), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2778), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2781), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2783), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2785), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2787), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2790), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2792), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3865), "ENROLLED", 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3865) },
                    { 2L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3869), "ENROLLED", 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3870) },
                    { 3L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3872), "ENROLLED", 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3873) },
                    { 4L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3875), "ENROLLED", 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3875) },
                    { 5L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3878), "ENROLLED", 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3879) },
                    { 6L, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3881), "ENROLLED", 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3882) },
                    { 7L, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3885), "ENROLLED", 13L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3885) },
                    { 8L, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3888), "ENROLLED", 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3888) },
                    { 9L, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3891), "ENROLLED", 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3891) },
                    { 10L, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3894), "ENROLLED", 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3895) },
                    { 11L, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3897), "ENROLLED", 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3899) },
                    { 12L, 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3901), "ENROLLED", 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3902) },
                    { 13L, 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3904), "ENROLLED", 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3905) },
                    { 14L, 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3907), "ENROLLED", 13L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3908) },
                    { 15L, 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3910), "ENROLLED", 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3911) },
                    { 16L, 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3914), "COMPLETED", 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3914) },
                    { 17L, 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3917), "COMPLETED", 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3918) },
                    { 18L, 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3920), "COMPLETED", 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3921) },
                    { 19L, 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3923), "COMPLETED", 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3924) },
                    { 20L, 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3926), "COMPLETED", 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3927) },
                    { 21L, 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3929), "COMPLETED", 13L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3930) },
                    { 22L, 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3932), "COMPLETED", 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3933) },
                    { 23L, 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3935), "COMPLETED", 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3936) },
                    { 24L, 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3938), "ENROLLED", 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3939) },
                    { 25L, 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3941), "ENROLLED", 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3942) },
                    { 26L, 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3944), "ENROLLED", 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3945) },
                    { 27L, 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3948), "ENROLLED", 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3948) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "DepartmentId", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8487), null, "CNH123456789@hutech.edu.vn", 0, "Nguyễn Huy Cường", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8487), "CNH123456789" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8584), null, "TNT123456789@hutech.edu.vn", 0, "Nguyễn Thanh Tùng", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8585), "TNT123456789" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8595), null, "KBP123456789@hutech.edu.vn", 0, "Bùi Phú Khuyên", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8595), "KBP123456789" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8713), 2L, "TDTT123456789@hutech.edu.vn", 0, "Đặng Thị Thạch Thảo", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8714), "TDTT123456789" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8723), 3L, "CHM123456789@hutech.edu.vn", 0, "Hàn Minh Châu", null, false, "$2a$11$MmTOc1jf3rBjKFC.8v5XfeFTeV5mEemXGLLFKFKddKenYqKoE0X12", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(8724), "CHM123456789" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3450), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3455), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3462), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3468), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3473), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3480), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1288), 4L, "Thành viên", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1289) },
                    { 4L, 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1295), 5L, "Thư ký", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1296) },
                    { 5L, 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1298), 6L, "Thành viên", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1299) },
                    { 6L, 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1302), 14L, "Chủ tịch", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1302) },
                    { 7L, 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1305), 15L, "Thư ký", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1305) },
                    { 8L, 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1307), 4L, "Thành viên", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1308) },
                    { 9L, 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1311), 5L, "Chủ tịch", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1311) },
                    { 10L, 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1313), 6L, "Thư ký", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1314) },
                    { 11L, 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1316), 14L, "Thành viên", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1317) },
                    { 12L, 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1319), 15L, "Chủ tịch", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1320) }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "MeetingId", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1408), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1411), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1414), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1417), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1419), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1422), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1424), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1427), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1430), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1435), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1437), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2467), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2472), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2475), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2478), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2480), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2483), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2486), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2489), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2492), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2495), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2497), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(974), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(980), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(983), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(985), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(987), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(990), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(992), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(994), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(996), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(998), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1001), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1003), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "LecturerId", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9389), null, 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9389) },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9395), null, 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9396) },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9401), null, 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9401) },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9406), null, 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9407) },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9411), null, 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9412) },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9417), null, 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9417) },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9422), null, 5, "Nhóm 7", 7L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9423) },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9428), null, 5, "Nhóm 8", 8L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9428) },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9434), null, 5, "Nhóm 9", 9L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9435) },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9439), null, 5, "Nhóm 10", 10L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9440) },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9445), null, 5, "Nhóm 11", 11L, "APPROVED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9446) },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9460), null, 5, "Nhóm 12", 12L, "PENDING", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9460) },
                    { 13L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9467), null, 5, "Nhóm 13", 13L, "PENDING", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9467) }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3570), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3571), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3573), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3575), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9276), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 26, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9279), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9290), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9293), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9295), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9298), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9299), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9301), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9303), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9305), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9307), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9309), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2098), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2100), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2103), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2105), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2108), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2110), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2112), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2114), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2116), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2118), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2120), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2123), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2000), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2005), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2008), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2010), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2012), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2015), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2017), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2019), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2021), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2023), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2026), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2876), 120, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2874), 1L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(2870), 7L },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2883), 60, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2882), 1L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(2881), 8L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2893), 180, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2886), 2L, new DateTime(2025, 5, 27, 0, 50, 7, 466, DateTimeKind.Utc).AddTicks(2885), 9L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2897), 60, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2896), 3L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(2894), 10L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2905), 120, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2903), 4L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(2899), 11L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2910), 240, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2909), 5L, new DateTime(2025, 5, 26, 23, 50, 7, 466, DateTimeKind.Utc).AddTicks(2908), 12L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2913), 60, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2912), 6L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(2911), 13L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2927), 120, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2925), 7L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(2915), 7L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2931), 180, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2930), 8L, new DateTime(2025, 5, 27, 0, 50, 7, 466, DateTimeKind.Utc).AddTicks(2929), 8L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2935), 60, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2934), 9L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(2933), 9L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2938), 120, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2938), 10L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(2937), 10L },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2942), 180, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2941), 11L, new DateTime(2025, 5, 27, 0, 50, 7, 466, DateTimeKind.Utc).AddTicks(2940), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3228), "Nộp bài tập lớn môn Lập trình", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, false, "Phòng họp B", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3229), 2L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3234), "Họp nhóm để phân công nhiệm vụ", new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, false, "Phòng họp B", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3234), 8L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3246), "Họp nhóm để kiểm tra tiến độ", new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, false, "Phòng họp C", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3247), 10L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3269), "Họp nhóm để chuẩn bị thuyết trình", new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, false, "Phòng họp A", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3270), 12L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3279), "Họp nhóm để hoàn thiện dự án", new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, false, "Phòng họp B", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3279), 7L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3289), "Họp nhóm để đánh giá tiến độ", new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, false, "Phòng họp C", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3289), 9L },
                    { 13L, new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3298), "Họp nhóm để phân tích yêu cầu dự án", new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 7L, false, "Phòng họp A", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3300), 11L },
                    { 15L, new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3312), "Họp nhóm để chuẩn bị báo cáo", new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 8L, false, "Phòng họp B", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 25, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3314), 13L },
                    { 17L, new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3324), "Họp nhóm bị hủy do lịch trùng", new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 9L, false, "Phòng họp C", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Meeting", new DateTime(2025, 5, 24, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3325), 8L },
                    { 19L, new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3335), "Họp nhóm để hoàn thiện thuyết trình", new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 10L, false, "Phòng họp A", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 23, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3336), 10L },
                    { 21L, new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3345), "Họp nhóm để đánh giá dự án", new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 11L, false, "Phòng họp B", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 5, 22, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(3346), 12L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Đã duyệt", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(655), 4L, 1L, 1L, 8.5f, 7L },
                    { 2L, "Đã duyệt", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(660), 4L, 1L, 1L, 8f, 7L },
                    { 3L, "Đã duyệt", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(663), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Chưa duyệt", 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(665), 6L, 3L, 3L, 8f, null },
                    { 5L, "Chưa duyệt", 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(668), 14L, 4L, 4L, 7f, null },
                    { 6L, "Chưa duyệt", 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(671), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Chưa duyệt", 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(673), 4L, 6L, 6L, 9f, null },
                    { 8L, "Chưa duyệt", 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(676), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Chưa duyệt", 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(678), 6L, 8L, 8L, 8f, null },
                    { 10L, "Chưa duyệt", 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(681), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Chưa duyệt", 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(684), 15L, 10L, 10L, 8f, null },
                    { 12L, "Đã duyệt", 13L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(686), 4L, 11L, 11L, 7f, null },
                    { 13L, "Đã duyệt", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(689), 4L, 1L, 1L, 8f, 8L },
                    { 14L, "Đã duyệt", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(692), 4L, 1L, 1L, 8f, 8L },
                    { 15L, "Đã duyệt", 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(695), 4L, 1L, 1L, 8f, 8L },
                    { 16L, "Đã duyệt", 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(698), 4L, 1L, 1L, 8.5f, 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "IsLeader", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9533), 7L },
                    { 2L, 1L, false, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9536), 8L },
                    { 3L, 2L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9538), 9L },
                    { 4L, 3L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9539), 10L },
                    { 5L, 3L, false, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9541), 11L },
                    { 6L, 4L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9544), 12L },
                    { 7L, 4L, false, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9546), 13L },
                    { 8L, 5L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9549), 7L },
                    { 9L, 6L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9551), 8L },
                    { 10L, 7L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9556), 9L },
                    { 11L, 8L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9558), 10L },
                    { 12L, 9L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9560), 11L },
                    { 13L, 10L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9562), 12L },
                    { 14L, 11L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9564), 13L },
                    { 15L, 12L, true, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9565), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9655), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9658), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9660), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9661), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9663), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9665), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9667), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9669), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9670), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9672), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9674), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9676), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1519), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1523), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1535), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1539), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1542), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1546), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1550), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1553), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1556), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1559), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1562), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1565), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1792), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1795), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1798), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1801), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1804), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1807), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1810), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1813), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1816), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1819), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1885), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1902), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1904), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1906), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1909), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1912), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1914), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1917), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1919), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1921), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1924), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1926), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(2003), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9752), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Báo cáo tuần 1" },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9756), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 2L, 2L, "IN_PROGRESS", null, "Báo cáo tuần 1" },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9759), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Báo cáo tuần 1" },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9763), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", 4L, 4L, "IN_PROGRESS", null, "Báo cáo tuần 1" },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9767), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Báo cáo tuần 1" },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9770), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", 6L, 6L, "IN_PROGRESS", null, "Báo cáo tuần 1" },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9773), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Báo cáo tuần 1" },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9777), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", 8L, 8L, "IN_PROGRESS", null, "Báo cáo tuần 1" },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9780), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Báo cáo tuần 1" },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9784), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", 10L, 10L, "IN_PROGRESS", null, "Báo cáo tuần 1" },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9788), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Báo cáo tuần 1" },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9791), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", 12L, 12L, "TODO", null, "Báo cáo tuần 1" },
                    { 13L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9796), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 1L, 1L, "IN_PROGRESS", null, "Báo cáo tuần 2" },
                    { 14L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9806), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 1L, 1L, "IN_PROGRESS", null, "Báo cáo tuần 3" },
                    { 15L, new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9809), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Báo cáo đồ án.", 1L, 1L, "IN_PROGRESS", null, "Báo cáo cuối kỳ" }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "MeetingId", "ProjectId", "Room", "StartTime" },
                values: new object[] { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1404), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1070), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1073), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1075), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1077), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1079), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1080), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1083), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1085), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1087), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1089), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1091), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(884), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(887), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(889), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(891), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(893), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(895), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(897), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(899), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(901), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(903), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(904), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(907), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(786), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(791), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(793), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(794), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(797), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(799), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(801), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(803), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(805), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(807), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(809), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(811), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1631), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1635), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1638), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1642), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1645), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1648), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1651), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1654), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1657), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1660), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1663), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(1666), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "TaskId", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9929), 1L, 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9951), 2L, 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9955), 3L, 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9959), 4L, 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9963), 5L, 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9967), 6L, 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9970), 7L, 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9973), 8L, 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9977), 9L, 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9981), 10L, 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9985), 11L, 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9989), 12L, 1 },
                    { 13L, "submissions/dt013.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9992), 1L, 1 },
                    { 14L, "submissions/dt014.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 27, 3, 50, 7, 465, DateTimeKind.Utc).AddTicks(9996), 15L, 1 }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "ErrorMessage", "ExecutionTime", "Language", "PlagiarismScore", "Result", "Status", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(278), null, 50.5f, "Python", 0.1f, "Output: Hello World", "Success", 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(279) },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println(\"Hello\"); } }", new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(283), null, 120f, "Java", 0.2f, "Output: Hello", "Success", 2L, new DateTime(2025, 5, 27, 2, 50, 7, 466, DateTimeKind.Utc).AddTicks(288) },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(292), null, 30.2f, "JavaScript", 0.15f, "Output: Hello World", "Success", 3L, new DateTime(2025, 5, 27, 1, 50, 7, 466, DateTimeKind.Utc).AddTicks(293) },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 27, 0, 50, 7, 466, DateTimeKind.Utc).AddTicks(297), "SyntaxError: unexpected EOF while parsing", null, "Python", 0.3f, "Error: Invalid syntax", "Failed", 4L, new DateTime(2025, 5, 27, 0, 50, 7, 466, DateTimeKind.Utc).AddTicks(298) },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println(\"Test\"); } }", new DateTime(2025, 5, 26, 23, 50, 7, 466, DateTimeKind.Utc).AddTicks(302), null, 110.5f, "Java", 0.1f, "Output: Test", "Success", 5L, new DateTime(2025, 5, 26, 23, 50, 7, 466, DateTimeKind.Utc).AddTicks(303) },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 26, 22, 50, 7, 466, DateTimeKind.Utc).AddTicks(306), null, 45f, "Python", 0.05f, "Output: IoT Security", "Success", 6L, new DateTime(2025, 5, 26, 22, 50, 7, 466, DateTimeKind.Utc).AddTicks(307) },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 26, 21, 50, 7, 466, DateTimeKind.Utc).AddTicks(310), null, 25.8f, "JavaScript", 0.2f, "Output: Social Media", "Success", 7L, new DateTime(2025, 5, 26, 21, 50, 7, 466, DateTimeKind.Utc).AddTicks(311) },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 26, 20, 50, 7, 466, DateTimeKind.Utc).AddTicks(314), "Process exceeded 5-second limit", null, "Python", 0.4f, "Execution timed out", "Timeout", 8L, new DateTime(2025, 5, 26, 20, 50, 7, 466, DateTimeKind.Utc).AddTicks(315) },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println(\"Warehouse\"); } }", new DateTime(2025, 5, 26, 19, 50, 7, 466, DateTimeKind.Utc).AddTicks(319), null, 130f, "Java", 0.1f, "Output: Warehouse", "Success", 9L, new DateTime(2025, 5, 26, 19, 50, 7, 466, DateTimeKind.Utc).AddTicks(320) },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 26, 18, 50, 7, 466, DateTimeKind.Utc).AddTicks(323), null, 48.3f, "Python", 0.05f, "Output: Booking System", "Success", 10L, new DateTime(2025, 5, 26, 18, 50, 7, 466, DateTimeKind.Utc).AddTicks(324) },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 26, 17, 50, 7, 466, DateTimeKind.Utc).AddTicks(327), null, 28.7f, "JavaScript", 0.15f, "Output: HR System", "Success", 11L, new DateTime(2025, 5, 26, 17, 50, 7, 466, DateTimeKind.Utc).AddTicks(328) },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 26, 16, 50, 7, 466, DateTimeKind.Utc).AddTicks(331), "NameError: name 'undefined_variable' is not defined", null, "Python", 0.3f, "Error: NameError", "Failed", 12L, new DateTime(2025, 5, 26, 16, 50, 7, 466, DateTimeKind.Utc).AddTicks(332) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(171), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(178), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(179), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(181), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(183), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(188), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(190), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(191), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(193), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(194), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(196), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(199), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(83), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 26, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(86), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(90), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(93), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(94), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(96), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(98), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(99), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(101), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(103), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(105), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 27, 3, 50, 7, 466, DateTimeKind.Utc).AddTicks(106), "submissions/dt011_v1.pdf", 11L, 1 }
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
                name: "IX_DefenseSchedules_MeetingId",
                table: "DefenseSchedules",
                column: "MeetingId");

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
                name: "IX_Submissions_TaskId",
                table: "Submissions",
                column: "TaskId");

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
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

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
                name: "FK_DefenseSchedules_Meetings_MeetingId",
                table: "DefenseSchedules",
                column: "MeetingId",
                principalTable: "Meetings",
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
                name: "Tasks");

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
