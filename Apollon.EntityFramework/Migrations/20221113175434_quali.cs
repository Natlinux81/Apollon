using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apollon.EntityFramework.Migrations
{
    public partial class quali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qualification",
                table: "NameList",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "NameList");
        }
    }
}
