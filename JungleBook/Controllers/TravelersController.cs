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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public IActionResult GetCreateTrip(Trip trip)
        {
            TripViewModel tripViewModel;
            if (trip.TripId == default)
            {
                 tripViewModel = new TripViewModel()
                {
                    DestinationOptions = new MultiSelectList(_repo.Destination.GetAllDestinations(), "DestinationId", "Name")
                };
                return View("CreateTrip",tripViewModel);
            }
            tripViewModel = new TripViewModel()
            {
                TravelerLoggedIn = GetLoggedInTraveler(),
                Trip = trip,
                TravelBuddies = _repo.Traveler.GetTravelBuddiesByTripId(trip.TripId).ToList(),
                DestinationOptions = new MultiSelectList(_repo.Destination.GetDestinationsByTripId(trip.TripId), "DestinationId", "Name")
            };
            
            return View("CreateTrip", tripViewModel);
        }
        [HttpPost]
        public IActionResult CreateTrip(TripViewModel viewModelFromForm)
        {
            Traveler traveler = GetLoggedInTraveler();
            List<Destination> usersSelectedDestinations = ReturnSelectionAsDestinationList(viewModelFromForm.selectedDestinations).ToList();
            if(_repo.Trip.FindByCondition(t=>t.TripId == viewModelFromForm.Trip.TripId).Any() == false)
            {
                CreateNewDestinations(usersSelectedDestinations);
                _repo.Trip.CreateTrip(viewModelFromForm.Trip);
                _repo.Save();
            }
            _repo.UserProfile.CreateUserProfile(viewModelFromForm.Trip, traveler);
            viewModelFromForm.Trip.Destinations = usersSelectedDestinations;
            _repo.Trip.Update(viewModelFromForm.Trip);
            _repo.Save();
            return RedirectToAction("Trips"); 
        }
        [HttpPost]
        public async Task<IActionResult> AddInvitedTraveler(string userName, string tripName)
        {
            UserProfile profile = await _repo.UserProfile.GetUserProfileByInviteCode(userName, tripName);
            Trip trip = _repo.Trip.GetTripById(profile.TripId.GetValueOrDefault());

            return RedirectToAction("GetCreateTrip", trip);
        }
        public IActionResult Trips()
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
            Trip tripFromDb = _repo.Trip.GetTripById(id);
            tripFromDb.Destinations = _repo.Destination.GetDestinationsByTripId(id).ToList();
            return View(tripFromDb);
        }
        //public IActionResult EmailInvitationPartialView()
        //{
        //    Traveler traveler = GetLoggedInTraveler();
        //    Message message = new Message()
        //    {
        //        SenderAddress = traveler.Email,
        //    };
        //    return ViewComponent("EmailInvitationViewComponent", message);
        //}
        [HttpPost]
        public IActionResult SendInvitations(TripViewModel modelFromForm)
        {
            modelFromForm.TravelerLoggedIn = GetLoggedInTraveler();
            modelFromForm.Trip = _repo.Trip.GetTripById(modelFromForm.Trip.TripId);
            List<string> recipients = modelFromForm.Message.RecipientAddress.Split(", ").ToList();
            modelFromForm.Message.MessageBody += EmailInvitation.CreateInvitationMessageWithInvitationCode(modelFromForm);
            MimeMessage email = EmailInvitation.CreateEmail(modelFromForm.Message.SenderAddress, recipients, modelFromForm.Message.MessageBody);
            EmailInvitation.SendEmailInvitation(email, API_Keys.EmailAddress, API_Keys.EmailPassword);
            return RedirectToAction("PlanTrip", new { id = modelFromForm.Trip.TripId });
        }

        [HttpGet]
        public async Task<IActionResult> PlanTrip(TripViewModel viewModelFromEventsSearch, int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Traveler traveler = _repo.Traveler.GetTravelerByUserId(userId);
            TripViewModel tripViewModel = new TripViewModel()
            {
                TravelerLoggedIn = traveler,
                TravelBuddies = await _repo.UserProfile.GetAllTravelersByTripAsync(id),
                UserProfile = await _repo.UserProfile.GetUserProfileByIdsAsync(traveler.TravelerId, id),
                Trip = _repo.Trip.GetTripById(id),
                Message = new Message()
                {
                    SenderAddress = traveler.Email
                }
            };
            
            if (viewModelFromEventsSearch.SearchResults != null )
            {
                tripViewModel.SearchResults = viewModelFromEventsSearch.SearchResults;
            }
            //tripViewModel.Trip.Destinations = _repo.Destination.GetDestinationsByTripId(tripId).ToList();
            //if (_repo.DayActivity.FindByCondition(da => da.Day == tripViewModel.Trip.Destinations.Where(d => d.Days.Distinct() == da.Day)).Any())
            //{
            //    tripViewModel.DayActivities = _repo.DayActivity.FindAll().ToList();
            //};
            //tripViewModel.DayActivities = _repo.DayActivity.GetActivitiesByDay(tripViewModel.UserProfile.Trip.Destinations);
            return  View(tripViewModel);
        }

        [HttpPost]
        public async Task<PartialViewResult> ShowEvents(TripViewModel modelFromView, string location, string keyword)
        {
            EventSearchResult events = await _searchRequest.Search(location, keyword);
            modelFromView.SearchResults = events;

            return PartialView("PlanTrip", modelFromView);
        }

        private string ConvertAddressToUrl(Address address)
        {   
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            if (address.City != null)
            {
                string city = address.City.Replace(' ', '+');
                url += city; 
            }
            if (address.State != null)
            {
                string state = address.State.Replace(' ', '+');
                url += "," + state;
            }
            if (address.Country!= null)
            {
                string country = address.Country.Replace(' ', '+');
                url += "," + country;
            }
            url += API_Keys.GoogleServicesKey;
            return url;
        }
        private double GetLatitude(JObject resultsFromGoogleServiceCall)
        {
            return Double.Parse(resultsFromGoogleServiceCall["results"][0]["geometry"]["location"]["lat"].ToString());
        }
        private double GetLongitude(JObject resultsFromGoogleServiceCall)
        {
            return Double.Parse(resultsFromGoogleServiceCall["results"][0]["geometry"]["location"]["lng"].ToString());
        }
        private string GetPlaceId(JObject resultsFromGoogleServiceCall)
        {
            return resultsFromGoogleServiceCall["results"][0]["place_id"].ToString();
        }
        private void SetLatLongAndPlaceId(Destination destination, JObject resultsFromGoogle)
        {
            destination.Address.Longitude = GetLongitude(resultsFromGoogle);
            destination.Address.Latitude = GetLatitude(resultsFromGoogle);
            destination.PlaceId = GetPlaceId(resultsFromGoogle);
        }
        private Traveler GetLoggedInTraveler()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _repo.Traveler.GetTravelerByUserId(userId);
        }
        
        private ICollection<Destination> ReturnSelectionAsDestinationList (ICollection<int> selectedDestination)
        {
            List<Destination> destinationList = new List<Destination>();
            List<Destination> destinationsFromDb = _repo.Destination.GetAllDestinations();
            foreach (int selection in selectedDestination)
            {
                destinationList.Add(destinationsFromDb.Find(d => d.DestinationId == selection));
            }
            return destinationList;
        }
        private void AssignProperties(Destination newDestination, string url, JObject googleService)
        {
            url = ConvertAddressToUrl(newDestination.Address);
            JObject resultsFromGoogle = _googleServices.GetDestinationInformation(url).Result;
            SetLatLongAndPlaceId(newDestination, resultsFromGoogle);
        }

        //TO-DO Add state, country, placeId
        private void CreateNewDestinations(ICollection<Destination> destinations)
        {
            JObject resultsFromGoogle = new JObject();
            string url ="";
            foreach(Destination destination in destinations)
            {
                if(_repo.Destination.DestinationExists(destination) == false)
                {
                    AssignProperties(destination, url, resultsFromGoogle);
                    _repo.Address.CreateAddress(destination.Address);
                    _repo.Save();
                    destination.AddressId = destination.Address.AddressId;
                    _repo.Destination.CreateDestination(destination);
                }
            }
            _repo.Save();
        }
    }
}