using LandmarkDAL.DAO;
using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkBLL.EmailOperations
{
    public class TokenBLL
    {
        public void RegisterToken(
          int UserID,
          string Token,
          DateTime Generate_token,
          DateTime? Confirmed)
        {
            RegisterTokens tokens = new RegisterTokens();
            tokens.UserID = UserID;
            tokens.Token = Token;
            tokens.Generated_token = Generate_token;
            tokens.Confirmed = Confirmed;

            TokenDAO tokenDAO = new TokenDAO();
            tokenDAO.Insert(tokens);
        }

        public void ConfirmToken(string Token)
        {
            // Find user's token
            TokenDAO tokenDao = new TokenDAO();
            Users user = tokenDao.GetUserByToken(Token);
            
            if (user == null)
            {
                throw new ArgumentException("No user found for this token.");
            }

            // Change user status to confirmed
            user.Confirmed = true;
            UsersDAO userDao = new UsersDAO();
            userDao.Update(user);

            // Change token confirmation date
            RegisterTokens regToken = tokenDao.GetByToken(Token);
            regToken.Confirmed = DateTime.Now;
            tokenDao.Update(regToken);
        }
    }
}
