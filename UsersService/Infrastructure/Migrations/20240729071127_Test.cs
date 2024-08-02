using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("1c3fecb1-7384-4c56-8303-e4ffdd43bbfb"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("4f1eb751-a16c-4483-8a61-672f51ead20d"));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("4af909e8-41bc-4e79-8592-164bee1c054b"), 23, "Ali", "Valiev" },
                    { new Guid("bbb1c51f-5db5-48cc-b8fb-be6b847ecce9"), 87, "James", "Esh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("4af909e8-41bc-4e79-8592-164bee1c054b"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbb1c51f-5db5-48cc-b8fb-be6b847ecce9"));

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("1c3fecb1-7384-4c56-8303-e4ffdd43bbfb"), 23, "Ali", "Valiev" },
                    { new Guid("4f1eb751-a16c-4483-8a61-672f51ead20d"), 87, "James", "Esh" }
                });
        }
    }
}
