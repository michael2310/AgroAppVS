using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class SeedUsersAndRoles3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "b819fe9a-2ba8-4f63-9691-042ed389c3f0", "admin@test.pl", "admin", "5b7bf5cb-e9e2-4844-ae9e-ee2811787367" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "SecurityStamp" },
                values: new object[] { "783cb2d9-2078-4847-b644-27f3f73385de", null, null, "326dac35-3ace-46ad-aa1d-6b70d2f9510a" });
        }
    }
}
