using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class DemandeAideFinanciereFils
    {
        [Name("Id")]
        public int Id { get; set; }
        [Name("Prenom")]
        public string Prenom { get; set; }
        [Name("Nom")]
        public string Nom { get; set; }
        

        [Name("IdAPD")]
        public int IdAPD { get; set; }
        [Name("NbHeureDemandeAPD")]
        public int NbHeureDemandeAPD { get; set; }
        [Name("NbHeureAccordeAPD")]
        public int NbHeureAccordeAPD { get; set; }

        [Name("CoutHorraireDemandeAPD")]
        public decimal CoutHorraireDemandeAPD { get; set; }

        [Name("CoutHorraireAccordeAPD")]
        public decimal CoutHorraireAccordeAPD { get; set; }


        [Name("IdAPJ")]
        public int IdAPJ { get; set; }
        [Name("NbHeureDemandeAPJ")]
        public int NbHeureDemandeAPJ { get; set; }
        [Name("NbHeureAccordeAPJ")]
        public int NbHeureAccordeAPJ { get; set; }

        [Name("CoutHorraireDemandeAPJ")]
        public decimal CoutHorraireDemandeAPJ { get; set; }

        [Name("CoutHorraireAccordeAPJ")]
        public decimal CoutHorraireAccordeAPJ { get; set; }



        [Name("IdVAEI")]
        public int IdVAEI { get; set; }
        [Name("NbHeureDemandeVAEI")]
        public int NbHeureDemandeVAEI { get; set; }
        [Name("NbHeureAccordeVAEI")]
        public int NbHeureAccordeVAEI { get; set; }

        [Name("CoutHorraireDemandeVAEI")]
        public decimal CoutHorraireDemandeVAEI { get; set; }

        [Name("CoutHorraireAccordeVAEI")]
        public decimal CoutHorraireAccordeVAEI { get; set; }


        [Name("IdVAEC")]
        public int IdVAEC { get; set; }

        [Name("NbHeureDemandeVAEC")]
        public int NbHeureDemandeVAEC { get; set; }

        [Name("NbHeureAccordeVAEC")]
        public int NbHeureAccordeVAEC { get; set; }

        [Name("CoutHorraireDemandeVAEC")]
        public decimal CoutHorraireDemandeVAEC { get; set; }

        [Name("CoutHorraireAccordeVAEC")]
        public decimal CoutHorraireAccordeVAEC { get; set; }


        [Name("IdFormatif")]
        public int IdFormatif { get; set; }
        [Name("NbHeureDemandeFormatif")]
        public int NbHeureDemandeFormatif { get; set; }

        [Name("NbHeureAccordeFormatif")]
        public int NbHeureAccordeFormatif { get; set; }

        [Name("CoutHorraireDemandeFormatif")]
        public decimal CoutHorraireDemandeFormatif { get; set; }

        [Name("CoutHorraireAccordeFormatif")]
        public decimal CoutHorraireAccordeFormatif { get; set; }


        [Name("IdJury")]
        public int IdJury { get; set; }

        [Name("NbHeureDemandeJury")]
        public int NbHeureDemandeJury { get; set; }

        [Name("NbHeureAccordeJury")]
        public int NbHeureAccordeJury { get; set; }

        [Name("CoutHorraireDemandeJury")]
        public decimal CoutHorraireDemandeJury { get; set; }

        [Name("CoutHorraireAccordeJury")]
        public decimal CoutHorraireAccordeJury { get; set; }
    }
}
