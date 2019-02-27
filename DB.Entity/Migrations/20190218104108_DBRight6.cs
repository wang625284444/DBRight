using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_WorkflowProcess_T_WorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess");

            migrationBuilder.DropTable(
                name: "T_WorkflowConfigure");

            migrationBuilder.DropIndex(
                name: "IX_T_WorkflowProcess_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess");

            migrationBuilder.DropColumn(
                name: "WorkflowConfigureEntityId",
                table: "T_WorkflowProcess");

            migrationBuilder.CreateTable(
                name: "T_ApprovalInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ApprovalInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ApprovalInfo");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "T_WorkflowConfigure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConfigureName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    IsStatus = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WorkflowConfigure", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_WorkflowProcess_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                column: "WorkflowConfigureEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_WorkflowProcess_T_WorkflowConfigure_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                column: "WorkflowConfigureEntityId",
                principalTable: "T_WorkflowConfigure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
