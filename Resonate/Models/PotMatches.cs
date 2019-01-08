using System;
namespace Resonate.Models
{
    public class PotMatches
    {
        public int PotMatchesId { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public int MatchLevel { get; set; } //1 artist 2 genre
        public String Name { get; set; } //Arctic Monkeys
    }
}
