using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SC.v1.Data.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password_salt",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password_salt",
                table: "users",
                type: "character(64)",
                fixedLength: true,
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }
    }
}
