using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class ajouterleschampsDureeSprintetJourTravailàlentiteProjet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DureeSprint",
                table: "Projets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JourTravail",
                table: "Projets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DureeSprint",
                table: "Projets");

            migrationBuilder.DropColumn(
                name: "JourTravail",
                table: "Projets");
        }
    }
}
