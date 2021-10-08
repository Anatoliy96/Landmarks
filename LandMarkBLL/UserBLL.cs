using LandmarkDAL.DAO;
using LandmarkDAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkBLL
{
   public class UserBLL : Users
    {
        public List<Users> GetAll()
        {
            UsersDAO usersDAO = new UsersDAO();
            List<Users> users = usersDAO.GetAll();

            return users;
        } 

        public Users GetByID(int ID)
        {
            UsersDAO usersDAO = new UsersDAO();
            Users user = usersDAO.GetByID(ID);

            return user;
        }

        public Users GetByName(string Name)
        {
            UsersDAO usersDAO = new UsersDAO();
            Users users = usersDAO.GetByName(Name);

            return users;
        }

        public void RegisterUser(
            string UserName,
            string Password,
            string ConfirmPassword)
        {
            Users user = new Users();

            user.Username = UserName;
            user.Password = PasswordHash.Hash(Password);
            user.ConfirmPassword = PasswordHash.Hash(ConfirmPassword);
            

            UsersDAO usersDAO = new UsersDAO();
            usersDAO.Insert(user);
        }
    }
}
