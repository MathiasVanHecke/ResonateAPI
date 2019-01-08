using System;
namespace Resonate.Models
{
    public class Matches
    {
        public int MatchesId { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public Boolean IsConfirmed { get; set; }
    }
}
