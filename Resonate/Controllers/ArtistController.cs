using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Resonate.Models;
using Resonate.Repositories;

namespace Resonate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController
    {
        private readonly IArtistsRepo _artistRepo;
        public ArtistController(IArtistsRepo artistsRepo)
        {
            _artistRepo = artistsRepo;
        }

        [HttpGet()]
        public List<Artist> GetArtists()
        {
            try
            {
                return _artistRepo.GetAllArtists();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
