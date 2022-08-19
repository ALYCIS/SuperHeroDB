using Microsoft.EntityFrameworkCore;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Data
{
    public class DataContext:DbContext
    {
        public DbSet<SuperHero> DbHeroes { get; set; }
        public DbSet<Comic> DbComics { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comic>().HasData(
                new Comic { Id=1, Name="Marvel"},
                new Comic { Id=2, Name="DC"}
                );

            modelBuilder.Entity<Comic>().HasData(
                new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", Comic = new Comic { Id = 1, Name = "Marvel" } },
                new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", Comic = new Comic { Id = 2, Name = "DC" } }
                );
        }
    }
}
