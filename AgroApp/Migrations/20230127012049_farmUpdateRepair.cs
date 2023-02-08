using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class farmUpdateRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3382c155-0c06-4b58-9be6-85b9e239efe5", "AQAAAAEAACcQAAAAEKAibLrzuzt+T4QcSXkncMyqHDVHLvuyy07RbTtWNZjtlqdh7A3w027uEtIySCwQAw==", "c8b0a1aa-d076-48b1-9a6f-15af3ad87867" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe871871-5375-4766-96a5-fbb400566a28", "AQAAAAEAACcQAAAAEKFnEY2I2v4vKQkMoRTr04kKQePyV9WDwWbafLy2rqx8T7yzj6yqWtukEsprbcu3Bg==", "37adb4b8-b294-424e-84eb-c8bd9ef4888b" });
        }
    }
}
