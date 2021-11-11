using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LandMarkBLL.DTO;
using LandmarkDAL.DAO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandmarksPresentation.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]

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

        public IActionResult UpdateLandMark(
            int ID,
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
            LandMarkBLL.LandmarkSearchBLO searchBLO = new LandMarkBLL.LandmarkSearchBLO();
            if (name == null)
            {
                return View(searchBLO.Get(terrainid));
            }
            if (picturepath == null)
            {
                LandmarkSearchDTO blo = searchBLO.Get(terrainid);
                searchBLO.UpdateLandMark(
                        ID,
                        name,
                        area,
                        description,
                        latitude,
                        longtitude,
                        attendance,
                        accesability,
                        history,
                        type,
                        blo.PicturePath,
                        terrainid);
            }
            else
            {
                searchBLO.UpdateLandMark(
                        ID,
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
            

            return View("index", "Home");
        }

       public IActionResult DeleteLandMark(int ID)
        {
            LandMarkBLL.LandmarkSearchBLO blo = new LandMarkBLL.LandmarkSearchBLO();
            blo.DeleteLandMark(ID);

            return RedirectToAction("index", "Home");
        }
    }
}
