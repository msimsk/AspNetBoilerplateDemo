using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mustafa.Migrations
{
    public partial class fullaudetadding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Warehouse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Warehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Warehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Warehouse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Warehouse",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Warehouse",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Vendor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Vendor",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Vendor",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Vendor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Vendor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Vendor",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Unitline",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Unitline",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Unitline",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Unitline",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Unitline",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Unitline",
                type: "bigint",
                nullable: true);

            

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "StockMove",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "StockMove",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "StockMove",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "StockMove",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "StockMove",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "StockMove",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Product",
                type: "bigint",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Warehouse");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Vendor");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Unitline");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "StockMove");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Product");

            
        }
    }
}
