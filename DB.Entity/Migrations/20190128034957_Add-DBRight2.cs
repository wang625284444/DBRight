using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class AddDBRight2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ModuleButtion_T_Module_ModuleEntityId",
                table: "T_ModuleButtion");

            migrationBuilder.RenameColumn(
                name: "ModuleEntityId",
                table: "T_ModuleButtion",
                newName: "ModuleId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ModuleButtion_ModuleEntityId",
                table: "T_ModuleButtion",
                newName: "IX_T_ModuleButtion_ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ModuleButtion_T_Module_ModuleId",
                table: "T_ModuleButtion",
                column: "ModuleId",
                principalTable: "T_Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ModuleButtion_T_Module_ModuleId",
                table: "T_ModuleButtion");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "T_ModuleButtion",
                newName: "ModuleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ModuleButtion_ModuleId",
                table: "T_ModuleButtion",
                newName: "IX_T_ModuleButtion_ModuleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ModuleButtion_T_Module_ModuleEntityId",
                table: "T_ModuleButtion",
                column: "ModuleEntityId",
                principalTable: "T_Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
