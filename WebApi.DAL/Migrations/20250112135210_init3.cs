using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "RoleGroups",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Majors",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Faculties",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "USER");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "CREATE_TEACHER", "CREATE_TEACHER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "RoleGroups");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Faculties");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "CREATE_QUIZ");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "Version" },
                values: new object[,]
                {
                    { 2, "DELETE_QUIZ", 0 },
                    { 3, "UPDATE_QUIZ", 0 },
                    { 4, "SELECT_QUIZ", 0 }
                });
        }
    }
}
