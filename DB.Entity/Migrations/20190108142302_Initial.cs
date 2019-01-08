using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkflowCreationTime = table.Column<DateTime>(nullable: false),
                    WorkflowApprover = table.Column<string>(nullable: true),
                    WorkflowTime = table.Column<DateTime>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UrlName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Pid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkflowCreationTime = table.Column<DateTime>(nullable: false),
                    WorkflowApprover = table.Column<string>(nullable: true),
                    WorkflowTime = table.Column<DateTime>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_RorkflowConfigure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConfigureName = table.Column<string>(nullable: true),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_RorkflowConfigure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkflowCreationTime = table.Column<DateTime>(nullable: false),
                    WorkflowApprover = table.Column<string>(nullable: true),
                    WorkflowTime = table.Column<DateTime>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserNumber = table.Column<string>(nullable: true),
                    UserAccount = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_RoleModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkflowCreationTime = table.Column<DateTime>(nullable: false),
                    WorkflowApprover = table.Column<string>(nullable: true),
                    WorkflowTime = table.Column<DateTime>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    ModuleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_RoleModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_RoleModule_T_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "T_Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_RoleModule_T_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_WorkflowProcess",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sequence = table.Column<long>(nullable: false),
                    SequenceName = table.Column<string>(nullable: true),
                    WorkflowConfigureId = table.Column<Guid>(nullable: false),
                    WorkflowConfigureEntityId = table.Column<Guid>(nullable: true),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_WorkflowProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_WorkflowProcess_T_RorkflowConfigure_WorkflowConfigureEntityId",
                        column: x => x.WorkflowConfigureEntityId,
                        principalTable: "T_RorkflowConfigure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkflowCreationTime = table.Column<DateTime>(nullable: false),
                    WorkflowApprover = table.Column<string>(nullable: true),
                    WorkflowTime = table.Column<DateTime>(nullable: false),
                    WorkflowStatus = table.Column<int>(nullable: false),
                    IsStatus = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserRole_T_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "T_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_UserRole_T_User_UserId",
                        column: x => x.UserId,
                        principalTable: "T_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_RoleModule_ModuleId",
                table: "T_RoleModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_RoleModule_RoleId",
                table: "T_RoleModule",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserRole_RoleId",
                table: "T_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_T_UserRole_UserId",
                table: "T_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_WorkflowProcess_WorkflowConfigureEntityId",
                table: "T_WorkflowProcess",
                column: "WorkflowConfigureEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_RoleModule");

            migrationBuilder.DropTable(
                name: "T_UserRole");

            migrationBuilder.DropTable(
                name: "T_WorkflowProcess");

            migrationBuilder.DropTable(
                name: "T_Module");

            migrationBuilder.DropTable(
                name: "T_Role");

            migrationBuilder.DropTable(
                name: "T_User");

            migrationBuilder.DropTable(
                name: "T_RorkflowConfigure");
        }
    }
}
