using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SuperHeroDB.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace SuperHeroDB.Client.Services
{
    public class DemandeAideFinanciereService : IDemandeAideFinanciereService
    {
        public List<DemandeAideFinanciere> DemandeAides { get; set; } = new List<DemandeAideFinanciere>();
        public DemandeAideFinanciere[] DemandesAF { get; set; }

        private readonly HttpClient _httpClient;

        public DemandeAideFinanciereService()
        {
            DemandeAides = GetAll().Result;
            DemandesAF = DemandeAides.ToArray();
        }

        public DemandeAideFinanciereService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<DemandeAideFinanciere>>  GetAll()
        {
            
            var result = await _httpClient.GetFromJsonAsync<List<DemandeAideFinanciereFils>>("api/superhero/dafs");

            foreach(var record in result)
            {
                DemandeAideFinanciere D = new DemandeAideFinanciere();
                D.Id = record.Id;
                D.Prenom = record.Prenom;
                D.Nom = record.Nom;

                D.PrestationsList.Add(new CoutParTypeDePrestation()
                {
                    Id = record.IdAPD,
                    NbHeureDemande = record.NbHeureDemandeAPD,
                    NbHeureAccorde = record.NbHeureAccordeAPD,
                    CoutHorraireDemande = record.CoutHorraireDemandeAPD,
                    CoutHorraireAccorde = record.CoutHorraireAccordeAPD,
                    IdDemandeAideFinanciere = D.Id
                }
                );

                D.PrestationsList.Add(new CoutParTypeDePrestation()
                {
                    Id = record.IdVAEC,
                    NbHeureDemande = record.NbHeureDemandeVAEC,
                    NbHeureAccorde = record.NbHeureAccordeVAEC,
                    CoutHorraireDemande = record.CoutHorraireDemandeVAEC,
                    CoutHorraireAccorde = record.CoutHorraireAccordeVAEC,
                    IdDemandeAideFinanciere = D.Id
                }
                );


                D.PrestationsList.Add(
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

                D.PrestationsList.Add(
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

                D.PrestationsList.Add(
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

                D.PrestationsList.Add(
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

                DemandeAides.Add(D);
            }

            DemandesAF = DemandeAides.ToArray();
            return DemandeAides;
        }


        public async Task<DemandeAideFinanciere> GetDemande(int id)
        {
            DemandeAideFinanciere D = new DemandeAideFinanciere();
            DemandeAides = await GetAll();

             D = DemandeAides.FirstOrDefault(d => d.Id == id);
            return D;
        }
    }
}
