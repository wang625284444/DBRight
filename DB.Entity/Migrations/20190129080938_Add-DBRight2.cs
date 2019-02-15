using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class AddDBRight2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_RoleButtion_ModuleButtionId",
                table: "T_RoleButtion",
                column: "ModuleButtionId");

            migrationBuilder.CreateIndex(
                name: "IX_T_RoleButtion_RoleId",
                table: "T_RoleButtion",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_RoleButtion_T_ModuleButtion_ModuleButtionId",
                table: "T_RoleButtion",
                column: "ModuleButtionId",
                principalTable: "T_ModuleButtion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_RoleButtion_T_Role_RoleId",
                table: "T_RoleButtion",
                column: "RoleId",
                principalTable: "T_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_RoleButtion_T_ModuleButtion_ModuleButtionId",
                table: "T_RoleButtion");

            migrationBuilder.DropForeignKey(
                name: "FK_T_RoleButtion_T_Role_RoleId",
                table: "T_RoleButtion");

            migrationBuilder.DropIndex(
                name: "IX_T_RoleButtion_ModuleButtionId",
                table: "T_RoleButtion");

            migrationBuilder.DropIndex(
                name: "IX_T_RoleButtion_RoleId",
                table: "T_RoleButtion");
        }
    }
}
