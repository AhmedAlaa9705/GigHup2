using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHup2.ViewModels
{
    public class HomeViewModel
    {
        public ILookup<int, Attendance> attendences;

        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowAction { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}