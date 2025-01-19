using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Name", "Version" },
                values: new object[,]
                {
                    { 2, "RULE_STUDENT", "RULE_STUDENT", 0 },
                    { 3, "RULE_TEACHER", "RULE_TEACHER", 0 }
                });

            migrationBuilder.InsertData(
                table: "RoleRoleGroup",
                columns: new[] { "RoleGroupsId", "RolesId" },
                values: new object[,]
                {
                    { 3, 3 },
                    { 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "RoleRoleGroup",
                columns: new[] { "RoleGroupsId", "RolesId" },
                values: new object[] { 3, 1 });
        }
    }
}
