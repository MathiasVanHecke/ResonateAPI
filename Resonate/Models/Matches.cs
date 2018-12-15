using System;
namespace Resonate.Models
{
    public class Matches
    {
        public int MatchesId { get; set; }
        public Guid User1 { get; set; }
        public Guid User2 { get; set; }
    }
}
