using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alkalmazott",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nev = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Beosztas = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fonok = table.Column<int>(type: "int", nullable: false),
                    Belepes = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fizetes = table.Column<int>(type: "int", nullable: false),
                    Jutalom = table.Column<int>(type: "int", nullable: false),
                    OsztId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alkalmazott", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alkalmazott");
        }
    }
}
