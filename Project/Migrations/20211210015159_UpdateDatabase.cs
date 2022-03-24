using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_fevourites_fevourite_id",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_fevourite_id",
                table: "stocks");

            migrationBuilder.DropColumn(
                name: "fevourite_id",
                table: "stocks");

            migrationBuilder.AlterColumn<string>(
                name: "contact_number",
                table: "customers",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    portfolio_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(nullable: false),
                    stock_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolios", x => x.portfolio_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolios");

            migrationBuilder.AddColumn<int>(
                name: "fevourite_id",
                table: "stocks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "contact_number",
                table: "customers",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_fevourite_id",
                table: "stocks",
                column: "fevourite_id");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_fevourites_fevourite_id",
                table: "stocks",
                column: "fevourite_id",
                principalTable: "fevourites",
                principalColumn: "fevourite_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
