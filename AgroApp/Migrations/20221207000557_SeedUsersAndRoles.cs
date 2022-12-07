using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class SeedUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2424ba03-fe48-427d-8feb-51cedaf5f3b9", "1", "Administrator", "Administrator" },
                    { "43cf4e6b-a87d-43b7-8896-68f6fc9cc64f", "2", "Farmer", "Farmer" },
                    { "f79e0432-f23c-4ec5-b7f2-8662f460659e", "3", "Employee", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FarmId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Position", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b6c29c2-68a5-41b2-99bb-bdffade561fa", 0, "8f2fde14-66ff-478f-8cf7-09ee91e0f1e7", "UserModel", "admin@test.pl", false, null, false, null, "Admin", null, null, null, null, false, "Admin", "06b3d753-99d9-4f44-ac9e-5455e7a30d6e", "Admin", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2424ba03-fe48-427d-8feb-51cedaf5f3b9", "7b6c29c2-68a5-41b2-99bb-bdffade561fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43cf4e6b-a87d-43b7-8896-68f6fc9cc64f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f79e0432-f23c-4ec5-b7f2-8662f460659e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2424ba03-fe48-427d-8feb-51cedaf5f3b9", "7b6c29c2-68a5-41b2-99bb-bdffade561fa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2424ba03-fe48-427d-8feb-51cedaf5f3b9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa");
        }
    }
}
