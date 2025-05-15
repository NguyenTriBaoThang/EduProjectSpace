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
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7689), "backups/db_backup_2025_02_01.sql" },
                    { 2L, new DateTime(2025, 5, 14, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7690), "backups/db_backup_2025_02_02.sql" },
                    { 3L, new DateTime(2025, 5, 13, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7692), "backups/db_backup_2025_02_03.sql" },
                    { 4L, new DateTime(2025, 5, 12, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7694), "backups/db_backup_2025_02_04.sql" },
                    { 5L, new DateTime(2025, 5, 11, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7695), "backups/db_backup_2025_02_05.sql" },
                    { 6L, new DateTime(2025, 5, 10, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7697), "backups/db_backup_2025_02_06.sql" },
                    { 7L, new DateTime(2025, 5, 9, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7698), "backups/db_backup_2025_02_07.sql" },
                    { 8L, new DateTime(2025, 5, 8, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7700), "backups/db_backup_2025_02_08.sql" },
                    { 9L, new DateTime(2025, 5, 7, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7708), "backups/db_backup_2025_02_09.sql" },
                    { 10L, new DateTime(2025, 5, 6, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7709), "backups/db_backup_2025_02_10.sql" },
                    { 11L, new DateTime(2025, 5, 5, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7711), "backups/db_backup_2025_02_11.sql" },
                    { 12L, new DateTime(2025, 5, 4, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7712), "backups/db_backup_2025_02_12.sql" }
                });

            migrationBuilder.InsertData(
                table: "DefenseCommittees",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5937), "Hội đồng 1" },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5998), "Hội đồng 2" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6000), "Hội đồng 3" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6001), "Hội đồng 4" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6002), "Hội đồng 5" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6004), "Hội đồng 6" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6005), "Hội đồng 7" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6007), "Hội đồng 8" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6008), "Hội đồng 9" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6009), "Hội đồng 10" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6011), "Hội đồng 11" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6012), "Hội đồng 12" }
                });

            migrationBuilder.InsertData(
                table: "FAQs",
                columns: new[] { "Id", "Answer", "Category", "CreatedAt", "Question" },
                values: new object[,]
                {
                    { 1L, "Đăng nhập, vào mục Nộp bài, tải file lên.", "Nộp bài", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6767), "Làm thế nào để nộp đồ án?" },
                    { 2L, "Xem lịch bảo vệ trong mục Lịch.", "Bảo vệ", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6769), "Thời gian bảo vệ là khi nào?" },
                    { 3L, "Vào mục Nhóm, gửi yêu cầu tham gia.", "Nhóm", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6771), "Làm sao để tham gia nhóm?" },
                    { 4L, "Vào mục Điểm số, chọn đồ án của bạn.", "Điểm số", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6772), "Cách xem điểm đồ án?" },
                    { 5L, "Vào mục Phản hồi, điền nội dung.", "Phản hồi", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6774), "Làm sao để gửi phản hồi?" },
                    { 6L, "Có, AI hỗ trợ gợi ý và đánh giá.", "Hỗ trợ", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6776), "Hệ thống có hỗ trợ AI không?" },
                    { 7L, "Vào mục Nhiệm vụ, nhấn Tạo mới.", "Nhiệm vụ", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6777), "Làm sao để tạo nhiệm vụ?" },
                    { 8L, "Vào mục Tài liệu, chọn tài liệu và tải.", "Tài liệu", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6779), "Cách tải tài liệu tham khảo?" },
                    { 9L, "Vào mục Lịch, chọn lịch họp nhóm.", "Họp nhóm", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6780), "Làm sao để xem lịch họp?" },
                    { 10L, "Vào mục Điểm số, chọn Kháng nghị.", "Kháng nghị", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6782), "Cách gửi kháng nghị điểm?" },
                    { 11L, "Có, vào mục Chat để trò chuyện nhóm.", "Chat", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6783), "Hệ thống có hỗ trợ chat không?" },
                    { 12L, "Vào Cài đặt, chọn Đổi mật khẩu.", "Tài khoản", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6785), "Làm sao để đổi mật khẩu?" }
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
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7784), null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK2-2025", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7787), null, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK1-2025", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7789), null, new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK3-2025", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "CreatedAt", "Key", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7297), "LOGO_URL", "images/hutech_logo.png" },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7299), "THEME_COLOR", "#1976d2" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7300), "EMAIL_SERVER", "smtp.hutech.edu.vn" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7301), "MAX_FILE_SIZE", "10485760" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7303), "DEFAULT_LANGUAGE", "vi" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7304), "NOTIFICATION_DURATION", "7" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7306), "SESSION_TIMEOUT", "30" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7307), "BACKUP_FREQUENCY", "daily" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7309), "ALLOWED_FILE_TYPES", "pdf,docx,zip" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7310), "TIMEZONE", "Asia/Ho_Chi_Minh" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7311), "MAX_LOGIN_ATTEMPTS", "5" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7313), "CHAT_ENABLED", "true" }
                });

            migrationBuilder.InsertData(
                table: "SystemMetrics",
                columns: new[] { "Id", "CreatedAt", "MetricType", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7360), "CPU", 45.5f },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7363), "RAM", 60f },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7364), "DISK", 75f },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7366), "NETWORK", 120.5f },
                    { 5L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7367), "CPU", 50f },
                    { 6L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7408), "RAM", 65f },
                    { 7L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7410), "DISK", 80f },
                    { 8L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7412), "NETWORK", 130f },
                    { 9L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7413), "CPU", 55f },
                    { 10L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7415), "RAM", 70f },
                    { 11L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7417), "DISK", 85f },
                    { 12L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7419), "NETWORK", 140f }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CreatedAt", "DefenseDate", "EndDate", "Name", "SemesterId", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "CNTT_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4189), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4190) },
                    { 2L, "CNTT_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4194), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNTT", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4195) },
                    { 3L, "KTPM_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4199), new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4200) },
                    { 4L, "KTPM_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4204), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KTPM", 1L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4204) },
                    { 5L, "ATTT_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4208), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4209) },
                    { 6L, "ATTT_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4212), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở ATTT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4213) },
                    { 7L, "KHMT_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4216), new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4217) },
                    { 8L, "KHMT_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4220), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở KHMT", 2L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OPEN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4221) },
                    { 9L, "HTTT_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4224), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4225) },
                    { 10L, "HTTT_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4235), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở HTTT", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4236) },
                    { 11L, "CNPM_TN_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4239), new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Tốt nghiệp CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4241) },
                    { 12L, "CNPM_CS_2025", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4245), new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Đồ án Cơ sở CNPM", 3L, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PLANNED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4245) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3824), "admin@hutech.edu.vn", 0, "Quản trị viên", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3824), "admin" },
                    { 2L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3834), "head1@hutech.edu.vn", 0, "Nguyễn Văn Hùng", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3835), "head1" },
                    { 3L, "/static/medit/imgUser/avatar.jpg", null, null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3841), "head2@hutech.edu.vn", 0, "Trần Thị Lan", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3841), "head2" },
                    { 7L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3980), "student1@hutech.edu.vn", 0, "Nguyễn Tri Bão Thắng", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3981), "student1" },
                    { 8L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3997), "student2@hutech.edu.vn", 0, "Trần Văn Bình", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3997), "student2" },
                    { 9L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4003), "student3@hutech.edu.vn", 0, "Lê Thị Cẩm", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4004), "student3" },
                    { 10L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4011), "student4@hutech.edu.vn", 0, "Phạm Văn Đức", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4011), "student4" },
                    { 11L, "/static/medit/imgUser/avatar.jpg", "21DTHA1", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4017), "student5@hutech.edu.vn", 0, "Hoàng Thị Em", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4018), "student5" },
                    { 12L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4025), "student6@hutech.edu.vn", 0, "Nguyễn Văn Phú", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4025), "student6" },
                    { 13L, "/static/medit/imgUser/avatar.jpg", "21DTHA2", null, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4070), "student7@hutech.edu.vn", 0, "Trần Thị Hồng", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4070), "student7" }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Đề xuất thêm tính năng phân tích dữ liệu thời gian thực.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7555), null, "PROJECT", 7L },
                    { 3L, "Nên tích hợp tính năng chat vào hệ thống quản lý.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7559), null, "PROJECT", 8L },
                    { 5L, "Đề xuất thêm cổng thanh toán cho website thương mại.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7562), null, "PROJECT", 9L },
                    { 7L, "Nên tích hợp công cụ phân tích dữ liệu mạnh hơn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7566), null, "PROJECT", 10L },
                    { 9L, "Đề xuất thêm chế độ offline cho app quản lý học tập.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7570), null, "PROJECT", 11L },
                    { 11L, "Nên tăng cường bảo mật cho hệ thống IoT.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7573), null, "PROJECT", 12L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7477), new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", null, new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7485), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 9L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7490), new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 2, 25, 23, 59, 0, 0, DateTimeKind.Unspecified), 11L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7495), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 13L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7500), new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), "Hạn nộp nhiệm vụ", null, new DateTime(2025, 3, 15, 23, 59, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7504), new DateTime(2025, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Bảo vệ đồ án", null, new DateTime(2025, 3, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 10L }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6068), 2L, "Chủ tịch" },
                    { 3L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6071), 3L, "Chủ tịch" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[] { 2L, "Nên dùng framework nào cho giao diện?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6964), null, "Thắc mắc về thiết kế giao diện", 9L, 3 });

            migrationBuilder.InsertData(
                table: "FeedbackSurveys",
                columns: new[] { "Id", "Content", "CreatedAt", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hệ thống dễ sử dụng.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7049), 4, 7L },
                    { 2L, "Cần cải thiện tốc độ tải.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7052), 3, 8L },
                    { 3L, "Giao diện thân thiện.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7053), 5, 9L },
                    { 4L, "Chat nhóm bị lỗi.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7055), 2, 10L },
                    { 5L, "Hỗ trợ tốt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7056), 4, 11L },
                    { 6L, "Cần thêm hướng dẫn sử dụng.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7058), 3, 12L },
                    { 7L, "Tính năng quản lý nhóm tốt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7059), 5, 13L },
                    { 8L, "Thông báo không hoạt động.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7061), 2, 7L },
                    { 9L, "Rất hài lòng với hệ thống.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7062), 5, 8L },
                    { 10L, "Cần cải thiện tốc độ.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7064), 3, 9L },
                    { 11L, "Giao diện đẹp.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7065), 4, 10L },
                    { 12L, "Hệ thống ổn định.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7067), 4, 11L }
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
                    { 1L, "LOGIN", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7621), "Admin đăng nhập hệ thống.", 1L },
                    { 2L, "SUBMISSION", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7623), "Sinh viên nộp bài cho đồ án 1.", 7L },
                    { 3L, "JOIN_GROUP", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7625), "Sinh viên tham gia Nhóm 1.", 8L },
                    { 4L, "SEND_MESSAGE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7626), "Gửi tin nhắn trong Nhóm 2.", 9L },
                    { 5L, "SUBMISSION", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7629), "Sinh viên nộp bài cho đồ án 3.", 10L },
                    { 6L, "CREATE_TASK", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7631), "Tạo nhiệm vụ mới trong đồ án 4.", 11L },
                    { 7L, "JOIN_GROUP", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7632), "Sinh viên tham gia Nhóm 5.", 12L },
                    { 8L, "SEND_MESSAGE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7634), "Gửi tin nhắn trong Nhóm 6.", 13L }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1L, "Hạn nộp là 28/02/2025.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6393), null, "user", "SENT", "Hạn nộp đồ án", "WEB", 7L },
                    { 2L, "Bài nộp đã được phản hồi.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6470), null, "group", "SENT", "Phản hồi bài nộp", "EMAIL", 9L }
                });

            migrationBuilder.InsertData(
                table: "SkillAssessments",
                columns: new[] { "Id", "CreatedAt", "Score", "Skill", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7120), 8, "Lập trình Python", 7L },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7122), 7, "Thiết kế giao diện", 8L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7123), 9, "Phân tích dữ liệu", 9L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7125), 6, "Lập trình Java", 10L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7127), 8, "Quản lý dự án", 11L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7128), 7, "Kiểm thử phần mềm", 12L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7130), 9, "Lập trình JavaScript", 13L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7131), 6, "Giao tiếp nhóm", 7L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7133), 8, "Thiết kế cơ sở dữ liệu", 8L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7134), 7, "Tích hợp API", 9L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7136), 8, "Lập trình C#", 10L },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7138), 9, "Phân tích yêu cầu", 11L }
                });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "EnrolledAt", "Status", "StudentId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7831), "ENROLLED", 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7831) },
                    { 2L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7833), "ENROLLED", 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7834) },
                    { 3L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7836), "ENROLLED", 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7836) },
                    { 4L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7879), "ENROLLED", 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7880) },
                    { 5L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7882), "ENROLLED", 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7882) },
                    { 6L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7884), "ENROLLED", 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7885) },
                    { 7L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7886), "ENROLLED", 13L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7887) },
                    { 8L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7889), "ENROLLED", 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7890) },
                    { 9L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7891), "ENROLLED", 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7892) },
                    { 10L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7894), "ENROLLED", 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7894) },
                    { 11L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7896), "ENROLLED", 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7897) },
                    { 12L, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7899), "ENROLLED", 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7899) },
                    { 13L, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7901), "ENROLLED", 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7901) },
                    { 14L, 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7903), "ENROLLED", 13L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7904) },
                    { 15L, 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7906), "ENROLLED", 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7906) },
                    { 16L, 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7908), "COMPLETED", 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7908) },
                    { 17L, 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7910), "COMPLETED", 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7911) },
                    { 18L, 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7913), "COMPLETED", 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7913) },
                    { 19L, 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7915), "COMPLETED", 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7916) },
                    { 20L, 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7919), "COMPLETED", 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7919) },
                    { 21L, 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7921), "COMPLETED", 13L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7922) },
                    { 22L, 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7923), "COMPLETED", 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7924) },
                    { 23L, 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7926), "COMPLETED", 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7926) },
                    { 24L, 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7928), "ENROLLED", 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7929) },
                    { 25L, 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7931), "ENROLLED", 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7931) },
                    { 26L, 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7933), "ENROLLED", 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7933) },
                    { 27L, 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7935), "ENROLLED", 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7936) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassCode", "CourseId", "CreatedAt", "Email", "FailedLoginAttempts", "FullName", "GroupId", "Locked", "Password", "RoleId", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 4L, "/static/medit/imgUser/avatar.jpg", null, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3850), "lecturer1@hutech.edu.vn", 0, "Lê Văn Nam", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3854), "lecturer1" },
                    { 5L, "/static/medit/imgUser/avatar.jpg", null, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3861), "lecturer2@hutech.edu.vn", 0, "Phạm Thị Mai", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3862), "lecturer2" },
                    { 6L, "/static/medit/imgUser/avatar.jpg", null, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3972), "lecturer3@hutech.edu.vn", 0, "Hoàng Văn Tùng", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(3973), "lecturer3" },
                    { 14L, "/static/medit/imgUser/avatar.jpg", null, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4077), "lecturer4@hutech.edu.vn", 0, "Nguyễn Thị Ngọc", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4078), "lecturer4" },
                    { 15L, "/static/medit/imgUser/avatar.jpg", null, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4084), "lecturer5@hutech.edu.vn", 0, "Võ Văn Tài", null, false, "$2a$11$SbINNemr35xbH/wzLNP6IuJvH2WYb9xHh42o4o4AVg5xGWFJ3jeAq", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4087), "lecturer5" }
                });

            migrationBuilder.InsertData(
                table: "CommitteeMembers",
                columns: new[] { "Id", "CommitteeId", "CreatedAt", "LecturerId", "Role" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6069), 4L, "Thành viên" },
                    { 4L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6072), 5L, "Thư ký" },
                    { 5L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6074), 6L, "Thành viên" },
                    { 6L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6075), 14L, "Chủ tịch" },
                    { 7L, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6077), 15L, "Thư ký" },
                    { 8L, 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6079), 4L, "Thành viên" },
                    { 9L, 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6080), 5L, "Chủ tịch" },
                    { 10L, 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6082), 6L, "Thư ký" },
                    { 11L, 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6083), 14L, "Thành viên" },
                    { 12L, 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6085), 15L, "Chủ tịch" }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "UserId" },
                values: new object[,]
                {
                    { 9L, "GRADE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7635), "Chấm điểm cho Nhóm 1.", 4L },
                    { 10L, "GRADE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7637), "Chấm điểm cho Nhóm 2.", 5L },
                    { 11L, "CREATE_PROJECT", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7638), "Tạo đồ án mới.", 6L },
                    { 12L, "UPDATE_PROJECT", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7640), "Cập nhật đồ án 4.", 14L }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Description", "GroupId", "LecturerId", "ProjectCode", "Status", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4344), "Phát triển ứng dụng AI hỗ trợ chẩn đoán bệnh.", 1L, 4L, "AI_YTE_2025_01", "NOT_SUBMITTED", "Ứng dụng AI trong y tế", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4344) },
                    { 2L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4350), "Xây dựng hệ thống quản lý đồ án sinh viên.", 2L, 5L, "QLDA_2025_01", "NOT_SUBMITTED", "Hệ thống quản lý đồ án", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4351) },
                    { 3L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4396), "Phát triển website bán hàng trực tuyến.", 3L, 6L, "TMĐT_2025_01", "NOT_SUBMITTED", "Ứng dụng thương mại điện tử", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4397) },
                    { 4L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4401), "Xây dựng hệ thống phân tích dữ liệu thời gian thực.", 4L, 14L, "PTDL_2025_01", "SUBMITTED", "Phân tích dữ liệu thời gian thực", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4402) },
                    { 5L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4407), "Phát triển app quản lý học tập cho sinh viên.", 5L, 15L, "QLHT_2025_01", "SUBMITTED", "Ứng dụng quản lý học tập", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4407) },
                    { 6L, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4412), "Xây dựng giải pháp bảo mật cho thiết bị IoT.", 6L, 4L, "BM_IOT_2025_01", "SUBMITTED", "Hệ thống bảo mật IoT", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4412) },
                    { 7L, 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4416), "Phân tích hành vi người dùng trên mạng xã hội.", 7L, 5L, "PTMXH_2025_01", "SUBMITTED", "Phân tích dữ liệu mạng xã hội", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4417) },
                    { 8L, 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4421), "Phát triển app học ngoại ngữ với AI.", 9L, 6L, "HNN_2025_01", "GRADED", "Ứng dụng học ngoại ngữ", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4421) },
                    { 9L, 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4425), "Xây dựng hệ thống quản lý kho hàng tự động.", 8L, 14L, "QLK_2025_01", "GRADED", "Hệ thống quản lý kho", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4426) },
                    { 10L, 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4430), "Phát triển app đặt lịch khám bệnh trực tuyến.", 10L, 15L, "DLKB_2025_01", "GRADED", "Ứng dụng đặt lịch khám bệnh", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4430) },
                    { 11L, 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4434), "Xây dựng hệ thống quản lý nhân sự cho doanh nghiệp.", 12L, 4L, "QLNS_2025_01", "GRADED", "Hệ thống quản lý nhân sự", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4435) },
                    { 12L, 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4439), "Phát triển app hỗ trợ học tập nhóm.", 11L, 5L, "HTN_2025_01", "PENDING", "Ứng dụng học tập nhóm", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4440) },
                    { 13L, 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4444), "Xây dựng hệ thống phân tích tài chính cá nhân.", 13L, 6L, "PTTC_2025_01", "PENDING", "Hệ thống phân tích tài chính", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4444) }
                });

            migrationBuilder.InsertData(
                table: "AISuggestions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Type", "UserId" },
                values: new object[,]
                {
                    { 2L, "Điểm nội dung có thể tăng nếu bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7557), 1L, "GRADE", null },
                    { 4L, "Điểm trình bày có thể tăng nếu cải thiện bố cục.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7560), 2L, "GRADE", null },
                    { 6L, "Điểm nội dung có thể tăng nếu bổ sung ví dụ thực tế.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7564), 3L, "GRADE", null },
                    { 8L, "Điểm phân tích có thể tăng nếu cải thiện độ chính xác.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7567), 4L, "GRADE", null },
                    { 10L, "Điểm thực hành có thể tăng nếu bổ sung tính năng.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7571), 5L, "GRADE", null },
                    { 12L, "Điểm bảo mật có thể tăng nếu kiểm tra kỹ hơn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7575), 6L, "GRADE", null }
                });

            migrationBuilder.InsertData(
                table: "DefenseSchedules",
                columns: new[] { "Id", "CreatedAt", "EndTime", "ProjectId", "Room", "StartTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6131), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1L, "A101", new DateTime(2025, 3, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6134), new DateTime(2025, 3, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2L, "A102", new DateTime(2025, 3, 2, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6137), new DateTime(2025, 3, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 3L, "A103", new DateTime(2025, 3, 3, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6139), new DateTime(2025, 3, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 4L, "A104", new DateTime(2025, 3, 4, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6141), new DateTime(2025, 3, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 5L, "A105", new DateTime(2025, 3, 5, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6143), new DateTime(2025, 3, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 6L, "A106", new DateTime(2025, 3, 6, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6145), new DateTime(2025, 3, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 7L, "A107", new DateTime(2025, 3, 7, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6147), new DateTime(2025, 3, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 8L, "A108", new DateTime(2025, 3, 8, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6149), new DateTime(2025, 3, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 9L, "A109", new DateTime(2025, 3, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6151), new DateTime(2025, 3, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 10L, "A110", new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6153), new DateTime(2025, 3, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 11L, "A111", new DateTime(2025, 3, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6155), new DateTime(2025, 3, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 12L, "A112", new DateTime(2025, 3, 12, 8, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Content", "CreatedAt", "ProjectId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Có ai biết cách tích hợp AI vào ứng dụng y tế?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6961), 1L, "Hỏi về AI trong y tế", 7L, 5 },
                    { 3L, "Nên dùng cổng thanh toán nào?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6966), 3L, "Thanh toán thương mại điện tử", 10L, 4 },
                    { 4L, "Có công cụ nào tốt để phân tích dữ liệu?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6968), 4L, "Phân tích dữ liệu", 12L, 2 },
                    { 5L, "App quản lý học tập nên có tính năng gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6970), 5L, "Quản lý học tập", 7L, 6 },
                    { 6L, "Làm sao để tăng cường bảo mật IoT?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6972), 6L, "Bảo mật IoT", 8L, 3 },
                    { 7L, "Có công cụ nào miễn phí để phân tích?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6975), 7L, "Phân tích mạng xã hội", 9L, 5 },
                    { 8L, "App học ngoại ngữ nên có gì đặc biệt?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6977), 8L, "Học ngoại ngữ", 10L, 4 },
                    { 9L, "Hệ thống quản lý kho nên tự động hóa thế nào?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6978), 9L, "Quản lý kho", 11L, 3 },
                    { 10L, "App đặt lịch nên có thông báo không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6981), 10L, "Đặt lịch khám bệnh", 12L, 5 },
                    { 11L, "Hệ thống nhân sự cần báo cáo gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6982), 11L, "Quản lý nhân sự", 13L, 2 },
                    { 12L, "App học nhóm nên có tính năng gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6984), 12L, "Học tập nhóm", 7L, 4 }
                });

            migrationBuilder.InsertData(
                table: "GradeSchedules",
                columns: new[] { "Id", "CreatedAt", "Deadline", "LecturerId", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5773), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 1L, "PENDING" },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5776), new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 2L, "PENDING" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5778), new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 3L, "COMPLETED" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5780), new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 4L, "PENDING" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5782), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 5L, "PENDING" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5783), new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 6L, "COMPLETED" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5785), new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 7L, "PENDING" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5787), new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6L, 8L, "PENDING" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5789), new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14L, 9L, "COMPLETED" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5791), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15L, 10L, "PENDING" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5793), new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4L, 11L, "PENDING" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5794), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5L, 12L, "COMPLETED" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreatedAt", "MaxMembers", "Name", "ProjectId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4636), 5, "Nhóm 1", 1L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4637) },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4642), 5, "Nhóm 2", 2L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4642) },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4646), 5, "Nhóm 3", 3L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4647) },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4651), 5, "Nhóm 4", 4L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4651) },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4655), 5, "Nhóm 5", 5L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4656) },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4659), 5, "Nhóm 6", 6L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4660) },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4664), 5, "Nhóm 7", 7L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4664) },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4668), 5, "Nhóm 8", 8L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4668) },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4672), 5, "Nhóm 9", 9L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4673) },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4677), 5, "Nhóm 10", 10L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4677) },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4681), 5, "Nhóm 11", 11L, "APPROVED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4681) },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4685), 5, "Nhóm 12", 12L, "PENDING", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4686) },
                    { 13L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4689), 5, "Nhóm 13", 13L, "PENDING", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4690) }
                });

            migrationBuilder.InsertData(
                table: "ProjectVersions",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Title", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4502), "Phiên bản ban đầu.", 1L, "Ứng dụng AI trong y tế", 1 },
                    { 2L, new DateTime(2025, 5, 14, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4504), "Cập nhật mô tả.", 1L, "Ứng dụng AI trong y tế (Cập nhật)", 2 },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4512), "Phiên bản ban đầu.", 2L, "Hệ thống quản lý đồ án", 1 },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4513), "Phiên bản ban đầu.", 3L, "Ứng dụng thương mại điện tử", 1 },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4515), "Phiên bản ban đầu.", 4L, "Phân tích dữ liệu thời gian thực", 1 },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4517), "Phiên bản ban đầu.", 5L, "Ứng dụng quản lý học tập", 1 },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4518), "Phiên bản ban đầu.", 6L, "Hệ thống bảo mật IoT", 1 },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4520), "Phiên bản ban đầu.", 7L, "Phân tích dữ liệu mạng xã hội", 1 },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4521), "Phiên bản ban đầu.", 8L, "Ứng dụng học ngoại ngữ", 1 },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4523), "Phiên bản ban đầu.", 9L, "Hệ thống quản lý kho", 1 },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4525), "Phiên bản ban đầu.", 10L, "Ứng dụng đặt lịch khám bệnh", 1 },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4526), "Phiên bản ban đầu.", 11L, "Hệ thống quản lý nhân sự", 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedBy", "ProjectId" },
                values: new object[,]
                {
                    { 1L, "Ứng dụng AI của bạn giải quyết vấn đề gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6696), 4L, 1L },
                    { 2L, "Hệ thống quản lý đồ án có những tính năng gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6698), 5L, 2L },
                    { 3L, "Website thương mại điện tử có tích hợp thanh toán không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6699), 6L, 3L },
                    { 4L, "Phân tích dữ liệu thời gian thực dùng công nghệ gì?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6701), 14L, 4L },
                    { 5L, "App quản lý học tập có hỗ trợ offline không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6702), 15L, 5L },
                    { 6L, "Hệ thống bảo mật IoT đã kiểm tra lỗ hổng chưa?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6704), 4L, 6L },
                    { 7L, "Phân tích dữ liệu mạng xã hội có chính xác không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6705), 5L, 7L },
                    { 8L, "App học ngoại ngữ hỗ trợ bao nhiêu ngôn ngữ?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6707), 6L, 8L },
                    { 9L, "Hệ thống quản lý kho có tự động hóa không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6708), 14L, 9L },
                    { 10L, "App đặt lịch khám bệnh có thông báo nhắc nhở không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6710), 15L, 10L },
                    { 11L, "Hệ thống quản lý nhân sự có báo cáo không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6711), 4L, 11L },
                    { 12L, "App học tập nhóm có tính năng chat không?", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6713), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6612), 4L, "resources/ai_doc.pdf", null, 1L, "Tài liệu AI", "REFERENCE" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6625), 6L, "resources/ecommerce.pdf", null, 3L, "Tài liệu thương mại điện tử", "REFERENCE" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6627), 14L, "resources/data_analysis.pdf", null, 4L, "Hướng dẫn phân tích dữ liệu", "REFERENCE" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6629), 15L, "resources/study_management.pdf", null, 5L, "Tài liệu quản lý học tập", "REFERENCE" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6631), 4L, "resources/iot_security.pdf", null, 6L, "Tài liệu bảo mật IoT", "REFERENCE" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6632), 5L, "resources/social_media_analysis.pdf", null, 7L, "Phân tích mạng xã hội", "REFERENCE" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6634), 6L, "resources/language_learning.pdf", null, 8L, "Tài liệu học ngoại ngữ", "REFERENCE" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6636), 14L, "resources/warehouse_management.pdf", null, 9L, "Hướng dẫn quản lý kho", "REFERENCE" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6638), 15L, "resources/booking_system.pdf", null, 10L, "Tài liệu đặt lịch khám bệnh", "REFERENCE" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6640), 4L, "resources/hr_management.pdf", null, 11L, "Tài liệu quản lý nhân sự", "REFERENCE" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6642), 5L, "resources/group_study.pdf", null, 12L, "Hướng dẫn học tập nhóm", "REFERENCE" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4952), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế giao diện quản lý đồ án.", null, 2L, "IN_PROGRESS", 9L, "Thiết kế giao diện" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4957), new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp API phân tích dữ liệu.", null, 4L, "IN_PROGRESS", 12L, "Tích hợp API" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4961), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra lỗ hổng bảo mật IoT.", null, 6L, "IN_PROGRESS", 8L, "Kiểm tra bảo mật" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4966), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp AI vào app học ngoại ngữ.", null, 8L, "IN_PROGRESS", 10L, "Tích hợp AI" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4971), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển giao diện đặt lịch khám.", null, 10L, "IN_PROGRESS", 12L, "Phát triển giao diện" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4975), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tích hợp tính năng chat nhóm.", null, 12L, "TODO", 13L, "Tích hợp chat" }
                });

            migrationBuilder.InsertData(
                table: "TimeTrackings",
                columns: new[] { "Id", "CreatedAt", "Duration", "EndTime", "ProjectId", "StartTime", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7202), 120, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7200), 1L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7196), 7L },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7206), 60, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7205), 1L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7204), 8L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7209), 180, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7208), 2L, new DateTime(2025, 5, 15, 15, 8, 50, 956, DateTimeKind.Utc).AddTicks(7208), 9L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7212), 60, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7211), 3L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7210), 10L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7216), 120, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7214), 4L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7214), 11L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7222), 240, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7218), 5L, new DateTime(2025, 5, 15, 14, 8, 50, 956, DateTimeKind.Utc).AddTicks(7217), 12L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7226), 60, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7225), 6L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7224), 13L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7229), 120, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7228), 7L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7227), 7L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7232), 180, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7231), 8L, new DateTime(2025, 5, 15, 15, 8, 50, 956, DateTimeKind.Utc).AddTicks(7230), 8L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7235), 60, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7234), 9L, new DateTime(2025, 5, 15, 17, 8, 50, 956, DateTimeKind.Utc).AddTicks(7233), 9L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7238), 120, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7237), 10L, new DateTime(2025, 5, 15, 16, 8, 50, 956, DateTimeKind.Utc).AddTicks(7236), 10L },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7241), 180, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7240), 11L, new DateTime(2025, 5, 15, 15, 8, 50, 956, DateTimeKind.Utc).AddTicks(7240), 11L }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "Id", "CreatedAt", "EndTime", "EventTitle", "GroupId", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7480), new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), "Nộp bài", 1L, new DateTime(2025, 2, 28, 23, 59, 0, 0, DateTimeKind.Unspecified), 2L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7482), new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 2L, new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 8L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7487), new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 3L, new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), 10L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7493), new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 4L, new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), 12L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7498), new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 5L, new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), 7L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(7502), new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm", 6L, new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 9L }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Comment", "CriteriaId", "GradedAt", "GradedBy", "GroupId", "ProjectId", "Score", "StudentId" },
                values: new object[,]
                {
                    { 1L, "Nội dung tốt.", 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5467), 4L, 1L, 1L, 8.5f, null },
                    { 2L, "Trình bày rõ ràng.", 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5470), 4L, 1L, 1L, 8f, null },
                    { 3L, "Nội dung ổn.", 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5473), 5L, 2L, 2L, 7.5f, null },
                    { 4L, "Nội dung tốt.", 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5475), 6L, 3L, 3L, 8f, null },
                    { 5L, "Cần cải thiện.", 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5477), 14L, 4L, 4L, 7f, null },
                    { 6L, "Thực hành tốt.", 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5480), 15L, 5L, 5L, 8.5f, null },
                    { 7L, "Bảo mật tốt.", 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5483), 4L, 6L, 6L, 9f, null },
                    { 8L, "Phân tích chưa sâu.", 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5565), 5L, 7L, 7L, 6.5f, null },
                    { 9L, "Ứng dụng ổn.", 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5568), 6L, 8L, 8L, 8f, null },
                    { 10L, "Quản lý tốt.", 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5573), 14L, 9L, 9L, 7.5f, null },
                    { 11L, "Tiện ích cao.", 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5575), 15L, 10L, 10L, 8f, null },
                    { 12L, "Hiệu quả ổn.", 13L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5578), 4L, 11L, 11L, 7f, null }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "Id", "GroupId", "JoinedAt", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4744), 7L },
                    { 2L, 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4746), 8L },
                    { 3L, 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4747), 9L },
                    { 4L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4749), 10L },
                    { 5L, 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4750), 11L },
                    { 6L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4752), 12L },
                    { 7L, 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4753), 13L },
                    { 8L, 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4754), 7L },
                    { 9L, 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4756), 8L },
                    { 10L, 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4757), 9L },
                    { 11L, 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4759), 10L },
                    { 12L, 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4800), 11L },
                    { 13L, 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4801), 12L },
                    { 14L, 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4803), 13L },
                    { 15L, 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4804), 7L }
                });

            migrationBuilder.InsertData(
                table: "GroupRequests",
                columns: new[] { "Id", "CreatedAt", "GroupId", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4863), 1L, "PENDING", 9L },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4865), 2L, "APPROVED", 10L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4867), 3L, "REJECTED", 12L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4868), 4L, "PENDING", 13L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4870), 5L, "APPROVED", 7L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4871), 6L, "PENDING", 8L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4873), 7L, "APPROVED", 9L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4875), 8L, "REJECTED", 10L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4876), 9L, "PENDING", 11L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4878), 10L, "APPROVED", 12L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4879), 11L, "PENDING", 13L },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4881), 12L, "REJECTED", 7L }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "EndTime", "GroupId", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6223), 4L, new DateTime(2025, 2, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Phòng B101", new DateTime(2025, 2, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 1" },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6227), 5L, new DateTime(2025, 2, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Online", new DateTime(2025, 2, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 2" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6234), 6L, new DateTime(2025, 2, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Phòng B102", new DateTime(2025, 2, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 3" },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6237), 14L, new DateTime(2025, 3, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 4L, "Online", new DateTime(2025, 3, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 4" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6239), 15L, new DateTime(2025, 3, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), 5L, "Phòng B103", new DateTime(2025, 3, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 5" },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6242), 4L, new DateTime(2025, 3, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 6L, "Online", new DateTime(2025, 3, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 6" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6244), 5L, new DateTime(2025, 3, 24, 15, 0, 0, 0, DateTimeKind.Unspecified), 7L, "Phòng B104", new DateTime(2025, 3, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 7" },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6247), 6L, new DateTime(2025, 3, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), 8L, "Online", new DateTime(2025, 3, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 8" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6249), 14L, new DateTime(2025, 4, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 9L, "Phòng B105", new DateTime(2025, 4, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 9" },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6251), 15L, new DateTime(2025, 4, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), 10L, "Online", new DateTime(2025, 4, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 10" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6254), 4L, new DateTime(2025, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 11L, "Phòng B106", new DateTime(2025, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 11" },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6256), 5L, new DateTime(2025, 4, 28, 15, 0, 0, 0, DateTimeKind.Unspecified), 12L, "Online", new DateTime(2025, 4, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Họp nhóm tuần 12" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "CreatedAt", "GroupId", "RecipientType", "Status", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 3L, "Bạn được thêm vào Nhóm 1.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6474), 1L, "user", "SENT", "Nhóm mới", "WEB", 8L },
                    { 4L, "Họp nhóm vào 14:00, 03/03/2025.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6476), 3L, "group", "SENT", "Họp nhóm", "WEB", 10L },
                    { 5L, "Đồ án Nhóm 4 cần chỉnh sửa.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6478), 4L, "group", "SENT", "Phản hồi đồ án", "WEB", 11L },
                    { 6L, "Bạn được giao nhiệm vụ mới.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6481), 5L, "user", "SENT", "Nhiệm vụ mới", "WEB", 12L },
                    { 7L, "Điểm của Nhóm 6 đã được cập nhật.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6483), 6L, "group", "SENT", "Cập nhật điểm", "WEB", 13L },
                    { 8L, "Hạn chót nhiệm vụ là 10/03/2025.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6486), 7L, "group", "SENT", "Hạn chót nhiệm vụ", "WEB", 7L },
                    { 9L, "Lịch bảo vệ: 08/03/2025, A108.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6490), 8L, "group", "SENT", "Lịch bảo vệ", "WEB", 8L },
                    { 10L, "Nhóm 9 nhận phản hồi mới.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6492), 9L, "group", "SENT", "Phản hồi mới", "WEB", 9L },
                    { 11L, "Đồ án Nhóm 10 đã được phê duyệt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6494), 10L, "group", "SENT", "Cập nhật đồ án", "WEB", 10L },
                    { 12L, "Nhiệm vụ của Nhóm 11 đã hoàn thành.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6496), 11L, "group", "SENT", "Nhiệm vụ hoàn thành", "WEB", 11L }
                });

            migrationBuilder.InsertData(
                table: "PeerReviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "GroupId", "RevieweeId", "ReviewerId", "Score" },
                values: new object[,]
                {
                    { 1L, "Làm việc tốt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6542), 1L, 8L, 7L, 8 },
                    { 2L, "Cần cải thiện giao tiếp.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6545), 1L, 7L, 8L, 7 },
                    { 3L, "Hỗ trợ nhóm tốt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6546), 3L, 11L, 10L, 9 },
                    { 4L, "Cần chủ động hơn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6548), 3L, 10L, 11L, 6 },
                    { 5L, "Đóng góp tích cực.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6550), 4L, 13L, 12L, 8 },
                    { 6L, "Cần cải thiện kỹ năng.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6552), 4L, 12L, 13L, 7 },
                    { 7L, "Làm việc hiệu quả.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6553), 5L, 8L, 7L, 9 },
                    { 8L, "Cần tập trung hơn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6555), 6L, 9L, 8L, 6 },
                    { 9L, "Hợp tác tốt.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6557), 7L, 10L, 9L, 8 },
                    { 10L, "Cần cải thiện thái độ.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6559), 8L, 11L, 10L, 7 },
                    { 11L, "Đóng góp lớn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6561), 9L, 12L, 11L, 9 },
                    { 12L, "Làm việc ổn.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6562), 10L, 13L, 12L, 8 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "FilePath", "GroupId", "ProjectId", "Title", "Type" },
                values: new object[] { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6616), 5L, "resources/report_template.docx", 2L, null, "Mẫu báo cáo", "SAMPLE" });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "SubmittedAt", "Version" },
                values: new object[,]
                {
                    { 1L, "submissions/dt001.pdf", 1L, 1L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5059), 1 },
                    { 2L, "submissions/dt002.pdf", 2L, 2L, "VALIDATED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5063), 1 },
                    { 3L, "submissions/dt003.pdf", 3L, 3L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5065), 1 },
                    { 4L, "submissions/dt004.pdf", 4L, 4L, "REJECTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5068), 1 },
                    { 5L, "submissions/dt005.pdf", 5L, 5L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5070), 1 },
                    { 6L, "submissions/dt006.pdf", 6L, 6L, "VALIDATED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5072), 1 },
                    { 7L, "submissions/dt007.pdf", 7L, 7L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5075), 1 },
                    { 8L, "submissions/dt008.pdf", 8L, 8L, "REJECTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5077), 1 },
                    { 9L, "submissions/dt009.pdf", 9L, 9L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5079), 1 },
                    { 10L, "submissions/dt010.pdf", 10L, 10L, "VALIDATED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5082), 1 },
                    { 11L, "submissions/dt011.pdf", 11L, 11L, "SUBMITTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5084), 1 },
                    { 12L, "submissions/dt012.pdf", 12L, 12L, "REJECTED", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5087), 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "GroupId", "ProjectId", "Status", "StudentId", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4948), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phân tích yêu cầu hệ thống AI.", 1L, 1L, "TODO", null, "Phân tích yêu cầu" },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4954), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế và triển khai CSDL.", 3L, 3L, "DONE", null, "Xây dựng cơ sở dữ liệu" },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4959), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phát triển tính năng quản lý lịch học.", 5L, 5L, "TODO", null, "Phát triển tính năng" },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4964), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thu thập dữ liệu từ mạng xã hội.", 7L, 7L, "DONE", null, "Thu thập dữ liệu" },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4968), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế hệ thống quản lý kho.", 9L, 9L, "TODO", null, "Thiết kế hệ thống" },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(4973), new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiểm tra chức năng quản lý nhân sự.", 11L, 11L, "DONE", null, "Kiểm tra chức năng" }
                });

            migrationBuilder.InsertData(
                table: "CodeRuns",
                columns: new[] { "Id", "Code", "CreatedAt", "Language", "PlagiarismScore", "Result", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "print('Hello World')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5304), "Python", 0.1f, "Success", 1L },
                    { 2L, "public class Main { public static void main(String[] args) { System.out.println('Hello'); } }", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5307), "Java", 0.2f, "Success", 2L },
                    { 3L, "console.log('Hello World');", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5309), "JavaScript", 0.15f, "Success", 3L },
                    { 4L, "print('Error Test')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5311), "Python", 0.3f, "Failed", 4L },
                    { 5L, "public class Test { public static void main(String[] args) { System.out.println('Test'); } }", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5313), "Java", 0.1f, "Success", 5L },
                    { 6L, "print('IoT Security')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5315), "Python", 0.05f, "Success", 6L },
                    { 7L, "console.log('Social Media');", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5317), "JavaScript", 0.2f, "Success", 7L },
                    { 8L, "print('Language Learning')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5320), "Python", 0.4f, "Failed", 8L },
                    { 9L, "public class Warehouse { public static void main(String[] args) { System.out.println('Warehouse'); } }", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5322), "Java", 0.1f, "Success", 9L },
                    { 10L, "print('Booking System')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5324), "Python", 0.05f, "Success", 10L },
                    { 11L, "console.log('HR System');", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5326), "JavaScript", 0.15f, "Success", 11L },
                    { 12L, "print('Group Study')", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5328), "Python", 0.3f, "Failed", 12L }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "CreatedAt", "LecturerId", "SubmissionId" },
                values: new object[,]
                {
                    { 1L, "Cần cải thiện phần phân tích dữ liệu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5240), 4L, 1L },
                    { 2L, "Tốt, nhưng cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5242), 5L, 2L },
                    { 3L, "Cần chỉnh sửa bố cục báo cáo.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5244), 6L, 3L },
                    { 4L, "Bài nộp chưa đạt yêu cầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5246), 14L, 4L },
                    { 5L, "Cần bổ sung hình ảnh minh họa.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5247), 15L, 5L },
                    { 6L, "Tốt, nội dung đầy đủ.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5249), 4L, 6L },
                    { 7L, "Cần cải thiện phần kết luận.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5250), 5L, 7L },
                    { 8L, "Bài nộp không đúng định dạng.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5252), 6L, 8L },
                    { 9L, "Cần bổ sung tài liệu tham khảo.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5253), 14L, 9L },
                    { 10L, "Tốt, đạt yêu cầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5255), 15L, 10L },
                    { 11L, "Cần chỉnh sửa phần giới thiệu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5256), 4L, 11L },
                    { 12L, "Bài nộp không đạt, cần làm lại.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5258), 5L, 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeAppeals",
                columns: new[] { "Id", "CreatedAt", "GradeId", "Reason", "Response", "Status", "StudentId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5854), 1L, "Điểm nội dung chưa hợp lý.", null, "PENDING", 7L },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5857), 2L, "Điểm trình bày thấp.", "Đã điều chỉnh điểm.", "APPROVED", 8L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5859), 3L, "Điểm nội dung không hợp lý.", "Điểm đã hợp lý.", "REJECTED", 9L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5862), 4L, "Điểm nội dung thấp.", null, "PENDING", 10L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5864), 5L, "Cần xem lại điểm.", null, "PENDING", 12L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5866), 6L, "Điểm thực hành chưa đúng.", "Đã điều chỉnh.", "APPROVED", 7L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5869), 7L, "Điểm bảo mật không hợp lý.", "Điểm hợp lý.", "REJECTED", 8L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5871), 8L, "Điểm phân tích thấp.", null, "PENDING", 9L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5873), 9L, "Điểm ứng dụng chưa đúng.", "Đã điều chỉnh.", "APPROVED", 10L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5875), 10L, "Điểm quản lý chưa hợp lý.", "Điểm hợp lý.", "REJECTED", 11L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5877), 11L, "Điểm tiện ích thấp.", null, "PENDING", 12L }
                });

            migrationBuilder.InsertData(
                table: "GradeLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "GradeId", "LecturerId" },
                values: new object[,]
                {
                    { 1L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5714), "Tạo điểm cho nhóm 1.", 1L, 4L },
                    { 2L, "UPDATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5716), "Cập nhật điểm nhóm 1.", 1L, 4L },
                    { 3L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5718), "Tạo điểm cho nhóm 1.", 2L, 4L },
                    { 4L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5720), "Tạo điểm cho nhóm 2.", 3L, 5L },
                    { 5L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5722), "Tạo điểm cho nhóm 3.", 4L, 6L },
                    { 6L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5724), "Tạo điểm cho nhóm 4.", 5L, 14L },
                    { 7L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5725), "Tạo điểm cho nhóm 5.", 6L, 15L },
                    { 8L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5727), "Tạo điểm cho nhóm 6.", 7L, 4L },
                    { 9L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5729), "Tạo điểm cho nhóm 7.", 8L, 5L },
                    { 10L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5730), "Tạo điểm cho nhóm 8.", 9L, 6L },
                    { 11L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5732), "Tạo điểm cho nhóm 9.", 10L, 14L },
                    { 12L, "CREATE", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5734), "Tạo điểm cho nhóm 10.", 11L, 15L }
                });

            migrationBuilder.InsertData(
                table: "GradeVersions",
                columns: new[] { "Id", "Comment", "CreatedAt", "GradeId", "Score", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Phiên bản đầu.", new DateTime(2025, 5, 14, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5639), 1L, 8f, 1 },
                    { 2L, "Cập nhật điểm.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5642), 1L, 8.5f, 2 },
                    { 3L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5643), 2L, 8f, 1 },
                    { 4L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5645), 3L, 7.5f, 1 },
                    { 5L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5647), 4L, 8f, 1 },
                    { 6L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5649), 5L, 7f, 1 },
                    { 7L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5653), 6L, 8.5f, 1 },
                    { 8L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5655), 7L, 9f, 1 },
                    { 9L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5657), 8L, 6.5f, 1 },
                    { 10L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5659), 9L, 8f, 1 },
                    { 11L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5661), 10L, 7.5f, 1 },
                    { 12L, "Phiên bản đầu.", new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5663), 11L, 8f, 1 }
                });

            migrationBuilder.InsertData(
                table: "MeetingRecords",
                columns: new[] { "Id", "CreatedAt", "FilePath", "MeetingId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6310), "records/meeting1.mp3", 1L },
                    { 2L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6312), "records/meeting2.mp4", 2L },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6313), "records/meeting3.mp3", 3L },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6315), "records/meeting4.mp4", 4L },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6316), "records/meeting5.mp3", 5L },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6319), "records/meeting6.mp4", 6L },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6320), "records/meeting7.mp3", 7L },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6321), "records/meeting8.mp4", 8L },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6323), "records/meeting9.mp3", 9L },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6324), "records/meeting10.mp4", 10L },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6326), "records/meeting11.mp3", 11L },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(6327), "records/meeting12.mp4", 12L }
                });

            migrationBuilder.InsertData(
                table: "SubmissionVersions",
                columns: new[] { "Id", "CreatedAt", "FilePath", "SubmissionId", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5133), "submissions/dt001_v1.pdf", 1L, 1 },
                    { 2L, new DateTime(2025, 5, 14, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5135), "submissions/dt001_v2.pdf", 1L, 2 },
                    { 3L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5138), "submissions/dt002_v1.pdf", 2L, 1 },
                    { 4L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5139), "submissions/dt003_v1.pdf", 3L, 1 },
                    { 5L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5141), "submissions/dt004_v1.pdf", 4L, 1 },
                    { 6L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5142), "submissions/dt005_v1.pdf", 5L, 1 },
                    { 7L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5168), "submissions/dt006_v1.pdf", 6L, 1 },
                    { 8L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5170), "submissions/dt007_v1.pdf", 7L, 1 },
                    { 9L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5172), "submissions/dt008_v1.pdf", 8L, 1 },
                    { 10L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5173), "submissions/dt009_v1.pdf", 9L, 1 },
                    { 11L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5175), "submissions/dt010_v1.pdf", 10L, 1 },
                    { 12L, new DateTime(2025, 5, 15, 18, 8, 50, 956, DateTimeKind.Utc).AddTicks(5176), "submissions/dt011_v1.pdf", 11L, 1 }
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
