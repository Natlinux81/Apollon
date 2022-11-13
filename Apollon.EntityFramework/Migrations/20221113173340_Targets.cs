using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apollon.EntityFramework.Migrations
{
    public partial class Targets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetitionImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NameList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassNumber = table.Column<int>(type: "int", nullable: false),
                    Society = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocietyNumber = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "NameList");
        }
    }
}
