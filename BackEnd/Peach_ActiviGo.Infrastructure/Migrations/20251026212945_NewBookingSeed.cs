using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewBookingSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateOnly(2025, 10, 26), "Klättra på olika nivåer", "Klättring" });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 26), new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 10, 25, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 26), new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 10, 25, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { 1, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { 1, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 25, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2025, 10, 26, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2025, 10, 26, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2025, 10, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2025, 10, 26, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 29, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 29, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 29, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ActivitySlots",
                columns: new[] { "Id", "ActivityLocationId", "CreatedDate", "EndTime", "IsCancelled", "SlotCapacity", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { 21, 6, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, 6, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, 6, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, 6, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, 7, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 31, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, 7, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 31, 11, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, 7, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 31, 13, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 28, 7, new DateOnly(2025, 10, 26), new DateTime(2025, 10, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 29, 8, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 30, 8, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, 8, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, 8, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, 9, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 11, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 34, 9, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 11, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 35, 9, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 11, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 36, 9, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 11, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 37, 10, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2025, 11, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 38, 10, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2025, 11, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 39, 10, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2025, 11, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 40, 10, new DateOnly(2025, 10, 26), new DateTime(2025, 11, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 15, new DateTime(2025, 11, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 26));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Göteborg centrum", new DateOnly(2025, 10, 26), 57.7089m, 11.9746m, "Göteborg" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Stockholm centrum", new DateOnly(2025, 10, 26), 59.3293m, 18.0686m, "Stockholm" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Malmö centrum", new DateOnly(2025, 10, 26), 55.6050m, 13.0038m, "Malmö" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Umeå centrum", new DateOnly(2025, 10, 26), 63.8258m, 20.2630m, "Umeå" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 24);

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

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name" },
                values: new object[] { new DateOnly(2025, 10, 21), "Klattra på olika nivåer", "Klattring" });

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivityLocations",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 21), new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { new DateOnly(2025, 10, 21), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "StartTime" },
                values: new object[] { 2, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 3, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 4, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 28, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2025, 10, 29, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 5, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2025, 10, 29, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 6, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2025, 10, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 6, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2025, 10, 30, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 7, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2025, 10, 31, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 7, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2025, 10, 31, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 8, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 8, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 9, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 9, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 10, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2025, 11, 3, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "ActivityLocationId", "CreatedDate", "EndTime", "SlotCapacity", "StartTime" },
                values: new object[] { 10, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2025, 11, 3, 14, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateOnly(2025, 10, 21));

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Falkenberg centrum", new DateOnly(2025, 10, 21), 56.9055m, 12.4912m, "Falkenberg" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Halmstad centrum", new DateOnly(2025, 10, 21), 56.6745m, 12.8570m, "Halmstad" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Veddige centrum", new DateOnly(2025, 10, 21), 57.2297m, 12.3836m, "Veddige" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "CreatedDate", "Latitude", "Longitude", "Name" },
                values: new object[] { "Slöinge centrum", new DateOnly(2025, 10, 21), 56.8358m, 12.7135m, "Slöinge" });
        }
    }
}
