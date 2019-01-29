using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class AddDBRight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ModuleButtion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ButtionName = table.Column<string>(nullable: true),
                    ModuleEntityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ModuleButtion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ModuleButtion_T_Module_ModuleEntityId",
                        column: x => x.ModuleEntityId,
                        principalTable: "T_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ModuleButtion_ModuleEntityId",
                table: "T_ModuleButtion",
                column: "ModuleEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ModuleButtion");
        }
    }
}
