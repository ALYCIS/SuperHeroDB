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
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
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
  /*
            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId= 1001 },
                new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 1002},
                new SuperHero { Id = 3, FirstName = "Bruce", LastName = "Lee", HeroName = "BruceLee", ComicId = 1002}
                );*/
        }
    }
}
