using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class update_FK_USER_FarmModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_AspNetUsers_Id",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_Id",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Farms",
                newName: "FarmOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms",
                column: "FarmOwnerId",
                unique: true,
                filter: "[FarmOwnerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_AspNetUsers_FarmOwnerId",
                table: "Farms",
                column: "FarmOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farms_AspNetUsers_FarmOwnerId",
                table: "Farms");

            migrationBuilder.DropIndex(
                name: "IX_Farms_FarmOwnerId",
                table: "Farms");

            migrationBuilder.RenameColumn(
                name: "FarmOwnerId",
                table: "Farms",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Id",
                table: "Farms",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Farms_AspNetUsers_Id",
                table: "Farms",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
