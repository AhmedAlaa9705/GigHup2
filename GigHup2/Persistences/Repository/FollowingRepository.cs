using GigHup2.Core.Repositorys;
using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace GigHup2.Persistences.Repository
{
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext db;
        public FollowingRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public Following GetFollowing(string followid,string followingid)
        {
         return  db.Followings.SingleOrDefault(a => a.FolloweeId == followid && a.FolloweeId == followingid);
        }
    }
}