using System;
using System.Collections.Generic;

namespace Resonate.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String UrlPf { get; set; }
        public String HrefSpotify { get; set; }
        public int Lat { get; set; }
        public int Long { get; set; }
        public String Beschrijving { get; set; }

        public virtual List<Artist> Artists { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
