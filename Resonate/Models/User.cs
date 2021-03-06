﻿using System;
using System.Collections.Generic;

namespace Resonate.Models
{
    public class User
    {
        public string id { get; set; }

        public string country { get; set; }
        public string display_name { get; set; }

        public string email { get; set; }
        public string href { get; set; }
        public string birthdate { get; set; }
        public string urlPf { get; set; }

        public string beschrijving { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
