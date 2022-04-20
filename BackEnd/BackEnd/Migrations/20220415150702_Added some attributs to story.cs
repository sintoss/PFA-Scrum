using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Addedsomeattributstostory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDone",
                table: "Stories");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDebut",
                table: "Stories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFin",
                table: "Stories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePrevuFin",
                table: "Stories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Etat",
                table: "Stories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDebut",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "DateFin",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "DatePrevuFin",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "Stories");

            migrationBuilder.AddColumn<bool>(
                name: "isDone",
                table: "Stories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
