using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHup2.ViewModels;
using Microsoft.AspNet.Identity;
using GigHup2.Persistences.Repository;
using GigHup2.Persistences;

namespace GigHup2.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private AttenddanceRepository attenddanceRepository;
        public HomeController()
        {
            db = new ApplicationDbContext();
            attenddanceRepository = new AttenddanceRepository(db);
        }
        public ActionResult Index(string query=null)
        {
           var upcomingGigs=  db.Gigs.Include(a => a.Artist)
                .Include(g=>g.Genre).Where(g => g.DateTime > DateTime.Now&& !g.IsCancled);

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = upcomingGigs.Where(a => a.Artist.Name.Contains(query) || a.Genre.Name.Contains(query) || a.Venue.Contains(query)); 
            }
            var userId = User.Identity.GetUserId();
            var attend =attenddanceRepository.GetFutureAttend(userId)
                .ToLookup(a => a.GigId);
            var viewModel = new HomeViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowAction = User.Identity.IsAuthenticated,
                Heading="Upcoming Gigs",
                SearchTerm=query,
                attendences=attend
                
                
            };
            return View("Gigs",viewModel);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}