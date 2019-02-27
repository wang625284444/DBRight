using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Entity.Migrations
{
    public partial class DBRight5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityName",
                table: "T_WorkflowConfigure",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityName",
                table: "T_WorkflowConfigure");
        }
    }
}
