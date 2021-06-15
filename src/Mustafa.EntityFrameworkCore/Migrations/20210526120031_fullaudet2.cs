using Microsoft.EntityFrameworkCore.Migrations;

namespace Mustafa.Migrations
{
    public partial class fullaudet2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "StockMove",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StockMove",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMove",
                table: "StockMove",
                column: "Id");
        }
    }
}
