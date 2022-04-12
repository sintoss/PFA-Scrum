using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class ajouterUtilisateurProjetDbSetetDiscriminatorchampsauUtilisateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_utilisateurProjets_AspNetUsers_UtilisateurId",
                table: "utilisateurProjets");

            migrationBuilder.DropForeignKey(
                name: "FK_utilisateurProjets_Projets_ProjetId",
                table: "utilisateurProjets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_utilisateurProjets",
                table: "utilisateurProjets");

            migrationBuilder.RenameTable(
                name: "utilisateurProjets",
                newName: "UtilisateurProjets");

            migrationBuilder.RenameIndex(
                name: "IX_utilisateurProjets_ProjetId",
                table: "UtilisateurProjets",
                newName: "IX_UtilisateurProjets_ProjetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UtilisateurProjets",
                table: "UtilisateurProjets",
                columns: new[] { "UtilisateurId", "ProjetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateurProjets_AspNetUsers_UtilisateurId",
                table: "UtilisateurProjets",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UtilisateurProjets_Projets_ProjetId",
                table: "UtilisateurProjets",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateurProjets_AspNetUsers_UtilisateurId",
                table: "UtilisateurProjets");

            migrationBuilder.DropForeignKey(
                name: "FK_UtilisateurProjets_Projets_ProjetId",
                table: "UtilisateurProjets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UtilisateurProjets",
                table: "UtilisateurProjets");

            migrationBuilder.RenameTable(
                name: "UtilisateurProjets",
                newName: "utilisateurProjets");

            migrationBuilder.RenameIndex(
                name: "IX_UtilisateurProjets_ProjetId",
                table: "utilisateurProjets",
                newName: "IX_utilisateurProjets_ProjetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_utilisateurProjets",
                table: "utilisateurProjets",
                columns: new[] { "UtilisateurId", "ProjetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateurProjets_AspNetUsers_UtilisateurId",
                table: "utilisateurProjets",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_utilisateurProjets_Projets_ProjetId",
                table: "utilisateurProjets",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
