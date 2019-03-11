using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "T_WorkflowApprovalInfo");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityDataId",
                table: "T_WorkflowApprovalInfo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "WorkflowStatus",
                table: "T_WorkflowApprovalInfo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityDataId",
                table: "T_WorkflowApprovalInfo");

            migrationBuilder.DropColumn(
                name: "WorkflowStatus",
                table: "T_WorkflowApprovalInfo");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "T_WorkflowApprovalInfo",
                nullable: true);
        }
    }
}
