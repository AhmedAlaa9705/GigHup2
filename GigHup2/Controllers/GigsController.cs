using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHup2.Core.Models;
using GigHup2.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using GigHup2.Persistences.Repository;
using GigHup2.Persistences;
using GigHup2.Core.Repositorys;

namespace GigHup2.Controllers
{
    public class GigsController : Controller
    {
        
        private IUnitOfWork unitOfWork;
        public GigsController(IUnitOfWork unitOf)
        {
            unitOfWork = unitOf;
        }
        public ActionResult Search(HomeViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var gigs = unitOfWork.gigRepository.GetUpComingGigs(userId);
            return View(gigs);
        }
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigViewModel
            {
                Genres = unitOfWork.genreRepository.GetGenres(),
                Heading="Add a Gig"
            };
            return View("GigForm",viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres =unitOfWork.genreRepository.GetGenres();
                return View("GigForm" ,viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime(),
                GenreId= viewModel.Genre   
            };
            unitOfWork.gigRepository.Add(gig);
            unitOfWork.Complete();

            return RedirectToAction("Mine", "Gigs");
          
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var gig =unitOfWork.gigRepository.GetGig(id);
            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != (string)User.Identity.GetUserId())
                return new HttpUnauthorizedResult();
            var viewModel = new GigViewModel
            {
                Id = gig.Id,
                Genres = unitOfWork.genreRepository.GetGenres(),
                Date=gig.DateTime.ToString("d MMM yyyy"),
                Time=gig.DateTime.ToString("HH:mm"),
                Genre=gig.GenreId,
                Venue=gig.Venue,
                Heading="Update a Gig"
               
            };
            return View("GigForm",viewModel);
        }
   
     
        public ActionResult Attending()
        {
            var userid = User.Identity.GetUserId();
            var viewModel = new HomeViewModel
            {
                UpcomingGigs =unitOfWork.gigRepository.GetGigsUserAttending(userid),
                ShowAction = User.Identity.IsAuthenticated,
                Heading = "Im Attending",
                attendences =unitOfWork.attenddanceRepository.GetFutureAttend(userid)
               .ToLookup(a => a.GigId)
            };
            return View("Gigs", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Updatee(GigViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = unitOfWork.genreRepository.GetGenres();
                return View("GigForm", viewModel);  
            }
            var gig =unitOfWork.gigRepository.GetGigWithAttendees(viewModel.Id);
            if (gig == null)
                return HttpNotFound();
            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult(); 

            gig.Modify(viewModel.GetDateTime(),viewModel.Venue,viewModel.Genre);
            unitOfWork.Complete();
            return RedirectToAction("Mine","Gigs");

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var art = User.Identity.IsAuthenticated;
            var gig = unitOfWork.gigRepository.GetGig(id);
            if (gig == null)
                return HttpNotFound();
            var viewModel = new GigDetailsViewmodel
            {
                Gig = gig
            };
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending =unitOfWork.attenddanceRepository.GetAttendance(gig.Id,userId)!=null;
                viewModel.IsFollowing =unitOfWork.followingRepository.GetFollowing(userId, gig.ArtistId) != null;
            }
            return View("Details",viewModel);

        }
    }
}