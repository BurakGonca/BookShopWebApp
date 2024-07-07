using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ordertabletotalpriceinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6eb18a1-8406-4897-8f20-8f4eea5c86d2", "AQAAAAIAAYagAAAAEA9tWlHta0Wyi5Bx6SBtC68T6t1sX7oXKVul1NTawMjhobv7rTaVZ2tHXZwT7hH62Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "baaef123-2673-405d-b168-5d86cec770dd", "AQAAAAIAAYagAAAAEBRdVLXIpRoUa4M7rfHEsJFWSLUza8bzIWzMmr0XFd1snoQ07Z1RVBvoPYhp7c+PnA==" });
        }
    }
}
