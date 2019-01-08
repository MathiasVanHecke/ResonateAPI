using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ResonateContext _context;
        public UserRepo(ResonateContext context)
        {
            _context = context;
        }

        public Boolean RegisterUser(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();

                //MATCHES MET ARTIESTEN
                foreach (Artist artist in user.Artists)
                {
                    String[] ids = _context.Artist.Where(u => u.ArtistName == Convert.ToString(artist.ArtistName) && u.UserId != user.id).Select(u => u.UserId).ToArray();
                    foreach (String id in ids)
                    {
                        _context.PotMatches.Add(new PotMatches() { User1 = user.id, User2 = id, MatchLevel = 1, Name = artist.ArtistName });
                        _context.SaveChanges();
                    }
                }

                //MATCHES MET GENRES
                foreach (Genre genre in user.Genres)
                {
                    String[] ids = _context.Genre.Where(u => u.GenreName == Convert.ToString(genre.GenreName) && u.UserId != user.id).Select(u => u.UserId).ToArray();
                    foreach (String id in ids)
                    {
                        _context.PotMatches.Add(new PotMatches() { User1 = user.id, User2 = id, MatchLevel = 2, Name = genre.GenreName });
                        _context.SaveChanges();
                    }
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
