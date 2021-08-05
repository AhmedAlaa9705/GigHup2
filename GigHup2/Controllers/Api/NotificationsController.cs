using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHup2.Core.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using GigHup2.Dtos;
using AutoMapper;
using GigHup2.Persistences;

namespace GigHup2.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext db;
        public NotificationsController()
        {
            db = new ApplicationDbContext();
        }
        public IEnumerable<NotificationsDto> GetNewNotifications()
        {
            var userid = User.Identity.GetUserId();
            var notifications = db.UserNotifications
                .Where(a => a.UserId == userid && !a.IsRead)
                .Select(a => a.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
        
            return notifications.Select(Mapper.Map<Notification, NotificationsDto>);
        }
        [HttpPost]
        public IHttpActionResult AsRead()
        {
            var userid = User.Identity.GetUserId();
            var notifications = db.UserNotifications.Where(a => a.UserId == userid && !a.IsRead).ToList();
            notifications.ForEach(s => s.Read());
            db.SaveChanges();
            return Ok();

        }
    }
}
