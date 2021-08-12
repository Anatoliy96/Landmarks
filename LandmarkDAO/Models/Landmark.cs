using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LandmarkDAL.Models
{
  public  class Landmark : Common
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public int Attendance { get; set; }
        public string Accesability { get; set; }
        public string History { get; set; }
        public string Type { get; set; }
        public string PicturePath { get; set; }

        [ForeignKey("Terrain")]

        public int TerrainID { get; set; }
    }
}
