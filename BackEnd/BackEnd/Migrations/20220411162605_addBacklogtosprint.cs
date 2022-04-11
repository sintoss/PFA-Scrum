using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class addBacklogtosprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BacklogId",
                table: "Sprints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_BacklogId",
                table: "Sprints",
                column: "BacklogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Backlogs_BacklogId",
                table: "Sprints",
                column: "BacklogId",
                principalTable: "Backlogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Backlogs_BacklogId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_BacklogId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "BacklogId",
                table: "Sprints");
        }
    }
}
