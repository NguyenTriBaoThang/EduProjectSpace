using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduProject_TADProgrammer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedIdentityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LecturerId",
                table: "StudentCourses",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6891));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7085), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7086) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7091), new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7097), new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7098) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7102), new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7107), new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7116) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7120), new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7125), new DateTime(2025, 6, 17, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7130), new DateTime(2025, 6, 16, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 15, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7135), new DateTime(2025, 6, 15, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 14, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7140), new DateTime(2025, 6, 14, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7141) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 13, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7239), new DateTime(2025, 6, 13, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7244), new DateTime(2025, 6, 12, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7245) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6499), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6506), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6507) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6644), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6645) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6650), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6650) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6657), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6662), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6663) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6667), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6668) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6672), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6679), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6688), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6689) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6693), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6698), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6704), new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6706) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6711), new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6712) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6717), new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6722), new DateTime(2025, 6, 21, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6723) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6728), new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6729) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6734), new DateTime(2025, 6, 20, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6740), new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6741) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6746), new DateTime(2025, 6, 19, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6755), new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6756) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6761), new DateTime(2025, 6, 18, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6762) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2972), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(2979), new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(2984) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(2989), new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 22, 49, 31, 665, DateTimeKind.Utc).AddTicks(2995), new DateTime(2025, 6, 22, 22, 49, 31, 665, DateTimeKind.Utc).AddTicks(2996) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 21, 49, 31, 665, DateTimeKind.Utc).AddTicks(3000), new DateTime(2025, 6, 22, 21, 49, 31, 665, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 20, 49, 31, 665, DateTimeKind.Utc).AddTicks(3005), new DateTime(2025, 6, 22, 20, 49, 31, 665, DateTimeKind.Utc).AddTicks(3006) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 19, 49, 31, 665, DateTimeKind.Utc).AddTicks(3010), new DateTime(2025, 6, 22, 19, 49, 31, 665, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 18, 49, 31, 665, DateTimeKind.Utc).AddTicks(3015), new DateTime(2025, 6, 22, 18, 49, 31, 665, DateTimeKind.Utc).AddTicks(3016) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 17, 49, 31, 665, DateTimeKind.Utc).AddTicks(3020), new DateTime(2025, 6, 22, 17, 49, 31, 665, DateTimeKind.Utc).AddTicks(3021) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 16, 49, 31, 665, DateTimeKind.Utc).AddTicks(3025), new DateTime(2025, 6, 22, 16, 49, 31, 665, DateTimeKind.Utc).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 15, 49, 31, 665, DateTimeKind.Utc).AddTicks(3030), new DateTime(2025, 6, 22, 15, 49, 31, 665, DateTimeKind.Utc).AddTicks(3031) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 22, 14, 49, 31, 665, DateTimeKind.Utc).AddTicks(3035), new DateTime(2025, 6, 22, 14, 49, 31, 665, DateTimeKind.Utc).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4226), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4230), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4231) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4233), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4237), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4238) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4240), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4241) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4244), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4247), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4248) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4250), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4251) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4254), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4257), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4258) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4260), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4261) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4263), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4264) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4268), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4279), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4279) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4285), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4285) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4291), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4291) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4297), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4304), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4305) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4313), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4314) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4320), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4327), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4328) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4354), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4537) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4560), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4565), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4566) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4108), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4110) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4113), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4114) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4117), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4118) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4120), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4124), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4125) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4128), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4131), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4134), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4138), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4138) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4141), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4144), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4148), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4464));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5655));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5658));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5661));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5663));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5665));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5670));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5678));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5680));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5426));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5430));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5444));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5447));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5912));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2821));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2824));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4011));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4017));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3775));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3795));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3602));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3618));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3432));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3439));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3447));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3457));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3466));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3469));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3473));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3476));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 4L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6113));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 5L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 6L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6117));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 7L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 8L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 9L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6123));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 10L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 11L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 12L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6133));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 13L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 14L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6139));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 15L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6688));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6691));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5820), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5821) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5828), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5834), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5840), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5846), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5852), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5853) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5858), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5864), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5865) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5870), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5870) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5875), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5876) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5886), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6007), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 3L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 4L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 5L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 6L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 7L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 8L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 9L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7732));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 10L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 11L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 12L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 13L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 14L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 15L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 16L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7744));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 17L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 18L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 19L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 20L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 21L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7827));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 22L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 23L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 24L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4726));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4837));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4847));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4857));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5049));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5064));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5355));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4967), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4968) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4976), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4977) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4984), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4985) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4991), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4998), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5004), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5010), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5011) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5017), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5030), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5036), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5037) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5042), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5043) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5049), new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(5050) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5268));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5270));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5271));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5154));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5157));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5161));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7616));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6004));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6006));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6011));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6022));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7442), 4L, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7443) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7446), 4L, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7449), 4L, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7450) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7453), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7456), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7456) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7459), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7459) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7461), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7464), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7465) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7467), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7470), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7471) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7473), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7474) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7476), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7479), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7482), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7485), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7485) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7488), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7488) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7490), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7491) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7493), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7496), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7497) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7499), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7500) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7502), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7505), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7508), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7511), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7514), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7514) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7516), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7517) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "EnrolledAt", "LecturerId", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7519), null, new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1348));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(845));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(848));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(851));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(865));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6311));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6404));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6409));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6411));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6414));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6416));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7225));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7231));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7237));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(7273));

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6125), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6113) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6130), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6129), new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6128) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6140), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6133), new DateTime(2025, 6, 22, 22, 49, 31, 665, DateTimeKind.Utc).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6145), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6144), new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6158), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6157), new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6163), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6162), new DateTime(2025, 6, 22, 21, 49, 31, 665, DateTimeKind.Utc).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6167), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6166), new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6165) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6183), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6182), new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6187), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6186), new DateTime(2025, 6, 22, 22, 49, 31, 665, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6192), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6191), new DateTime(2025, 6, 23, 0, 49, 31, 665, DateTimeKind.Utc).AddTicks(6190) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6197), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6195), new DateTime(2025, 6, 22, 23, 49, 31, 665, DateTimeKind.Utc).AddTicks(6194) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6201), new DateTime(2025, 6, 23, 1, 49, 31, 665, DateTimeKind.Utc).AddTicks(6200), new DateTime(2025, 6, 22, 22, 49, 31, 665, DateTimeKind.Utc).AddTicks(6199) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3632), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3632) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3650), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3661), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3661) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3669), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3670) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3678), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3861), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3862) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3897), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3898) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3908), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3908) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3917), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3925), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3926) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3937), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3937) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3947), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4010), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4020), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4029), "$2a$11$qtG1R9k1CQE7iToS6.1CZeKOg/8MxeRHW7TgUF5MnK3ysOaQAj/US", new DateTime(2025, 6, 23, 1, 49, 31, 664, DateTimeKind.Utc).AddTicks(4029) });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_LecturerId",
                table: "StudentCourses",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_LecturerId",
                table: "StudentCourses",
                column: "LecturerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_LecturerId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_LecturerId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "StudentCourses");

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5456));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5459));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5462));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5465));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5468));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5476));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5479));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5486));

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5650), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5652) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5657), new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5664), new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5665) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5669), new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5670) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5674), new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5688), new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5689) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 15, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5693), new DateTime(2025, 6, 15, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 14, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5698), new DateTime(2025, 6, 14, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5699) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 13, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5706), new DateTime(2025, 6, 13, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5707) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 12, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5711), new DateTime(2025, 6, 12, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5712) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5716), new DateTime(2025, 6, 11, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5722), new DateTime(2025, 6, 10, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5187), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5188) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5193), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5198), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5199) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5203), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5203) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5209), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5210) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5215), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5216) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5220), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5221) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5224), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5225) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5292), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5297), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5299) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5303), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5304) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5308), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5309) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5313), new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5316) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5320), new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5321) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5327) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5331), new DateTime(2025, 6, 19, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5337), new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5343), new DateTime(2025, 6, 18, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5344) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5348), new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5349) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5353), new DateTime(2025, 6, 17, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5354) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5359), new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5360) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5365), new DateTime(2025, 6, 16, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2160), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(2168), new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(2176), new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(2177) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 2, 55, 35, 513, DateTimeKind.Utc).AddTicks(2182), new DateTime(2025, 6, 21, 2, 55, 35, 513, DateTimeKind.Utc).AddTicks(2183) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 1, 55, 35, 513, DateTimeKind.Utc).AddTicks(2187), new DateTime(2025, 6, 21, 1, 55, 35, 513, DateTimeKind.Utc).AddTicks(2189) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 0, 55, 35, 513, DateTimeKind.Utc).AddTicks(2194), new DateTime(2025, 6, 21, 0, 55, 35, 513, DateTimeKind.Utc).AddTicks(2195) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 23, 55, 35, 513, DateTimeKind.Utc).AddTicks(2200), new DateTime(2025, 6, 20, 23, 55, 35, 513, DateTimeKind.Utc).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 22, 55, 35, 513, DateTimeKind.Utc).AddTicks(2205), new DateTime(2025, 6, 20, 22, 55, 35, 513, DateTimeKind.Utc).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 21, 55, 35, 513, DateTimeKind.Utc).AddTicks(2211), new DateTime(2025, 6, 20, 21, 55, 35, 513, DateTimeKind.Utc).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 20, 55, 35, 513, DateTimeKind.Utc).AddTicks(2216), new DateTime(2025, 6, 20, 20, 55, 35, 513, DateTimeKind.Utc).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 19, 55, 35, 513, DateTimeKind.Utc).AddTicks(2222), new DateTime(2025, 6, 20, 19, 55, 35, 513, DateTimeKind.Utc).AddTicks(2223) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 20, 18, 55, 35, 513, DateTimeKind.Utc).AddTicks(2227), new DateTime(2025, 6, 20, 18, 55, 35, 513, DateTimeKind.Utc).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3243), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3244) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3248), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3249) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3252), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3255), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3259), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3262), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3266), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3269), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3272), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3275), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3279), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3279) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3282), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3283) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(575), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(584), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(590), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(598), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(604), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(604) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(610), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(610) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(616), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(622), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(622) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(628), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(628) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(642), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(642) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(648), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(649) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(654), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(655) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3132), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3134) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3137), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3137) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3140), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3141) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3144), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3145) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3148), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3149) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3152), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3153) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3155), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3159), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3159) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3162), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3163) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3165), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3166) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3169), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3172), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3173) });

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3342));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3349));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3413));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4378));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4387));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4393));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4399));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4401));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4271));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4281));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2780));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2788));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2790));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2855));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2861));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2943));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2951));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2954));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2957));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2959));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2967));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2701));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2709));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 4L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 5L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 6L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1397));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 7L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 8L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 9L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 10L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 11L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 12L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 13L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 14L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 15L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1506));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1508));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1514));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1182), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1190), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1191) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1197), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1197) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1203), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1209), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1210) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1215), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1216) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1221), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1226), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1227) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1231), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1237), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1243), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1244) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1249), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1250) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1255), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1256) });

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 3L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 4L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 5L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 6L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 7L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6249));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 8L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6251));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 9L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 10L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 11L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 12L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 13L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 14L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 15L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6265));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 16L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 17L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 18L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 19L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 20L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 21L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 22L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 23L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 24L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5567));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5571));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3627));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3633));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3640));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3513));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3723));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3728));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3732));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3844));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1018));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1027));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1031));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1036));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(828), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(829) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(839), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(846), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(847) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(852), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(853) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(859), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(860) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(865), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(866) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(871), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(878), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(884), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(885) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(891), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(897), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(904), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(904) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(910), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(911) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4152));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4059));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6099));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6104));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4731));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4739));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4748));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5930), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5934), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5934) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5937), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5940), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5943), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5946), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5947) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5949), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5952), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5952) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5954), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5955) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5957), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5960), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5961) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5963), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5966), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5966) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5969), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5969) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5972), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5972) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5974), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5975) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5978), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5978) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5981), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5984), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5988), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5991), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5992) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5994), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5997), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6001), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6002) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6004), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6005) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6008), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6011), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(6011) });

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 20, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1955));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1785));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1859));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 15L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5007));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5015));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(5103));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1628));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4856), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4854), new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4862), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4860), new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4872), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4865), new DateTime(2025, 6, 21, 2, 55, 35, 513, DateTimeKind.Utc).AddTicks(4864) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4877), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4875), new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(4874) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4886), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4884), new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4890), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4889), new DateTime(2025, 6, 21, 1, 55, 35, 513, DateTimeKind.Utc).AddTicks(4888) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4894), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4893), new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(4892) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4906), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4905), new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(4897) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4910), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4909), new DateTime(2025, 6, 21, 2, 55, 35, 513, DateTimeKind.Utc).AddTicks(4908) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4914), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4913), new DateTime(2025, 6, 21, 4, 55, 35, 513, DateTimeKind.Utc).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4919), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4918), new DateTime(2025, 6, 21, 3, 55, 35, 513, DateTimeKind.Utc).AddTicks(4917) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4923), new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(4922), new DateTime(2025, 6, 21, 2, 55, 35, 513, DateTimeKind.Utc).AddTicks(4921) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(128), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(128) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(143), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(155), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(166), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(175), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(176) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(236), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(263), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(274), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(285), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(295), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(295) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(305), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(315), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(423), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(437), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(438) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(447), "$2a$11$Z7kUclbAKAsfEidKWzwcFe0iYvlk6fjlvgUeGpWd./oWqxIdNgp8K", new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(448) });
        }
    }
}
