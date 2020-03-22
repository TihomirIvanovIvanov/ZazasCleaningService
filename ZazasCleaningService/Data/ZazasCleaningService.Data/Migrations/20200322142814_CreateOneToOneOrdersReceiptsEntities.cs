using Microsoft.EntityFrameworkCore.Migrations;

namespace ZazasCleaningService.Data.Migrations
{
    public partial class CreateOneToOneOrdersReceiptsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Receipts_ReceiptId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ReceiptId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Receipts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_OrderId",
                table: "Receipts",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Orders_OrderId",
                table: "Receipts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Orders_OrderId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_OrderId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Receipts");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReceiptId",
                table: "Orders",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Receipts_ReceiptId",
                table: "Orders",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
