using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.DAO
{
   public class UsersDAO : UniversalDAO<Users>
    {
        public Users GetByUserName(string UserName)
        {
            return GetDbSet().FirstOrDefault(u => u.Username == UserName);
        }
    }
}
