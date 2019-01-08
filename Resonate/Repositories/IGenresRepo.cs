using System.Collections.Generic;
using Resonate.Models;

namespace Resonate.Repositories
{
    public interface IGenresRepo
    {
        List<string> GetAllGenres();
    }
}