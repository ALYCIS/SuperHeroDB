using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;

        [ForeignKey("Comic")]
        public int ComicId { get; set; }

        public SuperHero()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            HeroName = "";
            ComicId = 1001;
        }


        public override string ToString()
        {
            return Id.ToString()+"/"+FirstName+"/"+LastName+"/"+HeroName+"/ComicID = "+ComicId.ToString();
        }
    }
}
