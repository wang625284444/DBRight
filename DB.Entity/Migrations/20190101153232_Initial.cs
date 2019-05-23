using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
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
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RorkflowConfigure",
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
                    table.PrimaryKey("PK_RorkflowConfigure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModule",
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
                    table.PrimaryKey("PK_RoleModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleModule_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleModule_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowProcess",
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
                    table.PrimaryKey("PK_WorkflowProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowProcess_RorkflowConfigure_WorkflowConfigureEntityId",
                        column: x => x.WorkflowConfigureEntityId,
                        principalTable: "RorkflowConfigure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
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
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_ModuleId",
                table: "RoleModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModule_RoleId",
                table: "RoleModule",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowProcess_WorkflowConfigureEntityId",
                table: "WorkflowProcess",
                column: "WorkflowConfigureEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModule");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "WorkflowProcess");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RorkflowConfigure");
        }
    }
}
