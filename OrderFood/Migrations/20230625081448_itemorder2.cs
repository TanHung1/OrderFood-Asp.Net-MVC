using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class itemorder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("0ce65eb9-d3f5-498f-be9b-04ce050d3c85"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("a9218b2e-4bca-4591-ab17-8b75a011a40f"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("a9218b2e-4bca-4591-ab17-8b75a011a40f"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("0ce65eb9-d3f5-498f-be9b-04ce050d3c85"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }
    }
}
