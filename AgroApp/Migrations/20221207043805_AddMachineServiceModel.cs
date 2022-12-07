using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroApp.Migrations
{
    public partial class AddMachineServiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f7ceda-9f08-469e-9a33-b68620597660", "AQAAAAEAACcQAAAAECovgSCoBJOud/BN/NBrcsHt5xNvgdSKabdseJB5bVd2sJgV68YIFZ2rtOFP0h0/BA==", "2df95701-44ec-4f62-8167-63cf16344c1a" });

            migrationBuilder.CreateIndex(
                name: "IX_Service_MachineId",
                table: "Service",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b6c29c2-68a5-41b2-99bb-bdffade561fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a0f68aa-b9f8-48a0-b795-767274066a44", "AQAAAAEAACcQAAAAEGrFhvMQ2Xqs+2Q40u2WTjuOdBGNpsZnu3nrXYIF0SWBp1BfAaakGKOoUNqdX3tMIg==", "0d1f9224-8e39-43c8-992e-41646e6dff15" });
        }
    }
}
