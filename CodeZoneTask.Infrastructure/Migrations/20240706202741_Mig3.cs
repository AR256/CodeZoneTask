using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeZoneTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpeningHours",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "Description", "ExpirationDate", "Manufacturer", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "Electronics", "15-inch, 16GB RAM, 512GB SSD", null, "TechCorp", "Laptop", 999.99m, "LAP123" },
                    { 2, "Groceries", "1 liter, full cream", new DateTime(2024, 8, 6, 23, 27, 38, 268, DateTimeKind.Local).AddTicks(6443), "DairyBest", "Milk", 1.99m, "MIL456" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "ContactNumber", "Email", "Location", "ManagerName", "Name", "OpeningHours" },
                values: new object[,]
                {
                    { 1, "555-1234", "main@warehouse.com", "123 Main St, Anytown", "John Doe", "Main Warehouse", "9 AM - 5 PM" },
                    { 2, "555-5678", "downtown@store.com", "456 Market St, Big City", "Jane Smith", "Downtown Store", "10 AM - 8 PM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OpeningHours",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Items");
        }
    }
}
