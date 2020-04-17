using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JungleBook.Contracts;
using JungleBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JungleBook.Models.ViewModels;

namespace JungleBook.Controllers
{
    public class TravelersController : Controller
    {
        private IRepositoryWrapper _repo;
        public TravelersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_repo.Traveler.FindByCondition(t => t.ApplicationUserId == userId).Any())
            {
                //do stuff
            }
            else
            {
                RedirectToAction("Register");
            }
            return View();
        }
        //May be an unnecessary view, remove if not used.

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Traveler traveler)
        //{
        //    try
        //    {
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        traveler.ApplicationUserId = userId;
        //        _repo.Traveler.CreateTraveler(traveler);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public IActionResult CreateTrip()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrip(Trip tripFromForm)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Traveler travelerFromDB = _repo.Traveler.GetTravelerByUserId(userId);
            _repo.Trip.CreateTrip(tripFromForm);
            _repo.Save();
            _repo.UserProfile.CreateUserProfile(tripFromForm, travelerFromDB);
            _repo.Save();

            return RedirectToAction("Trips");
            
        }
        public IActionResult Trips(int travelerId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Traveler traveler = _repo.Traveler.GetTravelerByUserId(userId);
            
            List<Trip> trips = _repo.UserProfile.GetAllTripsByTraveler(traveler.TravelerId).ToList();
            if(trips.Any())
            {
                return View(trips);
            }
            //If deciding to go single page app- redirect to create trip
            //else
            //{
            //    RedirectToAction("CreateTrip");
            //}

            return View(trips);
        }
        public IActionResult TripDetails(int id)
        {
            var tripFromDb = _repo.Trip.GetTripById(id);
            return View(tripFromDb);
        }
        public IActionResult PlanTrip(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Traveler traveler = _repo.Traveler.GetTravelerByUserId(userId);
            //var profileFromDb = _repo.UserProfile.GetUserProfileByIds(traveler.TravelerId, id);
            //List<Traveler> TravelersOnTrip = _repo.UserProfile.GetAllTravelersByTrip(id);
            //List<DayActivity> daysActivities = _repo.DayActivity.GetActivitiesByDay(profileFromDb.Trip.Destinations);
            TripViewModel tripViewModel = new TripViewModel()
            {
                TravelerLoggedIn = traveler,
                TravelBuddies = _repo.UserProfile.GetAllTravelersByTrip(id),
                UserProfile = _repo.UserProfile.GetUserProfileByIds(traveler.TravelerId, id)
            };
            tripViewModel.DayActivities = _repo.DayActivity.GetActivitiesByDay(tripViewModel.UserProfile.Trip.Destinations);
            return View(tripViewModel);
        }
        public IActionResult InviteCollaborators()
        {
            return View();
        }
        
    }
}