using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class AddOwnerNameInFarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FarmOwnerName",
                table: "Farms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b5ec77-4b4f-43d4-98b5-fe302b95c205", "AQAAAAEAACcQAAAAEBWJB8y7Dtg5U40R6bIZRvD8Xsr1LF9M2NZVxfubx5WUKOUa7j/eWEym7OlGOexwJA==", "7c265c20-d54e-4f19-b15d-63e093612fda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmOwnerName",
                table: "Farms");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "445de921-9407-4f52-83c9-25d661a7d881", "AQAAAAEAACcQAAAAEKK5n1BYwR+cH7lAZhaUfLj+/cBRszb/sqiHJo/JfJF27CCEUKSpM3FhXAJgdQJmFQ==", "78fb6317-39f6-4ba6-bdab-ce8b0b2a08d6" });
        }
    }
}
