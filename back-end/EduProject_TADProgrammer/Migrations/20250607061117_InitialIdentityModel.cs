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
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "Id");
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
                name: "LecturerCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerCourses_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
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
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Submissions_Users_StudentId",
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
                    { 4L, new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9560), null, "Differential backup for Feb 4", "backups/db_backup_2025_02_04.sql", 73400320L, "Success", "Differential", new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9560) },
                    { 7L, new DateTime(2025, 6, 1, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9574), null, "Incremental backup for Feb 7", "backups/db_backup_2025_02_07.sql", 41943040L, "Success", "Incremental", new DateTime(2025, 6, 1, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9575) },
                    { 10L, new DateTime(2025, 5, 29, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9584), null, "Incremental backup for Feb 10", "backups/db_backup_2025_02_10.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 5, 29, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9585) }
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
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8460), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8462), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8464), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8465), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8467), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8468), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8470), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8472), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8473), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8475), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8476), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8478), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9646), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9649), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9651), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9059), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9062), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9063), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9064), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9066), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9067), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9069), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9070), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9071), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9073), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9074), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9076), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9123), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9125), "RAM", 60f },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9126), "DISK", 75f },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9127), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9129), "CPU", 50f },
                    { 6L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9131), "RAM", 65f },
                    { 7L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9132), "DISK", 80f },
                    { 8L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9134), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9136), "CPU", 55f },
                    { 10L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9137), "RAM", 70f },
                    { 11L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9139), "DISK", 85f },
                    { 12L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9141), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "DepartmentId", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5848), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5848) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5854), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5855) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5859), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5859) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5863), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5864) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5868), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5868) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5872), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5873) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5876), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5877) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5881) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5886), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5887) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5895), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5895) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp TTNT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5900) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5904), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở TTNT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5904) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name", "SemesterId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7734), "Hội đồng 1", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7736) },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7738), "Hội đồng 2", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7739) },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7741), "Hội đồng 3", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7741) },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7743), "Hội đồng 4", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7744) },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7746), "Hội đồng 5", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7746) },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7748), "Hội đồng 6", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7749) },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7751), "Hội đồng 7", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7751) },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7753), "Hội đồng 8", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7753) },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7755), "Hội đồng 9", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7756) },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7758), "Hội đồng 10", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7758) },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7760), "Hội đồng 11", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7760) },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7762), "Hội đồng 12", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7763) }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "EditGrading", "EditProjects", "EditUsers", "RoleId", "UpdatedAt", "ViewGrading", "ViewProjects", "ViewUsers" },
                values: new object[,]
                {
                    { 1L, true, true, true, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9866), true, true, true },
                    { 2L, false, false, false, 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9869), false, true, false },
                    { 3L, false, false, false, 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9871), false, true, false },
                    { 4L, false, false, false, 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9873), false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "DepartmentId", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5426), null, "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5427), "admin" },
                    { 2L, "/font-end/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5528), 1L, "AND123456789@hutech.edu.vn", 0, "Nguyễn Đình Ánh", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5529), "AND123456789" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5536), 2L, "HVT123456789@hutech.edu.vn", 0, "Văn Thiên Hoàng", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5536), "HVT123456789" },
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5542), null, "CNH123456789@hutech.edu.vn", 0, "Nguyễn Huy Cường", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5543), "CNH123456789" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5549), null, "TNT123456789@hutech.edu.vn", 0, "Nguyễn Thanh Tùng", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5549), "TNT123456789" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5555), null, "KBP123456789@hutech.edu.vn", 0, "Bùi Phú Khuyên", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5556), "KBP123456789" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5562), 1L, "2180601452@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5563), "2180601452" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5586), 1L, "2180600307@hutech.edu.vn", 0, "Huỳnh Thành Đô", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5586), "2180600307" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5641), 1L, "1911256118@hutech.edu.vn", 0, "Nguyễn Thuận An", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5642), "1911256118" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5650), 2L, "2180603746@hutech.edu.vn", 0, "Võ Thành Trung", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5652), "2180603746" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5658), 3L, "2180603747@hutech.edu.vn", 0, "Lê Quang Vinh", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5658), "2180603747" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5665), 3L, "2180603748@hutech.edu.vn", 0, "Trần Quang Tài", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5666), "2180603748" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5672), 3L, "2180603749@hutech.edu.vn", 0, "Trần Văn Tuệ", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5673), "2180603749" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5684), 2L, "TDTT123456789@hutech.edu.vn", 0, "Đặng Thị Thạch Thảo", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5684), "TDTT123456789" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5691), 3L, "CHM123456789@hutech.edu.vn", 0, "Hàn Minh Châu", null, false, "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5691), "CHM123456789" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9346), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9350), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9416), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9420), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9423), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9428), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Backups",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "FilePath", "FileSize", "Status", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9548), 1L, "Daily full database backup", "backups/db_backup_2025_02_01.sql", 104857600L, "Success", "Full", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9549) },
                    { 2L, new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9552), 1L, "Incremental backup for Feb 2", "backups/db_backup_2025_02_02.sql", 52428800L, "Success", "Incremental", new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9554) },
                    { 3L, new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9556), 2L, "Daily full database backup", "backups/db_backup_2025_02_03.sql", 110100480L, "Success", "Full", new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9557) },
                    { 5L, new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9563), 1L, "Incremental backup failed due to disk space", "backups/db_backup_2025_02_05.sql", null, "Failed", "Incremental", new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9569) },
                    { 6L, new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9571), 2L, "Weekly full database backup", "backups/db_backup_2025_02_06.sql", 115343360L, "Success", "Full", new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9572) },
                    { 8L, new DateTime(2025, 5, 31, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9578), 1L, "Differential backup in progress", "backups/db_backup_2025_02_08.sql", null, "Pending", "Differential", new DateTime(2025, 5, 31, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9578) },
                    { 9L, new DateTime(2025, 5, 30, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9581), 2L, "Daily full database backup", "backups/db_backup_2025_02_09.sql", 120586240L, "Success", "Full", new DateTime(2025, 5, 30, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9582) },
                    { 11L, new DateTime(2025, 5, 28, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9588), 1L, "Differential backup for Feb 11", "backups/db_backup_2025_02_11.sql", 83886080L, "Success", "Differential", new DateTime(2025, 5, 28, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9588) },
                    { 12L, new DateTime(2025, 5, 27, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9591), 2L, "Daily full database backup", "backups/db_backup_2025_02_12.sql", 125829120L, "Success", "Full", new DateTime(2025, 5, 27, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9592) }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9201), "Họp nhóm để thảo luận tiến độ dự án", new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, false, "Phòng họp A", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9201), 7L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9215), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9216), 9L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9224), "Nộp báo cáo nhiệm vụ cá nhân", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9224), 11L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9231), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9231), 13L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9239), "Nộp báo cáo thực tập", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, false, "Phòng họp B", new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9239), 8L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9247), "Bảo vệ đồ án tốt nghiệp", new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9248), 10L },
                    { 14L, new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9255), "Nộp bài tập môn Cấu trúc dữ liệu", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp bài tập", null, false, "Phòng họp B", new DateTime(2025, 3, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9256), 12L },
                    { 16L, new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9263), "Thi cuối kỳ môn Lập trình nâng cao", new DateTime(2025, 4, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 101", new DateTime(2025, 4, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9263), 7L },
                    { 18L, new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9271), "Nộp báo cáo dự án nhóm", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp báo cáo", null, false, "Phòng họp B", new DateTime(2025, 4, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9271), 9L },
                    { 20L, new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9279), "Thi cuối kỳ môn Cơ sở dữ liệu", new DateTime(2025, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Thi cuối kỳ", null, false, "Phòng thi 102", new DateTime(2025, 4, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9280), 11L },
                    { 22L, new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9287), "Bảo vệ đồ án chuyên ngành", new DateTime(2025, 4, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, false, "Hội trường", new DateTime(2025, 4, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Other", new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9288), 13L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7809), 2L, "Chủ tịch", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7810) },
                    { 2L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7812), 4L, "Thành viên", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7812) },
                    { 3L, 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7814), 3L, "Chủ tịch", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7815) },
                    { 4L, 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7817), 5L, "Thư ký", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7817) },
                    { 5L, 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7819), 6L, "Thành viên", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7820) },
                    { 6L, 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7822), 14L, "Chủ tịch", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7822) },
                    { 7L, 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7824), 15L, "Thư ký", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7824) },
                    { 8L, 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7826), 4L, "Thành viên", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7827) },
                    { 9L, 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7829), 5L, "Chủ tịch", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7829) },
                    { 10L, 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7831), 6L, "Thư ký", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7831) },
                    { 11L, 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7833), 14L, "Thành viên", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7834) },
                    { 12L, 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7835), 15L, "Chủ tịch", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7836) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8635), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8730), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8732), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8734), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8735), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8737), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8739), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8741), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8742), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8744), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8745), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8747), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8748), 4, 11L }
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
                table: "LecturerCourses",
                columns: new[] { "Id", "AssignedAt", "CourseId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9957), 1L, 4L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9959), 1L, 5L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9960), 1L, 6L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9962), 2L, 4L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9964), 2L, 5L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9965), 2L, 6L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9967), 3L, 4L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9968), 3L, 5L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9970), 3L, 6L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9971), 4L, 4L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9973), 4L, 5L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9974), 4L, 6L },
                    { 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9976), 5L, 14L },
                    { 14L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9977), 6L, 14L },
                    { 15L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9979), 7L, 15L },
                    { 16L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9980), 8L, 14L },
                    { 17L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9982), 9L, 6L },
                    { 18L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9983), 10L, 5L },
                    { 19L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9984), 11L, 4L },
                    { 20L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9986), 12L, 15L },
                    { 21L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9987), 1L, 2L },
                    { 22L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9989), 2L, 2L },
                    { 23L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9990), 3L, 2L },
                    { 24L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9992), 4L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 1L, "LOGIN", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9481), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9483), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9485), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9486), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9488), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9489), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9491), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9492), "Gửi tin nhắn trong Nhóm 6.", 13L },
                    { 9L, "GRADE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9494), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9495), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9497), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9498), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8144), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 4L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8147), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 4L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ApprovalReason", "ApprovalStatus", "CourseId", "CreatedAt", "Description", "GroupId", "ProjectCode", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, null, "APPROVED", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5997), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 1L, "AI_YTE_2025_01", "APPROVED", "Ứng dụng AI trong y tế", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5998) },
                    { 2L, null, "APPROVED", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6003), "Xây dựng hệ thống quản lý đồ án sinh viên.", 2L, "QLDA_2025_01", "APPROVED", "Hệ thống quản lý đồ án", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6004) },
                    { 3L, null, "APPROVED", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6008), "Phát triển website bán hàng trực tuyến.", 3L, "TMĐT_2025_01", "PENDING", "Ứng dụng thương mại điện tử", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6008) },
                    { 4L, null, "APPROVED", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6013), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 4L, "PTDL_2025_01", "PENDING", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6013) },
                    { 5L, null, "REJECTED", 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6017), "Phát triển app quản lý học tập cho sinh viên.", 5L, "QLHT_2025_01", "PENDING", "Ứng dụng quản lý học tập", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6018) },
                    { 6L, null, "PENDING", 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6022), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 6L, "BM_IOT_2025_01", "NOT_SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6022) },
                    { 7L, null, "PENDING", 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6119), "Phân tích hành vi người dùng trên mạng xã hội.", 7L, "PTMXH_2025_01", "NOT_SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6120) },
                    { 8L, null, "PENDING", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6124), "Phát triển app học ngoại ngữ với AI.", 9L, "HNN_2025_01", "APPROVED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6124) },
                    { 9L, null, "PENDING", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6128), "Xây dựng hệ thống quản lý kho hàng tự động.", 8L, "QLK_2025_01", "APPROVED", "Hệ thống quản lý kho", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6129) },
                    { 10L, null, "PENDING", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6133), "Phát triển app đặt lịch khám bệnh trực tuyến.", 10L, "DLKB_2025_01", "APPROVED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6133) },
                    { 11L, null, "PENDING", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6137), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 12L, "QLNS_2025_01", "APPROVED", "Hệ thống quản lý nhân sự", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6138) },
                    { 12L, null, "APPROVED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6142), "Phát triển app hỗ trợ học tập nhóm.", 11L, "HTN_2025_01", "PENDING", "Ứng dụng học tập nhóm", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6143) },
                    { 13L, null, "APPROVED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6147), "Xây dựng hệ thống phân tích tài chính cá nhân.", 13L, "PTTC_2025_01", "PENDING", "Hệ thống phân tích tài chính", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6148) }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8806), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8808), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8810), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8811), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8813), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8814), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8816), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8817), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8819), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8820), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8822), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8823), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9692), "ENROLLED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9692) },
                    { 2L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9695), "ENROLLED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9695) },
                    { 3L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9697), "ENROLLED", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9697) },
                    { 4L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9699), "ENROLLED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9700) },
                    { 5L, 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9702), "ENROLLED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9702) },
                    { 6L, 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9704), "ENROLLED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9704) },
                    { 7L, 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9707), "ENROLLED", 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9707) },
                    { 8L, 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9709), "ENROLLED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9710) },
                    { 9L, 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9712), "ENROLLED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9712) },
                    { 10L, 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9714), "ENROLLED", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9715) },
                    { 11L, 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9716), "ENROLLED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9717) },
                    { 12L, 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9719), "ENROLLED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9719) },
                    { 13L, 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9721), "ENROLLED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9722) },
                    { 14L, 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9723), "ENROLLED", 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9724) },
                    { 15L, 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9726), "ENROLLED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9726) },
                    { 16L, 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9728), "COMPLETED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9729) },
                    { 17L, 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9730), "COMPLETED", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9731) },
                    { 18L, 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9733), "COMPLETED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9733) },
                    { 19L, 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9735), "COMPLETED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9735) },
                    { 20L, 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9737), "COMPLETED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9738) },
                    { 21L, 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9740), "COMPLETED", 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9740) },
                    { 22L, 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9742), "COMPLETED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9742) },
                    { 23L, 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9744), "COMPLETED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9745) },
                    { 24L, 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9747), "ENROLLED", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9747) },
                    { 25L, 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9749), "ENROLLED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9749) },
                    { 26L, 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9751), "ENROLLED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9752) },
                    { 27L, 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9753), "ENROLLED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9754) }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9348), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9352), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9418), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9422), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9425), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9429), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "MeetingId", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7883), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7885), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7887), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7889), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7891), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7893), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7895), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7897), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7899), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7901), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7903), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), null, 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8632), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8637), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8639), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8641), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8643), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8645), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8648), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8649), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8652), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8653), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8655), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7556), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7558), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7560), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7562), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7564), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7566), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7567), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7569), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7571), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7573), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7574), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7576), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "LecturerId", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6308), 4L, 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6308) },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6313), 4L, 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6313) },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6318), 4L, 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6318) },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6386), null, 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6387) },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6391), null, 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6391) },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6395), null, 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6395) },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6399), null, 5, "Nhóm 7", 7L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6399) },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6403), null, 5, "Nhóm 8", 8L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6404) },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6408), null, 5, "Nhóm 9", 9L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6408) },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6412), null, 5, "Nhóm 10", 10L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6413) },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6416), null, 5, "Nhóm 11", 11L, "APPROVED", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6417) },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6421), null, 5, "Nhóm 12", 12L, "PENDING", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6422) },
                    { 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6425), null, 5, "Nhóm 13", 13L, "PENDING", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6426) }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6217), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6219), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6231), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6232), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6234), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6235), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6237), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6239), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6240), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6242), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6244), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6246), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8361), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8363), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8365), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8393), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8395), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8396), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8398), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8399), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8401), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8402), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8404), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8405), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8292), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8296), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8298), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8300), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8302), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8304), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8306), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8307), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8309), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8311), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8313), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8882), 120, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8881), 1L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8876), 7L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8886), 60, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8885), 1L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8884), 8L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8892), 180, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8888), 2L, new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(8887), 9L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8895), 60, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8894), 3L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8893), 10L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8900), 120, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8900), 4L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8896), 11L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8903), 240, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8902), 5L, new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(8902), 12L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8906), 60, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8905), 6L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8905), 13L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8989), 120, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8987), 7L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8982), 7L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8993), 180, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8992), 8L, new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(8991), 8L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8996), 60, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8995), 9L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8994), 9L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8999), 120, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8998), 10L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8997), 10L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9002), 180, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9001), 11L, new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(9000), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "EventTitle", "GroupId", "IsAllDay", "Location", "StartTime", "Status", "Type", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9207), "Nộp bài tập lớn môn Lập trình", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, false, "Phòng họp B", new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Deadline", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9208), 2L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9212), "Họp nhóm để phân công nhiệm vụ", new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, false, "Phòng họp B", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9212), 8L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9220), "Họp nhóm để kiểm tra tiến độ", new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, false, "Phòng họp C", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9220), 10L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9227), "Họp nhóm để chuẩn bị thuyết trình", new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, false, "Phòng họp A", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9228), 12L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9235), "Họp nhóm để hoàn thiện dự án", new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, false, "Phòng họp B", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9236), 7L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9244), "Họp nhóm để đánh giá tiến độ", new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, false, "Phòng họp C", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9244), 9L },
                    { 13L, new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9251), "Họp nhóm để phân tích yêu cầu dự án", new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 7L, false, "Phòng họp A", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9252), 11L },
                    { 15L, new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9259), "Họp nhóm để chuẩn bị báo cáo", new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 8L, false, "Phòng họp B", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9260), 13L },
                    { 17L, new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9267), "Họp nhóm bị hủy do lịch trùng", new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 9L, false, "Phòng họp C", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Meeting", new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9268), 8L },
                    { 19L, new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9275), "Họp nhóm để hoàn thiện thuyết trình", new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 10L, false, "Phòng họp A", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9276), 10L },
                    { 21L, new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9283), "Họp nhóm để đánh giá dự án", new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 11L, false, "Phòng họp B", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled", "Meeting", new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9284), 12L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Đã duyệt", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7288), 4L, 1L, 1L, 8.5f, 7L },
                    { 2L, "Đã duyệt", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7291), 4L, 1L, 1L, 8f, 7L },
                    { 3L, "Đã duyệt", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7293), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Chưa duyệt", 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7296), 6L, 3L, 3L, 8f, null },
                    { 5L, "Chưa duyệt", 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7298), 14L, 4L, 4L, 7f, null },
                    { 6L, "Chưa duyệt", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7300), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Chưa duyệt", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7350), 4L, 6L, 6L, 9f, null },
                    { 8L, "Chưa duyệt", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7352), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Chưa duyệt", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7355), 6L, 8L, 8L, 8f, null },
                    { 10L, "Chưa duyệt", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7357), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Chưa duyệt", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7359), 15L, 10L, 10L, 8f, null },
                    { 12L, "Đã duyệt", 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7362), 4L, 11L, 11L, 7f, null },
                    { 13L, "Đã duyệt", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7364), 4L, 1L, 1L, 8f, 8L },
                    { 14L, "Đã duyệt", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7367), 4L, 1L, 1L, 8f, 8L },
                    { 15L, "Đã duyệt", 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7370), 4L, 1L, 1L, 8f, 8L },
                    { 16L, "Đã duyệt", 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7372), 4L, 1L, 1L, 8.5f, 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "IsLeader", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6475), 7L },
                    { 2L, 1L, false, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6477), 8L },
                    { 3L, 2L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6479), 9L },
                    { 4L, 3L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6480), 10L },
                    { 5L, 3L, false, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6482), 11L },
                    { 6L, 4L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6483), 12L },
                    { 7L, 4L, false, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6485), 13L },
                    { 8L, 5L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6486), 7L },
                    { 9L, 6L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6488), 8L },
                    { 10L, 7L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6490), 9L },
                    { 11L, 8L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6491), 10L },
                    { 12L, 9L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6493), 11L },
                    { 13L, 10L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6494), 12L },
                    { 14L, 11L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6497), 13L },
                    { 15L, 12L, true, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6498), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6561), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6563), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6565), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6566), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6568), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6570), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6571), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6573), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6574), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6576), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6577), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6579), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7947), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7951), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7957), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7960), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7962), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7965), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7968), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7971), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7973), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7976), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7978), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8025), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8150), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8152), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8154), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8156), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8159), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8161), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8164), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8166), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8168), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8170), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8221), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8224), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8226), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8228), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8229), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8231), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8233), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8235), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8236), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8238), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8240), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8242), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8294), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6685), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", "Báo cáo tuần 1" },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6689), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 2L, 2L, "IN_PROGRESS", "Báo cáo tuần 1" },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6692), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", "Báo cáo tuần 1" },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6695), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", 4L, 4L, "IN_PROGRESS", "Báo cáo tuần 1" },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6697), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", "Báo cáo tuần 1" },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6700), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", 6L, 6L, "IN_PROGRESS", "Báo cáo tuần 1" },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6702), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", "Báo cáo tuần 1" },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6705), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", 8L, 8L, "IN_PROGRESS", "Báo cáo tuần 1" },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6707), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", "Báo cáo tuần 1" },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6710), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", 10L, 10L, "IN_PROGRESS", "Báo cáo tuần 1" },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6712), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", "Báo cáo tuần 1" },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6714), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", 12L, 12L, "TODO", "Báo cáo tuần 1" },
                    { 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6717), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 1L, 1L, "IN_PROGRESS", "Báo cáo tuần 2" },
                    { 14L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6719), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", 1L, 1L, "IN_PROGRESS", "Báo cáo tuần 3" },
                    { 15L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6722), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Báo cáo đồ án.", 1L, 1L, "IN_PROGRESS", "Báo cáo cuối kỳ" }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "MeetingId", "ProjectId", "Room", "StartTime" },
                values: new object[] { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7880), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7621), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7624), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7626), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7628), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7629), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7631), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7633), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7677), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7679), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7680), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7682), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7492), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7494), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7496), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7498), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7500), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7501), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7503), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7505), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7506), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7508), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7509), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7511), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7433), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7435), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7437), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7439), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7440), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7442), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7443), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7445), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7447), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7448), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7450), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7451), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8079), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8080), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8082), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8083), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8085), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8086), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8087), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8089), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8090), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8092), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8093), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8095), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "StudentId", "SubmittedAt", "TaskId", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6816), 1L, 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6819), 2L, 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6822), 3L, 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6826), 4L, 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6828), 5L, 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6831), 6L, 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6834), 7L, 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6837), 8L, 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6840), 9L, 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6843), 10L, 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", 13L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6846), 11L, 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6849), 12L, 1 },
                    { 13L, "submissions/dt013.pdf", 1L, 1L, "SUBMITTED", 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6851), 1L, 1 },
                    { 14L, "submissions/dt014.pdf", 1L, 1L, "SUBMITTED", 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6854), 15L, 1 }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "ErrorMessage", "ExecutionTime", "Language", "PlagiarismScore", "Result", "Status", "SubmissionId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7089), null, 50.5f, "Python", 0.1f, "Output: Hello World", "Success", 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7090) },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println(\"Hello\"); } }", new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(7094), null, 120f, "Java", 0.2f, "Output: Hello", "Success", 2L, new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(7096) },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(7099), null, 30.2f, "JavaScript", 0.15f, "Output: Hello World", "Success", 3L, new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(7100) },
                    { 4L, "print('Error Test')", new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(7103), "SyntaxError: unexpected EOF while parsing", null, "Python", 0.3f, "Error: Invalid syntax", "Failed", 4L, new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(7104) },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println(\"Test\"); } }", new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(7108), null, 110.5f, "Java", 0.1f, "Output: Test", "Success", 5L, new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(7108) },
                    { 6L, "print('IoT Security')", new DateTime(2025, 6, 7, 1, 11, 14, 130, DateTimeKind.Utc).AddTicks(7112), null, 45f, "Python", 0.05f, "Output: IoT Security", "Success", 6L, new DateTime(2025, 6, 7, 1, 11, 14, 130, DateTimeKind.Utc).AddTicks(7112) },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 6, 7, 0, 11, 14, 130, DateTimeKind.Utc).AddTicks(7115), null, 25.8f, "JavaScript", 0.2f, "Output: Social Media", "Success", 7L, new DateTime(2025, 6, 7, 0, 11, 14, 130, DateTimeKind.Utc).AddTicks(7116) },
                    { 8L, "print('Language Learning')", new DateTime(2025, 6, 6, 23, 11, 14, 130, DateTimeKind.Utc).AddTicks(7119), "Process exceeded 5-second limit", null, "Python", 0.4f, "Execution timed out", "Timeout", 8L, new DateTime(2025, 6, 6, 23, 11, 14, 130, DateTimeKind.Utc).AddTicks(7119) },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println(\"Warehouse\"); } }", new DateTime(2025, 6, 6, 22, 11, 14, 130, DateTimeKind.Utc).AddTicks(7122), null, 130f, "Java", 0.1f, "Output: Warehouse", "Success", 9L, new DateTime(2025, 6, 6, 22, 11, 14, 130, DateTimeKind.Utc).AddTicks(7123) },
                    { 10L, "print('Booking System')", new DateTime(2025, 6, 6, 21, 11, 14, 130, DateTimeKind.Utc).AddTicks(7126), null, 48.3f, "Python", 0.05f, "Output: Booking System", "Success", 10L, new DateTime(2025, 6, 6, 21, 11, 14, 130, DateTimeKind.Utc).AddTicks(7127) },
                    { 11L, "console.log('HR System');", new DateTime(2025, 6, 6, 20, 11, 14, 130, DateTimeKind.Utc).AddTicks(7129), null, 28.7f, "JavaScript", 0.15f, "Output: HR System", "Success", 11L, new DateTime(2025, 6, 6, 20, 11, 14, 130, DateTimeKind.Utc).AddTicks(7130) },
                    { 12L, "print('Group Study')", new DateTime(2025, 6, 6, 19, 11, 14, 130, DateTimeKind.Utc).AddTicks(7133), "NameError: name 'undefined_variable' is not defined", null, "Python", 0.3f, "Error: NameError", "Failed", 12L, new DateTime(2025, 6, 6, 19, 11, 14, 130, DateTimeKind.Utc).AddTicks(7134) }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7020), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7022), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7024), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7025), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7027), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7029), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7030), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7032), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7033), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7035), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7036), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7038), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6907), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6909), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6911), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6913), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6914), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6916), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6917), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6963), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6964), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6966), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6967), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6969), "submissions/dt011_v1.pdf", 11L, 1 }
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
                name: "IX_LecturerCourses_CourseId",
                table: "LecturerCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourses_LecturerId_CourseId",
                table: "LecturerCourses",
                columns: new[] { "LecturerId", "CourseId" },
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
                name: "IX_Submissions_StudentId",
                table: "Submissions",
                column: "StudentId");

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
                name: "LecturerCourses");

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
