using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class SplitOrders2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_IssuerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Receipts_ReceiptId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Services_ServiceId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ReceiptId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "ServiceOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ServiceId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IssuerId",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_IssuerId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "ServiceOrders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IssuerId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_AspNetUsers_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_IssuerId",
                table: "ProductOrders",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_IssuerId",
                table: "ServiceOrders",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Services_ServiceId",
                table: "ServiceOrders",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_AspNetUsers_IssuerId",
                table: "ServiceOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Services_ServiceId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders");

            migrationBuilder.RenameTable(
                name: "ServiceOrders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_ServiceId",
                table: "Order",
                newName: "IX_Order_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_IssuerId",
                table: "Order",
                newName: "IX_Order_IssuerId");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ReceiptId",
                table: "Order",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_IssuerId",
                table: "Order",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Receipts_ReceiptId",
                table: "Order",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_ProductId",
                table: "Order",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Services_ServiceId",
                table: "Order",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
