using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateUserLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedName",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UpdatedName",
                table: "UserLogins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserLogins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedName",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserLogins",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedName",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
