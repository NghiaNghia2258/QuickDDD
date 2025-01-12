using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserLoginId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserLoginId",
                table: "Teachers",
                column: "UserLoginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_UserLogins_UserLoginId",
                table: "Teachers",
                column: "UserLoginId",
                principalTable: "UserLogins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_UserLogins_UserLoginId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserLoginId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserLoginId",
                table: "Teachers");
        }
    }
}
