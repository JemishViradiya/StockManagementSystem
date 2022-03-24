using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    payment_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_type = table.Column<string>(nullable: true),
                    card_number = table.Column<string>(maxLength: 10, nullable: false),
                    card_cvv = table.Column<int>(maxLength: 3, nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    payment_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_payments_payments_payment_id1",
                        column: x => x.payment_id1,
                        principalTable: "payments",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(nullable: false),
                    contact_number = table.Column<int>(maxLength: 10, nullable: false),
                    customer_email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    payment_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customers_payments_payment_id",
                        column: x => x.payment_id,
                        principalTable: "payments",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetName = table.Column<string>(nullable: false),
                    state = table.Column<string>(nullable: false),
                    zipCode = table.Column<string>(maxLength: 6, nullable: false),
                    customerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "fevourites",
                columns: table => new
                {
                    fevourite_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(nullable: false),
                    customer_id1 = table.Column<int>(nullable: true),
                    stock_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fevourites", x => x.fevourite_id);
                    table.ForeignKey(
                        name: "FK_fevourites_customers_customer_id1",
                        column: x => x.customer_id1,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                columns: table => new
                {
                    stock_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stock_name = table.Column<string>(nullable: false),
                    stock_price = table.Column<double>(nullable: false),
                    stock_quantity = table.Column<int>(nullable: false),
                    customer_id = table.Column<int>(nullable: true),
                    fevourite_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stocks", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stocks_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stocks_fevourites_fevourite_id",
                        column: x => x.fevourite_id,
                        principalTable: "fevourites",
                        principalColumn: "fevourite_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalAmount = table.Column<double>(nullable: false),
                    orderDate = table.Column<DateTime>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: false),
                    stock_id = table.Column<int>(nullable: false),
                    stock_id1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_stocks_stock_id1",
                        column: x => x.stock_id1,
                        principalTable: "stocks",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_customerId",
                table: "addresses",
                column: "customerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_payment_id",
                table: "customers",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_fevourites_customer_id1",
                table: "fevourites",
                column: "customer_id1");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerId",
                table: "orders",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_stock_id1",
                table: "orders",
                column: "stock_id1");

            migrationBuilder.CreateIndex(
                name: "IX_payments_payment_id1",
                table: "payments",
                column: "payment_id1");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_customer_id",
                table: "stocks",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_stocks_fevourite_id",
                table: "stocks",
                column: "fevourite_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "stocks");

            migrationBuilder.DropTable(
                name: "fevourites");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "payments");
        }
    }
}
