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
using MimeKit;
using JungleBook.Services;
using Newtonsoft.Json.Linq;

namespace JungleBook.Controllers
{
    public class TravelersController : Controller
    {
        private IRepositoryWrapper _repo;
        private ISearchRequest _searchRequest;
        private IGoogleServices _googleServices;
        public TravelersController(IRepositoryWrapper repo, ISearchRequest searchRequest, IGoogleServices googleServices)
        {
            _repo = repo;
            _searchRequest = searchRequest;
            _googleServices = googleServices;

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
        public IActionResult CreateTrip(Trip tripFromForm, Destination newDestination)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Traveler travelerFromDB = _repo.Traveler.GetTravelerByUserId(userId);

            _repo.Destination.CreateDestination(newDestination);
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
            Message message = new Message();
            message.SenderAddress = this.User.FindFirstValue(ClaimTypes.Email.ToLower());
            return View(message);
        }
        [HttpPost]
        public IActionResult InviteCollaborators(Message message)
        {
            List<string> recipients = message.RecipientAddress.Split(", ").ToList();
            MimeMessage email = EmailInvitation.CreateEmail(message.SenderAddress, recipients, message.MessageBody);
            EmailInvitation.SendEmailInvitation(email, API_Keys.EmailAddress, API_Keys.EmailPassword);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult ShowEvents()
        {
            return PartialView("ShowEvents");
        }
        [HttpPost]
        public async Task<PartialViewResult> ShowEvents(string location, string eventKeyword)
        {
            JObject events = await _searchRequest.Search(location, eventKeyword);
            return PartialView(events);
        }
        private string ConvertCityStateCountryToUrl(Address address)
        {
            string city = address.City.Replace(' ', '+');
            string state = address.State.Replace(' ', '+');
            string country = address.Country.Replace(' ', '+');
            string htmlCall = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string url = $"{htmlCall},+{city},+{state},{country}{API_Keys.GoogleServicesKey}";
            return url;
        }
        private double GetLatitude(JObject resultsFromGoogleServiceCall)
        {
            return Double.Parse(resultsFromGoogleServiceCall.SelectToken("results.geometry.location.lat").ToString());
        }
        private double GetLongitude(JObject resultsFromGoogleServiceCall)
        {
            return Double.Parse(resultsFromGoogleServiceCall.SelectToken("results.geometry.location.lng").ToString());
        }
        private string GetPlaceId(JObject resultsFromGoogleServiceCall)
        {
            return resultsFromGoogleServiceCall.SelectToken("results.place_id").ToString();
        }
    }
}