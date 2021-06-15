using Microsoft.EntityFrameworkCore.Migrations;

namespace Mustafa.Migrations
{
    public partial class updatecharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CATEGORY_ID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unitline_UNITLINE_ID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Product_PRODUCT_ID",
                table: "StockMove");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Vendor_VENDOR_ID",
                table: "StockMove");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Warehouse_WAREHOUSE_ID",
                table: "StockMove");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Warehouse",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "Warehouse",
                newName: "Descr");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Vendor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "Vendor",
                newName: "Descr");

            migrationBuilder.RenameColumn(
                name: "VKNO",
                table: "Vendor",
                newName: "TaxNo");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "Unitline",
                newName: "Descr");

            migrationBuilder.RenameColumn(
                name: "UNIT_TYPE",
                table: "Unitline",
                newName: "UnitType");

            migrationBuilder.RenameColumn(
                name: "UNITPRICE",
                table: "StockMove",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "StockMove",
                newName: "Descr");

            migrationBuilder.RenameColumn(
                name: "WAREHOUSE_ID",
                table: "StockMove",
                newName: "WarehouseId");

            migrationBuilder.RenameColumn(
                name: "VENDOR_ID",
                table: "StockMove",
                newName: "VendorId");

            migrationBuilder.RenameColumn(
                name: "QUANNTITY",
                table: "StockMove",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "PRODUCT_ID",
                table: "StockMove",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_WAREHOUSE_ID",
                table: "StockMove",
                newName: "IX_StockMove_WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_VENDOR_ID",
                table: "StockMove",
                newName: "IX_StockMove_VendorId");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_PRODUCT_ID",
                table: "StockMove",
                newName: "IX_StockMove_ProductId");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Product",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LASTPRICE",
                table: "Product",
                newName: "LastPrice");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "Product",
                newName: "Descr");

            migrationBuilder.RenameColumn(
                name: "UNITLINE_ID",
                table: "Product",
                newName: "UnitlineId");

            migrationBuilder.RenameColumn(
                name: "IMG_PATH",
                table: "Product",
                newName: "ImgPath");

            migrationBuilder.RenameColumn(
                name: "CATEGORY_ID",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UNITLINE_ID",
                table: "Product",
                newName: "IX_Product_UnitlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CATEGORY_ID",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DESCR",
                table: "Category",
                newName: "Descr");

            migrationBuilder.AlterColumn<string>(
                name: "Descr",
                table: "StockMove",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unitline_UnitlineId",
                table: "Product",
                column: "UnitlineId",
                principalTable: "Unitline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Product_ProductId",
                table: "StockMove",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Vendor_VendorId",
                table: "StockMove",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Warehouse_WarehouseId",
                table: "StockMove",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Unitline_UnitlineId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Product_ProductId",
                table: "StockMove");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Vendor_VendorId",
                table: "StockMove");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMove_Warehouse_WarehouseId",
                table: "StockMove");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Warehouse",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Warehouse",
                newName: "DESCR");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Vendor",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Vendor",
                newName: "DESCR");

            migrationBuilder.RenameColumn(
                name: "TaxNo",
                table: "Vendor",
                newName: "VKNO");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Unitline",
                newName: "DESCR");

            migrationBuilder.RenameColumn(
                name: "UnitType",
                table: "Unitline",
                newName: "UNIT_TYPE");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "StockMove",
                newName: "UNITPRICE");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "StockMove",
                newName: "DESCR");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "StockMove",
                newName: "WAREHOUSE_ID");

            migrationBuilder.RenameColumn(
                name: "VendorId",
                table: "StockMove",
                newName: "VENDOR_ID");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StockMove",
                newName: "QUANNTITY");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StockMove",
                newName: "PRODUCT_ID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_WarehouseId",
                table: "StockMove",
                newName: "IX_StockMove_WAREHOUSE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_VendorId",
                table: "StockMove",
                newName: "IX_StockMove_VENDOR_ID");

            migrationBuilder.RenameIndex(
                name: "IX_StockMove_ProductId",
                table: "StockMove",
                newName: "IX_StockMove_PRODUCT_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Product",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "LastPrice",
                table: "Product",
                newName: "LASTPRICE");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Product",
                newName: "DESCR");

            migrationBuilder.RenameColumn(
                name: "UnitlineId",
                table: "Product",
                newName: "UNITLINE_ID");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "Product",
                newName: "IMG_PATH");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CATEGORY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_UnitlineId",
                table: "Product",
                newName: "IX_Product_UNITLINE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_CATEGORY_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Descr",
                table: "Category",
                newName: "DESCR");

            migrationBuilder.AlterColumn<string>(
                name: "DESCR",
                table: "StockMove",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove",
                column: "DESCR");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CATEGORY_ID",
                table: "Product",
                column: "CATEGORY_ID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unitline_UNITLINE_ID",
                table: "Product",
                column: "UNITLINE_ID",
                principalTable: "Unitline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Product_PRODUCT_ID",
                table: "StockMove",
                column: "PRODUCT_ID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Vendor_VENDOR_ID",
                table: "StockMove",
                column: "VENDOR_ID",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMove_Warehouse_WAREHOUSE_ID",
                table: "StockMove",
                column: "WAREHOUSE_ID",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
