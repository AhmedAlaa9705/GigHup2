using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHup2.Core.Models;
using GigHup2.Persistences.Repository;
using GigHup2.Core.Repositorys;

namespace GigHup2.Persistences
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        public IGigRepository gigRepository { get; private set; }
        public IAttenddanceRepository attenddanceRepository { get; private set; }
        public IFollowingRepository followingRepository { get; private set; }
        public IGenreRepository genreRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
            gigRepository = new GigRepository(context);
            attenddanceRepository = new AttenddanceRepository(context);
            followingRepository = new FollowingRepository(context);
            genreRepository = new GenreRepository(context);

        }
        public void Complete()
        {
            db.SaveChanges();
        }
    }
}