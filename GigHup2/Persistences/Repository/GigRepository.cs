using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHup2.Core.Models;
using System.Data.Entity;
using GigHup2.Core.Repositorys;

namespace GigHup2.Persistences.Repository
{
    public class GigRepository:IGigRepository
    {
        private ApplicationDbContext db;
        public GigRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public Gig GetGig(int gigid)
        {
           return db.Gigs.Include(a=>a.Artist).Include(g=>g.Genre).Single(a => a.Id == gigid);
        }
        public IEnumerable<Gig> GetUpComingGigs(string artistId)
        {
           return db.Gigs
                .Where(a => a.ArtistId == artistId && a.DateTime > DateTime.Now && !a.IsCancled)
                .Include(g => g.Genre)
                .ToList();
        }
        public Gig GetGigWithAttendees(int gigId)
        {
          return  db.Gigs.Include(g => g.Attendances
            .Select(a => a.UserAttend))
                .Single(g => g.Id == gigId);
        }
        public IEnumerable<Gig> GetGigsUserAttending(string userid)
        {
            return db.Attendances
                .Where(a => a.UserAttendId == userid)
                .Select(a => a.Gig)
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
        }

        public void Add(Gig gig)
        {
            db.Gigs.Add(gig);
        }
    }
}