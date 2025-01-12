using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Code", "DeletedAt", "DeletedBy", "DeletedName", "IsDeleted", "Name", "Version" },
                values: new object[,]
                {
                    { 1, "CS", null, null, null, false, "Công nghệ thông tin", 0 },
                    { 2, "EE", null, null, null, false, "Kỹ thuật điện", 0 },
                    { 3, "ME", null, null, null, false, "Cơ khí", 0 },
                    { 4, "CE", null, null, null, false, "Xây dựng", 0 },
                    { 5, "AE", null, null, null, false, "Kỹ thuật môi trường", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
