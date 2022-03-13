using backend.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScrumProject4GI.Models
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Modelbuilder For UtilisateurProjet Class

            modelBuilder.Entity<UtilisateurProjet>()
                .HasKey(t => new { t.UtilisateurId, t.ProjetId });

            modelBuilder.Entity<UtilisateurProjet>()
                .HasOne(pt => pt.Utilisateur)
                .WithMany(p => p.UtilisateurProjets)
                .HasForeignKey(pt => pt.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UtilisateurProjet>()
                .HasOne(pt => pt.Projet)
                .WithMany(t => t.UtilisateurProjets)
                .HasForeignKey(pt => pt.ProjetId)
                .OnDelete(DeleteBehavior.Restrict);

            // Modelbuilder For UtilisateurReunion Class

            modelBuilder.Entity<UtilisateurReunion>()
                .HasKey(t => new { t.UtilisateurId, t.ReunionId });

            modelBuilder.Entity<UtilisateurReunion>()
                .HasOne(pt => pt.Utilisateur)
                .WithMany(p => p.UtilisateurReunions)
                .HasForeignKey(pt => pt.UtilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UtilisateurReunion>()
                .HasOne(pt => pt.Reunion)
                .WithMany(t => t.UtilisateurReunions)
                .HasForeignKey(pt => pt.ReunionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Modelbuilder For SprintStory Class

            modelBuilder.Entity<SprintStory>()
                .HasKey(t => new { t.SprintId, t.StoryId });

            modelBuilder.Entity<SprintStory>()
                .HasOne(pt => pt.Story)
                .WithMany(t => t.SprintStories)
                .HasForeignKey(pt => pt.StoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SprintStory>()
                .HasOne(pt => pt.Sprint)
                .WithMany(p => p.SprintStories)
                .HasForeignKey(pt => pt.SprintId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Projet> Projets { get; set; }
        public DbSet<Backlog> Backlogs { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Reunion> Reunions { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<ScrumMaster> ScrumMasters { get; set; }
        public DbSet<Developpeur> Developpeurs { get; set; }
        public DbSet<Testeur> Testeurs { get; set; }
        public DbSet<ProductOwner> Productowners { get; set; }
    }
}