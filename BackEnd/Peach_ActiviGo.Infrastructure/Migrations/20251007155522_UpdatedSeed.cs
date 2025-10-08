using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DropColumn(
                name: "LatLong",
                table: "Locations");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Locations",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Locations",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 59.330000m, 18.060000m });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 59.320000m, 18.040000m });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 59.340000m, 18.050000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "LatLong",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "e9117b6f-2c22-4529-845d-e69d74343d31", "admin@activigo.se", true, false, null, "ADMIN@ACTIVIGO.SE", "ADMIN@ACTIVIGO.SE", "AQAAAAIAAYagAAAAEE67IKOcsXZojy2jU/F9tkl5zfWSYSTjejSLYSlB/oK7EEzZN/7RLeeVRMw3PVO2YQ==", null, false, "9367a0f6-4995-4f10-a234-6939143ecc33", false, "admin@activigo.se" },
                    { "2", 0, "807fdaad-bf89-446b-b8c7-41898ef2e7f7", "anna@activigo.se", true, false, null, "ANNA@ACTIVIGO.SE", "ANNA@ACTIVIGO.SE", "AQAAAAIAAYagAAAAEMMPJ/KaFN44+ejIfRzIbpHuXCiyQ2GQiZPIFIoIhgS4HO+A74gOscoR4nFaywgQxQ==", null, false, "3916da70-93ed-48d0-ac9a-fbc60e4ec352", false, "anna@activigo.se" },
                    { "3", 0, "5058a998-9e37-4c2a-94f8-4ab14df269a3", "bjorn@activigo.se", true, false, null, "BJORN@ACTIVIGO.SE", "BJORN@ACTIVIGO.SE", "AQAAAAIAAYagAAAAEJMIw0JusaxBczSfvWp1Iz1YMa/8rIvOPnuSJs8S1muPzHugln55cLMDuMCVZREkrg==", null, false, "01be9d93-9165-47bb-ba1d-d548d0cb31cd", false, "bjorn@activigo.se" },
                    { "4", 0, "11ba6388-80cd-41da-949a-0a53b8558aaa", "carla@activigo.se", true, false, null, "CARLA@ACTIVIGO.SE", "CARLA@ACTIVIGO.SE", "AQAAAAIAAYagAAAAEC2TrZRU0FC1hygth2VQAXdZ+CAw40X5sVPrFHHIuCOdoUEcsLXW7OM1tUyKmhFHtA==", null, false, "58c43aea-ba10-4646-8b5e-e9a0cd6423f0", false, "carla@activigo.se" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "LatLong",
                value: "59.33,18.06");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "LatLong",
                value: "59.32,18.04");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "LatLong",
                value: "59.34,18.05");
        }
    }
}
