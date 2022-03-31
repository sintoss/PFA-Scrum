using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class updateprojetentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateAffectation",
                table: "TesteurStory",
                newName: "DateAffectation");

            migrationBuilder.RenameColumn(
                name: "DateDernierModification",
                table: "Taches",
                newName: "DateDerniereModification");

            migrationBuilder.RenameColumn(
                name: "DateDernierModification",
                table: "Stories",
                newName: "DateDerniereModification");

            migrationBuilder.RenameColumn(
                name: "DateDernierModification",
                table: "Sprints",
                newName: "DateDerniereModification");

            migrationBuilder.RenameColumn(
                name: "EstValide",
                table: "Releases",
                newName: "IsValide");

            migrationBuilder.RenameColumn(
                name: "dateAffectation",
                table: "DeveloppeurStory",
                newName: "DateAffectation");

            migrationBuilder.RenameColumn(
                name: "DateDernierModification",
                table: "Backlogs",
                newName: "DateDerniereModification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePrevueFin",
                table: "Projets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "Projets",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "Projets");

            migrationBuilder.RenameColumn(
                name: "DateAffectation",
                table: "TesteurStory",
                newName: "dateAffectation");

            migrationBuilder.RenameColumn(
                name: "DateDerniereModification",
                table: "Taches",
                newName: "DateDernierModification");

            migrationBuilder.RenameColumn(
                name: "DateDerniereModification",
                table: "Stories",
                newName: "DateDernierModification");

            migrationBuilder.RenameColumn(
                name: "DateDerniereModification",
                table: "Sprints",
                newName: "DateDernierModification");

            migrationBuilder.RenameColumn(
                name: "IsValide",
                table: "Releases",
                newName: "EstValide");

            migrationBuilder.RenameColumn(
                name: "DateAffectation",
                table: "DeveloppeurStory",
                newName: "dateAffectation");

            migrationBuilder.RenameColumn(
                name: "DateDerniereModification",
                table: "Backlogs",
                newName: "DateDernierModification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePrevueFin",
                table: "Projets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
