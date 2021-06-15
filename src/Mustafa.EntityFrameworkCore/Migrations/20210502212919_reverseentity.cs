using Microsoft.EntityFrameworkCore.Migrations;

namespace Mustafa.Migrations
{
    public partial class reverseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCR = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockMoveType",
                columns: table => new
                {
                    Id = table.Column<bool>(type: "bit", nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMoveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unitline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNIT_TYPE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unitline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VKNO = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IMG_PATH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LAST_PRICE = table.Column<float>(type: "float", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    UNITLINE_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Unitline_UNITLINE_ID",
                        column: x => x.UNITLINE_ID,
                        principalTable: "Unitline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockMove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCR = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UNIT_PRICE = table.Column<float>(type: "float", nullable: false),
                    QUANTITY = table.Column<float>(type: "float", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    VENDOR_ID = table.Column<int>(type: "int", nullable: true),
                    WAREHOUSE_ID = table.Column<int>(type: "int", nullable: true),
                    StockMoveTypeId = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMove", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMove_Product_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMove_StockMoveType_StockMoveTypeId",
                        column: x => x.StockMoveTypeId,
                        principalTable: "StockMoveType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMove_Vendor_VENDOR_ID",
                        column: x => x.VENDOR_ID,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StockMove_Warehouse_WAREHOUSE_ID",
                        column: x => x.WAREHOUSE_ID,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CATEGORY_ID",
                table: "Product",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UNITLINE_ID",
                table: "Product",
                column: "UNITLINE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockMove_PRODUCT_ID",
                table: "StockMove",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockMove_StockMoveTypeId",
                table: "StockMove",
                column: "StockMoveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMove_VENDOR_ID",
                table: "StockMove",
                column: "VENDOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_StockMove_WAREHOUSE_ID",
                table: "StockMove",
                column: "WAREHOUSE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockMove");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "StockMoveType");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Unitline");
        }
    }
}
