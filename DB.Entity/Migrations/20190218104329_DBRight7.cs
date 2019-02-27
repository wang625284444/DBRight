using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_ApprovalInfo",
                table: "T_ApprovalInfo");

            migrationBuilder.RenameTable(
                name: "T_ApprovalInfo",
                newName: "T_WorkflowApprovalInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_WorkflowApprovalInfo",
                table: "T_WorkflowApprovalInfo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T_WorkflowApprovalInfo",
                table: "T_WorkflowApprovalInfo");

            migrationBuilder.RenameTable(
                name: "T_WorkflowApprovalInfo",
                newName: "T_ApprovalInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_ApprovalInfo",
                table: "T_ApprovalInfo",
                column: "Id");
        }
    }
}
