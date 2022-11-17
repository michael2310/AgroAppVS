using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class Add_Relation_Farm_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Fields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FarmId",
                table: "Fields",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Farms_FarmId",
                table: "Fields",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Farms_FarmId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_FarmId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Fields");
        }
    }
}
