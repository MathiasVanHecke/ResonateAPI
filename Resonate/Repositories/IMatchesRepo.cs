using System;

namespace Resonate.Repositories
{
    public interface IMatchesRepo
    {
        bool AddMatch(Guid user1, Guid user2);
    }
}