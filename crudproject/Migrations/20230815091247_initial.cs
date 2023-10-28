using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudproject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Productid);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Storeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Storename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Storeid);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Salesid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productid = table.Column<int>(type: "int", nullable: true),
                    Custid = table.Column<int>(type: "int", nullable: true),
                    Storeid = table.Column<int>(type: "int", nullable: true),
                    Datesold = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Salesid);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_Custid",
                        column: x => x.Custid,
                        principalTable: "Customers",
                        principalColumn: "CustId");
                    table.ForeignKey(
                        name: "FK_Sales_Products_Productid",
                        column: x => x.Productid,
                        principalTable: "Products",
                        principalColumn: "Productid");
                    table.ForeignKey(
                        name: "FK_Sales_Stores_Storeid",
                        column: x => x.Storeid,
                        principalTable: "Stores",
                        principalColumn: "Storeid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Custid",
                table: "Sales",
                column: "Custid");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Productid",
                table: "Sales",
                column: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_Storeid",
                table: "Sales",
                column: "Storeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
