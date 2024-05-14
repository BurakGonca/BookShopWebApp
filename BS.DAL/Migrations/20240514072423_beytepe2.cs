using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class beytepe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderDetailId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderDetailId",
                table: "Order",
                column: "OrderDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderDetail_OrderDetailId",
                table: "Order",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
