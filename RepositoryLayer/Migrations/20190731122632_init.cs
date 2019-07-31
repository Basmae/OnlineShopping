using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("a229e6ce-47ab-44bd-867e-18dab78e550d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("cb24c610-ba72-4b15-814c-aa6eb43d9007"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("1a8c8375-b7f4-4b59-9c8b-87ca9dd6b992"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("a915dca0-f0d4-4294-a50c-40f28b9cfb9b"));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7557efb0-a958-4127-9480-8153421aea1f"), "this is the first product", 100.0, "P1", 5.0 },
                    { new Guid("554fe505-09aa-48a0-8b4f-8de8ce28bb1a"), "this is the second product", 200.0, "P2", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("280ac25c-cc55-45ea-b909-96b6c8b2ec0d"), "Basma" },
                    { new Guid("489f39b4-fc4b-4adc-b080-963fdb0cdec9"), "Ola" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("554fe505-09aa-48a0-8b4f-8de8ce28bb1a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: new Guid("7557efb0-a958-4127-9480-8153421aea1f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("280ac25c-cc55-45ea-b909-96b6c8b2ec0d"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: new Guid("489f39b4-fc4b-4adc-b080-963fdb0cdec9"));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "Description", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { new Guid("cb24c610-ba72-4b15-814c-aa6eb43d9007"), "this is the first product", 100.0, "P1", 5.0 },
                    { new Guid("a229e6ce-47ab-44bd-867e-18dab78e550d"), "this is the second product", 200.0, "P2", 10.0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("1a8c8375-b7f4-4b59-9c8b-87ca9dd6b992"), "Basma" },
                    { new Guid("a915dca0-f0d4-4294-a50c-40f28b9cfb9b"), "Ola" }
                });
        }
    }
}
