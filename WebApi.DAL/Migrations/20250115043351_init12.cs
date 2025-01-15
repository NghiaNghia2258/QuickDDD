using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculties",
                keyColumn: "Id",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "Code", "DeletedAt", "DeletedBy", "DeletedName", "IsDeleted", "Name", "Version" },
                values: new object[] { 5, "AE", null, null, null, false, "Kỹ thuật môi trường", 0 });
        }
    }
}
