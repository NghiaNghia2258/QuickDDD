using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.InsertData(
                table: "RoleGroups",
                columns: new[] { "Id", "Code", "Name", "Version" },
                values: new object[] { 4, "STUDENT", "Student", 0 });

            migrationBuilder.InsertData(
                table: "RoleRoleGroup",
                columns: new[] { "RoleGroupsId", "RolesId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RoleRoleGroup",
                keyColumns: new[] { "RoleGroupsId", "RolesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "RoleRoleGroup",
                columns: new[] { "RoleGroupsId", "RolesId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 4 }
                });
        }
    }
}
