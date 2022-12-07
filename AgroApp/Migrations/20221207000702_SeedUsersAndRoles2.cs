using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class SeedUsersAndRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "783cb2d9-2078-4847-b644-27f3f73385de", "326dac35-3ace-46ad-aa1d-6b70d2f9510a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f2fde14-66ff-478f-8cf7-09ee91e0f1e7", "06b3d753-99d9-4f44-ac9e-5455e7a30d6e" });
        }
    }
}
