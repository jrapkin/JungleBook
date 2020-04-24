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
using JungleBook.Util;

namespace JungleBook.Controllers
{
    public class TravelersController : Controller
    {
        private IRepositoryWrapper _repo;
        private ISearchRequest _searchRequest;
        private IGoogleServices _googleServices;
        private IHikingProject _hikingService;
        private IWeatherRequest _weatherRequest;
        public TravelersController(IRepositoryWrapper repo, IWeatherRequest weatherRequest, ISearchRequest searchRequest, IGoogleServices googleServices, IHikingProject hikingService)
        {
            _repo = repo;
            _searchRequest = searchRequest;
            _googleServices = googleServices;
            _hikingService = hikingService;
            _weatherRequest = weatherRequest;

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
                return View("CreateTrip", tripViewModel);
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
            if (_repo.Trip.FindByCondition(t => t.TripId == viewModelFromForm.Trip.TripId).Any() == false)
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
            if (trips.Any())
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
            DetailsViewModel detailsViewModel = new DetailsViewModel()
            {
                Trip = _repo.Trip.GetTripById(id)
            };
           detailsViewModel.Trip.Destinations =_repo.Destination.GetDestinationsByTripId(id).ToList();
           detailsViewModel.Message = RecommendTripDateBasedOnWeather(detailsViewModel.Trip.Destinations.First()).Result;
            
            return View(detailsViewModel);
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
            if (viewModelFromEventsSearch.SearchResults != null)
            {
                tripViewModel.SearchResults = viewModelFromEventsSearch.SearchResults;
            }
            if (viewModelFromEventsSearch.CampingResults != null)
            {
                tripViewModel.CampingResults = viewModelFromEventsSearch.CampingResults;
            }
            if (viewModelFromEventsSearch.PlaceResults != null)
            {
                tripViewModel.PlaceResults = viewModelFromEventsSearch.PlaceResults;
            }
            tripViewModel.Interests = SelectListItemHelper.GetInterests().ToList();
            return View(tripViewModel);
        }

        [HttpPost]
        public async Task<PartialViewResult> ShowEvents(TripViewModel modelFromView, string location, string keyword)
        {
            EventSearchResult events = await _searchRequest.Search(location, keyword);
            modelFromView.SearchResults = events;

            return PartialView("PlanTrip", modelFromView);
        }
        [HttpPost]
        public async Task<PartialViewResult> SelectInterests(TripViewModel modelFromView)
        {
            
            List<Destination> destinations = _repo.Destination.GetDestinationsByTripId(modelFromView.Trip.TripId).ToList();
            List<Address> addressesToCall = GetAddressesForLocationSearch(destinations);

            switch (modelFromView.SelectedInterest)
            {
                case "resturant":
                    modelFromView.PlaceResults = await _googleServices.PlacesSearch(addressesToCall.FirstOrDefault().Latitude.ToString(),
                        addressesToCall.FirstOrDefault().Longitude.ToString(), modelFromView.SelectedInterest);
                    break;
                case "hiking":
                case "camping":
                case "outdoors":
                modelFromView.HikingResult = await _hikingService.SearchForHikingSpots(addressesToCall.FirstOrDefault().Latitude.ToString(),
                        addressesToCall.FirstOrDefault().Longitude.ToString());
                    break;
            }
            return PartialView("PlanTrip", modelFromView);
        }
        public IActionResult ViewMap()
        {
            Traveler traveler = GetLoggedInTraveler();

            List<Destination> destinations = _repo.UserProfile.GetAllDestinationsByTravelerId(traveler.TravelerId).ToList();
            MapViewModel mapViewModel = new MapViewModel()
            {
                VisitedDestinations = CheckIfAlreadyVisited(destinations),
                FutureDestinations = FilterFutureDestinations(destinations)
            };
            return View(mapViewModel);
        }

        private List<Address> GetAddressesForLocationSearch(List<Destination> destinations)
        {
            List <Address> addressesForSearch = new List<Address>();
            foreach (Destination item in destinations)
            {
                addressesForSearch.Add(item.Address);
            }
            return addressesForSearch;
        }
        private List<Destination> CheckIfAlreadyVisited(List<Destination> destinations)
        {
            List<Destination> visitedDestinations = new List<Destination>();
            foreach (Destination destination in destinations)
            {
                if (destination.DepartureDate.Date < DateTime.Today)
                {
                    visitedDestinations.Add(destination);
                }
            }
            return visitedDestinations;
        }
        private List<Destination> FilterFutureDestinations(List<Destination> destinations)
        {
            List<Destination> futureDestinations = new List<Destination>();
            foreach (Destination destination in destinations)
            {
                if (destination.ArrivalDate.Date > DateTime.Today)
                {
                    futureDestinations.Add(destination);
                }
            }
            return futureDestinations;
        }
        private string ConvertAddressToGoogleUrl(Address address)
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
            url = ConvertAddressToGoogleUrl(newDestination.Address);
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
        private string ConvertAddressToWeatherUrl(Address address)
        {

                string city = address.City.Replace(' ', '+');

                string country = address.Country.Replace(' ', '+');

            string url = $"https://api.worldweatheronline.com/premium/v1/past-weather.ashx?q={city},{country}&date=2018-07-20&enddate=2019-07-20&key={API_Keys.WorldWeather}&format=json";
            return url;
        }
        private async Task<string> RecommendTripDateBasedOnWeather(Destination destination)
        {
            string recommendation;
            string url = ConvertAddressToWeatherUrl(destination.Address);
            WeatherHistory weatherHistory = await _weatherRequest.GetHistoricalWeather(url);
            List<int> positiveScores = new List<int>();

            foreach (var item in weatherHistory.data.weather)
            {
                if(double.Parse(item.mintempF) > 50 && double.Parse(item.maxtempF) <90)
                {

                    positiveScores.Add(int.Parse(item.mintempF));
                }
                else
                {
                    continue;
                }
            }
            if( positiveScores.Count > 500)
            {
                recommendation = "Go during their summer months";
            }
            else
            {
                recommendation = "The weather is too hard to determine right now. We need more time to recommend.";
            }

            return recommendation;

        }
    }
}