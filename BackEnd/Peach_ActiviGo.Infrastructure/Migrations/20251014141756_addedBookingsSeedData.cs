using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedBookingsSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_CustomerId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 25, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 26, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 26, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 24, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 24, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 27, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 27, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 25, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 25, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 28, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 28, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 23, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 23, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 26, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 26, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 14), new DateTime(2025, 10, 29, 18, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 10, 29, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "ActivitySlots",
                columns: new[] { "Id", "ActivityLocationId", "CreatedDate", "EndTime", "IsCanselled", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { 25, 1, new DateOnly(2025, 10, 14), new DateTime(2025, 10, 4, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 4, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 26, 3, new DateOnly(2025, 10, 14), new DateTime(2025, 10, 7, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 7, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 27, 5, new DateOnly(2025, 10, 14), new DateTime(2025, 10, 10, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 10, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 28, 7, new DateOnly(2025, 10, 14), new DateTime(2025, 10, 12, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 12, 17, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ActivitySlotId", "BookingDate", "CreatedDate", "CustomerId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1005, 1, new DateTime(2025, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2025, 10, 14), "cce4e116-f149-4d7a-9094-e3cfc2a62229", null },
                    { 1006, 2, new DateTime(2025, 1, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2025, 10, 14), "aa2c47dc-15f2-4e15-b409-7f94b48e554c", null },
                    { 1007, 3, new DateTime(2025, 1, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2025, 10, 14), "1f9ede01-aff8-4803-910c-24e78bc7fb8a", null },
                    { 1008, 4, new DateTime(2025, 1, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2025, 10, 14), "3217607b-81cc-4fdd-a16f-00e186e2d74f", null },
                    { 1009, 5, new DateTime(2025, 1, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2025, 10, 14), "2786eacf-fda5-4772-9336-5cb72ccce08b", null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 14));

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "ActivitySlotId", "BookingDate", "CreatedDate", "CustomerId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1001, 25, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateOnly(2025, 10, 14), "cce4e116-f149-4d7a-9094-e3cfc2a62229", null },
                    { 1002, 26, new DateTime(2025, 10, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateOnly(2025, 10, 14), "aa2c47dc-15f2-4e15-b409-7f94b48e554c", null },
                    { 1003, 27, new DateTime(2025, 10, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateOnly(2025, 10, 14), "1f9ede01-aff8-4803-910c-24e78bc7fb8a", null },
                    { 1004, 28, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Local), new DateOnly(2025, 10, 14), "8a54eb5f-01bc-4055-a6bf-be2048462451", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.AddColumn<string>(
                name: "CustomerId1",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId1",
                table: "Bookings",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_CustomerId1",
                table: "Bookings",
                column: "CustomerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
