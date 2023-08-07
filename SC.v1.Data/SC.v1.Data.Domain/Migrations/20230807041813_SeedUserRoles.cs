using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SC.v1.Data.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "role_id", "role_name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Cliente" },
                    { 3, "Contador" },
                    { 4, "Proveedor" },
                    { 5, "Gerente" },
                    { 6, "Auditor" },
                    { 7, "Asesor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "role_id",
                keyValue: 7);
        }
    }
}
