using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apollon.EntityFramework.Migrations
{
    public partial class Target : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Targets",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Targets",
                table: "Tournaments");
        }
    }
}
