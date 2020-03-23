using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZazasCleaningService.Data.Migrations
{
    public partial class InheritBaseDeletableModelForTheEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Rooms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Receipts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Receipts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Receipts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Receipts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ProductTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ProductTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Kids",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Kids",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kids",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Kids",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Homes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Homes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Homes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Homes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IsDeleted",
                table: "Rooms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_IsDeleted",
                table: "Receipts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_IsDeleted",
                table: "ProductTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsDeleted",
                table: "Products",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Kids_IsDeleted",
                table: "Kids",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_IsDeleted",
                table: "Homes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_IsDeleted",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_IsDeleted",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_IsDeleted",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_IsDeleted",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IsDeleted",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Kids_IsDeleted",
                table: "Kids");

            migrationBuilder.DropIndex(
                name: "IX_Homes_IsDeleted",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Homes");
        }
    }
}
