using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class SeedUsersAndRoles4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c4b5263-d0d6-4dbb-b845-1a6034a3ccb1", "ADMIN@TEST.PL", "ADMIN", "AQAAAAEAACcQAAAAEAJR1foNsEofDYFD9EaxZ/4STk86SI650eu4/NJBgm/LaLVC0t71rvphPSJX/Xmw8g==", "166adfa7-3a5f-496c-bdc8-6b8bdee94d3f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b819fe9a-2ba8-4f63-9691-042ed389c3f0", "admin@test.pl", "admin", null, "5b7bf5cb-e9e2-4844-ae9e-ee2811787367" });
        }
    }
}
