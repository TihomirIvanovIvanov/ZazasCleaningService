namespace AspNetCoreTemplate.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddServiceReceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceReceiptId",
                table: "ServiceOrders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceReceipts",
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
                    table.PrimaryKey("PK_ServiceReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReceipts_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_ServiceReceiptId",
                table: "ServiceOrders",
                column: "ServiceReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReceipts_RecipientId",
                table: "ServiceReceipts",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_ServiceReceipts_ServiceReceiptId",
                table: "ServiceOrders",
                column: "ServiceReceiptId",
                principalTable: "ServiceReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_ServiceReceipts_ServiceReceiptId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceReceipts");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_ServiceReceiptId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "ServiceReceiptId",
                table: "ServiceOrders");
        }
    }
}
