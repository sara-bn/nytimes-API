using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopStories.Migrations
{
    public partial class InnitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    key = table.Column<string>(nullable: false),
                    section = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    published_date = table.Column<DateTime>(nullable: false),
                    byline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
