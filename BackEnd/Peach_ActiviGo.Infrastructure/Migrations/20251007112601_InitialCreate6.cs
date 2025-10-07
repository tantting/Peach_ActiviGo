using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsIndoor = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLocations_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySlots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityLocationId = table.Column<int>(type: "int", nullable: false),
                    IsCanselled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySlots_ActivityLocations_ActivityLocationId",
                        column: x => x.ActivityLocationId,
                        principalTable: "ActivityLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivitySlotId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_ActivitySlots_ActivitySlotId",
                        column: x => x.ActivitySlotId,
                        principalTable: "ActivitySlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 10, 7), null, "Träning", null },
                    { 2, new DateOnly(2025, 10, 7), null, "Spel", null },
                    { 3, new DateOnly(2025, 10, 7), null, "Kondition", null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "CreatedDate", "LatLong", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Huvudgatan 1", new DateOnly(2025, 10, 7), "59.33,18.06", "Sportcenter X", null },
                    { 2, "Parkvägen 5", new DateOnly(2025, 10, 7), "59.32,18.04", "Utomhusarenan", null },
                    { 3, "Centrumtorget 2", new DateOnly(2025, 10, 7), "59.34,18.05", "City Gym", null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateOnly(2025, 10, 7), "Racketsport i par", "/img/padel.jpg", "Padel", 120m, null },
                    { 2, 2, new DateOnly(2025, 10, 7), "Inomhus pingis", "/img/pingis.jpg", "Pingis", 80m, null },
                    { 3, 1, new DateOnly(2025, 10, 7), "Inomhusklättring", "/img/climb.jpg", "Klättring", 150m, null },
                    { 4, 1, new DateOnly(2025, 10, 7), "Träning i utegym", "/img/utegym.jpg", "Utegym", 0m, null },
                    { 5, 1, new DateOnly(2025, 10, 7), "Lugn och fokuserad träning", "/img/yoga.jpg", "Yoga", 100m, null },
                    { 6, 3, new DateOnly(2025, 10, 7), "Högintensiv utomhusträning", "/img/bootcamp.jpg", "Bootcamp", 120m, null },
                    { 7, 3, new DateOnly(2025, 10, 7), "Gruppträning löpning", "/img/run.jpg", "Löpning", 60m, null },
                    { 8, 1, new DateOnly(2025, 10, 7), "Kondition och styrka", "/img/crossfit.jpg", "Crossfit", 140m, null }
                });

            migrationBuilder.InsertData(
                table: "ActivityLocations",
                columns: new[] { "Id", "ActivityId", "Capacity", "CreatedDate", "IsIndoor", "LocationId", "UpdatedDate", "isActive" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateOnly(2025, 10, 7), true, 1, null, true },
                    { 2, 1, 4, new DateOnly(2025, 10, 7), false, 2, null, true },
                    { 3, 2, 2, new DateOnly(2025, 10, 7), true, 1, null, true },
                    { 4, 3, 8, new DateOnly(2025, 10, 7), true, 1, null, true },
                    { 5, 4, 10, new DateOnly(2025, 10, 7), false, 2, null, true },
                    { 6, 5, 12, new DateOnly(2025, 10, 7), true, 3, null, true },
                    { 7, 6, 15, new DateOnly(2025, 10, 7), false, 2, null, true },
                    { 8, 7, 20, new DateOnly(2025, 10, 7), false, 2, null, true }
                });

            migrationBuilder.InsertData(
                table: "ActivitySlots",
                columns: new[] { "Id", "ActivityLocationId", "CreatedDate", "EndTime", "IsCanselled", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 9, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 9, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 2, 1, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 12, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 12, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 3, 1, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 4, 2, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 10, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 10, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 5, 2, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 13, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 6, 2, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 7, 3, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 11, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 11, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 8, 3, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 14, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 9, 3, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 10, 4, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 12, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 12, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 11, 4, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 12, 4, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 13, 5, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 13, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 13, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 14, 5, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 15, 5, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 16, 6, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 14, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 14, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 17, 6, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 17, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 17, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 18, 6, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 20, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 20, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 19, 7, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 15, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 15, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 20, 7, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 18, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 18, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 21, 7, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 21, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 21, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 22, 8, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 16, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 16, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 23, 8, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 19, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 19, 17, 0, 0, 0, DateTimeKind.Local), null },
                    { 24, 8, new DateOnly(2025, 10, 7), new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Local), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLocations_ActivityId_LocationId_IsIndoor",
                table: "ActivityLocations",
                columns: new[] { "ActivityId", "LocationId", "IsIndoor" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLocations_LocationId",
                table: "ActivityLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySlots_ActivityLocationId",
                table: "ActivitySlots",
                column: "ActivityLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ActivitySlotId",
                table: "Bookings",
                column: "ActivitySlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId1",
                table: "Bookings",
                column: "CustomerId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ActivitySlots");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ActivityLocations");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
