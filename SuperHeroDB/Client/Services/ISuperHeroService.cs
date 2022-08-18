using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        public event Action OnChange;
        public List<Comic> Comics { get; set; }
        public List<SuperHero> Heroes { get; set; }
        Task<List<SuperHero>> GetSuperHeros();
        Task GetComics();
        Task<SuperHero> GetSuperHeroById(int id);
        Task<Comic> GetComicById(int id);
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
        Task<List<SuperHero>> UpdateSuperHero(SuperHero hero, int id);
        Task<List<SuperHero>> DeleteSuperHero(int id);
    }
}
