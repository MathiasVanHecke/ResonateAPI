using System;

namespace Resonate.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public Guid UserId { get; set; }
        public String ArtistName { get; set; }
        public String HrefSpotify { get; set; }
        public String UrlPf { get; set; }
    }
}
