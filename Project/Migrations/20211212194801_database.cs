using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "portfolio_size",
                table: "portfolios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "portfolio_size",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "status",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
