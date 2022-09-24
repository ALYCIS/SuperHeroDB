using System;
using System.Collections.Generic;

#nullable disable

namespace SuperHeroDB.Shared
{
    public partial class CoutParTypeDePrestation
    {
        public int Id { get; set; }
        public int IdDemandeAideFinanciere { get; set; }
        public int Nbheure { get; set; }
        public int NbHeureDemande { get; set; }
        public int NbHeureAccorde { get; set; }
        public decimal CoutHorraireDemande { get; set; }
        public decimal CoutHorraireAccorde { get; set; }
        public decimal? CoutHorraireMax { get; set; }
        public string Libelle { get; set; }

        public virtual DemandeAideFinanciere IdDemandeAideFinanciereNavigation { get; set; }
    }
}
