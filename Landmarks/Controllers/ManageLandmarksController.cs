using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandmarksPresentation.Controllers
{
    public class ManageLandmarksController : Controller
    {
        [Obsolete]
        private IHostingEnvironment Environment;

        [Obsolete]
        public ManageLandmarksController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Obsolete]
        public IActionResult InsertLandMarks(
            string name,
            string area,
            string description,
            double latitude,
            double longtitude,
            int attendance,
            string accesability,
            string history,
            string type,
            IFormFile picturepath,
            int terrainid)
        {
            if(name != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "images");
                using (FileStream stream = new FileStream(Path.Combine(path, picturepath.FileName), FileMode.Create))
                {
                    picturepath.CopyTo(stream);
                    LandMarkBLL.LandmarkSearchBLO landmark = new LandMarkBLL.LandmarkSearchBLO();

                    landmark.AddLandMark(
                        name,
                        area,
                        description,
                        latitude,
                        longtitude,
                        attendance,
                        accesability,
                        history,
                        type,
                        picturepath.FileName,
                        terrainid);
                }
            }
            return View("Index");
        }

        //public IActionResult UpdateLandMark(
        //    string name,
        //    string area,
        //    string description,
        //    double latitude,
        //    double longtitude,
        //    int attendance,
        //    string accesability,
        //    string history,
        //    string type,
        //    IFormFile picturepath,
        //    int terrainid)
        //{

        //}
    }
}
