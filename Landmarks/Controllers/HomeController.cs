using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Landmarks.Models;
using LandMarkBLL;
using Microsoft.AspNetCore.Authorization;
using static LandMarkBLL.LandmarkSearchBLO;
using LandmarkDAL.DAO.Context;

namespace Landmarks.Controllers
{
    [Authorize]
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
                return RedirectToAction("Login", "Account");
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

       public IActionResult SearchLandmarkByName(string search)
        {
            LandmarkSearchBLO blo = new LandmarkSearchBLO();
            
            return View("ViewFilteredLandmarks", blo.FindByName(search));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
