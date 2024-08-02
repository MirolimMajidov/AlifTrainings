using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmailAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("4af909e8-41bc-4e79-8592-164bee1c054b"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbb1c51f-5db5-48cc-b8fb-be6b847ecce9"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MyUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "MyUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "MyUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Email", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("78491c20-b2df-498c-b798-d9ad1ce52b3f"), 23, null, "Ali", "Valiev" },
                    { new Guid("f84dab40-86ed-480d-a7ee-5e8529270447"), 87, null, "James", "Esh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("78491c20-b2df-498c-b798-d9ad1ce52b3f"));

            migrationBuilder.DeleteData(
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: new Guid("f84dab40-86ed-480d-a7ee-5e8529270447"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "MyUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MyUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "MyUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "MyUsers",
                columns: new[] { "Id", "Age", "Name", "LastName" },
                values: new object[,]
                {
                    { new Guid("4af909e8-41bc-4e79-8592-164bee1c054b"), 23, "Ali", "Valiev" },
                    { new Guid("bbb1c51f-5db5-48cc-b8fb-be6b847ecce9"), 87, "James", "Esh" }
                });
        }
    }
}
