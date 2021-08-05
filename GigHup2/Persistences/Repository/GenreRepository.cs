using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHup2.Core.Repositorys;
using GigHup2.Persistences;
using GigHup2.Core.Models;

namespace GigHup2.Persistences.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext db;
        public GenreRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return db.Genres.ToList();
        }
    }
}