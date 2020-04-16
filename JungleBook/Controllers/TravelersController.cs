using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JungleBook.Contracts;
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
    }
}