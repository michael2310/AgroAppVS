using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e526b4e-9249-425f-a279-a76d7a0cc1ea", "AQAAAAEAACcQAAAAEBHDti5nvfx2Ky0VhpkXjywRqI2KtF6ZaELI1/gepEgRLb7N3M0a3aLhaEOp8Crmuw==", "c10b373a-0bef-4b6d-834c-25fdf510ee39" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294d8ba7-f2ee-4d63-8c5f-258aa4a4732c", "AQAAAAEAACcQAAAAELk+2CsmR24yIDmGNIFB8aKwx2dXhVSCnqjypzfKEyGirnmpmrqsmCFa2MbNBZwjbg==", "6ee1ec90-3271-400e-ac85-87629a51ce9b" });
        }
    }
}
