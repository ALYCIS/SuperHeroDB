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
        public DbSet<SuperHero> SuperHeros { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comic>().HasData(
                new Comic { Id=1001, Name="Marvel"},
                new Comic { Id=1002, Name ="DC" }
                );
  
            modelBuilder.Entity<Comic>().HasData(
                new SuperHero { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId= 1001 },
                new SuperHero { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 1002}
                );
        }
    }
}
