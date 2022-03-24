using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class updatedatabe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "portfolios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_stock_id",
                table: "portfolios",
                column: "stock_id");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolios_stocks_stock_id",
                table: "portfolios",
                column: "stock_id",
                principalTable: "stocks",
                principalColumn: "stock_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_stocks_stock_id",
                table: "portfolios");

            migrationBuilder.DropIndex(
                name: "IX_portfolios_stock_id",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "portfolios");
        }
    }
}
