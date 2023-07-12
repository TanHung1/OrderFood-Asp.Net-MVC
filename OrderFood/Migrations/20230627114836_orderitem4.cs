using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class orderitem4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<Guid>(
                name: "DishtId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("ecec20d1-7b40-4370-8668-4c9913d7a9df"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "DishtId",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("fac845ca-41c9-4d4b-92e1-a2c494fb699a"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }
    }
}
