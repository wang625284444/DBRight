using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "T_WorkflowApprovalInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "T_WorkflowApprovalInfo");
        }
    }
}
