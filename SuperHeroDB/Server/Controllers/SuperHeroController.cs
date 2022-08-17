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
        static List<Comic> comics = new List<Comic>
        {
            new Comic{Name="Marvel", Id=0},
            new Comic{Name="DC", Id=1}

        };

        List<SuperHero> heros = new List<SuperHero>
        {
            new SuperHero{Id=1,FirstName="Peter", LastName="Parker", HeroName="Spiderman", Comic=comics[0]},
            new SuperHero{Id=2,FirstName="Bruce", LastName="Wayne", HeroName="Batman", Comic=comics[1]}
        };

        [HttpGet]
        public IActionResult GetSuperHeros()
        {
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleSuperHero(int id)
        {
            var hero = heros.FirstOrDefault(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Super Hero wasn't found. Too bad. :(");
            }
            return Ok(hero);
        }
    }
}
