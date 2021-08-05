using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHup2.Dtos
{
    public class NotificationsDto
    {
       
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }

        
        public GigDto Gig { get; set; }
    }
}