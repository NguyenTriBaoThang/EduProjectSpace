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
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DefenseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AISuggestions", x => x.Id);
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
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    MaxMembers = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    LecturerId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                columns: new[] { "Id", "CreatedAt", "FilePath" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9287), "backups/db_backup_2025_02_01.sql" },
                    { 2L, new DateTime(2025, 5, 14, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9289), "backups/db_backup_2025_02_02.sql" },
                    { 3L, new DateTime(2025, 5, 13, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9416), "backups/db_backup_2025_02_03.sql" },
                    { 4L, new DateTime(2025, 5, 12, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9421), "backups/db_backup_2025_02_04.sql" },
                    { 5L, new DateTime(2025, 5, 11, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9433), "backups/db_backup_2025_02_05.sql" },
                    { 6L, new DateTime(2025, 5, 10, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9437), "backups/db_backup_2025_02_06.sql" },
                    { 7L, new DateTime(2025, 5, 9, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9442), "backups/db_backup_2025_02_07.sql" },
                    { 8L, new DateTime(2025, 5, 8, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9446), "backups/db_backup_2025_02_08.sql" },
                    { 9L, new DateTime(2025, 5, 7, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9600), "backups/db_backup_2025_02_09.sql" },
                    { 10L, new DateTime(2025, 5, 6, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9603), "backups/db_backup_2025_02_10.sql" },
                    { 11L, new DateTime(2025, 5, 5, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9606), "backups/db_backup_2025_02_11.sql" },
                    { 12L, new DateTime(2025, 5, 4, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(9609), "backups/db_backup_2025_02_12.sql" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5272), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5275), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5278), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5280), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5282), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5284), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5287), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5288), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5291), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5293), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5295), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5297), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(42), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(45), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(48), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5905), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5907), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5910), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5912), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5914), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5916), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5918), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5920), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5922), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5924), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5926), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5928), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6000), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6003), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6005), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6007), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(6009), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(6012), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(6015), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(6017), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(6019), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(6021), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(6024), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(6025), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(47), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(48) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(54), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(56) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(61), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(62) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(66), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(67) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(71), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(72) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(76), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(77) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(82), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(83) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(87), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(88) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(92), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(93) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(121), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(122) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(133), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(134) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(142), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(145) }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name", "SemesterId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4187), "Hội đồng 1", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4187) },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4190), "Hội đồng 2", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4191) },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4193), "Hội đồng 3", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4194) },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4196), "Hội đồng 4", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4197) },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4200), "Hội đồng 5", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4200) },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4202), "Hội đồng 6", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4203) },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4208), "Hội đồng 7", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4209) },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4211), "Hội đồng 8", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4212) },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4215), "Hội đồng 9", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4215) },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4217), "Hội đồng 10", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4218) },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4220), "Hội đồng 11", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4221) },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4223), "Hội đồng 12", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4224) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(4003), "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(4008), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5135), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 4L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5147), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5184), "head2@hutech.edu.vn", 0, "Trần Thị Lan", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 4L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5185), "head2" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5257), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5258), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5409), "student2@hutech.edu.vn", 0, "Trần Văn Bình", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5410), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5419), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5419), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5427), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5428), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5436), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5437), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5446), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5446), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5455), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5455), "student7" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6262), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6267), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6271), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6276), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6281), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6284), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6100), new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6109), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6115), new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), 11L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6184), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 13L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6190), new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6196), new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 10L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4294), 2L, "Chủ tịch", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4294) },
                    { 3L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4365), 3L, "Chủ tịch", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4366) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5393), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5580), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5583), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5585), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5587), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5590), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5592), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5594), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5596), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5598), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5600), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5602), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5604), 4, 11L }
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
                    { 1L, "LOGIN", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6348), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6351), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6353), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6355), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6356), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6358), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6361), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6363), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4809), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4812), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5679), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5682), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5684), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5686), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5688), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5690), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5692), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5693), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5695), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5697), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5699), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5701), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(189), "ENROLLED", 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(190) },
                    { 2L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(193), "ENROLLED", 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(194) },
                    { 3L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(199), "ENROLLED", 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(200) },
                    { 4L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(204), "ENROLLED", 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(204) },
                    { 5L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(216), "ENROLLED", 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(217) },
                    { 6L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(219), "ENROLLED", 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(223) },
                    { 7L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(225), "ENROLLED", 13L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(226) },
                    { 8L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(228), "ENROLLED", 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(229) },
                    { 9L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(231), "ENROLLED", 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(232) },
                    { 10L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(234), "ENROLLED", 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(235) },
                    { 11L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(238), "ENROLLED", 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(238) },
                    { 12L, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(240), "ENROLLED", 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(241) },
                    { 13L, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(243), "ENROLLED", 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(244) },
                    { 14L, 6L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(247), "ENROLLED", 13L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(247) },
                    { 15L, 6L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(250), "ENROLLED", 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(251) },
                    { 16L, 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(253), "COMPLETED", 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(254) },
                    { 17L, 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(257), "COMPLETED", 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(257) },
                    { 18L, 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(260), "COMPLETED", 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(260) },
                    { 19L, 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(263), "COMPLETED", 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(264) },
                    { 20L, 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(266), "COMPLETED", 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(267) },
                    { 21L, 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(269), "COMPLETED", 13L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(270) },
                    { 22L, 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(272), "COMPLETED", 7L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(273) },
                    { 23L, 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(275), "COMPLETED", 8L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(276) },
                    { 24L, 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1013), "ENROLLED", 9L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1014) },
                    { 25L, 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1018), "ENROLLED", 10L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1019) },
                    { 26L, 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1023), "ENROLLED", 11L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1024) },
                    { 27L, 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1030), "ENROLLED", 12L, new DateTime(2025, 5, 15, 19, 24, 39, 82, DateTimeKind.Utc).AddTicks(1031) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5199), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5200), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5208), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5209), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5218), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5218), "lecturer3" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5465), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5465), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5536), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", null, false, "$2a$11$RlgrWdDdqTv.sAhSLWhO.uzkZwANrAYhomMv7.dtHP0VX4ncfbZ/i", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 79, DateTimeKind.Utc).AddTicks(5537), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4297), 4L, "Thành viên", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4298) },
                    { 4L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4369), 5L, "Thư ký", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4370) },
                    { 5L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4372), 6L, "Thành viên", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4373) },
                    { 6L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4376), 14L, "Chủ tịch", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4376) },
                    { 7L, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4379), 15L, "Thư ký", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4380) },
                    { 8L, 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4382), 4L, "Thành viên", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4383) },
                    { 9L, 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4385), 5L, "Chủ tịch", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4386) },
                    { 10L, 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4388), 6L, "Thư ký", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4389) },
                    { 11L, 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4391), 14L, "Thành viên", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4392) },
                    { 12L, 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4394), 15L, "Chủ tịch", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4395) }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6365), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6366), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6368), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6370), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "GroupId", "LecturerId", "ProjectCode", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(299), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 1L, 4L, "AI_YTE_2025_01", "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(300) },
                    { 2L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(311), "Xây dựng hệ thống quản lý đồ án sinh viên.", 2L, 5L, "QLDA_2025_01", "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(312) },
                    { 3L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(323), "Phát triển website bán hàng trực tuyến.", 3L, 6L, "TMĐT_2025_01", "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(324) },
                    { 4L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(329), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 4L, 14L, "PTDL_2025_01", "SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(330) },
                    { 5L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(335), "Phát triển app quản lý học tập cho sinh viên.", 5L, 15L, "QLHT_2025_01", "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(335) },
                    { 6L, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(498), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 6L, 4L, "BM_IOT_2025_01", "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(498) },
                    { 7L, 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(504), "Phân tích hành vi người dùng trên mạng xã hội.", 7L, 5L, "PTMXH_2025_01", "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(506) },
                    { 8L, 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(512), "Phát triển app học ngoại ngữ với AI.", 9L, 6L, "HNN_2025_01", "GRADED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(512) },
                    { 9L, 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(517), "Xây dựng hệ thống quản lý kho hàng tự động.", 8L, 14L, "QLK_2025_01", "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(518) },
                    { 10L, 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(523), "Phát triển app đặt lịch khám bệnh trực tuyến.", 10L, 15L, "DLKB_2025_01", "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(523) },
                    { 11L, 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(528), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 12L, 4L, "QLNS_2025_01", "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(529) },
                    { 12L, 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(533), "Phát triển app hỗ trợ học tập nhóm.", 11L, 5L, "HTN_2025_01", "PENDING", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(534) },
                    { 13L, 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(538), "Xây dựng hệ thống phân tích tài chính cá nhân.", 13L, 6L, "PTTC_2025_01", "PENDING", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(539) }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6265), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6269), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6273), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6278), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6282), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6286), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4465), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4469), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4472), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4475), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4478), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4481), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4484), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4487), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4489), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4492), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4495), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4497), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5390), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5396), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5398), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5401), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5403), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5406), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5408), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5411), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5413), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5416), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5418), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3937), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3940), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3942), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3944), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3946), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3948), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3950), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3952), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3954), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3956), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3958), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3960), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(808), 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(808) },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(815), 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(815) },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(821), 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(821) },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(891), 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(892) },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(898), 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(899) },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(904), 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(905) },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(910), 5, "Nhóm 7", 7L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(910) },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(916), 5, "Nhóm 8", 8L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(917) },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(922), 5, "Nhóm 9", 9L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(923) },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(928), 5, "Nhóm 10", 10L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(929) },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(934), 5, "Nhóm 11", 11L, "APPROVED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(935) },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(940), 5, "Nhóm 12", 12L, "PENDING", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(940) },
                    { 13L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(945), 5, "Nhóm 13", 13L, "PENDING", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(946) }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(627), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 14, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(631), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(643), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(646), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(650), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(654), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(656), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(658), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(660), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(662), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(664), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(666), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5176), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5179), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5181), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5183), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5185), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5188), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5190), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5192), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5194), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5199), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5201), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5203), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5069), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5084), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5087), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5089), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5093), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5095), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5097), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5100), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5102), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5105), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5107), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2779), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2786), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2793), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2799), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2805), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2812), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5784), 120, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5782), 1L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(5776), 7L },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5789), 60, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5787), 1L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(5787), 8L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5792), 180, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5791), 2L, new DateTime(2025, 5, 15, 16, 24, 39, 81, DateTimeKind.Utc).AddTicks(5791), 9L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5797), 60, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5795), 3L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(5794), 10L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5800), 120, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5799), 4L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(5798), 11L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5810), 240, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5804), 5L, new DateTime(2025, 5, 15, 15, 24, 39, 81, DateTimeKind.Utc).AddTicks(5803), 12L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5814), 60, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5813), 6L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(5812), 13L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5818), 120, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5817), 7L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(5816), 7L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5822), 180, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5821), 8L, new DateTime(2025, 5, 15, 16, 24, 39, 81, DateTimeKind.Utc).AddTicks(5820), 8L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5826), 60, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5825), 9L, new DateTime(2025, 5, 15, 18, 24, 39, 81, DateTimeKind.Utc).AddTicks(5824), 9L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5830), 120, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5828), 10L, new DateTime(2025, 5, 15, 17, 24, 39, 81, DateTimeKind.Utc).AddTicks(5828), 10L },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5834), 180, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5832), 11L, new DateTime(2025, 5, 15, 16, 24, 39, 81, DateTimeKind.Utc).AddTicks(5831), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6103), new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6107), new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6113), new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6181), new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), 12L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6188), new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(6193), new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 9L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3534), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3538), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3541), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3545), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3548), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3551), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3554), 4L, 6L, 6L, 9f, null },
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3557), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3560), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3566), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3569), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3572), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1024), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1027), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1029), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1031), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1033), 11L },
                    { 6L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1034), 12L },
                    { 7L, 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1036), 13L },
                    { 8L, 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1038), 7L },
                    { 9L, 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1040), 8L },
                    { 10L, 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1043), 9L },
                    { 11L, 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1045), 10L },
                    { 12L, 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1047), 11L },
                    { 13L, 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1049), 12L },
                    { 14L, 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1050), 13L },
                    { 15L, 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(1052), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2534), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2538), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2541), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2543), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2545), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2548), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2550), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2551), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2554), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2556), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2558), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2560), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4577), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4582), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4590), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4594), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4597), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4600), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4603), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4607), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4610), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4614), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4617), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4620), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4816), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4819), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4822), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4829), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4832), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4835), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4837), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4840), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4843), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4846), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4975), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4978), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4982), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4984), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4987), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4990), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4993), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4995), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4998), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5000), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5002), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5005), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(5078), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2899), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2903), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2907), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2910), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2914), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2917), 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2920), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2923), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2927), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2930), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2933), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2936), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2775), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2783), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2789), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2796), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2802), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2808), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "Language", "PlagiarismScore", "Result", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3341), "Python", 0.1f, "Success", 1L },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3345), "Java", 0.2f, "Success", 2L },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3348), "JavaScript", 0.15f, "Success", 3L },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3351), "Python", 0.3f, "Failed", 4L },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println('Test'); } }", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3353), "Java", 0.1f, "Success", 5L },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3357), "Python", 0.05f, "Success", 6L },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3359), "JavaScript", 0.2f, "Success", 7L },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3362), "Python", 0.4f, "Failed", 8L },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println('Warehouse'); } }", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3364), "Java", 0.1f, "Success", 9L },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3367), "Python", 0.05f, "Success", 10L },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3369), "JavaScript", 0.15f, "Success", 11L },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3372), "Python", 0.3f, "Failed", 12L }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3105), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3108), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3110), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3112), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3114), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3116), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3118), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3120), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3122), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3124), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3266), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3269), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4093), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4096), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4098), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4100), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4102), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4104), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4106), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4108), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4111), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4113), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4115), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3862), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3865), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3867), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3869), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3871), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3873), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3875), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3877), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3878), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3880), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3882), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3884), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3666), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3671), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3755), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3757), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3760), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3762), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3764), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3767), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3770), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3772), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3774), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3776), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4687), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4690), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4692), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4694), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4697), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4699), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4701), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4703), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4705), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4707), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4708), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(4710), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(2999), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 14, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3001), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3007), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3009), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3011), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3013), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3015), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3017), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3019), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3021), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3023), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 15, 19, 24, 39, 81, DateTimeKind.Utc).AddTicks(3024), "submissions/dt011_v1.pdf", 11L, 1 }
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
                name: "IX_Projects_LecturerId",
                table: "Projects",
                column: "LecturerId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_ProjectId",
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
                name: "Semesters");
        }
    }
}
