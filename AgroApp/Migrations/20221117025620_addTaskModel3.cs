using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class addTaskModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_FarmId",
                table: "Tasks",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Farms_FarmId",
                table: "Tasks",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "FarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Farms_FarmId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_FarmId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "Tasks");
        }
    }
}
