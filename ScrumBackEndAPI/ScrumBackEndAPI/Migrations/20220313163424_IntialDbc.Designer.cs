﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScrumProject4GI.Models;

namespace ScrumBackEndAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220313163424_IntialDbc")]
    partial class IntialDbc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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

            modelBuilder.Entity("backend.Models.Entity.Backlog", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDernierModification")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Backlogs");
                });

            modelBuilder.Entity("backend.Models.Entity.DeveloppeurStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DeveloppeurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAffectation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeveloppeurId");

                    b.HasIndex("StoryId");

                    b.ToTable("DeveloppeurStory");
                });

            modelBuilder.Entity("backend.Models.Entity.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BacklogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrevueFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScrumMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScrumMasterId");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("backend.Models.Entity.Release", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EstValide")
                        .HasColumnType("bit");

                    b.Property<int>("SprintId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SprintId");

                    b.ToTable("Releases");
                });

            modelBuilder.Entity("backend.Models.Entity.Reunion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

            modelBuilder.Entity("backend.Models.Entity.ScrumMasterProjet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<string>("ScrumMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.HasIndex("ScrumMasterId");

                    b.ToTable("ScrumMasterProjet");
                });

            modelBuilder.Entity("backend.Models.Entity.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDernierModification")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("backend.Models.Entity.SprintStory", b =>
                {
                    b.Property<int>("SprintId")
                        .HasColumnType("int");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.HasKey("SprintId", "StoryId");

                    b.HasIndex("StoryId");

                    b.ToTable("SprintStory");
                });

            modelBuilder.Entity("backend.Models.Entity.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BacklogId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDernierModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BacklogId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("backend.Models.Entity.Tache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateDernierModification")
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

            modelBuilder.Entity("backend.Models.Entity.TesteurStory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<string>("TesteurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("dateAffectation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("TesteurId");

                    b.ToTable("TesteurStory");
                });

            modelBuilder.Entity("backend.Models.Entity.Utilisateur", b =>
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

            modelBuilder.Entity("backend.Models.Entity.UtilisateurProjet", b =>
                {
                    b.Property<string>("UtilisateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("UtilisateurId", "ProjetId");

                    b.HasIndex("ProjetId");

                    b.ToTable("UtilisateurProjet");
                });

            modelBuilder.Entity("backend.Models.Entity.UtilisateurReunion", b =>
                {
                    b.Property<string>("UtilisateurId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ReunionId")
                        .HasColumnType("int");

                    b.HasKey("UtilisateurId", "ReunionId");

                    b.HasIndex("ReunionId");

                    b.ToTable("UtilisateurReunion");
                });

            modelBuilder.Entity("backend.Models.Entity.Developpeur", b =>
                {
                    b.HasBaseType("backend.Models.Entity.Utilisateur");

                    b.HasDiscriminator().HasValue("Developpeur");
                });

            modelBuilder.Entity("backend.Models.Entity.ProductOwner", b =>
                {
                    b.HasBaseType("backend.Models.Entity.Utilisateur");

                    b.HasDiscriminator().HasValue("ProductOwner");
                });

            modelBuilder.Entity("backend.Models.Entity.ScrumMaster", b =>
                {
                    b.HasBaseType("backend.Models.Entity.Utilisateur");

                    b.HasDiscriminator().HasValue("ScrumMaster");
                });

            modelBuilder.Entity("backend.Models.Entity.Testeur", b =>
                {
                    b.HasBaseType("backend.Models.Entity.Utilisateur");

                    b.HasDiscriminator().HasValue("Testeur");
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
                    b.HasOne("backend.Models.Entity.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("backend.Models.Entity.Utilisateur", null)
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

                    b.HasOne("backend.Models.Entity.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("backend.Models.Entity.Utilisateur", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("backend.Models.Entity.Backlog", b =>
                {
                    b.HasOne("backend.Models.Entity.Projet", "Projet")
                        .WithOne("Backlog")
                        .HasForeignKey("backend.Models.Entity.Backlog", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("backend.Models.Entity.DeveloppeurStory", b =>
                {
                    b.HasOne("backend.Models.Entity.Developpeur", "Developpeur")
                        .WithMany("DeveloppeurStories")
                        .HasForeignKey("DeveloppeurId");

                    b.HasOne("backend.Models.Entity.Story", "Story")
                        .WithMany("DeloppeurStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developpeur");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("backend.Models.Entity.Projet", b =>
                {
                    b.HasOne("backend.Models.Entity.ScrumMaster", "ScrumMaster")
                        .WithMany()
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("backend.Models.Entity.Release", b =>
                {
                    b.HasOne("backend.Models.Entity.Sprint", "Sprint")
                        .WithMany("Releases")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("backend.Models.Entity.Reunion", b =>
                {
                    b.HasOne("backend.Models.Entity.Projet", null)
                        .WithMany("Reunion")
                        .HasForeignKey("ProjetId");

                    b.HasOne("backend.Models.Entity.ScrumMaster", "ScrumMaster")
                        .WithMany("Reunions")
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("backend.Models.Entity.ScrumMasterProjet", b =>
                {
                    b.HasOne("backend.Models.Entity.Projet", "Projet")
                        .WithMany("ScrumMasterProjets")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Entity.ScrumMaster", "ScrumMaster")
                        .WithMany("ScrumMasterProjet")
                        .HasForeignKey("ScrumMasterId");

                    b.Navigation("Projet");

                    b.Navigation("ScrumMaster");
                });

            modelBuilder.Entity("backend.Models.Entity.SprintStory", b =>
                {
                    b.HasOne("backend.Models.Entity.Sprint", "Sprint")
                        .WithMany("SprintStories")
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Models.Entity.Story", "Story")
                        .WithMany("SprintStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");

                    b.Navigation("Story");
                });

            modelBuilder.Entity("backend.Models.Entity.Story", b =>
                {
                    b.HasOne("backend.Models.Entity.Backlog", "Backlog")
                        .WithMany("Stories")
                        .HasForeignKey("BacklogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Backlog");
                });

            modelBuilder.Entity("backend.Models.Entity.Tache", b =>
                {
                    b.HasOne("backend.Models.Entity.Story", "Story")
                        .WithMany("Taches")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("backend.Models.Entity.TesteurStory", b =>
                {
                    b.HasOne("backend.Models.Entity.Story", "Story")
                        .WithMany("TesteurStories")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Entity.Testeur", "Testeur")
                        .WithMany("TesteurStories")
                        .HasForeignKey("TesteurId");

                    b.Navigation("Story");

                    b.Navigation("Testeur");
                });

            modelBuilder.Entity("backend.Models.Entity.UtilisateurProjet", b =>
                {
                    b.HasOne("backend.Models.Entity.Projet", "Projet")
                        .WithMany("UtilisateurProjets")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Models.Entity.Utilisateur", "Utilisateur")
                        .WithMany("UtilisateurProjets")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("backend.Models.Entity.UtilisateurReunion", b =>
                {
                    b.HasOne("backend.Models.Entity.Reunion", "Reunion")
                        .WithMany("UtilisateurReunions")
                        .HasForeignKey("ReunionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("backend.Models.Entity.Utilisateur", "Utilisateur")
                        .WithMany("UtilisateurReunions")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reunion");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("backend.Models.Entity.Backlog", b =>
                {
                    b.Navigation("Stories");
                });

            modelBuilder.Entity("backend.Models.Entity.Projet", b =>
                {
                    b.Navigation("Backlog");

                    b.Navigation("Reunion");

                    b.Navigation("ScrumMasterProjets");

                    b.Navigation("UtilisateurProjets");
                });

            modelBuilder.Entity("backend.Models.Entity.Reunion", b =>
                {
                    b.Navigation("UtilisateurReunions");
                });

            modelBuilder.Entity("backend.Models.Entity.Sprint", b =>
                {
                    b.Navigation("Releases");

                    b.Navigation("SprintStories");
                });

            modelBuilder.Entity("backend.Models.Entity.Story", b =>
                {
                    b.Navigation("DeloppeurStories");

                    b.Navigation("SprintStories");

                    b.Navigation("Taches");

                    b.Navigation("TesteurStories");
                });

            modelBuilder.Entity("backend.Models.Entity.Utilisateur", b =>
                {
                    b.Navigation("UtilisateurProjets");

                    b.Navigation("UtilisateurReunions");
                });

            modelBuilder.Entity("backend.Models.Entity.Developpeur", b =>
                {
                    b.Navigation("DeveloppeurStories");
                });

            modelBuilder.Entity("backend.Models.Entity.ScrumMaster", b =>
                {
                    b.Navigation("Reunions");

                    b.Navigation("ScrumMasterProjet");
                });

            modelBuilder.Entity("backend.Models.Entity.Testeur", b =>
                {
                    b.Navigation("TesteurStories");
                });
#pragma warning restore 612, 618
        }
    }
}
