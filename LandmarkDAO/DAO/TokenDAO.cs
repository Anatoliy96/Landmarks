using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandmarkDAL.DAO
{
    public class TokenDAO : UniversalDAO<RegisterTokens>
    {
        public Users GetUserByToken(string Token)
        {
            RegisterTokens regToken = GetByToken(Token);
            if (regToken == null)
            {
                return null;
            }

            UsersDAO userDao = new UsersDAO();
            return userDao.GetByID(regToken.UserID);
        }
        public RegisterTokens GetByToken(string Token)
        {
            return GetDbSet().FirstOrDefault(t => t.Token == Token);
        }
    }
}
