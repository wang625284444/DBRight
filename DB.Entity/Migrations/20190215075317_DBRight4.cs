using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_WorkflowProcess_T_RorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_RorkflowConfigure",
                table: "T_RorkflowConfigure");

            migrationBuilder.RenameTable(
                name: "T_RorkflowConfigure",
                newName: "T_WorkflowConfigure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_WorkflowConfigure",
                table: "T_WorkflowConfigure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_WorkflowProcess_T_WorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                column: "WorkflowConfigureEntityId",
                principalTable: "T_WorkflowConfigure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_WorkflowProcess_T_WorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_WorkflowConfigure",
                table: "T_WorkflowConfigure");

            migrationBuilder.RenameTable(
                name: "T_WorkflowConfigure",
                newName: "T_RorkflowConfigure");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_RorkflowConfigure",
                table: "T_RorkflowConfigure",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_T_WorkflowProcess_T_RorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                column: "WorkflowConfigureEntityId",
                principalTable: "T_RorkflowConfigure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
