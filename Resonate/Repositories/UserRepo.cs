using System;
using Resonate.Models;

namespace Resonate.Repositories
{
    public class UserRepo
    {
        private readonly ResonateContext _context;
        public UserRepo(ResonateContext context)
        {
            _context = context;
        }
    }
}
