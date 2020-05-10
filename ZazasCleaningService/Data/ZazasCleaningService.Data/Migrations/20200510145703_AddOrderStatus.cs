using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class AddOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ServiceOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ProductOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrders_StatusId",
                table: "ServiceOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_StatusId",
                table: "ProductOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatuses_IsDeleted",
                table: "OrderStatuses",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_OrderStatuses_StatusId",
                table: "ProductOrders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_OrderStatuses_StatusId",
                table: "ServiceOrders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_OrderStatuses_StatusId",
                table: "ProductOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_OrderStatuses_StatusId",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrders_StatusId",
                table: "ServiceOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_StatusId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ServiceOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ProductOrders");
        }
    }
}
