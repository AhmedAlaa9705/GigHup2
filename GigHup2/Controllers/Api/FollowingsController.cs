using GigHup2.Dtos;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHup2.Core.Models;
using GigHup2.Persistences;

namespace GigHup2.Controllers.Api
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext db;
        public FollowingsController()
        {
            db = new ApplicationDbContext();
        }
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (db.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("The followin is already exist.");
            }
            var followinf = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            db.Followings.Add(followinf);
            db.SaveChanges();

            return Ok();
        }
    }
}
