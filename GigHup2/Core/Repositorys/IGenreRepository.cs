using System.Collections.Generic;
using GigHup2.Core.Models;


namespace GigHup2.Core.Repositorys
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}