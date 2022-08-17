using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        public List<Comic> Comics { get; set; }
        public List<SuperHero> Heroes { get; set; }
        Task<List<SuperHero>> GetSuperHeros();
        Task GetComics();
        Task<SuperHero> GetSuperHeroById(int id);
        Task<Comic> GetComicById(int id);
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
    }
}
