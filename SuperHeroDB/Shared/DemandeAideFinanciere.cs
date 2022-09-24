using CsvHelper.Configuration;
using System;
using System.Collections.Generic;

#nullable disable

namespace SuperHeroDB.Shared
{
    public class DemandeAideFinanciere
    {
        public DemandeAideFinanciere()
        {
            CoutParTypeDePrestations = new HashSet<CoutParTypeDePrestation>();
        }

        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<CoutParTypeDePrestation> CoutParTypeDePrestations { get; set; }
        public CoutParTypeDePrestation[] Prestations = new CoutParTypeDePrestation[6];
        public List<CoutParTypeDePrestation> PrestationsList { get; set; } = new List<CoutParTypeDePrestation>();
    }

    public class DemandeAideFinanciereMap : ClassMap<DemandeAideFinanciere>
    {
        public string[] PrestationCode = new string[] { "APJ", "VAEI", "VAEC", "Formatif", "Jury" };
        DemandeAideFinanciereMap()
        {

            Map(m => m.Id).Name("Id");
            Map(m => m.Prenom).Name("Prenom");
            Map(m => m.Nom).Name("Nom");

            for (int i = 0; i < 5; i++)
            {
                Map(m => m.Prestations[i].CoutHorraireAccorde).Name("CoutHorraireAccorde" + PrestationCode[i]);
                Map(m => m.Prestations[i].CoutHorraireDemande).Name("CoutHorraireDemande" + PrestationCode[i]);
                Map(m => m.Prestations[i].Id).Name("Id" + PrestationCode[i]);
                Map(m => m.Prestations[i].NbHeureAccorde).Name("NbHeureAccorde" + PrestationCode[i]);
                Map(m => m.Prestations[i].NbHeureDemande).Name("NbHeureDemande" + PrestationCode[i]);
            }
        }
    }
}
