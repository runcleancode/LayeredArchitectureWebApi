using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "555c8960-2726-425d-aba7-56abd0126d88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "581d7982-2d45-4baf-a263-8114d6d5ef2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df37aa81-116a-4ed5-9883-bc69d5e57eed");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6aea67cf-1807-4567-a1af-1b05f5c6e9ef", "6f53bd1b-9a32-461b-a8c6-9418452cdcb5", "Editor", "EDITOR" },
                    { "a2071458-f4e0-41eb-9583-4c1307bfc510", "6d24b947-bab0-4232-927e-4322c4e487c0", "User", "USER" },
                    { "ecbaff20-cdf9-429f-8724-e660df195d30", "a9c26462-0545-453d-8849-52b6890c5c1c", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6aea67cf-1807-4567-a1af-1b05f5c6e9ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2071458-f4e0-41eb-9583-4c1307bfc510");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecbaff20-cdf9-429f-8724-e660df195d30");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "555c8960-2726-425d-aba7-56abd0126d88", "1759d653-6af7-4a3a-808f-83af6c171118", "User", "USER" },
                    { "581d7982-2d45-4baf-a263-8114d6d5ef2f", "2635a720-bf26-4a17-ab55-8e2cb56aa85c", "Editor", "EDITOR" },
                    { "df37aa81-116a-4ed5-9883-bc69d5e57eed", "00671d02-f767-4387-9513-0fd11ec583dd", "Admin", "ADMIN" }
                });
        }
    }
}
