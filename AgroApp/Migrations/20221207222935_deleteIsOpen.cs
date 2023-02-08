using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class deleteIsOpen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "NextService",
                table: "Machines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "294d8ba7-f2ee-4d63-8c5f-258aa4a4732c", "AQAAAAEAACcQAAAAELk+2CsmR24yIDmGNIFB8aKwx2dXhVSCnqjypzfKEyGirnmpmrqsmCFa2MbNBZwjbg==", "6ee1ec90-3271-400e-ac85-87629a51ce9b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextService",
                table: "Machines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f7ceda-9f08-469e-9a33-b68620597660", "AQAAAAEAACcQAAAAECovgSCoBJOud/BN/NBrcsHt5xNvgdSKabdseJB5bVd2sJgV68YIFZ2rtOFP0h0/BA==", "2df95701-44ec-4f62-8167-63cf16344c1a" });
        }
    }
}
