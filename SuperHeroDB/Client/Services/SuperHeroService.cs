using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;

        public SuperHeroService(HttpClient httpClient)
        { 
            this._httpClient = httpClient;
        }

        public List<Comic> Comics { get; set; } = new List<Comic>();
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();

        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var result =  await _httpClient.PostAsJsonAsync<SuperHero>("api/superhero",hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            return Heroes;
        }

        public async Task<Comic> GetComicById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Comic>($"api/superhero/comics/{id}");
        }

        public async Task GetComics()
        {
            Comics = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
        }

        public async Task<SuperHero> GetSuperHeroById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeros()
        {
            Heroes = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            return Heroes;
        }
    }
}
