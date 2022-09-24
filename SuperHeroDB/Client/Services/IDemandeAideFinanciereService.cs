using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperHeroDB.Shared;

namespace SuperHeroDB.Client.Services
{
    public interface IDemandeAideFinanciereService
    {

        /*public Task<DemandeAideFinanciere[]> GetAll();*/
        public DemandeAideFinanciere[] DemandesAF { get; set; }
        public List<DemandeAideFinanciere> DemandeAides { get; set; }

        public Task<List<DemandeAideFinanciere>> GetAll();

        public Task<DemandeAideFinanciere> GetDemande(int id);

    }
}
