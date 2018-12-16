using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class MatchesRepo : IMatchesRepo
    {
        private readonly ResonateContext _context;
        public MatchesRepo(ResonateContext context)
        {
            _context = context;
        }

        //Add Matches
        public Boolean AddMatch(Guid user1, Guid user2)
        {
            try
            {
                //Kijken of de match al bestaat
                //Moeten worden omgedraaid want de request zal ook omgedraaid zijn als er al een eerste match ligt.
                Matches match = _context.Matches.Where(m => m.User1 == user2 && m.User2 == user1 && m.IsConfirmed == false).SingleOrDefault();
                if(match == null)
                {
                    //De eerste persoon wil matchen / tweede heeft nog niet ja gezegd
                    _context.Matches.Add(new Matches(){ User1 = user1, User2 = user2, IsConfirmed = false });
                    _context.SaveChanges();
                }
                else
                {
                    //De eerste persoon wil matches / de tweede persoon ook => leg de match
                    match.IsConfirmed = true;
                    _context.Entry(match).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
