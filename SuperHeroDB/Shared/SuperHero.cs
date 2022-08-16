﻿using System;
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
    }
}
