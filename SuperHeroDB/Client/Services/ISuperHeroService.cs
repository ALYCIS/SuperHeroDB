using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeros();
    }
}
