using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations
{
    /// <inheritdoc />
    public partial class orderchangeFirstName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Orders",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Orders",
                newName: "FullName");
        }
    }
}
