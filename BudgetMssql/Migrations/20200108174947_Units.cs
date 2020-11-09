using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Budget.Mssql.Migrations
{
    public partial class Units : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(maxLength: 20, nullable: false),
                    FullName = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
