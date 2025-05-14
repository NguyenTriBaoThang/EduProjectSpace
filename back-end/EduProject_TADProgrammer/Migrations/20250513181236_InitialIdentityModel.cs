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
                name: "Backups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefenseCommittees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenseCommittees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    MetricType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SemesterId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Semesters_SemesterId",
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
                    CourseId = table.Column<long>(type: "bigint", nullable: true)
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
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeMembers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommitteeId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_CommitteeMembers_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_FeedbackSurveys_Users_UserId",
                        column: x => x.UserId,
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
                    Action = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Projects_Users_LecturerId",
                        column: x => x.LecturerId,
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
                    EnrolledAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "AISuggestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AISuggestions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    table.ForeignKey(
                        name: "FK_Discussions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_GradeSchedules_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    EventTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calendars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_Grades_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_GradedBy",
                        column: x => x.GradedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_GroupRequests_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupRequests_Users_StudentId",
                        column: x => x.StudentId,
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
                    table.ForeignKey(
                        name: "FK_GradeAppeals_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeAppeals_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_GradeLogs_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradeLogs_Users_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Users",
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
                name: "CodeRuns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlagiarismScore = table.Column<float>(type: "real", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeRuns_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Feedbacks_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_LecturerId",
                        column: x => x.LecturerId,
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
                columns: new[] { "Id", "CreatedAt", "FilePath" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2123), "backups/db_backup_2025_02_01.sql" },
                    { 2L, new DateTime(2025, 5, 12, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2126), "backups/db_backup_2025_02_02.sql" },
                    { 3L, new DateTime(2025, 5, 11, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2129), "backups/db_backup_2025_02_03.sql" },
                    { 4L, new DateTime(2025, 5, 10, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2131), "backups/db_backup_2025_02_04.sql" },
                    { 5L, new DateTime(2025, 5, 9, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2133), "backups/db_backup_2025_02_05.sql" },
                    { 6L, new DateTime(2025, 5, 8, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2135), "backups/db_backup_2025_02_06.sql" },
                    { 7L, new DateTime(2025, 5, 7, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2138), "backups/db_backup_2025_02_07.sql" },
                    { 8L, new DateTime(2025, 5, 6, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2140), "backups/db_backup_2025_02_08.sql" },
                    { 9L, new DateTime(2025, 5, 5, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2153), "backups/db_backup_2025_02_09.sql" },
                    { 10L, new DateTime(2025, 5, 4, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2156), "backups/db_backup_2025_02_10.sql" },
                    { 11L, new DateTime(2025, 5, 3, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2158), "backups/db_backup_2025_02_11.sql" },
                    { 12L, new DateTime(2025, 5, 2, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2160), "backups/db_backup_2025_02_12.sql" }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9052), "Hội đồng 1" },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9055), "Hội đồng 2" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9057), "Hội đồng 3" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9059), "Hội đồng 4" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9061), "Hội đồng 5" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9063), "Hội đồng 6" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9066), "Hội đồng 7" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9069), "Hội đồng 8" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9070), "Hội đồng 9" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9072), "Hội đồng 10" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9074), "Hội đồng 11" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9075), "Hội đồng 12" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(253), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(256), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(259), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(261), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(263), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(265), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(267), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(269), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(272), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(274), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(275), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(278), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2239), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2242), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2245), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1505), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1508), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1511), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1513), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1515), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1517), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1519), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1521), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1523), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1525), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1527), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1529), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1602), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1605), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1607), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1610), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1611), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1614), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1616), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1619), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1621), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1623), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1626), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1627), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "EndDate", "Name", "SemesterId", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6847), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6851), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6854), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6857), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6859), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6862), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6864), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6867), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6870), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6873), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6875), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6878), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6625), "admin@hutech.edu.vn", 0, "Quản trị viên", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6626), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6632), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6633), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6636), "head2@hutech.edu.vn", 0, "Trần Thị Lan", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6637), "head2" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6660), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6660), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6679), "student2@hutech.edu.vn", 0, "Trần Văn Bình", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6680), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6685), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6686), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6689), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6689), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6694), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6695), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6698), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6699), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6702), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6703), "student7" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1940), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1947), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1953), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1957), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1962), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1966), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1707), new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1719), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1726), new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), 11L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1733), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 13L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1740), new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1862), new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 10L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9140), 2L, "Chủ tịch" },
                    { 3L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9145), 3L, "Chủ tịch" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(518), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(971), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(975), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1050), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1052), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1055), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1058), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1060), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1062), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1064), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1066), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1068), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1070), 4, 11L }
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
                    { 1L, "LOGIN", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2037), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2040), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2042), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2045), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2047), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2049), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2051), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2053), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9610), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9614), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1241), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1245), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1247), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1250), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1252), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1255), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1257), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1259), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1262), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1264), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1266), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1268), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2304), 7L },
                    { 2L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2306), 7L },
                    { 3L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2308), 8L },
                    { 4L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2311), 8L },
                    { 5L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2313), 9L },
                    { 6L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2315), 9L },
                    { 7L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2317), 10L },
                    { 8L, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2319), 10L },
                    { 9L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2321), 11L },
                    { 10L, 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2323), 11L },
                    { 11L, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2325), 12L },
                    { 12L, 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2327), 12L },
                    { 13L, 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2329), 13L },
                    { 14L, 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2331), 13L },
                    { 15L, 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2334), 7L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6645), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6645), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6649), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6650), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6654), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6655), "lecturer3" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6707), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6708), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6712), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", false, "$2a$11$VBs3j29Wbhovn5/pTVBXL.mHbOv3YPthWs8cTFed./tNOM8E0CgL2", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6713), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9143), 4L, "Thành viên" },
                    { 4L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9148), 5L, "Thư ký" },
                    { 5L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9210), 6L, "Thành viên" },
                    { 6L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9214), 14L, "Chủ tịch" },
                    { 7L, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9216), 15L, "Thư ký" },
                    { 8L, 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9218), 4L, "Thành viên" },
                    { 9L, 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9220), 5L, "Chủ tịch" },
                    { 10L, 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9222), 6L, "Thư ký" },
                    { 11L, 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9224), 14L, "Thành viên" },
                    { 12L, 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9226), 15L, "Chủ tịch" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2055), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2057), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2059), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(2060), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "LecturerId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6983), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 4L, "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6984) },
                    { 2L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6988), "Xây dựng hệ thống quản lý đồ án sinh viên.", 5L, "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6989) },
                    { 3L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6992), "Phát triển website bán hàng trực tuyến.", 6L, "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6993) },
                    { 4L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6996), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 14L, "NOT_SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(6996) },
                    { 5L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7000), "Phát triển app quản lý học tập cho sinh viên.", 15L, "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7000) },
                    { 6L, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7003), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 4L, "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7004) },
                    { 7L, 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7007), "Phân tích hành vi người dùng trên mạng xã hội.", 5L, "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7008) },
                    { 8L, 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7010), "Phát triển app học ngoại ngữ với AI.", 6L, "SUBMITTED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7011) },
                    { 9L, 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7014), "Xây dựng hệ thống quản lý kho hàng tự động.", 14L, "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7014) },
                    { 10L, 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7017), "Phát triển app đặt lịch khám bệnh trực tuyến.", 15L, "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7018) },
                    { 11L, 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7021), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 4L, "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7022) },
                    { 12L, 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7025), "Phát triển app hỗ trợ học tập nhóm.", 5L, "GRADED", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7025) },
                    { 13L, 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7028), "Xây dựng hệ thống phân tích tài chính cá nhân.", 6L, "GRADED", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7029) }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1943), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1949), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1955), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1959), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1964), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1969), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9292), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9296), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9299), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9302), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9305), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9307), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9310), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9313), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9315), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9318), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9321), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9323), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(515), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(520), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(523), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(526), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(528), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(531), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(534), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(536), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(539), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(541), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(544), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8870), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8873), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8877), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8880), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8883), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8886), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8889), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8891), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8894), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8896), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8898), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8900), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7298), "Nhóm 1", 1L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7301), "Nhóm 2", 2L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7303), "Nhóm 3", 3L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7306), "Nhóm 4", 4L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7307), "Nhóm 5", 5L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7310), "Nhóm 6", 6L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7312), "Nhóm 7", 7L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7314), "Nhóm 8", 8L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7316), "Nhóm 9", 9L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7317), "Nhóm 10", 10L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7319), "Nhóm 11", 11L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7321), "Nhóm 12", 12L },
                    { 13L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7323), "Nhóm 13", 13L }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7102), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 12, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7105), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7120), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7122), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7125), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7127), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7129), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7131), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7134), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7136), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7138), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7140), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(147), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(150), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(153), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(155), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(157), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(159), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(161), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(165), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(168), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(170), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(172), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(174), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(31), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(46), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(49), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(51), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(54), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(56), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(59), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(61), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(64), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(67), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(69), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7717), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7724), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7737), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7744), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7750), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7756), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1365), 120, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1361), 1L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1353), 7L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1371), 60, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1370), 1L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1368), 8L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1376), 180, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1375), 2L, new DateTime(2025, 5, 13, 15, 12, 33, 196, DateTimeKind.Utc).AddTicks(1373), 9L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1380), 60, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1379), 3L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1378), 10L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1384), 120, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1383), 4L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1382), 11L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1388), 240, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1387), 5L, new DateTime(2025, 5, 13, 14, 12, 33, 196, DateTimeKind.Utc).AddTicks(1386), 12L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1392), 60, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1391), 6L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1390), 13L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1396), 120, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1395), 7L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1394), 7L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1400), 180, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1399), 8L, new DateTime(2025, 5, 13, 15, 12, 33, 196, DateTimeKind.Utc).AddTicks(1398), 8L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1404), 60, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1403), 9L, new DateTime(2025, 5, 13, 17, 12, 33, 196, DateTimeKind.Utc).AddTicks(1402), 9L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1408), 120, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1407), 10L, new DateTime(2025, 5, 13, 16, 12, 33, 196, DateTimeKind.Utc).AddTicks(1406), 10L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1412), 180, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1411), 11L, new DateTime(2025, 5, 13, 15, 12, 33, 196, DateTimeKind.Utc).AddTicks(1410), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1712), new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1716), new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1722), new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1730), new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), 12L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1737), new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(1858), new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 9L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8504), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8509), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8511), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8514), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8517), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8521), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8523), 4L, 6L, 6L, 9f, null },
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8525), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8528), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8530), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8532), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8535), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7392), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7395), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7396), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7398), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7400), 11L },
                    { 6L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7402), 12L },
                    { 7L, 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7404), 13L },
                    { 8L, 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7406), 7L },
                    { 9L, 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7408), 8L },
                    { 10L, 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7410), 9L },
                    { 11L, 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7412), 10L },
                    { 12L, 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7414), 11L },
                    { 13L, 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7416), 12L },
                    { 14L, 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7417), 13L },
                    { 15L, 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7419), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7588), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7590), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7593), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7594), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7596), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7598), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7600), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7602), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7604), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7606), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7608), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7611), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9394), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9398), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9408), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9411), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9414), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9417), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9420), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9423), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9426), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9429), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9431), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9434), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9620), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9624), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9629), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9633), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9637), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9641), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9645), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9649), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9653), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9657), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9787), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9791), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9795), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9798), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9937), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9940), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9942), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9945), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9947), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9950), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9952), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9954), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 196, DateTimeKind.Utc).AddTicks(34), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7869), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7872), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7875), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7878), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7880), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7883), 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7885), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7888), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7890), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7892), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7897), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7900), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7711), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7727), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7741), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7747), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(7753), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "Language", "PlagiarismScore", "Result", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8248), "Python", 0.1f, "Success", 1L },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8252), "Java", 0.2f, "Success", 2L },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8255), "JavaScript", 0.15f, "Success", 3L },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8257), "Python", 0.3f, "Failed", 4L },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println('Test'); } }", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8260), "Java", 0.1f, "Success", 5L },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8263), "Python", 0.05f, "Success", 6L },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8266), "JavaScript", 0.2f, "Success", 7L },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8268), "Python", 0.4f, "Failed", 8L },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println('Warehouse'); } }", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8272), "Java", 0.1f, "Success", 9L },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8274), "Python", 0.05f, "Success", 10L },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8277), "JavaScript", 0.15f, "Success", 11L },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8279), "Python", 0.3f, "Failed", 12L }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8153), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8156), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8159), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8161), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8163), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8165), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8167), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8169), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8171), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8173), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8176), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8178), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8968), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8971), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8974), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8977), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8980), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8982), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8985), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8988), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8990), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8992), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8994), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8793), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8796), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8799), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8801), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8802), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8805), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8807), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8809), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8812), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8814), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8816), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8818), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 12, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8695), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8699), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8701), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8704), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8706), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8708), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8710), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8712), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8714), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8717), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8719), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8722), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9503), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9506), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9508), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9510), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9512), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9514), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9516), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9518), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9520), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9522), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9524), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(9526), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8050), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 12, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8054), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8057), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8059), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8061), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8063), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8065), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8068), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8069), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8072), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8074), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 13, 18, 12, 33, 195, DateTimeKind.Utc).AddTicks(8076), "submissions/dt011_v1.pdf", 11L, 1 }
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
                name: "IX_Courses_SemesterId",
                table: "Courses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenseCommittees_Name",
                table: "DefenseCommittees",
                column: "Name",
                unique: true);

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
                name: "IX_Groups_ProjectId",
                table: "Groups",
                column: "ProjectId");

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
                name: "IX_Projects_LecturerId",
                table: "Projects",
                column: "LecturerId");

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
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Semesters");
        }
    }
}
