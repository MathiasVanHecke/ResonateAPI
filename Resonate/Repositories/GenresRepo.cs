using System;
using System.Collections.Generic;
using System.Linq;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class GenresRepo : IGenresRepo
    {
        private readonly ResonateContext _context;
        public GenresRepo(ResonateContext context)
        {
            _context = context;
        }

        public List<string> GetAllGenres()
        {
            return _context.Genre.Select(u => u.GenreName).Distinct().ToList();
        }

    }
}
