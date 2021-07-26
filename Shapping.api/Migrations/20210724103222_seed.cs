using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shapping.api.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "Phone" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "Azadi", "Tehran", "Farhadi25@gmail.com", "Farhad", "09362322511" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "City", "Email", "Name", "Phone" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Amam", "Amol", "nima11@gmail.com", "Nima", "09306628281" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "DateExpiration", "DateManufacture", "Name", "StoreId" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "2021/1/5", "2020/1/5", "Ice cream", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35") });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "DateExpiration", "DateManufacture", "Name", "StoreId" },
                values: new object[] { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), "2020/12/7", "2020/8/7", "Cake", new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"));
        }
    }
}
