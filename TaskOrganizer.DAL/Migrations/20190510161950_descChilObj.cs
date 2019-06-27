using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskOrganizer.DAL.Migrations
{
    public partial class descChilObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ChildObjectives",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ChildObjectives");
        }
    }
}
