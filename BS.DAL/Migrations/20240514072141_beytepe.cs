using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class beytepe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_OrderDetail_OrderDetailId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Book_OrderDetailId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BookId",
                table: "OrderDetail",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Book_BookId",
                table: "OrderDetail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Book_BookId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_BookId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookShoppingCart",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookShoppingCart", x => new { x.BooksId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_BookShoppingCart_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookShoppingCart_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_OrderDetailId",
                table: "Book",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_BookShoppingCart_ShoppingCartsId",
                table: "BookShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_OrderDetail_OrderDetailId",
                table: "Book",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
