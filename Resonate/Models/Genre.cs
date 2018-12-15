using System;
namespace Resonate.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public Guid UserId { get; set; }
        public String GenreName { get; set; }
    }
}
