// <auto-generated />
using System;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220412020851_SeedRoles")]
    partial class SeedRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Models.Backlog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId")
                        .IsUnique();

                    b.ToTable("Backlogs");
                });

            modelBuilder.Entity("BackEnd.Models.DeveloppeurStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DeveloppeurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAffectation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "DeveloppeurId", "StoryId");

                    b.HasIndex("DeveloppeurId");

                    b.HasIndex("StoryId");

                    b.ToTable("DeveloppeurStories");
                });

            modelBuilder.Entity("BackEnd.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BacklogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatePrevueFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScrumMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScrumMasterId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("BackEnd.Models.Release", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValide")
                        .HasColumnType("bit");

                    b.Property<int>("SprintId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("BackEnd.Models.Reunion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateReunion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emplacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjetId")
                        .HasColumnType("int");

                    b.Property<string>("ScrumMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.HasIndex("ScrumMasterId");

                    b.ToTable("Reunions");
                });

            modelBuilder.Entity("BackEnd.Models.ScrumMasterProjet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<string>("ScrumMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.HasIndex("ScrumMasterId");

                    b.ToTable("ScrumMasterProjet");
                });

            modelBuilder.Entity("BackEnd.Models.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BacklogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Dateestimeedefin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BacklogId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("BackEnd.Models.SprintStory", b =>
                {
                    b.Property<int>("SprintId")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("SprintId", "StoryId");

                    b.HasIndex("StoryId");

                    b.ToTable("sprintStories");
                });

            modelBuilder.Entity("BackEnd.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BacklogId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BacklogId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("BackEnd.Models.Tache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDerniereModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Etat")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("BackEnd.Models.TesteurStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAffectation")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<string>("TesteurId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("TesteurId");

                    b.ToTable("TesteurStory");
                });

            modelBuilder.Entity("BackEnd.Models.Utilisateur", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NomComplet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("pathImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Utilisateur");
                });

            modelBuilder.Entity("BackEnd.Models.UtilisateurReunion", b =>
                {
                    b.Property<string>("UtilisateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReunionId")
                        .HasColumnType("int");

                    b.HasKey("UtilisateurId", "ReunionId");

                    b.HasIndex("ReunionId");

                    b.ToTable("UtilisateurReunion");
                });

            modelBuilder.Entity("BackEnd.Models.utilisateurProjets", b =>
                {
                    b.Property<string>("utilisateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("utilisateurId", "ProjetId");

                    b.HasIndex("ProjetId");

                    b.ToTable("utilisateurProjets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BackEnd.Models.Developpeur", b =>
                {
                    b.HasBaseType("BackEnd.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Developpeur");
                });

            modelBuilder.Entity("BackEnd.Models.ProductOwner", b =>
                {
                    b.HasBaseType("BackEnd.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("ProductOwner");
                });

            modelBuilder.Entity("BackEnd.Models.ScrumMaster", b =>
                {
                    b.HasBaseType("BackEnd.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("ScrumMaster");
                });

            modelBuilder.Entity("BackEnd.Models.Testeur", b =>
                {
                    b.HasBaseType("BackEnd.Models.Utilisateur");

                    b.HasDiscriminator().HasValue("Testeur");
                });

            modelBuilder.Entity("BackEnd.Models.Backlog", b =>
                {
                    b.HasOne("BackEnd.Models.Projet", "Projet")
                        .WithOne("Backlog")
                        .HasForeignKey("BackEnd.Models.Backlog", "ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("BackEnd.Models.DeveloppeurStory", b =>
                {
                    b.HasOne("BackEnd.Models.Developpeur", "Developpeur")
                        .WithMany("DeveloppeurStories")
                        .HasForeignKey("DeveloppeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Story", "Story")
                        .WithMany("DeloppeurStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developpeur");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("BackEnd.Models.Projet", b =>
                {
                    b.HasOne("BackEnd.Models.ScrumMaster", "ScrumMaster")
                        .WithMany()
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("BackEnd.Models.Release", b =>
                {
                    b.HasOne("BackEnd.Models.Sprint", "Sprint")
                        .WithMany("Releases")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("BackEnd.Models.Reunion", b =>
                {
                    b.HasOne("BackEnd.Models.Projet", null)
                        .WithMany("Reunion")
                        .HasForeignKey("ProjetId");

                    b.HasOne("BackEnd.Models.ScrumMaster", "ScrumMaster")
                        .WithMany("Reunions")
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("BackEnd.Models.ScrumMasterProjet", b =>
                {
                    b.HasOne("BackEnd.Models.Projet", "Projet")
                        .WithMany("ScrumMasterProjets")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.ScrumMaster", "ScrumMaster")
                        .WithMany("ScrumMasterProjet")
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("Projet");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("BackEnd.Models.Sprint", b =>
                {
                    b.HasOne("BackEnd.Models.Backlog", "Backlog")
                        .WithMany()
                        .HasForeignKey("BacklogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Backlog");
                });

            modelBuilder.Entity("BackEnd.Models.SprintStory", b =>
                {
                    b.HasOne("BackEnd.Models.Sprint", "Sprint")
                        .WithMany("SprintStories")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Story", "Story")
                        .WithMany("SprintStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("BackEnd.Models.Story", b =>
                {
                    b.HasOne("BackEnd.Models.Backlog", "Backlog")
                        .WithMany("Stories")
                        .HasForeignKey("BacklogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Backlog");
                });

            modelBuilder.Entity("BackEnd.Models.Tache", b =>
                {
                    b.HasOne("BackEnd.Models.Story", "Story")
                        .WithMany("Taches")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("BackEnd.Models.TesteurStory", b =>
                {
                    b.HasOne("BackEnd.Models.Story", "Story")
                        .WithMany("TesteurStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Testeur", "Testeur")
                        .WithMany("TesteurStories")
                        .HasForeignKey("TesteurId");

                    b.Navigation("Story");

                    b.Navigation("Testeur");
                });

            modelBuilder.Entity("BackEnd.Models.UtilisateurReunion", b =>
                {
                    b.HasOne("BackEnd.Models.Reunion", "Reunion")
                        .WithMany("UtilisateurReunions")
                        .HasForeignKey("ReunionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Utilisateur", "Utilisateur")
                        .WithMany("UtilisateurReunions")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reunion");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("BackEnd.Models.utilisateurProjets", b =>
                {
                    b.HasOne("BackEnd.Models.Projet", "Projet")
                        .WithMany("UtilisateurProjets")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Utilisateur", "utilisateur")
                        .WithMany("utilisateurProjets")
                        .HasForeignKey("utilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackEnd.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackEnd.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BackEnd.Models.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Models.Backlog", b =>
                {
                    b.Navigation("Stories");
                });

            modelBuilder.Entity("BackEnd.Models.Projet", b =>
                {
                    b.Navigation("Backlog");

                    b.Navigation("Reunion");

                    b.Navigation("ScrumMasterProjets");

                    b.Navigation("UtilisateurProjets");
                });

            modelBuilder.Entity("BackEnd.Models.Reunion", b =>
                {
                    b.Navigation("UtilisateurReunions");
                });

            modelBuilder.Entity("BackEnd.Models.Sprint", b =>
                {
                    b.Navigation("Releases");

                    b.Navigation("SprintStories");
                });

            modelBuilder.Entity("BackEnd.Models.Story", b =>
                {
                    b.Navigation("DeloppeurStories");

                    b.Navigation("SprintStories");

                    b.Navigation("Taches");

                    b.Navigation("TesteurStories");
                });

            modelBuilder.Entity("BackEnd.Models.Utilisateur", b =>
                {
                    b.Navigation("utilisateurProjets");

                    b.Navigation("UtilisateurReunions");
                });

            modelBuilder.Entity("BackEnd.Models.Developpeur", b =>
                {
                    b.Navigation("DeveloppeurStories");
                });

            modelBuilder.Entity("BackEnd.Models.ScrumMaster", b =>
                {
                    b.Navigation("Reunions");

                    b.Navigation("ScrumMasterProjet");
                });

            modelBuilder.Entity("BackEnd.Models.Testeur", b =>
                {
                    b.Navigation("TesteurStories");
                });
#pragma warning restore 612, 618
        }
    }
}
