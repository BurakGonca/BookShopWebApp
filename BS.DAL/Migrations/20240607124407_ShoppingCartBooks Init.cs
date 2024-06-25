using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartBooksInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "UserType" },
                values: new object[] { "6c1c4abe-a96a-47ed-b7cb-74ee8de590ec", (byte)3, "AQAAAAIAAYagAAAAEIDG1NeT9dm6cS4zSRfwo/SM+O9Jae1ks86iFPD+3U87O05gYfCm68MxOwlSgLV/1w==", (byte)2 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShoppingCartId",
                table: "Books",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ShoppingCarts_ShoppingCartId",
                table: "Books",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ShoppingCarts_ShoppingCartId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShoppingCartId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Gender", "PasswordHash", "UserType" },
                values: new object[] { "0e532529-b29e-4771-8134-58ea1a40d06a", (byte)2, "AQAAAAIAAYagAAAAENyVOQcRw/iSpTlguvX09VgL3kYRg7qL8yrSCEO6si2bG4O4ci9tD+pAVhFPKy8YTg==", (byte)0 });
        }
    }
}
