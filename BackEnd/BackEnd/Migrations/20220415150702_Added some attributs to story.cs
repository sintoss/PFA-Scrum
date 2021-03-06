using System;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Addedsomeattributstostory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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

            migrationBuilder.AddColumn<string>(
                name: "Etat",
                table: "Stories",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: Etat.ToDo);
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

        }
    }
}
