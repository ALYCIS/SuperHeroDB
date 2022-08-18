using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDB.Shared
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public Comic Comic { get; set; }

        public SuperHero()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            HeroName = "";
            Comic = new Comic() { Id = 0, Name = "" };
        }


        public override string ToString()
        {
            return Id.ToString()+"/"+FirstName+"/"+LastName+"/"+HeroName+"/Comic = "+Comic.ToString();
        }
    }
}
