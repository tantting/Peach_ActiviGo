using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Peach_ActiviGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRemainingCapacityforactivitySlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfParticipants",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RemainingCapacity",
                table: "ActivitySlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ActivitySlots",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 1,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 2,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 3,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 4,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 5,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 6,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 7,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 8,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 9,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 10,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 11,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 12,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 13,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 14,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 15,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 16,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 17,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 18,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 19,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 20,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 21,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 22,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 23,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 24,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 25,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 26,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 27,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 28,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 29,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 30,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 31,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 32,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 33,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 34,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 35,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 36,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 37,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 38,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 39,
                column: "RemainingCapacity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ActivitySlots",
                keyColumn: "Id",
                keyValue: 40,
                column: "RemainingCapacity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfParticipants",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RemainingCapacity",
                table: "ActivitySlots");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ActivitySlots");
        }
    }
}
