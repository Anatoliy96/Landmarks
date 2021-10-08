using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandmarkDAL.DAO.Context;
using LandmarkDAL.Models;

namespace LandmarkDAL.DAO
{
   public class LandmarkDAO : UniversalDAO<Landmark>
    {
        public List<Landmark> FilterByName(string Search)
        {

            {
                LandmarkContext context = new LandmarkContext();
                return context.LandMark.Where(l => l.Name.ToLower().Contains(Search)).ToList();
            }
        }
    }
}
