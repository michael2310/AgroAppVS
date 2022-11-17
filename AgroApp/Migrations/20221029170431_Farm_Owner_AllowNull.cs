using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class Farm_Owner_AllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms");

            migrationBuilder.AlterColumn<string>(
                name: "FarmOwnerId",
                table: "Farms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms",
                column: "FarmOwnerId",
                unique: true,
                filter: "[FarmOwnerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms");

            migrationBuilder.AlterColumn<string>(
                name: "FarmOwnerId",
                table: "Farms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms",
                column: "FarmOwnerId",
                unique: true);
        }
    }
}
