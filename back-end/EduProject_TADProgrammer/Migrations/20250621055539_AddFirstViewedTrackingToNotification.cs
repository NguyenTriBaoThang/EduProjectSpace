using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduProject_TADProgrammer.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstViewedTrackingToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstViewedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstViewed",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3723), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3728), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3732), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3736), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3739), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3743), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3746), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3750), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3753), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3757), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3760), null, false });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "FirstViewedAt", "IsFirstViewed" },
                values: new object[] { new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(3764), null, false });

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

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "FilePath", "GroupId", "ProjectId", "Status", "StudentId", "SubmittedAt", "TaskId", "Version" },
                values: new object[] { 15L, "submissions/dt015.pdf", 1L, 1L, "SUBMITTED", 8L, new DateTime(2025, 6, 21, 5, 55, 35, 513, DateTimeKind.Utc).AddTicks(1874), 1L, 1 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DropColumn(
                name: "FirstViewedAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsFirstViewed",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9416));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9418));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9422));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "AISuggestions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9548), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9549) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9552), new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9554) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9556), new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9560), new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9563), new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9571), new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9572) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 1, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9574), new DateTime(2025, 6, 1, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9575) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 31, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9578), new DateTime(2025, 5, 31, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9578) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 30, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9581), new DateTime(2025, 5, 30, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9582) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 29, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9584), new DateTime(2025, 5, 29, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9588), new DateTime(2025, 5, 28, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9588) });

            migrationBuilder.UpdateData(
                table: "Backups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 5, 27, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9591), new DateTime(2025, 5, 27, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9592) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9201), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9201) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9207), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9212), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9215), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9220), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9224), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9227), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9231), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9231) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9235), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9239), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9244), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9244) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9247), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9248) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9251), new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9255), new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9259), new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9260) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9263), new DateTime(2025, 6, 5, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9263) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9267), new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9268) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9271), new DateTime(2025, 6, 4, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9275), new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9279), new DateTime(2025, 6, 3, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9283), new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Calendars",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9287), new DateTime(2025, 6, 2, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7089), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(7094), new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(7096) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(7099), new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(7100) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(7103), new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(7108), new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(7108) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 1, 11, 14, 130, DateTimeKind.Utc).AddTicks(7112), new DateTime(2025, 6, 7, 1, 11, 14, 130, DateTimeKind.Utc).AddTicks(7112) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 0, 11, 14, 130, DateTimeKind.Utc).AddTicks(7115), new DateTime(2025, 6, 7, 0, 11, 14, 130, DateTimeKind.Utc).AddTicks(7116) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 23, 11, 14, 130, DateTimeKind.Utc).AddTicks(7119), new DateTime(2025, 6, 6, 23, 11, 14, 130, DateTimeKind.Utc).AddTicks(7119) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 11, 14, 130, DateTimeKind.Utc).AddTicks(7122), new DateTime(2025, 6, 6, 22, 11, 14, 130, DateTimeKind.Utc).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 21, 11, 14, 130, DateTimeKind.Utc).AddTicks(7126), new DateTime(2025, 6, 6, 21, 11, 14, 130, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 20, 11, 14, 130, DateTimeKind.Utc).AddTicks(7129), new DateTime(2025, 6, 6, 20, 11, 14, 130, DateTimeKind.Utc).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "CodeRuns",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 19, 11, 14, 130, DateTimeKind.Utc).AddTicks(7133), new DateTime(2025, 6, 6, 19, 11, 14, 130, DateTimeKind.Utc).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7809), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7812), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7814), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7817), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7819), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7822), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7824), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7826), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7829), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7831), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7831) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7833), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "CommitteeMembers",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7835), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5848), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5854), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5855) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5859), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5863), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5864) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5868), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5868) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5872), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5876), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5877) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5886), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5887) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5895), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5895) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5899), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5900) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5904), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7734), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7738), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7739) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7741), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7741) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7743), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7744) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7746), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7746) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7748), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7749) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7751), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7751) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7753), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7753) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7755), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7756) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7758), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7758) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7760), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "DefenseCommittees",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7762), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7763) });

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7893));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.UpdateData(
                table: "DefenseSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7903));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8632));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8639));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8643));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "Discussions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8745));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "FeedbackSurveys",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7025));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7027));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7035));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "GradeAppeals",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7498));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7503));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "GradeLogs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7573));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "GradeSchedules",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7440));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "GradeVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7288));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7296));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7359));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7364));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7367));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16L,
                column: "GradedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 1L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6475));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 2L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6477));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 3L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 4L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 5L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6482));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 6L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 7L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6485));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 8L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 9L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 10L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 11L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6491));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 12L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 13L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 14L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6497));

            migrationBuilder.UpdateData(
                table: "GroupMembers",
                keyColumn: "Id",
                keyValue: 15L,
                column: "JoinedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6498));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6561));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6565));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.UpdateData(
                table: "GroupRequests",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6308), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6308) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6313), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6318), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6386), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6387) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6391), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6395), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6395) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6399), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6399) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6403), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6404) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6408), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6412), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6413) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6416), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6417) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6421), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6422) });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6425), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6426) });

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 1L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9957));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 2L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 3L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 4L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 5L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 6L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 7L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9967));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 8L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 9L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 10L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9971));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 11L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 12L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 13L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 14L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 15L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9979));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 16L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9980));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 17L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 18L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 19L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 20L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 21L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 22L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 23L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "LecturerCourses",
                keyColumn: "Id",
                keyValue: 24L,
                column: "AssignedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9485));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9488));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8082));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8085));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8089));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8093));

            migrationBuilder.UpdateData(
                table: "MeetingRecords",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7947));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7951));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7973));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(7978));

            migrationBuilder.UpdateData(
                table: "Meetings",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "PeerReviews",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6217));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6231));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6235));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "ProjectVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6246));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5997), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5998) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6003), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6008), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6008) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6013), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6013) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6017), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6022), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6119), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6124), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6124) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6128), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6129) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6133), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6133) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6137), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6142), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6143) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6147), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6148) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8398));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "UpdatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8816));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8817));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8820));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "SkillAssessments",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9692), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9695), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9697), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9699), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9700) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9702), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9702) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9704), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9707), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9709), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9712), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9712) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9714), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9715) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9716), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9719), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9719) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9721), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9723), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9724) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9726), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9726) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9728), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9729) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9730), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9731) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9733), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9735), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9735) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9737), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9740), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9740) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9742), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9744), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9747), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9747) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9749), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9751), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "StudentCourses",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "EnrolledAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9753), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 6, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6911));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "SubmissionVersions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 1L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6816));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 4L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 5L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 6L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 7L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 8L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 9L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 10L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 11L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 12L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 13L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "Id",
                keyValue: 14L,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9132));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "SystemMetrics",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6689));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6692));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6702));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6705));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6707));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6717));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8882), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8881), new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8886), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8885), new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8892), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8888), new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8895), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8894), new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8893) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8900), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8900), new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8903), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8902), new DateTime(2025, 6, 7, 2, 11, 14, 130, DateTimeKind.Utc).AddTicks(8902) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8906), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8905), new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8905) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8989), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8987), new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8982) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8993), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8992), new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(8991) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8996), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8995), new DateTime(2025, 6, 7, 5, 11, 14, 130, DateTimeKind.Utc).AddTicks(8994) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8999), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(8998), new DateTime(2025, 6, 7, 4, 11, 14, 130, DateTimeKind.Utc).AddTicks(8997) });

            migrationBuilder.UpdateData(
                table: "TimeTrackings",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9002), new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(9001), new DateTime(2025, 6, 7, 3, 11, 14, 130, DateTimeKind.Utc).AddTicks(9000) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5426), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5528), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5529) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5536), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5536) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5542), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5549), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5549) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5555), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5562), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5586), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5641), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5642) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5650), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5652) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5658), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5665), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5666) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5672), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5673) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5684), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5684) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5691), "$2a$11$eHOVdgXoOGbmti4okfvxKOep9REsYRub8niqy/N67iPhWmGdQRpgW", new DateTime(2025, 6, 7, 6, 11, 14, 130, DateTimeKind.Utc).AddTicks(5691) });
        }
    }
}
