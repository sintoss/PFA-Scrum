using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class addsprintstorytocontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintStory_Sprints_SprintId",
                table: "SprintStory");

            migrationBuilder.DropForeignKey(
                name: "FK_SprintStory_Stories_StoryId",
                table: "SprintStory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SprintStory",
                table: "SprintStory");

            migrationBuilder.RenameTable(
                name: "SprintStory",
                newName: "sprintStories");

            migrationBuilder.RenameIndex(
                name: "IX_SprintStory_StoryId",
                table: "sprintStories",
                newName: "IX_sprintStories_StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sprintStories",
                table: "sprintStories",
                columns: new[] { "SprintId", "StoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_sprintStories_Sprints_SprintId",
                table: "sprintStories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sprintStories_Stories_StoryId",
                table: "sprintStories",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sprintStories_Sprints_SprintId",
                table: "sprintStories");

            migrationBuilder.DropForeignKey(
                name: "FK_sprintStories_Stories_StoryId",
                table: "sprintStories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sprintStories",
                table: "sprintStories");

            migrationBuilder.RenameTable(
                name: "sprintStories",
                newName: "SprintStory");

            migrationBuilder.RenameIndex(
                name: "IX_sprintStories_StoryId",
                table: "SprintStory",
                newName: "IX_SprintStory_StoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SprintStory",
                table: "SprintStory",
                columns: new[] { "SprintId", "StoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SprintStory_Sprints_SprintId",
                table: "SprintStory",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SprintStory_Stories_StoryId",
                table: "SprintStory",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
