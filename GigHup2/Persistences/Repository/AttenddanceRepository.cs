using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHup2.Core.Models;
using GigHup2.Core.Repositorys;

namespace GigHup2.Persistences.Repository
{
    public class AttenddanceRepository : IAttenddanceRepository
    {
        private ApplicationDbContext db;
        public AttenddanceRepository(ApplicationDbContext context)
        {
            db = context; 
        }
        public IEnumerable<Attendance> GetFutureAttend(string userid)
        {
            return db.Attendances.Where(a => a.UserAttendId == userid && a.Gig.DateTime > DateTime.Now).ToList();
        }
        public Attendance GetAttendance(int gigId,string userid)
        {
            
            return db.Attendances.SingleOrDefault(a => a.GigId == gigId && a.UserAttendId == userid);
        }
    }
}