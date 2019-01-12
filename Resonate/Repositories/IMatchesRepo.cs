using System;
using System.Collections.Generic;
using Resonate.Models;

namespace Resonate.Repositories
{
    public interface IMatchesRepo
    {
        User AddMatch(String user1, String user2);
        List<User> GetMatches(String userId);


        List<User> GetPotMatches(String user, int matchLevel, string name);
    }
}