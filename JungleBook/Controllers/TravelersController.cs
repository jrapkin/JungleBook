using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JungleBook.Contracts;
using JungleBook.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Traveler traveler)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                traveler.ApplicationUserId = userId;
                _repo.Traveler.Create(traveler);
            }
        }
        public IActionResult CreateTrip()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrip(Trip tripFromForm)
        {
            _repo.Trip.CreateTrip(tripFromForm);

            return RedirectToAction("Trips");
            
        }
        public IActionResult Trips()
        {
            List<Trip> trips = _repo.Trip.GetAllTrips().ToList();
            if(trips != null)
            {
                //do stuff
                
            }
            else
            {
                RedirectToAction("CreateTrip");
            }
            return View();
        }
    }
}