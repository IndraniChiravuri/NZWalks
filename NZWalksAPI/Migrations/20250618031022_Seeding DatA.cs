using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5162e552-93a2-4e35-a264-c9d1987a08f1"), "Medium" },
                    { new Guid("a22691a3-3b18-4ce0-9381-2f782cde9cce"), "Easy" },
                    { new Guid("f9f564ef-ea12-4dcd-8dc4-34a9afb74119"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("2c3ebf81-c52c-472b-b77e-902b3ea59c82"), "WGN", "Wellington.jpg", "Wellington" },
                    { new Guid("44e543d5-ac41-4714-9ae9-16a23dd1b79b"), "STL", "STL.png", "Southland" },
                    { new Guid("5c6d4f7b-0377-4575-82c9-8ed97507ead4"), "BOP", null, "Bay of Plenty" },
                    { new Guid("d022a2e6-a5d3-4908-aeb5-93e8b03469bf"), "NL", null, "Nelson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5162e552-93a2-4e35-a264-c9d1987a08f1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a22691a3-3b18-4ce0-9381-2f782cde9cce"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f9f564ef-ea12-4dcd-8dc4-34a9afb74119"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2c3ebf81-c52c-472b-b77e-902b3ea59c82"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("44e543d5-ac41-4714-9ae9-16a23dd1b79b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5c6d4f7b-0377-4575-82c9-8ed97507ead4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d022a2e6-a5d3-4908-aeb5-93e8b03469bf"));
        }
    }
}
