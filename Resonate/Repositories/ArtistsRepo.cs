﻿using System;
using System.Collections.Generic;
using System.Linq;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class ArtistsRepo : IArtistsRepo
    {
        private readonly ResonateContext _context;
        public ArtistsRepo(ResonateContext context)
        {
            _context = context;
        }

        public List<Artist> GetAllArtists()
        {
            return _context.Artist.Distinct().ToList();
        }
    }
}
