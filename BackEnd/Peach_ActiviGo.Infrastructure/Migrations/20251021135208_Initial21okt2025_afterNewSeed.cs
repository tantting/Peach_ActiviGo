using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial21okt2025_afterNewSeed : Migration
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
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
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
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    SlotCapacity = table.Column<int>(type: "int", nullable: false),
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
                    ActivitySlotId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CancelledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 10, 21), "Spännande utomhusaktiviteter", "Äventyr", null },
                    { 2, new DateOnly(2025, 10, 21), "Aktiviteter vid havet och sjöar", "Vatten", null },
                    { 3, new DateOnly(2025, 10, 21), "Inomhus- och utomhusträning", "Träning", null },
                    { 4, new DateOnly(2025, 10, 21), "Lugna aktiviteter för kropp och själ", "Avkoppling", null }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "CreatedDate", "Latitude", "Longitude", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Varberg centrum", new DateOnly(2025, 10, 21), 57.1056m, 12.2508m, "Varberg", null },
                    { 2, "Falkenberg centrum", new DateOnly(2025, 10, 21), 56.9055m, 12.4912m, "Falkenberg", null },
                    { 3, "Halmstad centrum", new DateOnly(2025, 10, 21), 56.6745m, 12.8570m, "Halmstad", null },
                    { 4, "Veddige centrum", new DateOnly(2025, 10, 21), 57.2297m, 12.3836m, "Veddige", null },
                    { 5, "Slöinge centrum", new DateOnly(2025, 10, 21), 56.8358m, 12.7135m, "Slöinge", null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 2, new DateOnly(2025, 10, 21), "Lär dig surfa i havet", "images/surf.jpg", "Surfkurs", 899m, null },
                    { 2, 4, new DateOnly(2025, 10, 21), "Avkopplande yoga inomhus", "images/yoga.jpg", "Yogapass", 299m, null },
                    { 3, 1, new DateOnly(2025, 10, 21), "Klattra på olika nivåer", "images/climb.jpg", "Klattring", 499m, null },
                    { 4, 3, new DateOnly(2025, 10, 21), "Cykla i skog och mark", "images/mtb.jpg", "Mountainbike", 699m, null },
                    { 5, 2, new DateOnly(2025, 10, 21), "Paddla i lugnt vatten", "images/sup.jpg", "Stand Up Paddle", 599m, null },
                    { 6, 3, new DateOnly(2025, 10, 21), "Intensiv cykelträning inomhus", "images/spinning.jpg", "Spinning", 249m, null },
                    { 7, 4, new DateOnly(2025, 10, 21), "Bastuupplevelse med dofter", "images/sauna.jpg", "Saunagus", 350m, null },
                    { 8, 1, new DateOnly(2025, 10, 21), "Actionfyllt lagspel utomhus", "images/paintball.jpg", "Paintball", 550m, null }
                });

            migrationBuilder.InsertData(
                table: "ActivityLocations",
                columns: new[] { "Id", "ActivityId", "Capacity", "CreatedDate", "IsIndoor", "LocationId", "UpdatedDate", "isActive" },
                values: new object[,]
                {
                    { 1, 1, 15, new DateOnly(2025, 10, 21), false, 1, null, true },
                    { 2, 1, 12, new DateOnly(2025, 10, 21), false, 2, null, true },
                    { 3, 2, 10, new DateOnly(2025, 10, 21), true, 3, null, true },
                    { 4, 2, 8, new DateOnly(2025, 10, 21), true, 4, null, true },
                    { 5, 3, 18, new DateOnly(2025, 10, 21), false, 5, null, true },
                    { 6, 4, 14, new DateOnly(2025, 10, 21), false, 1, null, true },
                    { 7, 5, 16, new DateOnly(2025, 10, 21), false, 2, null, true },
                    { 8, 6, 12, new DateOnly(2025, 10, 21), true, 3, null, true },
                    { 9, 7, 10, new DateOnly(2025, 10, 21), true, 4, null, true },
                    { 10, 8, 20, new DateOnly(2025, 10, 21), false, 5, null, true }
                });

            migrationBuilder.InsertData(
                table: "ActivitySlots",
                columns: new[] { "Id", "ActivityLocationId", "CreatedDate", "EndTime", "IsCancelled", "SlotCapacity", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 10, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 10, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 2, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 3, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 10, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 3, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 27, 14, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 4, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 4, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2025, 10, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 5, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 18, new DateTime(2025, 10, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 5, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 18, new DateTime(2025, 10, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, 6, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, 6, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 14, new DateTime(2025, 10, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, 7, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 16, new DateTime(2025, 10, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, 7, new DateOnly(2025, 10, 21), new DateTime(2025, 10, 31, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 16, new DateTime(2025, 10, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, 8, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, 8, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 12, new DateTime(2025, 11, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, 9, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 11, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, 9, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 10, new DateTime(2025, 11, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, 10, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 20, new DateTime(2025, 11, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, 10, new DateOnly(2025, 10, 21), new DateTime(2025, 11, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 20, new DateTime(2025, 11, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), null }
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
