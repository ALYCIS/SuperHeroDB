using Microsoft.EntityFrameworkCore;
using SuperHeroDB.Client.Services;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Data
{
    public class DataContext:DbContext
    {
        public DbSet<SuperHero> SuperHeros { get; set; }
        public DbSet<Comic> Comics { get; set; }

        public virtual DbSet<CoutParTypeDePrestation> CoutParTypeDePrestations { get; set; }
        public virtual DbSet<DemandeAideFinanciere> DemandeAideFinancieres { get; set; }

        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=REVA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SuperHeroService S = new SuperHeroService(); // On fait appel aux services

            foreach (var c in S.Comics)
            {
                modelBuilder.Entity<Comic>().HasData(
                    c
                    );
            }

            foreach( var s in S.Heroes)
            {
                modelBuilder.Entity<SuperHero>().HasData(
                    s
                    );
            }

            // Pour la suite

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CoutParTypeDePrestation>(entity =>
            {
                entity.ToTable("CoutParTypeDePrestation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CoutHorraireAccorde).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CoutHorraireDemande).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CoutHorraireMax).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Libelle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDemandeAideFinanciereNavigation)
                    .WithMany(p => p.CoutParTypeDePrestations)
                    .HasForeignKey(d => d.IdDemandeAideFinanciere)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoutParTypeDePrestation_DemandeAideFinanciere");
            });

            modelBuilder.Entity<DemandeAideFinanciere>(entity =>
            {
                entity.ToTable("DemandeAideFinanciere");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });


            // Pour la data
           /* DemandeAideFinanciereService demandeAideFinanciereService = new DemandeAideFinanciereService();
            foreach (var c in S.Comics)
            {
                modelBuilder.Entity<Comic>().HasData(
                    c
                    );
            }*/

            /* OnModelCreatingPartial(modelBuilder);*/

            /*
                      modelBuilder.Entity<SuperHero>().HasData(
                          new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId= 1001 },
                          new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 1002},
                          new SuperHero { Id = 3, FirstName = "Bruce", LastName = "Lee", HeroName = "BruceLee", ComicId = 1002}
                          );*/
            // Pour la suite
        }
        /*partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
