using LandmarkDAL.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkBLL
{
    public class UsersBLL
    {
        public List<ApplicationUser> GetAll()
        {
            LandmarkDAL.DAO.UsersDAO usersdao = new LandmarkDAL.DAO.UsersDAO();
            List<ApplicationUser> applicationUsers = usersdao.GetAll();

            return applicationUsers;
        }

        public ApplicationUser GetByID(int ID)
        {
            LandmarkDAL.DAO.UsersDAO users = new LandmarkDAL.DAO.UsersDAO();
            ApplicationUser applicationUsers = users.GetByID(ID);

            return applicationUsers;
        }

        public ApplicationUser GetByName(string username)
        {
            LandmarkDAL.DAO.UsersDAO usersDAO = new LandmarkDAL.DAO.UsersDAO();
            ApplicationUser applicationUser = usersDAO.GetbyName(username);

            return applicationUser;
        }
        public void RegisterUser(
            string UserName,
            DateTimeOffset? LockoutEnd,
            bool TwoFactorEnabled,
            bool PhoneNumberConfirmed,
            string PhoneNumber,
            string ConcurrencyStamp,
            string SecurityStamp,
            string PasswordHash,
            bool EmailConfirmed,
            string NormalizedEmail,
            string Email,
            string NormalizedUserName,
            bool LockoutEnabled,
            int AccessFailedCount
            )
        {
            ApplicationUser applicationUsers = new ApplicationUser();
            applicationUsers.UserName = UserName;
            applicationUsers.LockoutEnd = LockoutEnd;
            applicationUsers.TwoFactorEnabled = TwoFactorEnabled;
            applicationUsers.PhoneNumberConfirmed = PhoneNumberConfirmed;
            applicationUsers.PhoneNumber = PhoneNumber;
            applicationUsers.ConcurrencyStamp = ConcurrencyStamp;
            applicationUsers.SecurityStamp = SecurityStamp;
            applicationUsers.PasswordHash = PasswordHash;
            applicationUsers.EmailConfirmed = EmailConfirmed;
            applicationUsers.NormalizedEmail = NormalizedEmail;
            applicationUsers.Email = Email;
            applicationUsers.NormalizedUserName = NormalizedUserName;
            applicationUsers.LockoutEnabled = LockoutEnabled;
            applicationUsers.AccessFailedCount = AccessFailedCount;

            LandmarkDAL.DAO.UsersDAO usersDAO = new LandmarkDAL.DAO.UsersDAO();
            usersDAO.Insert(applicationUsers);
        }

        public ApplicationUser UserLogin(string Username)
        {
            LandmarkDAL.DAO.UsersDAO usersDAO = new LandmarkDAL.DAO.UsersDAO();
            ApplicationUser applicationUser = usersDAO.GetbyName(Username);

            applicationUser.UserName = applicationUser.UserName;
            applicationUser.PasswordHash = applicationUser.PasswordHash;

            return applicationUser;
        }
    }
}
