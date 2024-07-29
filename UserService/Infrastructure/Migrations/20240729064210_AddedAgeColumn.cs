using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAgeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("512c8fd0-3693-41cf-bdcd-e7b0d1e66123"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("f602d3d8-4412-48dc-88f4-ee18cf51990a"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "MyUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("a37d0ad9-63ce-481c-a141-c93bc1099045"), 87, "James", "Esh" },
                    { new Guid("eac40fd2-151d-473a-80fc-a0807fa5941b"), 23, "Ali", "Valiev" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("a37d0ad9-63ce-481c-a141-c93bc1099045"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("eac40fd2-151d-473a-80fc-a0807fa5941b"));

            migrationBuilder.DropColumn(
                name: "Age",
                table: "MyUsers");

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("512c8fd0-3693-41cf-bdcd-e7b0d1e66123"), "Ali", "Valiev" },
                    { new Guid("f602d3d8-4412-48dc-88f4-ee18cf51990a"), "James", "Esh" }
                });
        }
    }
}
