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
                    AvatarUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClassCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(794), "backups/db_backup_2025_02_01.sql" },
                    { 2L, new DateTime(2025, 5, 13, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(796), "backups/db_backup_2025_02_02.sql" },
                    { 3L, new DateTime(2025, 5, 12, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(797), "backups/db_backup_2025_02_03.sql" },
                    { 4L, new DateTime(2025, 5, 11, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(798), "backups/db_backup_2025_02_04.sql" },
                    { 5L, new DateTime(2025, 5, 10, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(799), "backups/db_backup_2025_02_05.sql" },
                    { 6L, new DateTime(2025, 5, 9, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(800), "backups/db_backup_2025_02_06.sql" },
                    { 7L, new DateTime(2025, 5, 8, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(801), "backups/db_backup_2025_02_07.sql" },
                    { 8L, new DateTime(2025, 5, 7, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(803), "backups/db_backup_2025_02_08.sql" },
                    { 9L, new DateTime(2025, 5, 6, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(806), "backups/db_backup_2025_02_09.sql" },
                    { 10L, new DateTime(2025, 5, 5, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(807), "backups/db_backup_2025_02_10.sql" },
                    { 11L, new DateTime(2025, 5, 4, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(808), "backups/db_backup_2025_02_11.sql" },
                    { 12L, new DateTime(2025, 5, 3, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(809), "backups/db_backup_2025_02_12.sql" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "EndDate", "Name", "Semester", "StartDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8150), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8152), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8154), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8155), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8157), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8158), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8161), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8163), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8164), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8165), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8170), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8171), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9456), "Hội đồng 1" },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9458), "Hội đồng 2" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9459), "Hội đồng 3" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9459), "Hội đồng 4" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9460), "Hội đồng 5" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9462), "Hội đồng 6" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9463), "Hội đồng 7" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9464), "Hội đồng 8" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9465), "Hội đồng 9" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9466), "Hội đồng 10" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9467), "Hội đồng 11" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9468), "Hội đồng 12" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(50), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(52), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(53), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(54), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(55), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(56), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(57), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(58), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(59), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(60), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(61), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(63), "Làm sao để đổi mật khẩu?" }
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
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(488), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(489), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(491), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(492), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(493), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(494), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(495), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(496), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(497), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(498), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(499), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(500), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(540), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(541), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(542), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(543), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(544), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(545), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(547), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(548), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(549), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(550), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(551), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(552), "NETWORK", 140f }
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
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7951), "admin@hutech.edu.vn", 0, "Quản trị viên", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7952), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7955), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7956), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7958), "head2@hutech.edu.vn", 0, "Trần Thị Lan", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7958), "head2" },
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7961), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7961), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7963), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7963), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7966), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7966), "lecturer3" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7968), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7968), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7979), "student2@hutech.edu.vn", 0, "Trần Văn Bình", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7980), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7982), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7982), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7986), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(7986), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8053), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8053), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8056), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8057), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8058), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8059), "student7" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8061), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8062), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8069), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", false, "$2a$11$261mUVrBlv.4LeYg65IyOOAzRxgO2nEKcCKDzB.5aBRKEBySQV9X2", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8069), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(660), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(665), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(673), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(675), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(677), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(679), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(599), new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(605), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(610), new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), 11L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(613), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 13L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(616), new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(619), new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 10L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9505), 2L, "Chủ tịch" },
                    { 2L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9506), 4L, "Thành viên" },
                    { 3L, 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9507), 3L, "Chủ tịch" },
                    { 4L, 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9508), 5L, "Thư ký" },
                    { 5L, 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9510), 6L, "Thành viên" },
                    { 6L, 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9511), 14L, "Chủ tịch" },
                    { 7L, 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9512), 15L, "Thư ký" },
                    { 8L, 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9513), 4L, "Thành viên" },
                    { 9L, 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9514), 5L, "Chủ tịch" },
                    { 10L, 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9515), 6L, "Thư ký" },
                    { 11L, 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9516), 14L, "Thành viên" },
                    { 12L, 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9517), 15L, "Chủ tịch" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(194), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(279), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(281), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(282), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(284), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(286), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(287), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(288), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(289), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(290), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(291), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(292), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(293), 4, 11L }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 1L, "LOGIN", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(741), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(743), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(744), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(745), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(746), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(750), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(751), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(752), "Gửi tin nhắn trong Nhóm 6.", 13L },
                    { 9L, "GRADE", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(753), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(754), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(755), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(756), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9778), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9780), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "LecturerId", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8254), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 4L, "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8255) },
                    { 2L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8258), "Xây dựng hệ thống quản lý đồ án sinh viên.", 5L, "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8259) },
                    { 3L, 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8261), "Phát triển website bán hàng trực tuyến.", 6L, "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8261) },
                    { 4L, 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8263), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 14L, "NOT_SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8263) },
                    { 5L, 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8265), "Phát triển app quản lý học tập cho sinh viên.", 15L, "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8265) },
                    { 6L, 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8266), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 4L, "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8267) },
                    { 7L, 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8268), "Phân tích hành vi người dùng trên mạng xã hội.", 5L, "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8269) },
                    { 8L, 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8271), "Phát triển app học ngoại ngữ với AI.", 6L, "SUBMITTED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8271) },
                    { 9L, 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8272), "Xây dựng hệ thống quản lý kho hàng tự động.", 14L, "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8273) },
                    { 10L, 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8274), "Phát triển app đặt lịch khám bệnh trực tuyến.", 15L, "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8275) },
                    { 11L, 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8276), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 4L, "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8276) },
                    { 12L, 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8278), "Phát triển app hỗ trợ học tập nhóm.", 5L, "GRADED", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8278) },
                    { 13L, 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8280), "Xây dựng hệ thống phân tích tài chính cá nhân.", 6L, "GRADED", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8280) }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(331), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(333), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(334), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(335), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(336), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(337), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(339), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(340), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(341), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(342), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(343), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(345), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(664), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(671), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(674), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(676), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(678), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(681), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9554), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9556), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9558), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9559), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9561), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9562), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9563), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9565), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9566), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9568), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9569), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9570), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(191), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(195), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(196), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(198), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(203), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(205), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(206), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(207), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(209), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(210), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(211), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9345), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9347), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9348), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9349), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9350), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9352), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9353), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9354), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9356), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9357), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9358), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9361), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8404), "Nhóm 1", 1L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8406), "Nhóm 2", 2L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8407), "Nhóm 3", 3L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8408), "Nhóm 4", 4L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8409), "Nhóm 5", 5L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8410), "Nhóm 6", 6L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8411), "Nhóm 7", 7L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8412), "Nhóm 8", 8L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8413), "Nhóm 9", 9L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8414), "Nhóm 10", 10L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8415), "Nhóm 11", 11L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8416), "Nhóm 12", 12L },
                    { 13L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8417), "Nhóm 13", 13L }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8325), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 13, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8328), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8333), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8334), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8335), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8336), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8338), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8339), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8340), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8341), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8343), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8344), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9993), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9994), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9995), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9996), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9997), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9998), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9999), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(1), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(3), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(4), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(5), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(6), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9901), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9905), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9906), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9908), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9910), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9936), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9941), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9943), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9944), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9946), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9947), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8617), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8621), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8628), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8631), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8641), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8644), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(419), 120, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(418), 1L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(417), 7L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(421), 60, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(421), 1L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(420), 8L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(424), 180, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(423), 2L, new DateTime(2025, 5, 13, 23, 44, 15, 658, DateTimeKind.Utc).AddTicks(422), 9L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(426), 60, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(425), 3L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(425), 10L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(428), 120, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(427), 4L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(427), 11L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(430), 240, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(429), 5L, new DateTime(2025, 5, 13, 22, 44, 15, 658, DateTimeKind.Utc).AddTicks(429), 12L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(432), 60, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(431), 6L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(431), 13L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(437), 120, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(436), 7L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(433), 7L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(439), 180, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(438), 8L, new DateTime(2025, 5, 13, 23, 44, 15, 658, DateTimeKind.Utc).AddTicks(438), 8L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(442), 60, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(440), 9L, new DateTime(2025, 5, 14, 1, 44, 15, 658, DateTimeKind.Utc).AddTicks(440), 9L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(444), 120, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(444), 10L, new DateTime(2025, 5, 14, 0, 44, 15, 658, DateTimeKind.Utc).AddTicks(443), 10L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(446), 180, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(446), 11L, new DateTime(2025, 5, 13, 23, 44, 15, 658, DateTimeKind.Utc).AddTicks(445), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(602), new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(608), new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(611), new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), 12L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(615), new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 658, DateTimeKind.Utc).AddTicks(618), new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 9L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9093), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9094), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9096), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9097), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9098), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9100), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9101), 4L, 6L, 6L, 9f, null },
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9102), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9107), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9109), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9110), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9111), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8459), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8460), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8461), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8462), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8463), 11L },
                    { 6L, 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8464), 12L },
                    { 7L, 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8465), 13L },
                    { 8L, 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8466), 7L },
                    { 9L, 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8467), 8L },
                    { 10L, 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8468), 9L },
                    { 11L, 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8469), 10L },
                    { 12L, 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8470), 11L },
                    { 13L, 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8497), 12L },
                    { 14L, 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8498), 13L },
                    { 15L, 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8499), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8549), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8550), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8552), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8553), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8554), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8555), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8556), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8560), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8561), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8562), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8563), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8565), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9658), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9660), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9663), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9665), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9666), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9668), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9669), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9671), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9672), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9674), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9677), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9678), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9781), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9783), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9785), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9787), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9788), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9790), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9791), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9793), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9795), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9796), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9836), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9839), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9840), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9841), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9843), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9844), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9845), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9847), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9848), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9849), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9850), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9852), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9903), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8721), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8723), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8724), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8726), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8727), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8728), 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8730), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8731), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8732), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8734), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8735), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8737), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8614), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8619), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8623), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8629), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8639), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8642), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "Language", "PlagiarismScore", "Result", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8913), "Python", 0.1f, "Success", 1L },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8915), "Java", 0.2f, "Success", 2L },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8917), "JavaScript", 0.15f, "Success", 3L },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8918), "Python", 0.3f, "Failed", 4L },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println('Test'); } }", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8919), "Java", 0.1f, "Success", 5L },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8921), "Python", 0.05f, "Success", 6L },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8922), "JavaScript", 0.2f, "Success", 7L },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8925), "Python", 0.4f, "Failed", 8L },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println('Warehouse'); } }", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8926), "Java", 0.1f, "Success", 9L },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8928), "Python", 0.05f, "Success", 10L },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8929), "JavaScript", 0.15f, "Success", 11L },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8930), "Python", 0.3f, "Failed", 12L }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8839), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8840), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8841), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8843), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8845), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8846), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8847), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8863), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8864), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8865), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8867), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8868), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9402), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9404), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9405), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9406), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9407), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9409), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9410), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9411), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9412), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9413), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9415), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9235), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9237), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9290), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9292), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9293), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9294), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9295), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9297), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9299), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9300), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9301), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9302), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 13, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9172), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9174), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9175), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9176), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9178), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9179), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9180), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9181), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9182), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9186), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9187), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9188), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9716), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9717), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9718), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9719), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9720), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9721), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9722), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9723), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9724), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9725), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9726), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(9727), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8775), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 13, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8778), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8779), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8780), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8781), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8782), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8783), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8784), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8786), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8787), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8788), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 14, 2, 44, 15, 657, DateTimeKind.Utc).AddTicks(8789), "submissions/dt011_v1.pdf", 11L, 1 }
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
