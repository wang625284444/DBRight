using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class AddDBRight3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_UserRole_T_Role_RoleId",
                table: "T_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_T_UserRole_T_User_UserId",
                table: "T_UserRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "T_UserRole",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "T_UserRole",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_UserRole_T_Role_RoleId",
                table: "T_UserRole",
                column: "RoleId",
                principalTable: "T_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_UserRole_T_User_UserId",
                table: "T_UserRole",
                column: "UserId",
                principalTable: "T_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_UserRole_T_Role_RoleId",
                table: "T_UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_T_UserRole_T_User_UserId",
                table: "T_UserRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "T_UserRole",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "T_UserRole",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_T_UserRole_T_Role_RoleId",
                table: "T_UserRole",
                column: "RoleId",
                principalTable: "T_Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_T_UserRole_T_User_UserId",
                table: "T_UserRole",
                column: "UserId",
                principalTable: "T_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
