using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("78491c20-b2df-498c-b798-d9ad1ce52b3f"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84dab40-86ed-480d-a7ee-5e8529270447"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MyUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Email", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("91802531-f584-4ef8-b540-4a8aa53b297d"), 87, null, "James", "Esh" },
                    { new Guid("adfca954-c605-4535-a743-a905ad466d0c"), 23, null, "Ali", "Valiev" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("91802531-f584-4ef8-b540-4a8aa53b297d"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("adfca954-c605-4535-a743-a905ad466d0c"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "MyUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Email", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("78491c20-b2df-498c-b798-d9ad1ce52b3f"), 23, null, "Ali", "Valiev" },
                    { new Guid("f84dab40-86ed-480d-a7ee-5e8529270447"), 87, null, "James", "Esh" }
                });
        }
    }
}
