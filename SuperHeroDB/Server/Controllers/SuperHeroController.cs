using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        private static List<DemandeAideFinanciere> Demandes;
        private static DemandeAideFinanciere[] DemandesArray;
        private static List<DemandeAideFinanciereFils> test;

        [HttpGet("dafs")]
        public IActionResult GetDemandes()
        {
            
            return Ok(test);

        }

        [HttpGet("dafs/{id:int}")]
        public IActionResult GetDemandesById(int Id)
        {
   
            return Ok(Demandes.FirstOrDefault(d => d.Id == Id));
        }

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

        public SuperHeroController()
        {
            Demandes = new List<DemandeAideFinanciere>();
            test = new List<DemandeAideFinanciereFils>();

            using (var reader = new StreamReader(@"C:\Users\CISSE\Desktop\Blazor\SuperHeroDB\SuperHeroDB\Client\Services\data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                /*csv.Configuration.Delimiter = ";";*/
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var record = csv.GetRecord<DemandeAideFinanciereFils>();
                    DemandeAideFinanciere D = new DemandeAideFinanciere();
                    D.Id = record.Id;
                    D.Prenom = record.Prenom;
                    D.Nom = record.Nom;

                    D.CoutParTypeDePrestations.Add(new CoutParTypeDePrestation()
                    {
                        Id = record.IdVAEC,
                        NbHeureDemande = record.NbHeureDemandeVAEC,
                        NbHeureAccorde = record.NbHeureAccordeVAEC,
                        CoutHorraireDemande = record.CoutHorraireDemandeVAEC,
                        CoutHorraireAccorde = record.CoutHorraireAccordeVAEC,
                        IdDemandeAideFinanciere = D.Id
                    }
                    );

                    D.CoutParTypeDePrestations.Add(new CoutParTypeDePrestation()
                    {
                        Id = record.IdAPD,
                        NbHeureDemande = record.NbHeureDemandeAPD,
                        NbHeureAccorde = record.NbHeureAccordeAPD,
                        CoutHorraireDemande = record.CoutHorraireDemandeAPD,
                        CoutHorraireAccorde = record.CoutHorraireAccordeAPD,
                        IdDemandeAideFinanciere = D.Id
                    }
                    );


                    D.CoutParTypeDePrestations.Add(
                    new CoutParTypeDePrestation()
                    {
                        Id = record.IdVAEI,
                        NbHeureDemande = record.NbHeureDemandeVAEI,
                        NbHeureAccorde = record.NbHeureAccordeVAEI,
                        CoutHorraireDemande = record.CoutHorraireDemandeVAEI,
                        CoutHorraireAccorde = record.CoutHorraireAccordeVAEI,
                        IdDemandeAideFinanciere = D.Id
                    }
                    );

                    D.CoutParTypeDePrestations.Add(
                    new CoutParTypeDePrestation()
                    {
                        Id = record.IdJury,
                        NbHeureDemande = record.NbHeureDemandeJury,
                        NbHeureAccorde = record.NbHeureAccordeJury,
                        CoutHorraireDemande = record.CoutHorraireDemandeJury,
                        CoutHorraireAccorde = record.CoutHorraireAccordeJury,
                        IdDemandeAideFinanciere = D.Id
                    }
                    );

                    D.CoutParTypeDePrestations.Add(
                   new CoutParTypeDePrestation()
                   {
                       Id = record.IdFormatif,
                       NbHeureDemande = record.NbHeureDemandeFormatif,
                       NbHeureAccorde = record.NbHeureAccordeFormatif,
                       CoutHorraireDemande = record.CoutHorraireDemandeFormatif,
                       CoutHorraireAccorde = record.CoutHorraireAccordeFormatif,
                       IdDemandeAideFinanciere = D.Id
                   }
                   );

                    D.CoutParTypeDePrestations.Add(
                   new CoutParTypeDePrestation()
                   {
                       Id = record.IdAPJ,
                       NbHeureDemande = record.NbHeureDemandeAPJ,
                       NbHeureAccorde = record.NbHeureAccordeAPJ,
                       CoutHorraireDemande = record.CoutHorraireDemandeAPJ,
                       CoutHorraireAccorde = record.CoutHorraireAccordeAPJ,
                       IdDemandeAideFinanciere = D.Id
                   }
                   );

                    Demandes.Add(D);
                    test.Add(record);
                }
                DemandesArray = Demandes.ToArray();
            }
        }
    }
}
