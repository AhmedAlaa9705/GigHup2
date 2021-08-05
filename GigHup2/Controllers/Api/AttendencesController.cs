using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GigHup2.Core.Models;
using Microsoft.AspNet.Identity;
using GigHup2.Dtos;
using GigHup2.Persistences;

namespace GigHup2.Controllers.Api
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext db;
        public AttendencesController()
        {
            db = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult attend(AttendenceDto dto)
        {
            var userid = User.Identity.GetUserId();
            if (db.Attendances.Any(a => a.UserAttendId == userid && a.GigId == dto.GigId))
            {
                return BadRequest("The attendance already exist.");
            }

            var attendence = new Attendance
            {
                GigId = dto.GigId,
                UserAttendId=userid
                
            };
            db.Attendances.Add(attendence);
            db.SaveChanges();

            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult DeleteAtten(int id)
        {
            var userId = User.Identity.GetUserId();
            var attend=db.Attendances.SingleOrDefault(a => a.UserAttendId == userId && a.GigId == id);
            if (attend == null)
                return NotFound();
            db.Attendances.Remove(attend);
            db.SaveChanges();
            return Ok(id);
        }
    }
}
