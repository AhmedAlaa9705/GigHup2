using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GigHup2.Core.Models;

namespace GigHup2.ViewModels
{
    public class GigDetailsViewmodel
    {
        public Gig Gig { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsAttending { get; set; }
    }
}