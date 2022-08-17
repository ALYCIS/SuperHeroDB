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

        public async Task<SuperHero> GetSuperById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        public async Task<List<SuperHero>> GetSuperHeros()
        {
            return await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        }
    }
}
