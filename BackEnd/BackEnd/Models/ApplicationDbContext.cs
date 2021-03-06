using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;


namespace BackEnd.Models
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder
           .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             // Modelbuilder For UtilisateurProjet Class

            modelBuilder.Entity<utilisateurProjets>()
                .HasKey(t => new { t.utilisateurId, t.ProjetId });

            modelBuilder.Entity<utilisateurProjets>()
                .HasOne(pt => pt.utilisateur)
                .WithMany(p => p.utilisateurProjets)
                .HasForeignKey(pt => pt.utilisateurId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<utilisateurProjets>()
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

            // Modelbuilder For DeveloppeurStories Class

            modelBuilder.Entity<DeveloppeurStory>()
             .HasKey(ds => new { ds.Id , ds.DeveloppeurId , ds.StoryId });
            modelBuilder.Entity<DeveloppeurStory>()
                .HasOne(d => d.Developpeur)
                .WithMany(ds => ds.DeveloppeurStories)
                .HasForeignKey(ds => ds.DeveloppeurId);
            modelBuilder.Entity<DeveloppeurStory>()
                .HasOne(s => s.Story)
                .WithMany(ds => ds.DeveloppeurStories)
                .HasForeignKey(ds => ds.StoryId);

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
        public DbSet<DeveloppeurStory> DeveloppeurStories { get; set; }
        public DbSet<utilisateurProjets> utilisateurProjets { get; set; }
        public DbSet<TesteurStory> TesteurStory { get; set; }
        public DbSet<SprintStory> sprintStories { get; set; }
        
    }
}