using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShiftService.Migrations
{
    public partial class ShiftMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    employeeSlots = table.Column<int>(nullable: false),
                    shiftDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    shiftId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.id, x.shiftId });
                    table.ForeignKey(
                        name: "FK_Users_Shifts_shiftId",
                        column: x => x.shiftId,
                        principalTable: "Shifts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_shiftId",
                table: "Users",
                column: "shiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
