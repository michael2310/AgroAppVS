using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class UpdateRegisterRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "445de921-9407-4f52-83c9-25d661a7d881", "AQAAAAEAACcQAAAAEKK5n1BYwR+cH7lAZhaUfLj+/cBRszb/sqiHJo/JfJF27CCEUKSpM3FhXAJgdQJmFQ==", "78fb6317-39f6-4ba6-bdab-ce8b0b2a08d6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c4b5263-d0d6-4dbb-b845-1a6034a3ccb1", "AQAAAAEAACcQAAAAEAJR1foNsEofDYFD9EaxZ/4STk86SI650eu4/NJBgm/LaLVC0t71rvphPSJX/Xmw8g==", "166adfa7-3a5f-496c-bdc8-6b8bdee94d3f" });
        }
    }
}
