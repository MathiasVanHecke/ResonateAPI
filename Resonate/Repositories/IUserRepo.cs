using Resonate.Models;

namespace Resonate.Repositories
{
    public interface IUserRepo
    {
        bool RegisterUser(User user);

        User GetUser(string id);
    }
}