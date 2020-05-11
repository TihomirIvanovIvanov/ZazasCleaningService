using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class AddProductReceipts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Receipts_ReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_ReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "ProductOrders");

            migrationBuilder.AddColumn<int>(
                name: "ProductReceiptId",
                table: "ProductOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IssuedOnPicture = table.Column<string>(nullable: true),
                    RecipientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReceipts_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductReceiptId",
                table: "ProductOrders",
                column: "ProductReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReceipts_RecipientId",
                table: "ProductReceipts",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_ProductReceipts_ProductReceiptId",
                table: "ProductOrders",
                column: "ProductReceiptId",
                principalTable: "ProductReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_ProductReceipts_ProductReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropTable(
                name: "ProductReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_ProductReceiptId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "ProductReceiptId",
                table: "ProductOrders");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "ProductOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IssuedOnPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ReceiptId",
                table: "ProductOrders",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_IsDeleted",
                table: "Receipts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_RecipientId",
                table: "Receipts",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Receipts_ReceiptId",
                table: "ProductOrders",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
