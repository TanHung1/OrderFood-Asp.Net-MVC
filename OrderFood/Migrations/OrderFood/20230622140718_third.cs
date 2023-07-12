using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFood.Migrations.OrderFood
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1962656-a088-481c-8f57-e2b8dc4e43e9", "86ccbcd0-c840-4b85-b5c3-95562d7eb708", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2de8f282-8583-4fbe-be30-474c2f887956", 0, null, "9e7680e1-c2cb-4e05-bdb5-06377f42fc3d", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKMCwNfMBe5Y7beaLDQL0ujdAgJj+vQ1BI185l5wlt3feylmrQsUShTmWY3zvlr7dw==", "1234567890", false, "bf2d8c85-2c88-44a8-92b2-371244eb6310", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1962656-a088-481c-8f57-e2b8dc4e43e9", "2de8f282-8583-4fbe-be30-474c2f887956" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1962656-a088-481c-8f57-e2b8dc4e43e9", "2de8f282-8583-4fbe-be30-474c2f887956" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1962656-a088-481c-8f57-e2b8dc4e43e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2de8f282-8583-4fbe-be30-474c2f887956");
        }
    }
}
