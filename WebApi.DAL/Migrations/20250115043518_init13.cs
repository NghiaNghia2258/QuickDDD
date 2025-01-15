using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "Id", "Code", "DeletedAt", "DeletedBy", "DeletedName", "FacultyId", "IsDeleted", "Name", "Version" },
                values: new object[,]
                {
                    { 1, "101", null, null, null, 1, false, "Khoa học máy tính", 0 },
                    { 2, "125", null, null, null, 1, false, "Kỹ thuật phần mềm", 0 },
                    { 3, "210", null, null, null, 2, false, "Hệ thông điện", 0 },
                    { 4, "225", null, null, null, 2, false, "Điện công nghiệp và dân dụng", 0 },
                    { 5, "315", null, null, null, 3, false, "Sức bền vật liệu", 0 },
                    { 6, "323", null, null, null, 3, false, "Khí động học", 0 },
                    { 7, "411", null, null, null, 4, false, "Kỹ thuật xây dựng", 0 },
                    { 8, "431", null, null, null, 4, false, "Kỹ thuật vật liệu", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Majors",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
