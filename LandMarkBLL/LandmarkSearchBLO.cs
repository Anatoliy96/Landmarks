using LandmarkDAL.DAO;
using LandmarkDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using LandMarkBLL.DTO;
using LandMarkBLL.ObjectTransfering;

namespace LandMarkBLL
{
   public class LandmarkSearchBLO
    {
        public List<DTO.LandmarkSearchDTO> GetAll()
        {
            LandmarkDAO landmarkDao = new LandmarkDAO();
            List<Landmark> landmarks = landmarkDao.GetAll();
            List<LandmarkSearchDTO> landmarkDtos = new List<LandmarkSearchDTO>();
            foreach (var l in landmarks)
            {
                DaoToBloConverter<Landmark, LandmarkSearchDTO> converter = 
                    new DaoToBloConverter<Landmark, LandmarkSearchDTO>();

                landmarkDtos.Add(converter.CopyProperties(l));
            }

            return landmarkDtos;
        }

        public LandmarkSearchDTO Get(int ID)
        {
            LandmarkDAO landmarkDAO = new LandmarkDAO();
            Landmark landmark = landmarkDAO.GetByID(ID);
            LandmarkSearchDTO landmarkSearch = new LandmarkSearchDTO();

            DaoToBloConverter<Landmark, LandmarkSearchDTO> converter =
                new DaoToBloConverter<Landmark, LandmarkSearchDTO>();
            landmarkSearch = converter.CopyProperties(landmark);

            return landmarkSearch;
        }

        public void AddLandMark(
            string Name,
            string Area,
            string Description,
            double Latitude,
            double Longtitute,
            int Attendance,
            string Accesability,
            string History,
            string Type,
            string PicturePath,
            int TerrainID)
        {
            Landmark landmark = new Landmark();

            landmark.Name = Name;
            landmark.Area = Area;
            landmark.Description = Description;
            landmark.Latitude = Latitude;
            landmark.Longtitude = Longtitute;
            landmark.Attendance = Attendance;
            landmark.Accesability = Accesability;
            landmark.History = History;
            landmark.Type = Type;
            landmark.PicturePath = PicturePath;
            landmark.TerrainID = TerrainID;

            LandmarkDAO landmarkDAO = new LandmarkDAO();
            landmarkDAO.Insert(landmark);
        }

        public void UpdateLandMark(
            int ID,
            string Name,
            string Area,
            string Description,
            double Latitude,
            double Longtitute,
            int Attendance,
            string Accesability,
            string History,
            string Type,
            string PicturePath,
            int TerrainID)
        {
            Landmark landmark = new Landmark();

            landmark.ID = ID;
            landmark.Name = Name;
            landmark.Area = Area;
            landmark.Description = Description;
            landmark.Latitude = Latitude;
            landmark.Longtitude = Longtitute;
            landmark.Attendance = Attendance;
            landmark.Accesability = Accesability;
            landmark.History = History;
            landmark.Type = Type;
            landmark.PicturePath = PicturePath;
            landmark.TerrainID = TerrainID;

            LandmarkDAO landmarkDAO = new LandmarkDAO();
            landmarkDAO.Update(landmark);
        }

        public void DeleteLandMark(int ID)
        {
            LandmarkDAO dao = new LandmarkDAO();

            dao.Delete(ID);
        }
    }
}
