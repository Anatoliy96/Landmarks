using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landmarks.Models;
using LandMarkBLL;

namespace Landmarks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Auth()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }
        public IActionResult Index()
        {
            LandmarkSearchBLO blo = new LandmarkSearchBLO();
            return View(blo.GetAll());
        }

        public IActionResult SinglePlace(int ID)
        {
            LandmarkSearchBLO landmarkSearchBLO = new LandmarkSearchBLO();
            return View(landmarkSearchBLO.Get(ID));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
