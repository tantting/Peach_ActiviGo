using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingStatusAndCancelledAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 13, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 14, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 25, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 11), new DateTime(2025, 10, 26, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 26, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 11));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 11, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 11, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 14, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 12, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 12, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 13, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 14, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 9), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 9));
        }
    }
}
