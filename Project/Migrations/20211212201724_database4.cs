using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class database4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_customers_customer_id1",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_orders_orderid",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_customer_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_orderid",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "customer_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "orderid",
                table: "payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customer_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderid",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_customer_id1",
                table: "payments",
                column: "customer_id1");

            migrationBuilder.CreateIndex(
                name: "IX_payments_orderid",
                table: "payments",
                column: "orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_customers_customer_id1",
                table: "payments",
                column: "customer_id1",
                principalTable: "customers",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_orders_orderid",
                table: "payments",
                column: "orderid",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
