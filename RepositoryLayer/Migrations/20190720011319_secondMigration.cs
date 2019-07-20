using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("a5aad81d-4c5f-4b47-82cd-7e573bc486a9"), "this is the first product", 100.0, "P1", 5.0 },
                    { new Guid("681a08da-9489-46e3-b629-5fa7f027b86d"), "this is the second product", 200.0, "P2", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("1856298f-bce6-4477-9e67-c05a834a9d44"), "Basma" },
                    { new Guid("9f28cc0a-85d7-4ee3-ba7c-d6aeb5c3e2e1"), "Ola" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("681a08da-9489-46e3-b629-5fa7f027b86d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("a5aad81d-4c5f-4b47-82cd-7e573bc486a9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("1856298f-bce6-4477-9e67-c05a834a9d44"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("9f28cc0a-85d7-4ee3-ba7c-d6aeb5c3e2e1"));
        }
    }
}
