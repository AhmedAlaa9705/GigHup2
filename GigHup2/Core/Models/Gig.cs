using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHup2.Core.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCancled { get; set; }

        public ApplicationUser Artist { get; set; }
        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue  { get; set; }

       
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public ICollection<Attendance> Attendances { get;private set; }
        public Gig()
        {
            Attendances = new Collection< Attendance>();
        }
        public void Cancel()
        {
            IsCancled = true;
            var notification = Notification.GigCancled(this);

            foreach (var attend in Attendances.Select(a=>a.UserAttend))
            {
                attend.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime,string venu,byte genre)
        {
            var notificatiom = Notification.GigUpdated(this, DateTime, Venue);
            

            Venue = venu;
            DateTime = dateTime;
            GenreId = genre;
            foreach (var attend in Attendances.Select(a => a.UserAttend))
                attend.Notify(notificatiom);
        
        }
    }
}