using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ovning_9.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Count", "Description", "Name", "Orderdate", "Price", "Shelf" },
                values: new object[,]
                {
                    { 1, "Peripherals", 45, "Mechanical RGB keyboard", "Keyboard", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 899, "A1" },
                    { 2, "Displays", 12, "27 inch 4K IPS", "Monitor", new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3499, "B3" },
                    { 3, "Peripherals", 60, "Ergonomic wireless mouse", "Mouse", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 549, "A2" },
                    { 4, "Audio", 25, "Noise cancelling USB headset", "Headset", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1299, "C1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
