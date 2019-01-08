using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Resonate.Models;
using Resonate.Repositories;

namespace Resonate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController
    {
        private readonly IGenresRepo _genresRepo;
        public GenreController(IGenresRepo genresRepo)
        {
            _genresRepo = genresRepo;
        }

        [HttpGet()]
        public List<string> GetGenres(Guid id)
        {
            try
            {
                return _genresRepo.GetAllGenres();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
