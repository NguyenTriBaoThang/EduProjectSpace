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
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
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
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    Locked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(6062), "backups/db_backup_2025_02_01.sql" },
                    { 2L, new DateTime(2025, 5, 5, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(6065), "backups/db_backup_2025_02_02.sql" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "EndDate", "Name", "Semester", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3448), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3452), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4706), "Hội đồng 1" },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4709), "Hội đồng 2" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5270), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5273), "Thời gian bảo vệ là khi nào?" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "Quản trị viên", "ROLE_ADMIN" },
                    { 2L, "Giảng viên hướng dẫn", "ROLE_LECTURER_GUIDE" },
                    { 3L, "Sinh viên", "ROLE_STUDENT" },
                    { 4L, "Trưởng bộ môn", "ROLE_HEAD" }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5760), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5763), "THEME_COLOR", "#1976d2" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5816), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5819), "RAM", 60f }
                });

            migrationBuilder.InsertData(
                table: "GradeCriteria",
                columns: new[] { "Id", "CourseId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { 1L, 1L, "Chất lượng nội dung đồ án.", "Nội dung", 0.4f },
                    { 2L, 1L, "Cách trình bày báo cáo.", "Trình bày", 0.3f },
                    { 3L, 1L, "Kỹ năng bảo vệ.", "Bảo vệ", 0.3f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3214), "admin@hutech.edu.vn", 0, "Quản trị viên", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3215), "admin" },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3220), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 4L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3222), "head1" },
                    { 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3226), "head2@hutech.edu.vn", 0, "Trần Thị Lan", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 4L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3227), "head2" },
                    { 4L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3230), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3231), "lecturer1" },
                    { 5L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3234), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3235), "lecturer2" },
                    { 6L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3239), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3239), "lecturer3" },
                    { 7L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3243), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3244), "student1" },
                    { 8L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3257), "student2@hutech.edu.vn", 0, "Trần Văn Bình", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3258), "student2" },
                    { 9L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3261), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3262), "student3" },
                    { 10L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3265), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3266), "student4" },
                    { 11L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3269), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", false, "$2a$11$q4RoFFsn855Eqt.SkAKVL.E90ELKmg//yFHyXLYyZQEjM5JNo5OeK", 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3270), "student5" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[] { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5948), null, "PROJECT", 7L });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[] { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5882), new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4765), 2L, "Chủ tịch" },
                    { 2L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4768), 4L, "Thành viên" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5406), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5497), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5500), 3, 8L }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 1L, "LOGIN", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(6004), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(6007), "Sinh viên nộp bài cho đồ án 1.", 7L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5007), null, "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5011), null, "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "LecturerId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3530), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 4L, "APPROVED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3531) },
                    { 2L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3535), "Xây dựng hệ thống quản lý đồ án sinh viên.", 5L, "PENDING", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3536) },
                    { 3L, 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3539), "Phát triển website bán hàng trực tuyến.", 6L, "APPROVED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3540) }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5619), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5623), 7, "Thiết kế giao diện", 8L }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[] { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5951), 1L, "GRADE", null });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4818), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4822), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5403), 1L, "Hỏi về AI trong y tế", 7L, 5 });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4590), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4594), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3679), "Nhóm 1", 1L },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3683), "Nhóm 2", 2L },
                    { 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3686), "Nhóm 3", 3L }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3602), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 5, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3605), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5202), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5205), 5L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5130), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[] { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3932), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5695), 120, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5693), 1L, new DateTime(2025, 5, 6, 7, 11, 8, 348, DateTimeKind.Utc).AddTicks(5690), 7L },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5702), 60, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5700), 1L, new DateTime(2025, 5, 6, 8, 11, 8, 348, DateTimeKind.Utc).AddTicks(5699), 8L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[] { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5887), new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 2L });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4415), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4419), 4L, 1L, 1L, 8f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3760), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3762), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3765), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3767), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3768), 11L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3831), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3834), 2L, "APPROVED", 10L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4885), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4889), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5061), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5065), 1L, 7L, 8L, 7 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(5134), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4006), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4010), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[] { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(3927), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "Language", "PlagiarismScore", "Result", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4213), "Python", 0.1f, "Success", 1L },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4216), "Java", 0.2f, "Success", 2L }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4137), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4141), 5L, 2L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[] { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4653), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4545), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4548), "Cập nhật điểm nhóm 1.", 1L, 4L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 5, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4486), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4490), 1L, 8.5f, 2 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4940), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4943), "records/meeting2.mp4", 2L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 6, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4064), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 5, 9, 11, 8, 348, DateTimeKind.Utc).AddTicks(4067), "submissions/dt001_v2.pdf", 1L, 2 }
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
                name: "IX_SkillAssessments_StudentId",
                table: "SkillAssessments",
                column: "StudentId");

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
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
