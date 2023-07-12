using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class orderitem6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("8c3dd338-2275-491f-818b-f6cf9d9dd89a"));

            migrationBuilder.DropColumn(
                name: "DishtId",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("44ac981f-b957-444f-b474-8ab22645183f"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("44ac981f-b957-444f-b474-8ab22645183f"));

            migrationBuilder.AddColumn<Guid>(
                name: "DishtId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("8c3dd338-2275-491f-818b-f6cf9d9dd89a"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }
    }
}
