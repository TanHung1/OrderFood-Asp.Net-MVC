using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class itemorder3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("a9218b2e-4bca-4591-ab17-8b75a011a40f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DishId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("18508d55-387d-40db-a3df-778cf68735ad"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: new Guid("18508d55-387d-40db-a3df-778cf68735ad"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DishId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "CategoryId", "Description", "Image", "NameDish", "Price" },
                values: new object[] { new Guid("a9218b2e-4bca-4591-ab17-8b75a011a40f"), 1, "ngon", "rrr", "Pizza Bò Beefsteak Phô Mai Kiểu New York - New York CheeseSteak", 199000m });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Dishes_DishId",
                table: "OrderItems",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
