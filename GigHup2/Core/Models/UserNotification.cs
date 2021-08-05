using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GigHup2.Core.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order =1)]
        public string UserId { get;private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public ApplicationUser User { get;  private set; }

        public Notification Notification { get; private   set; }

        public bool IsRead { get; private set; }
        public UserNotification()
        {

        }
        public UserNotification(ApplicationUser applicationUser, Notification notification)
        {
            if (applicationUser == null)
                throw new ArgumentException("user");

            if(notification==null)
                throw new ArgumentException("notification");

            Notification = notification;
            User = applicationUser;

        }
        public void Read()
        {
            IsRead = true;
        }
    }
}