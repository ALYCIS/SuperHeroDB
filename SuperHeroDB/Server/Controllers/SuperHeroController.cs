using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<Comic> comics = new List<Comic>
        {
            new Comic{Name="Marvel", Id=1001},
            new Comic{Name="DC", Id=1002},
            new Comic{Name="Karate", Id=1003}
        };

        private static List<SuperHero> heros = new List<SuperHero>
        {
            new SuperHero{Id=1,FirstName="Peter", LastName="Parker", HeroName="Spiderman", ComicId=1001},
            new SuperHero{Id=2,FirstName="Bruce", LastName="Wayne", HeroName="Batman", ComicId=1002},
            new SuperHero{Id=3, FirstName = "Bruce", LastName = "Lee", HeroName = "BruceLee", ComicId = 1003}
        };


        [HttpGet("comics")]
        public IActionResult GetComics() => Ok(comics);

        [HttpGet("comics/{id:int}")]
        public IActionResult GetComicById(int Id)=> Ok(comics.FirstOrDefault(c => c.Id == Id));

        [HttpGet]
        public IActionResult GetSuperHeros() => Ok(heros);

        [HttpGet("{id}")]
        public IActionResult GetSingleSuperHero(int id)
        {
            var hero = heros.FirstOrDefault(h => h.Id == id);
            return hero == null ? NotFound("Super Hero wasn't found. Too bad. :(") : Ok(hero);
        }
        [HttpPost]
        public IActionResult CreateSuperHero(SuperHero hero)
        {
            hero.Id = heros.Max(h => h.Id + 1);
            heros.Add(hero);
            return Ok(heros);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSuperHero(SuperHero hero, int id)
        {
            var Dbhero = heros.FirstOrDefault(h => h.Id == id);
            if (Dbhero == null)
            {
                return NotFound("Super Hero wasn't found. Too bad. :(");
            }
            var indexe = heros.IndexOf(Dbhero);
            heros[indexe] = hero;
            return Ok(heros);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSuperHero(int id)
        {
            var Dbhero = heros.FirstOrDefault(h => h.Id == id);
            if (Dbhero == null)
            {
                return NotFound("Super Hero wasn't found. Too bad. :(");
            }
            var indexe = heros.IndexOf(Dbhero);
            try
            {
                heros.RemoveAt(indexe);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
            return Ok(heros);
        }
    }
}
