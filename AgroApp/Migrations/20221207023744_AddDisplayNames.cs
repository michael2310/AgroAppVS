using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class AddDisplayNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0f68aa-b9f8-48a0-b795-767274066a44", "AQAAAAEAACcQAAAAEGrFhvMQ2Xqs+2Q40u2WTjuOdBGNpsZnu3nrXYIF0SWBp1BfAaakGKOoUNqdX3tMIg==", "0d1f9224-8e39-43c8-992e-41646e6dff15" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b5ec77-4b4f-43d4-98b5-fe302b95c205", "AQAAAAEAACcQAAAAEBWJB8y7Dtg5U40R6bIZRvD8Xsr1LF9M2NZVxfubx5WUKOUa7j/eWEym7OlGOexwJA==", "7c265c20-d54e-4f19-b15d-63e093612fda" });
        }
    }
}
