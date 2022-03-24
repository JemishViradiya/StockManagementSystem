using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class database2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_payments_payment_id",
                table: "customers");

            migrationBuilder.DropForeignKey(
                name: "FK_payments_payments_payment_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_payment_id1",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_customers_payment_id",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "payment_id1",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "payment_id",
                table: "customers");

            migrationBuilder.AddColumn<int>(
                name: "customer_id1",
                table: "payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderid",
                table: "payments",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "order_id",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "orderid",
                table: "payments");

            migrationBuilder.AddColumn<int>(
                name: "payment_id1",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "payment_id",
                table: "customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_id1",
                table: "payments",
                column: "payment_id1");

            migrationBuilder.CreateIndex(
                name: "IX_customers_payment_id",
                table: "customers",
                column: "payment_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_payments_payment_id",
                table: "customers",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "payment_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_payments_payments_payment_id1",
                table: "payments",
                column: "payment_id1",
                principalTable: "payments",
                principalColumn: "payment_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
