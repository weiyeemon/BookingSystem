using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Model.Migrations
{
    /// <inheritdoc />
    public partial class Add_ScheduleType_Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleType",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8146), new DateTime(2023, 11, 12, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8125) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8160), new DateTime(2023, 11, 12, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 19, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8163), new DateTime(2023, 11, 12, 8, 35, 0, 384, DateTimeKind.Local).AddTicks(8162) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleType",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6329), new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6346), new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6344) });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 11, 18, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6351), new DateTime(2023, 11, 11, 17, 19, 0, 441, DateTimeKind.Local).AddTicks(6349) });
        }
    }
}
