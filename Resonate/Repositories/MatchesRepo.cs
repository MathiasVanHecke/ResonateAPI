using System;
using System.Collections.Generic;
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
        public User AddMatch(String user1, String user2)
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
                    User emUser = new User();
                    return emUser;
                }
                else
                {
                    //De eerste persoon wil matches / de tweede persoon ook => leg de match
                    match.IsConfirmed = true;
                    _context.Entry(match).State = EntityState.Modified;
                    _context.SaveChanges();

                    User user = _context.User.Where(u => u.id == user2)
                        .Include(u => u.Artists)
                        .Include(u => u.Genres)
                        .SingleOrDefault();
                    return user ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetMatches(String userId)
        {
            try
            {
                var ids = _context.Matches.Where(m => m.User1 == userId && m.IsConfirmed == true).Select(m => m.User2).ToArray();
                var ids2 = _context.Matches.Where(m => m.User2 == userId && m.IsConfirmed == true).Select(m => m.User1).ToArray();

                List<User> matches = new List<User>();

                foreach(String id in ids)
                {
                    matches.Add(_context.User.Where(u => u.id == id)
                        .Include(u => u.Artists)
                        .Include(u => u.Genres)
                        .SingleOrDefault());
                }

                foreach (String id in ids2)
                {
                    matches.Add(_context.User.Where(u => u.id == id)
                        .Include(u => u.Artists)
                        .Include(u => u.Genres)
                        .SingleOrDefault());
                }
                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetPotMatches(String user, int matchLevel, string name)
        {
            try
            {
                var ids = _context.PotMatches.Where(p => p.User1 == user && p.MatchLevel == matchLevel && p.Name == name).Select(p => p.User2).ToArray();
                var ids2 = _context.PotMatches.Where(p => p.User2 == user && p.MatchLevel == matchLevel && p.Name == name).Select(p => p.User1).ToArray();

                List<User> potmatches = new List<User>();

                foreach (String id in ids)
                {
                    potmatches.Add(_context.User.Where(u => u.id == id)
                        .Include(u => u.Artists)
                        .Include(u => u.Genres)
                        .SingleOrDefault());
                }

                foreach (String id in ids2)
                {
                    potmatches.Add(_context.User.Where(u => u.id == id)
                        .Include(u => u.Artists)
                        .Include(u => u.Genres)
                        .SingleOrDefault());
                }

                List<User> matches = new List<User>();
                matches = potmatches.Distinct().ToList();

                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
