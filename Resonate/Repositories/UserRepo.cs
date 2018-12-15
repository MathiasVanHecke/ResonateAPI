using System;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ResonateContext _context;
        public UserRepo(ResonateContext context)
        {
            _context = context;
        }

        public Boolean RegisterUser(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}
