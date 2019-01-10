using System.Collections.Generic;
using Resonate.Models;

namespace Resonate.Repositories
{
    public interface IArtistsRepo
    {
        List<Artist> GetAllArtists();
    }
}