using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHup2.Core.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get;private set; }
        public string  OriginalVenue{ get;private set; }

        [Required]
        public Gig Gig { get; set; }
        public Notification()
        {

        }
        private Notification(NotificationType type,Gig gig)
        {
            if (gig == null)
                throw new ArgumentException("gig");
            Type = type;
            Gig = gig;
            DateTime = DateTime.Now;
        }
        public static Notification GigCreated(Gig gig)
        {
            return new Notification(NotificationType.GigCreated, gig);
        }
        public static Notification GigUpdated(Gig newGig,DateTime originalDateTime,string originalVenue)
        {
           var notification=new Notification(NotificationType.GigUpdated, newGig);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            return notification;
        }
        public static Notification GigCancled(Gig gig)
        {
            return new Notification(NotificationType.GigCancled, gig);
        }
    }
}