using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class AddRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "CreationUser",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "WorkflowApprover",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "WorkflowCreationTime",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "WorkflowStatus",
                table: "T_Module");

            migrationBuilder.DropColumn(
                name: "WorkflowTime",
                table: "T_Module");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "T_Module",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreationUser",
                table: "T_Module",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "T_Module",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "T_Module",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WorkflowApprover",
                table: "T_Module",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkflowCreationTime",
                table: "T_Module",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "WorkflowStatus",
                table: "T_Module",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkflowTime",
                table: "T_Module",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
