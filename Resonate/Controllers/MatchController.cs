using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Resonate.Models;
using Resonate.Repositories;

namespace Resonate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController
    {
        private readonly IMatchesRepo _matchesRepo;
        public MatchController(IMatchesRepo matchesRepo)
        {
            _matchesRepo = matchesRepo;
        }

        [HttpPost("{user1}/{user2}")]
        public User AddMatch(string user1, string user2)
        {
            try
            {

                User result = _matchesRepo.AddMatch(user1, user2);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return result ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public List<User> GetMatches(String id)
        {
            try
            {
                List<User> matches = _matchesRepo.GetMatches(id);
                return matches;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
