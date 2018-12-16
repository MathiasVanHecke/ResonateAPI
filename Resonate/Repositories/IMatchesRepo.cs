using System;
using System.Collections.Generic;
using Resonate.Models;

namespace Resonate.Repositories
{
    public interface IMatchesRepo
    {
        User AddMatch(Guid user1, Guid user2);
        List<User> GetMatches(Guid userId);
    }
}