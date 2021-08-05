using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHup2.Core.Models;
using Microsoft.AspNet.Identity;
using GigHup2.Persistences;

namespace GigHup2.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext db;
        public GigsController()
        {
            db = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userid = User.Identity.GetUserId();
            var gig = db.Gigs.Include(g=>g.Attendances.Select(a=>a.UserAttend))
                .Single(a=>a.Id==id&&a.ArtistId==userid);

            if (gig.IsCancled)
                return NotFound();
            gig.Cancel();
         

          
            db.SaveChanges();
            return Ok();
        }
    }
}
