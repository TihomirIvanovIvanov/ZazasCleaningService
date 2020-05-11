using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class AddProductOrdersProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "ProductOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ReceiptId",
                table: "ProductOrders",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Receipts_ReceiptId",
                table: "ProductOrders",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Receipts_ReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_ReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "ProductOrders");
        }
    }
}
