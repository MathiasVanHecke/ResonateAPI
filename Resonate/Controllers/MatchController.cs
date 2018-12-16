using System;
using Microsoft.AspNetCore.Mvc;
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
        public bool AddMatch(Guid user1, Guid user2)
        {
            try
            {

                Boolean succes = _matchesRepo.AddMatch(user1, user2);
                if (succes)
                {
                    return succes;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
