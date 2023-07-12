using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class orderitem5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("ecec20d1-7b40-4370-8668-4c9913d7a9df"));

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "OrderItems");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("8c3dd338-2275-491f-818b-f6cf9d9dd89a"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("8c3dd338-2275-491f-818b-f6cf9d9dd89a"));

            migrationBuilder.AddColumn<Guid>(
                name: "DishId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("ecec20d1-7b40-4370-8668-4c9913d7a9df"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId");
        }
    }
}
