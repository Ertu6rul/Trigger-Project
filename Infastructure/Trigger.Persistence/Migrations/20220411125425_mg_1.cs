using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trigger.Persistence.Migrations
{
    public partial class mg_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Voice1Url = table.Column<string>(type: "TEXT", nullable: false),
                    Voice2Url = table.Column<string>(type: "TEXT", nullable: false),
                    Voice3Url = table.Column<string>(type: "TEXT", nullable: false),
                    Voice4Url = table.Column<string>(type: "TEXT", nullable: false),
                    Voice5Url = table.Column<string>(type: "TEXT", nullable: false),
                    Voice6Url = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formats");
        }
    }
}
