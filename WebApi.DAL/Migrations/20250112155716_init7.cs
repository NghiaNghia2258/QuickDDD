using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "DeletedAt", "DeletedBy", "DeletedName", "ExerciseCredits", "IsDeleted", "IsIncludedInGPA", "IsMandatory", "Name", "PracticeCredits", "Semester", "TheoryCredits", "Version" },
                values: new object[,]
                {
                    { 1, "TCC", null, null, null, 0, false, false, false, "Toán cao cấp", 0, 0, 0, 0 },
                    { 2, "VLDC", null, null, null, 0, false, false, false, "Vật lý đại cương", 0, 0, 0, 0 },
                    { 3, "OOP", null, null, null, 0, false, false, false, "Lập trình hướng đối tượng", 0, 0, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
